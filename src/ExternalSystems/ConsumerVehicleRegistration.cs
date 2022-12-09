using System;
using System.Collections.Generic;

namespace ConsumerVehicleRegistration
{
    public record Car
    {
        public Car(int passengers)
        {
            Passengers = passengers;
        }

        public int Passengers { get; }

    }
}
