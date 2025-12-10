using System;
using System.Threading;
using System.Threading.Tasks;

namespace ACE.RCON.Desktop.RCON
{
    /// <summary>
    /// Interface for RCON connections (TCP or WebSocket)
    /// </summary>
    public interface IConnection : IDisposable
    {
        /// <summary>
        /// Gets whether the connection is currently connected
        /// </summary>
        bool IsConnected { get; }

        /// <summary>
        /// Gets the connection type (TCP or WebSocket)
        /// </summary>
        string ConnectionType { get; }

        /// <summary>
        /// Event raised when a message is received
        /// </summary>
        event EventHandler<string> MessageReceived;

        /// <summary>
        /// Event raised when the connection is closed
        /// </summary>
        event EventHandler<string> ConnectionClosed;

        /// <summary>
        /// Connects to the RCON server
        /// </summary>
        /// <param name="address">Server address (IP or hostname)</param>
        /// <param name="port">Server port</param>
        /// <param name="password">Optional password (for Rust-style auth in URL)</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>True if connected successfully</returns>
        Task<bool> ConnectAsync(string address, int port, string password, CancellationToken cancellationToken);

        /// <summary>
        /// Sends a message to the server
        /// </summary>
        /// <param name="message">JSON message to send</param>
        /// <param name="cancellationToken">Cancellation token</param>
        Task SendAsync(string message, CancellationToken cancellationToken);

        /// <summary>
        /// Disconnects from the server
        /// </summary>
        Task DisconnectAsync();
    }
}
