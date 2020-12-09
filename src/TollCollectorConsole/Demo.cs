using CommercialRegistration;
using ConsumerVehicleRegistration;
using LiveryRegistration;
using System;
using TollCollectorLib;

namespace TollCollectorConsole
{
    class Demo
    {
        public static void Output()
        {
            var soloDriver = new Car(Passengers: 0);
            var twoRideShare = new Car(Passengers: 1);
            var threeRideShare = new Car (Passengers: 2);
            var fullVan = new Car(Passengers: 5);
            var emptyTaxi = new Taxi(Fares: 0);
            var singleFare = new Taxi(Fares: 1);
            var doubleFare = new Taxi(Fares: 2);
            var fullVanPool = new Taxi(Fares: 5);
            var lowOccupantBus = new Bus(Capacity: 90, Riders: 15);
            var normalBus = new Bus(Capacity: 90, Riders: 75);
            var fullBus = new Bus(Capacity: 90, Riders: 85);

            var heavyTruck = new DeliveryTruck(GrossWeightClass: 7500);
            var truck = new DeliveryTruck(GrossWeightClass: 4000);
            var lightTruck = new DeliveryTruck(GrossWeightClass: 2500);

            Console.WriteLine($"The toll for a solo driver is {TollCalculator.CalculateToll(soloDriver)}");
            Console.WriteLine($"The toll for a two ride share is {TollCalculator.CalculateToll(twoRideShare)}");
            Console.WriteLine($"The toll for a three ride share is {TollCalculator.CalculateToll(threeRideShare)}");
            Console.WriteLine($"The toll for a fullVan is {TollCalculator.CalculateToll(fullVan)}");

            Console.WriteLine($"The toll for an empty taxi is {TollCalculator.CalculateToll(emptyTaxi)}");
            Console.WriteLine($"The toll for a single fare taxi is {TollCalculator.CalculateToll(singleFare)}");
            Console.WriteLine($"The toll for a double fare taxi is {TollCalculator.CalculateToll(doubleFare)}");
            Console.WriteLine($"The toll for a full van taxi is {TollCalculator.CalculateToll(fullVanPool)}");

            Console.WriteLine($"The toll for a low-occupant bus is {TollCalculator.CalculateToll(lowOccupantBus)}");
            Console.WriteLine($"The toll for a regular bus is {TollCalculator.CalculateToll(normalBus)}");
            Console.WriteLine($"The toll for a bus is {TollCalculator.CalculateToll(fullBus)}");

            Console.WriteLine($"The toll for a truck is {TollCalculator.CalculateToll(heavyTruck)}");
            Console.WriteLine($"The toll for a truck is {TollCalculator.CalculateToll(truck)}");
            Console.WriteLine($"The toll for a truck is {TollCalculator.CalculateToll(lightTruck)}");

            try
            {
                TollCalculator.CalculateToll("this will fail");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Caught an argument exception when using the wrong type");
            }
            try
            {
                TollCalculator.CalculateToll(null!); // use the bang this way cautiously - I want to cause the runtime error here
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Caught an argument exception when using null");
            }

            Console.WriteLine("Testing the time premiums");

            var testTimes = new DateTime[]
            {
                new DateTime(2019, 3, 4, 8, 0, 0), // morning rush
                new DateTime(2019, 3, 6, 11, 30, 0), // daytime
                new DateTime(2019, 3, 7, 17, 15, 0), // evening rush
                new DateTime(2019, 3, 14, 03, 30, 0), // overnight

                new DateTime(2019, 3, 16, 8, 30, 0), // weekend morning rush
                new DateTime(2019, 3, 17, 14, 30, 0), // weekend daytime
                new DateTime(2019, 3, 17, 18, 05, 0), // weekend evening rush
                new DateTime(2019, 3, 16, 01, 30, 0), // weekend overnight
            };

            Console.WriteLine("====================================================");
            foreach (var time in testTimes)
            {
                Console.WriteLine($"Inbound premium at {time} is {TollCalculator.PeakTimePremium(time, true)}");
                Console.WriteLine($"Outbound premium at {time} is {TollCalculator.PeakTimePremium(time, false)}");
            }
        }
    }
}
