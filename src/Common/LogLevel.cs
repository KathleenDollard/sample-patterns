using System;

namespace Common
{
    [Flags]
    public enum LogLevel
    {
        Info,
        Warning = 0b0010,
        Error = 0b0100,
        ReallyBad = 0b_0100_0000_0000,
        Worse = 0b_1000_0000_0000,
    }
}