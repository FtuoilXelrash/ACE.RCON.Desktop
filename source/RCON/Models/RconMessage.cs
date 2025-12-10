using Newtonsoft.Json;
using System.Collections.Generic;

namespace ACE.RCON.Desktop.RCON.Models
{
    /// <summary>
    /// Represents an RCON request message sent to the server
    /// </summary>
    public class RconRequest
    {
        [JsonProperty("Identifier")]
        public int Identifier { get; set; }

        [JsonProperty("Command")]
        public string Command { get; set; }

        [JsonProperty("Args", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Args { get; set; }

        [JsonProperty("Password", NullValueHandling = NullValueHandling.Ignore)]
        public string Password { get; set; }

        [JsonProperty("Name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        public RconRequest()
        {
        }

        public RconRequest(int identifier, string command, params string[] args)
        {
            Identifier = identifier;
            Command = command;
            Args = args != null && args.Length > 0 ? args : null;
        }
    }

    /// <summary>
    /// Represents an RCON response message received from the server
    /// </summary>
    public class RconResponse
    {
        [JsonProperty("Identifier")]
        public int Identifier { get; set; }

        [JsonProperty("Status")]
        public string Status { get; set; }

        [JsonProperty("Message")]
        public string Message { get; set; }

        [JsonProperty("Command", NullValueHandling = NullValueHandling.Ignore)]
        public string Command { get; set; }

        [JsonProperty("Data", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, object> Data { get; set; }

        [JsonProperty("Error", NullValueHandling = NullValueHandling.Ignore)]
        public string Error { get; set; }

        [JsonProperty("Debug")]
        public bool Debug { get; set; }

        /// <summary>
        /// Gets whether this response indicates success
        /// </summary>
        public bool IsSuccess => Status == "success" || Status == "authenticated";

        /// <summary>
        /// Gets whether this response is an error
        /// </summary>
        public bool IsError => Status == "error";

        /// <summary>
        /// Gets whether this is a broadcast message (Identifier 0 or -1)
        /// </summary>
        public bool IsBroadcast => Identifier == 0 || Identifier == -1;

        /// <summary>
        /// Gets whether this is a console log message
        /// </summary>
        public bool IsLogMessage => Status?.StartsWith("log_") == true;

        /// <summary>
        /// Gets whether this is a player event
        /// </summary>
        public bool IsPlayerEvent => Status == "player_event";

        /// <summary>
        /// Gets the log level from status (if this is a log message)
        /// </summary>
        public string GetLogLevel()
        {
            if (!IsLogMessage) return null;
            return Status.Substring(4).ToUpper(); // Remove "log_" prefix
        }

        /// <summary>
        /// Gets a typed data value from the Data dictionary
        /// </summary>
        public T GetData<T>(string key, T defaultValue = default(T))
        {
            if (Data == null || !Data.ContainsKey(key))
                return defaultValue;

            try
            {
                var value = Data[key];
                if (value is T typedValue)
                    return typedValue;

                // Try to convert using Newtonsoft.Json
                var json = JsonConvert.SerializeObject(value);
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch
            {
                return defaultValue;
            }
        }
    }

    /// <summary>
    /// Response status constants
    /// </summary>
    public static class RconStatus
    {
        public const string Success = "success";
        public const string Error = "error";
        public const string Authenticated = "authenticated";
        public const string LogInfo = "log_info";
        public const string LogWarn = "log_warn";
        public const string LogError = "log_error";
        public const string LogDebug = "log_debug";
        public const string PlayerEvent = "player_event";
        public const string StatusUpdate = "status_update";
    }
}
