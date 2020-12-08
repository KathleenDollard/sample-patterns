using System;

namespace Common
{
    [Flags]
    public enum LogLevel
    {
        Info,
        Warning = 2,
        Error = 4,
    }
}