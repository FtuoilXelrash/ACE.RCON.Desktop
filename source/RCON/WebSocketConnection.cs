using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ACE.RCON.Desktop.Utilities;

namespace ACE.RCON.Desktop.RCON
{
    /// <summary>
    /// WebSocket implementation of RCON connection
    /// </summary>
    public class WebSocketConnection : IConnection
    {
        private ClientWebSocket webSocket;
        private CancellationTokenSource receiveCts;
        private readonly SemaphoreSlim sendSemaphore = new SemaphoreSlim(1, 1);
        private bool isDisposed;

        public bool IsConnected => webSocket?.State == WebSocketState.Open;
        public string ConnectionType => "WebSocket";

        public event EventHandler<string> MessageReceived;
        public event EventHandler<string> ConnectionClosed;

        public async Task<bool> ConnectAsync(string address, int port, string password, CancellationToken cancellationToken)
        {
            try
            {
                Logger.Info($"Connecting to WebSocket RCON at {address}:{port}...");

                webSocket = new ClientWebSocket();
                receiveCts = new CancellationTokenSource();

                // Build WebSocket URL with password in path for Rust-style auth
                var url = string.IsNullOrEmpty(password)
                    ? $"ws://{address}:{port}/rcon"
                    : $"ws://{address}:{port}/{password}";

                Logger.Debug($"WebSocket URL: {url.Replace(password, "***")}");

                await webSocket.ConnectAsync(new Uri(url), cancellationToken);

                if (webSocket.State == WebSocketState.Open)
                {
                    Logger.Info("WebSocket connection established");

                    // Start receiving messages
                    _ = Task.Run(() => ReceiveLoop(receiveCts.Token), receiveCts.Token);

                    return true;
                }

                Logger.Warning($"WebSocket connection failed. State: {webSocket.State}");
                return false;
            }
            catch (Exception ex)
            {
                Logger.Error("WebSocket connection failed", ex);
                return false;
            }
        }

        public async Task SendAsync(string message, CancellationToken cancellationToken)
        {
            if (!IsConnected)
            {
                throw new InvalidOperationException("Not connected to server");
            }

            await sendSemaphore.WaitAsync(cancellationToken);
            try
            {
                var bytes = Encoding.UTF8.GetBytes(message);
                var buffer = new ArraySegment<byte>(bytes);

                Logger.Debug($"Sending: {message}");

                await webSocket.SendAsync(buffer, WebSocketMessageType.Text, true, cancellationToken);
            }
            finally
            {
                sendSemaphore.Release();
            }
        }

        public async Task DisconnectAsync()
        {
            if (webSocket != null && IsConnected)
            {
                try
                {
                    Logger.Info("Disconnecting WebSocket...");

                    receiveCts?.Cancel();

                    await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Client closing", CancellationToken.None);

                    Logger.Info("WebSocket disconnected");
                }
                catch (Exception ex)
                {
                    Logger.Error("Error during WebSocket disconnect", ex);
                }
            }
        }

        private async Task ReceiveLoop(CancellationToken cancellationToken)
        {
            var buffer = new byte[8192];

            try
            {
                while (!cancellationToken.IsCancellationRequested && IsConnected)
                {
                    var segment = new ArraySegment<byte>(buffer);
                    var sb = new StringBuilder();

                    WebSocketReceiveResult result;
                    do
                    {
                        result = await webSocket.ReceiveAsync(segment, cancellationToken);

                        if (result.MessageType == WebSocketMessageType.Close)
                        {
                            Logger.Info("Server closed WebSocket connection");
                            OnConnectionClosed("Server closed connection");
                            return;
                        }

                        sb.Append(Encoding.UTF8.GetString(buffer, 0, result.Count));

                    } while (!result.EndOfMessage);

                    var message = sb.ToString();
                    if (!string.IsNullOrEmpty(message))
                    {
                        Logger.Debug($"Received: {message}");
                        OnMessageReceived(message);
                    }
                }
            }
            catch (OperationCanceledException)
            {
                Logger.Debug("WebSocket receive loop cancelled");
            }
            catch (WebSocketException ex)
            {
                Logger.Error("WebSocket error in receive loop", ex);
                OnConnectionClosed($"WebSocket error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Logger.Error("Unexpected error in receive loop", ex);
                OnConnectionClosed($"Unexpected error: {ex.Message}");
            }
        }

        private void OnMessageReceived(string message)
        {
            MessageReceived?.Invoke(this, message);
        }

        private void OnConnectionClosed(string reason)
        {
            ConnectionClosed?.Invoke(this, reason);
        }

        public void Dispose()
        {
            if (!isDisposed)
            {
                receiveCts?.Cancel();
                receiveCts?.Dispose();
                sendSemaphore?.Dispose();
                webSocket?.Dispose();
                isDisposed = true;
            }
        }
    }
}
