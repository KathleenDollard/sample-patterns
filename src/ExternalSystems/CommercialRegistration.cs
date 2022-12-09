using System;
using System.Collections.Generic;

namespace CommercialRegistration
{
    public record DeliveryTruck 
    {
        public DeliveryTruck(int grossWeightClass)
        {
            GrossWeightClass = grossWeightClass;
        }

        public int GrossWeightClass { get; set; }

    }
}