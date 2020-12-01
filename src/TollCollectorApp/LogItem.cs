using Common;
using TollCollectorLib;

namespace TollCollectorApp
{
    internal class LogItem
    {
        public string Path { get; }
        public string Message { get; }

        public LogItem(LogLevel logLevel, string message)
        {
            Path = logLevel switch
            {
                LogLevel.Error => "Images/error.png",
                LogLevel.Warning => "Images/warning.png",
                _ => "Images/info.png"
            };

            Message = message;
        }
    }
}
