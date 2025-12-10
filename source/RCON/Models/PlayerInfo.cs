using System;

namespace ACE.RCON.Desktop.RCON.Models
{
    /// <summary>
    /// Represents information about an online player
    /// </summary>
    public class PlayerInfo
    {
        public string Name { get; set; }
        public string AccountName { get; set; }
        public int Level { get; set; }
        public string Race { get; set; }
        public string Location { get; set; }
        public string PlayerGuid { get; set; }

        public override string ToString()
        {
            return $"{Name} ({AccountName}) - Level {Level}";
        }
    }

    /// <summary>
    /// Represents a player login/logoff event
    /// </summary>
    public class PlayerEvent
    {
        public string EventType { get; set; } // "login" or "logoff"
        public string PlayerName { get; set; }
        public string PlayerGuid { get; set; }
        public int Level { get; set; }
        public string Location { get; set; }
        public int Count { get; set; } // Current online player count after this event
        public DateTime? WorldTime { get; set; }

        public bool IsLogin => EventType == "login";
        public bool IsLogoff => EventType == "logoff";
    }

    /// <summary>
    /// Represents a chat message
    /// </summary>
    public class ChatMessage
    {
        public string ChatType { get; set; } // "General", "Guild", "Trade"
        public string PlayerName { get; set; }
        public string AccountName { get; set; }
        public string Message { get; set; }
        public DateTime Timestamp { get; set; }

        public ChatMessage()
        {
            Timestamp = DateTime.Now;
        }

        public override string ToString()
        {
            return $"[{ChatType}] [{AccountName}]: {Message}";
        }
    }

    /// <summary>
    /// Represents a banned account
    /// </summary>
    public class BannedAccount
    {
        public string AccountName { get; set; }
        public DateTime? BanExpiration { get; set; }
        public string BanReason { get; set; }

        public bool IsPermanent => BanExpiration == null;

        public string GetExpirationString()
        {
            if (IsPermanent)
                return "Never (Permanent)";

            return BanExpiration?.ToString("yyyy-MM-dd HH:mm:ss") ?? "Unknown";
        }
    }
}
