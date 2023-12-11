using System;
using System.Collections.Generic;

namespace LiveryRegistration
{
    public record Taxi(int Fares)
    { }


    public record Bus(int Capacity, int Riders)
    { }

//    public int Capacity { get; }
//    public int Riders { get; }

//    public void Deconstruct(out int capacity, out int riders)
//    {
//        capacity = Capacity;
//        riders = Riders;
//    }

//}
}
