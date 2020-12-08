using System;

namespace Common
{
    [Flags]
    public enum LogLevel
    {
        Info=0b0000,
        Warning = 0b0010,
        Error = 0b0100,
        ReallyBad = 0b0100_0000_0000,
        Worse = 0b1000_0000_0000,
    }
}