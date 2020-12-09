using System;
using System.Collections.Generic;

namespace CommercialRegistration
{
    public class DeliveryTruck : IEquatable<DeliveryTruck>
    {
        public DeliveryTruck(int grossWeightClass)
        {
            GrossWeightClass = grossWeightClass;
        }

        public int GrossWeightClass { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as DeliveryTruck);
        }

        public bool Equals(DeliveryTruck other)
        {
            return other != null &&
                   GrossWeightClass == other.GrossWeightClass;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(GrossWeightClass);
        }

        public override string ToString()
        {
            return $"DeliveryTruck {{ {nameof(GrossWeightClass)} = {GrossWeightClass} }}";
        }

        public static bool operator ==(DeliveryTruck left, DeliveryTruck right)
        {
            return EqualityComparer<DeliveryTruck>.Default.Equals(left, right);
        }

        public static bool operator !=(DeliveryTruck left, DeliveryTruck right)
        {
            return !(left == right);
        }
    }
}