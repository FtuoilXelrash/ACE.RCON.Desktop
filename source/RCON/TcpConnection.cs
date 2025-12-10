using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ACE.RCON.Desktop.Utilities;

namespace ACE.RCON.Desktop.RCON
{
    /// <summary>
    /// TCP implementation of RCON connection
    /// </summary>
    public class TcpConnection : IConnection
    {
        private TcpClient tcpClient;
        private NetworkStream stream;
        private StreamReader reader;
        private StreamWriter writer;
        private CancellationTokenSource receiveCts;
        private readonly SemaphoreSlim sendSemaphore = new SemaphoreSlim(1, 1);
        private bool isDisposed;

        public bool IsConnected => tcpClient?.Connected == true;
        public string ConnectionType => "TCP";

        public event EventHandler<string> MessageReceived;
        public event EventHandler<string> ConnectionClosed;

        public async Task<bool> ConnectAsync(string address, int port, string password, CancellationToken cancellationToken)
        {
            try
            {
                Logger.Info($"Connecting to TCP RCON at {address}:{port}...");

                tcpClient = new TcpClient();
                await tcpClient.ConnectAsync(address, port);

                if (!tcpClient.Connected)
                {
                    Logger.Warning("TCP connection failed");
                    return false;
                }

                stream = tcpClient.GetStream();
                reader = new StreamReader(stream, Encoding.UTF8);
                writer = new StreamWriter(stream, Encoding.UTF8) { AutoFlush = true };

                Logger.Info("TCP connection established");

                // For Rust-style auth, send password as first message
                if (!string.IsNullOrEmpty(password))
                {
                    Logger.Debug("Sending password for Rust-style auth");
                    await writer.WriteLineAsync(password);
                }

                receiveCts = new CancellationTokenSource();

                // Start receiving messages
                _ = Task.Run(() => ReceiveLoop(receiveCts.Token), receiveCts.Token);

                return true;
            }
            catch (Exception ex)
            {
                Logger.Error("TCP connection failed", ex);
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
                Logger.Debug($"Sending: {message}");

                // TCP RCON protocol uses line-delimited JSON
                await writer.WriteLineAsync(message);
            }
            finally
            {
                sendSemaphore.Release();
            }
        }

        public async Task DisconnectAsync()
        {
            if (tcpClient != null && IsConnected)
            {
                try
                {
                    Logger.Info("Disconnecting TCP...");

                    receiveCts?.Cancel();

                    writer?.Close();
                    reader?.Close();
                    stream?.Close();
                    tcpClient?.Close();

                    Logger.Info("TCP disconnected");
                }
                catch (Exception ex)
                {
                    Logger.Error("Error during TCP disconnect", ex);
                }
            }

            await Task.CompletedTask;
        }

        private async Task ReceiveLoop(CancellationToken cancellationToken)
        {
            try
            {
                while (!cancellationToken.IsCancellationRequested && IsConnected)
                {
                    // TCP RCON protocol uses line-delimited JSON
                    var line = await reader.ReadLineAsync();

                    if (line == null)
                    {
                        Logger.Info("Server closed TCP connection");
                        OnConnectionClosed("Server closed connection");
                        return;
                    }

                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        Logger.Debug($"Received: {line}");
                        OnMessageReceived(line);
                    }
                }
            }
            catch (OperationCanceledException)
            {
                Logger.Debug("TCP receive loop cancelled");
            }
            catch (IOException ex)
            {
                Logger.Error("TCP I/O error in receive loop", ex);
                OnConnectionClosed($"I/O error: {ex.Message}");
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
                writer?.Dispose();
                reader?.Dispose();
                stream?.Dispose();
                tcpClient?.Dispose();
                isDisposed = true;
            }
        }
    }
}
