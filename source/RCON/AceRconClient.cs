using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ACE.RCON.Desktop.RCON.Models;
using ACE.RCON.Desktop.Utilities;

namespace ACE.RCON.Desktop.RCON
{
    /// <summary>
    /// Event arguments for RCON messages
    /// </summary>
    public class RconMessageEventArgs : EventArgs
    {
        public RconResponse Response { get; set; }
        public RconMessageEventArgs(RconResponse response) { Response = response; }
    }

    /// <summary>
    /// Event arguments for player events
    /// </summary>
    public class PlayerEventArgs : EventArgs
    {
        public PlayerEvent PlayerEvent { get; set; }
        public PlayerEventArgs(PlayerEvent playerEvent) { PlayerEvent = playerEvent; }
    }

    /// <summary>
    /// Event arguments for server status updates
    /// </summary>
    public class ServerStatusEventArgs : EventArgs
    {
        public ServerStatus ServerStatus { get; set; }
        public ServerStatusEventArgs(ServerStatus status) { ServerStatus = status; }
    }

    /// <summary>
    /// Main ACE RCON client - handles protocol, authentication, and message routing
    /// </summary>
    public class AceRconClient : IDisposable
    {
        private IConnection connection;
        private int nextIdentifier = 1;
        private readonly Dictionary<int, TaskCompletionSource<RconResponse>> pendingRequests
            = new Dictionary<int, TaskCompletionSource<RconResponse>>();
        private readonly object pendingLock = new object();
        private bool isDisposed;
        private bool useAceAuthentication;

        // Events
        public event EventHandler Connected;
        public event EventHandler<string> Disconnected;
        public event EventHandler<RconMessageEventArgs> MessageReceived;
        public event EventHandler<PlayerEventArgs> PlayerLogin;
        public event EventHandler<PlayerEventArgs> PlayerLogoff;
        public event EventHandler<ServerStatusEventArgs> ServerStatusUpdated;
        public event EventHandler<Exception> ErrorOccurred;

        // Properties
        public bool IsConnected => connection?.IsConnected == true;
        public bool IsAuthenticated { get; private set; }
        public string ServerAddress { get; private set; }
        public int ServerPort { get; private set; }
        public string ConnectionType => connection?.ConnectionType ?? "None";

        /// <summary>
        /// Connects and authenticates to an ACE RCON server
        /// </summary>
        /// <param name="address">Server address</param>
        /// <param name="port">Server port</param>
        /// <param name="useTcp">Use TCP if true, WebSocket if false</param>
        /// <param name="password">RCON password</param>
        /// <param name="accountName">Account name (for ACE-style auth), leave empty for Rust-style</param>
        /// <param name="cancellationToken">Cancellation token</param>
        public async Task<bool> ConnectAndAuthenticateAsync(string address, int port, bool useTcp,
            string password, string accountName, CancellationToken cancellationToken)
        {
            try
            {
                ServerAddress = address;
                ServerPort = port;

                // Determine auth style based on whether account name is provided
                bool useAceAuth = !string.IsNullOrWhiteSpace(accountName);

                Logger.Info($"Connecting to {address}:{port} via {(useTcp ? "TCP" : "WebSocket")}...");
                Logger.Info($"Auth mode: {(useAceAuth ? "ACE-style (account+password)" : "Rust-style (password only)")}");

                // Create appropriate connection type
                connection = useTcp ? (IConnection)new TcpConnection() : new WebSocketConnection();

                // Subscribe to connection events
                connection.MessageReceived += OnConnectionMessageReceived;
                connection.ConnectionClosed += OnConnectionClosed;

                // For Rust-style, password goes in connection (URL or first message)
                // For ACE-style, we connect without password and send auth command after
                string connectionPassword = useAceAuth ? null : password;

                var connected = await connection.ConnectAsync(address, port, connectionPassword, cancellationToken);

                if (!connected)
                {
                    Logger.Error("Connection failed");
                    return false;
                }

                Logger.Info($"Connected to {address}:{port} via {ConnectionType}");
                OnConnected();

                // For ACE-style, send auth command
                if (useAceAuth)
                {
                    return await AuthenticateAceStyleAsync(accountName, password, cancellationToken);
                }
                else
                {
                    // For Rust-style, we're already authenticated via the connection
                    // But we need to wait for the auth response
                    await Task.Delay(500, cancellationToken); // Give server time to respond

                    // Check if we got any error
                    if (IsConnected)
                    {
                        IsAuthenticated = true;
                        Logger.Info("Rust-style authentication successful (password in connection)");
                        return true;
                    }
                    else
                    {
                        Logger.Error("Rust-style authentication failed - connection was closed by server");
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error("Connection/authentication failed", ex);
                OnError(ex);
                return false;
            }
        }

        /// <summary>
        /// Authenticates using ACE-style account and password
        /// </summary>
        private async Task<bool> AuthenticateAceStyleAsync(string accountName, string password, CancellationToken cancellationToken)
        {
            try
            {
                Logger.Info($"Sending ACE-style auth command for account: {accountName}...");

                var request = new RconRequest
                {
                    Identifier = GetNextIdentifier(),
                    Command = "auth",
                    Password = password,
                    Name = accountName
                };

                var response = await SendRequestAsync(request, cancellationToken, timeout: TimeSpan.FromSeconds(10));

                if (response != null && response.Status == RconStatus.Authenticated)
                {
                    IsAuthenticated = true;
                    Logger.Info("ACE-style authentication successful");
                    return true;
                }

                Logger.Warning($"ACE-style authentication failed: {response?.Message ?? "No response"}");
                return false;
            }
            catch (Exception ex)
            {
                Logger.Error("ACE-style authentication error", ex);
                return false;
            }
        }

        /// <summary>
        /// Sends a command to the server and waits for response
        /// </summary>
        public async Task<RconResponse> SendCommandAsync(string command, CancellationToken cancellationToken,
            params string[] args)
        {
            return await SendCommandAsync(command, cancellationToken, TimeSpan.FromSeconds(30), args);
        }

        /// <summary>
        /// Sends a command to the server and waits for response with custom timeout
        /// </summary>
        public async Task<RconResponse> SendCommandAsync(string command, CancellationToken cancellationToken,
            TimeSpan timeout, params string[] args)
        {
            var request = new RconRequest(GetNextIdentifier(), command, args);
            return await SendRequestAsync(request, cancellationToken, timeout);
        }

        /// <summary>
        /// Sends an RCON request and waits for response
        /// </summary>
        private async Task<RconResponse> SendRequestAsync(RconRequest request, CancellationToken cancellationToken,
            TimeSpan timeout)
        {
            if (!IsConnected)
            {
                throw new InvalidOperationException("Not connected to server");
            }

            var tcs = new TaskCompletionSource<RconResponse>();

            // Register pending request
            lock (pendingLock)
            {
                pendingRequests[request.Identifier] = tcs;
            }

            try
            {
                // Serialize and send
                var json = JsonConvert.SerializeObject(request);
                await connection.SendAsync(json, cancellationToken);

                // Wait for response with timeout
                using (var timeoutCts = new CancellationTokenSource(timeout))
                using (var linkedCts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, timeoutCts.Token))
                {
                    linkedCts.Token.Register(() => tcs.TrySetCanceled());

                    return await tcs.Task;
                }
            }
            catch (OperationCanceledException)
            {
                Logger.Warning($"Command '{request.Command}' timed out or was cancelled");
                return null;
            }
            finally
            {
                // Remove pending request
                lock (pendingLock)
                {
                    pendingRequests.Remove(request.Identifier);
                }
            }
        }

        /// <summary>
        /// Disconnects from the server
        /// </summary>
        public async Task DisconnectAsync()
        {
            if (connection != null)
            {
                await connection.DisconnectAsync();
                IsAuthenticated = false;
            }
        }

        /// <summary>
        /// Gets the next identifier for requests
        /// </summary>
        private int GetNextIdentifier()
        {
            return Interlocked.Increment(ref nextIdentifier);
        }

        // Event Handlers

        private void OnConnectionMessageReceived(object sender, string message)
        {
            try
            {
                var response = JsonConvert.DeserializeObject<RconResponse>(message);

                if (response == null)
                {
                    Logger.Warning($"Failed to parse RCON response: {message}");
                    return;
                }

                // Route based on identifier and status
                if (response.IsBroadcast)
                {
                    // Broadcast message - route by type
                    RouteBroadcastMessage(response);
                }
                else
                {
                    // Response to our request - complete pending request
                    lock (pendingLock)
                    {
                        if (pendingRequests.TryGetValue(response.Identifier, out var tcs))
                        {
                            tcs.TrySetResult(response);
                        }
                        else
                        {
                            Logger.Warning($"Received response for unknown identifier: {response.Identifier}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error("Error processing received message", ex);
                OnError(ex);
            }
        }

        private void RouteBroadcastMessage(RconResponse response)
        {
            try
            {
                if (response.IsPlayerEvent)
                {
                    // Player login/logoff event
                    var playerEvent = new PlayerEvent
                    {
                        EventType = response.Command,
                        PlayerName = response.GetData<string>("playerName"),
                        PlayerGuid = response.GetData<string>("playerGuid"),
                        Level = response.GetData<int>("level"),
                        Location = response.GetData<string>("location"),
                        Count = response.GetData<int>("count"),
                        WorldTime = response.GetData<DateTime?>("WorldTime")
                    };

                    if (playerEvent.IsLogin)
                        OnPlayerLogin(playerEvent);
                    else if (playerEvent.IsLogoff)
                        OnPlayerLogoff(playerEvent);
                }
                else if (response.IsLogMessage)
                {
                    // Console log message
                    OnMessageReceived(response);
                }
                else if (response.Status == RconStatus.StatusUpdate)
                {
                    // Server status update
                    // TODO: Parse server status from response.Data
                }
            }
            catch (Exception ex)
            {
                Logger.Error("Error routing broadcast message", ex);
            }
        }

        private void OnConnectionClosed(object sender, string reason)
        {
            Logger.Info($"Connection closed: {reason}");
            IsAuthenticated = false;
            OnDisconnected(reason);
        }

        // Event Raisers

        private void OnConnected()
        {
            Connected?.Invoke(this, EventArgs.Empty);
        }

        private void OnDisconnected(string reason)
        {
            Disconnected?.Invoke(this, reason);
        }

        private void OnMessageReceived(RconResponse response)
        {
            MessageReceived?.Invoke(this, new RconMessageEventArgs(response));
        }

        private void OnPlayerLogin(PlayerEvent playerEvent)
        {
            PlayerLogin?.Invoke(this, new PlayerEventArgs(playerEvent));
        }

        private void OnPlayerLogoff(PlayerEvent playerEvent)
        {
            PlayerLogoff?.Invoke(this, new PlayerEventArgs(playerEvent));
        }

        private void OnError(Exception ex)
        {
            ErrorOccurred?.Invoke(this, ex);
        }

        public void Dispose()
        {
            if (!isDisposed)
            {
                connection?.Dispose();

                // Cancel all pending requests
                lock (pendingLock)
                {
                    foreach (var tcs in pendingRequests.Values)
                    {
                        tcs.TrySetCanceled();
                    }
                    pendingRequests.Clear();
                }

                isDisposed = true;
            }
        }
    }
}
