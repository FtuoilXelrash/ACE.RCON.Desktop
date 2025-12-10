using System;

namespace ACE.RCON.Desktop.RCON.Models
{
    /// <summary>
    /// Represents server status information
    /// </summary>
    public class ServerStatus
    {
        public string ServerName { get; set; }
        public string Status { get; set; }
        public int CurrentPlayers { get; set; }
        public int MaxPlayers { get; set; }
        public long Uptime { get; set; }
        public DateTime? WorldTime { get; set; }
        public string RconVersion { get; set; }
        public string AceServerVersion { get; set; }
        public string AceServerBuild { get; set; }
        public int AceDatabaseBaseVersion { get; set; }
        public int AceDatabasePatchVersion { get; set; }

        /// <summary>
        /// Gets whether the server is online
        /// </summary>
        public bool IsOnline => Status == "Online";

        /// <summary>
        /// Gets uptime as a formatted string
        /// </summary>
        public string GetFormattedUptime()
        {
            if (Uptime == 0)
                return "0 seconds";

            var ts = TimeSpan.FromSeconds(Uptime);
            return $"{ts.Days} days, {ts.Hours} hours, {ts.Minutes} minutes, {ts.Seconds} seconds";
        }

        /// <summary>
        /// Calculates uptime from WorldTime if available
        /// </summary>
        public void UpdateUptimeFromWorldTime()
        {
            if (WorldTime.HasValue)
            {
                Uptime = (long)(DateTime.UtcNow - WorldTime.Value).TotalSeconds;
            }
        }
    }
}
