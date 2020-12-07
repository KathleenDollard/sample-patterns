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
            if (logLevel == LogLevel.Error)
            {
                Path = "Images/error.png";
            }
            else  if (logLevel == LogLevel.Warning)
            {
                Path = "Images/warning.png";
            }
            else 
            {
                Path = "Images/info.png";
            }

            Message = message;
        }
    }
}
