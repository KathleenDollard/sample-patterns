using System;
using System.Collections.Generic;

namespace GreenRegistration
{
    public record Cycle : IEquatable<Cycle>
    {
        public Cycle(int riders, int wheels)
        {
            Riders = riders;
            Wheels = wheels;
        }

        public int Riders { get; }
        public int Wheels { get; }

        public void Deconstruct(out int riders, out int wheels)
        {
            riders = Riders;
            wheels = Wheels;
        }

    }
}
