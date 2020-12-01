using System;

namespace TollCollectorApp
{
    internal static class Extensions
    {
        public static bool NextBool(this Random random)
            => Convert.ToBoolean(random.Next(0, 2));

        public static char NextNumberChar(this Random random)
            => (char)('0' + random.Next(0, 10));

        public static char NextAlphaChar(this Random random)
            => (char)('A' + random.Next(0, 26));
    }
}
