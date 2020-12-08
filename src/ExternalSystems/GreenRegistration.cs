using System;
using System.Collections.Generic;

namespace GreenRegistration
{
    public class Cycle : IEquatable<Cycle>
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

        public override bool Equals(object obj)
        {
            return Equals(obj as Cycle);
        }

        public bool Equals(Cycle other)
        {
            return other != null &&
                   Riders == other.Riders &&
                   Wheels == other.Wheels;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Riders, Wheels);
        }

        public override string ToString()
        {
            return $"Cycle {{ {nameof(Riders)} = {Riders}, {nameof(Wheels)} = {Wheels} }}";
        }

        public static bool operator ==(Cycle left, Cycle right)
        {
            return EqualityComparer<Cycle>.Default.Equals(left, right);
        }

        public static bool operator !=(Cycle left, Cycle right)
        {
            return !(left == right);
        }
    }
}
