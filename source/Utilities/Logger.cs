using System;
using System.IO;
using System.Threading;

namespace ACE.RCON.Desktop.Utilities
{
    /// <summary>
    /// Simple file-based logger with thread safety
    /// </summary>
    public static class Logger
    {
        private static readonly object lockObject = new object();
        private static string logDirectory = "logs";
        private static bool enableDebugLogging = true;

        /// <summary>
        /// Gets or sets whether debug logging is enabled
        /// </summary>
        public static bool EnableDebugLogging
        {
            get => enableDebugLogging;
            set => enableDebugLogging = value;
        }

        /// <summary>
        /// Initializes the logger with a custom log directory
        /// </summary>
        public static void Initialize(string directory)
        {
            logDirectory = directory;
            EnsureLogDirectoryExists();
        }

        /// <summary>
        /// Logs a debug message
        /// </summary>
        public static void Debug(string message)
        {
            if (EnableDebugLogging)
                WriteLog("DEBUG", message);
        }

        /// <summary>
        /// Logs an info message
        /// </summary>
        public static void Info(string message)
        {
            WriteLog("INFO", message);
        }

        /// <summary>
        /// Logs a warning message
        /// </summary>
        public static void Warning(string message)
        {
            WriteLog("WARNING", message);
        }

        /// <summary>
        /// Logs an error message
        /// </summary>
        public static void Error(string message)
        {
            WriteLog("ERROR", message);
        }

        /// <summary>
        /// Logs an error message with exception details
        /// </summary>
        public static void Error(string message, Exception ex)
        {
            WriteLog("ERROR", $"{message}\nException: {ex.GetType().Name}: {ex.Message}\nStack Trace: {ex.StackTrace}");
        }

        private static void WriteLog(string level, string message)
        {
            lock (lockObject)
            {
                try
                {
                    EnsureLogDirectoryExists();

                    var timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                    var logMessage = $"[{timestamp}] [{level}] {message}";

                    // Write to daily log file
                    var logFile = Path.Combine(logDirectory, $"app_{DateTime.Now:yyyy-MM-dd}.log");
                    File.AppendAllText(logFile, logMessage + Environment.NewLine);

                    // Also write to console if attached
                    #if DEBUG
                    Console.WriteLine(logMessage);
                    #endif
                }
                catch (Exception ex)
                {
                    // Fail silently to prevent logging errors from crashing the app
                    Console.WriteLine($"Logger error: {ex.Message}");
                }
            }
        }

        private static void EnsureLogDirectoryExists()
        {
            if (!Directory.Exists(logDirectory))
            {
                Directory.CreateDirectory(logDirectory);
            }
        }

        /// <summary>
        /// Cleans up old log files older than the specified number of days
        /// </summary>
        public static void CleanupOldLogs(int daysToKeep)
        {
            try
            {
                EnsureLogDirectoryExists();

                var cutoffDate = DateTime.Now.AddDays(-daysToKeep);
                var logFiles = Directory.GetFiles(logDirectory, "*.log");

                foreach (var file in logFiles)
                {
                    var fileInfo = new FileInfo(file);
                    if (fileInfo.LastWriteTime < cutoffDate)
                    {
                        File.Delete(file);
                        Info($"Deleted old log file: {fileInfo.Name}");
                    }
                }
            }
            catch (Exception ex)
            {
                Error("Failed to cleanup old logs", ex);
            }
        }
    }
}
