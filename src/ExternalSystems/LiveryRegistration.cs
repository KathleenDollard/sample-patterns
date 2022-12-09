using System;
using System.Collections.Generic;

namespace LiveryRegistration
{
    public record Taxi 
    {
        public Taxi(int fares)
        {
            Fares = fares;
        }

        public int Fares { get; }

    }

    public record Bus 
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

    }
}
