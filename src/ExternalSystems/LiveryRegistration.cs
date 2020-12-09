using System;
using System.Collections.Generic;

namespace LiveryRegistration
{
    public class Taxi : IEquatable<Taxi>
    {
        public Taxi(int fares)
        {
            Fares = fares;
        }

        public int Fares { get; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Taxi);
        }

        public bool Equals(Taxi other)
        {
            return other != null &&
                   Fares == other.Fares;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Fares);
        }

        public override string ToString()
        {
            return $"Taxi {{ {nameof(Fares)} = {Fares} }}";
        }

        public static bool operator ==(Taxi left, Taxi right)
        {
            return EqualityComparer<Taxi>.Default.Equals(left, right);
        }

        public static bool operator !=(Taxi left, Taxi right)
        {
            return !(left == right);
        }
    }

    public class Bus : IEquatable<Bus>
    {
        public Bus(int capacity, int riders)
        {
            Capacity = capacity;
            Riders = riders;
        }

        public int Capacity { get; }
        public int Riders { get; }

        public void Deconstruct(out int capacity, out int riders)
        {
            capacity = Capacity;
            riders = Riders;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Bus);
        }

        public bool Equals(Bus other)
        {
            return other != null &&
                   Capacity == other.Capacity &&
                   Riders == other.Riders;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Capacity, Riders);
        }

        public override string ToString()
        {
            return $"Bus {{ {nameof(Capacity)} = {Capacity}, {nameof(Riders)} = {Riders} }}";
        }

        public static bool operator ==(Bus left, Bus right)
        {
            return EqualityComparer<Bus>.Default.Equals(left, right);
        }

        public static bool operator !=(Bus left, Bus right)
        {
            return !(left == right);
        }
    }
}
