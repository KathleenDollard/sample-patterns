using System;
using System.Collections.Generic;

namespace ConsumerVehicleRegistration
{
    public class Car : IEquatable<Car>
    {
        public Car(int passengers)
        {
            Passengers = passengers;
        }

        public int Passengers { get; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Car);
        }

        public bool Equals(Car other)
        {
            return other != null &&
                   Passengers == other.Passengers;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Passengers);
        }

        public override string ToString()
        {
            return $"Car {{ {nameof(Passengers)} = {Passengers} }}";
        }

        public static bool operator ==(Car left, Car right)
        {
            return EqualityComparer<Car>.Default.Equals(left, right);
        }

        public static bool operator !=(Car left, Car right)
        {
            return !(left == right);
        }
    }
}
