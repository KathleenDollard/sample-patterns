﻿using CommercialRegistration;
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
            var soloDriver = new Car(passengers: 0);
            var twoRideShare = new Car(passengers: 1);
            var threeRideShare = new Car(passengers: 2);
            var fullVan = new Car(passengers: 5);
            var emptyTaxi = new Taxi(fares: 0);
            var singleFare = new Taxi(fares: 1);
            var doubleFare = new Taxi(fares: 2);
            var fullVanPool = new Taxi(fares: 5);
            var lowOccupantBus = new Bus(capacity: 90, riders: 15);
            var normalBus = new Bus(capacity: 90, riders: 75);
            var fullBus = new Bus(capacity: 90, riders: 85);

            var heavyTruck = new DeliveryTruck(grossWeightClass: 7500);
            var truck = new DeliveryTruck(grossWeightClass: 4000);
            var lightTruck = new DeliveryTruck(grossWeightClass: 2500);

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

            Console.WriteLine("Testing the time premiums");

            var testTimes = new DateTime[]
            {
                new DateTime(2021, 11, 4, 8, 0, 0), // morning rush
                new DateTime(2021, 11, 6, 11, 30, 0), // daytime
                new DateTime(2021, 11, 7, 17, 15, 0), // evening rush
                new DateTime(2021, 11, 14, 03, 30, 0), // overnight
                                   
                new DateTime(2021, 11, 16, 8, 30, 0), // weekend morning rush
                new DateTime(2021, 11, 17, 14, 30, 0), // weekend daytime
                new DateTime(2021, 11, 17, 18, 05, 0), // weekend evening rush
                new DateTime(2021, 11, 16, 01, 30, 0), // weekend overnight
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
