using System;
using CommercialRegistration;
using ConsumerVehicleRegistration;
using LiveryRegistration;

namespace TollCollectorLib

{
    public static class TollCalculator
    {
        private const decimal carBase = 2.00m;
        private const decimal taxiBase = 3.50m;
        private const decimal busBase = 5.00m;
        private const decimal deliveryTruckBase = 10.00m;

        public static decimal CalculateToll6(object vehicle)
        {
            if (vehicle is null)
            {
                throw new ArgumentNullException(nameof(vehicle));
            }
            var c = vehicle as Car;
            if (c != null)
            {
                if (c.Passengers == 0)
                {
                    return carBase + 0.5m;
                }
                if (c.Passengers == 1)
                {
                    return carBase;
                }
                if (c.Passengers == 2)
                {
                    return carBase - 0.5m;
                }
                return carBase - 1.00m;
            }
            else
            {
                //
                // I am going to go be a truckstop waitress now, I just can't
                // do them all
                //
                return int.MinValue;
            }

        }

        public static decimal CalculateToll(object vehicle)
        {
            if (vehicle is null)
            {
                throw new ArgumentNullException(nameof(vehicle));
            }
            switch (vehicle)
            {
                case Car c when c.Passengers == 0:
                    return carBase + 0.5m;
                case Car c when c.Passengers == 1:
                    return carBase;
                case Car c when c.Passengers == 2:
                    return carBase - 0.50m;
                case Car c:
                    return carBase - 1.00m;

                case Taxi t when t.Fares == 0:
                    return taxiBase + 1.0m;
                case Taxi t when t.Fares == 1:
                    return taxiBase;
                case Taxi t when t.Fares == 2:
                    return taxiBase - 0.50m;
                case Taxi t:
                    return taxiBase - 1.00m;

                case Bus b when ((double)b.Riders / b.Capacity) < 0.50:
                    return busBase + 2.00m;
                case Bus b when ((double)b.Riders / b.Capacity) > 0.90:
                    return busBase - 1.00m;
                case Bus b:
                    return busBase;

                case DeliveryTruck t when t.GrossWeightClass > 5000:
                    return deliveryTruckBase + 5.00m;
                case DeliveryTruck t when t.GrossWeightClass < 3000:
                    return deliveryTruckBase - 2.00m;
                case DeliveryTruck t:
                    return deliveryTruckBase;

                default:
                    throw new ArgumentException(message: "Not a known vehicle type", paramName: nameof(vehicle));
            };
        }

        public static decimal PeakTimePremium(DateTime timeOfToll, bool inbound)
        {
            if (IsWeekDay(timeOfToll))
            {
                if (GetTimeBand(timeOfToll) == TimeBand.MorningRush)
                {
                    return inbound ? 2.00m : 1.00m;
                }
                if (GetTimeBand(timeOfToll) == TimeBand.Daytime)
                {
                    return 1.50m;
                }
                if (GetTimeBand(timeOfToll) == TimeBand.EveningRush)
                {
                    return !inbound ? 2.00m : 1.00m;
                }
                if (GetTimeBand(timeOfToll) == TimeBand.Overnight)
                {
                    return 0.75m;
                }
            }
            return 1.00m;

        }

        private static bool IsWeekDay(DateTime timeOfToll)
        {
            switch (timeOfToll.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    return true;
                case DayOfWeek.Tuesday:
                    return true;
                case DayOfWeek.Wednesday:
                    return true;
                case DayOfWeek.Thursday:
                    return true;
                case DayOfWeek.Friday:
                    return true;
                case DayOfWeek.Saturday:
                    return false;
                case DayOfWeek.Sunday:
                    return false;
                default:
                    return true;
            };
        }

        private enum TimeBand
        {
            MorningRush,
            Daytime,
            EveningRush,
            Overnight
        }

        private static TimeBand GetTimeBand(DateTime timeOfToll)
        {
            var hour = timeOfToll.Hour;
            if (hour < 6)
            {
                return TimeBand.Overnight;
            }
            else if (hour < 10)
            {
                return TimeBand.MorningRush;
            }
            else if (hour < 16)
            {
                return TimeBand.Daytime;
            }
            else if (hour < 20)
            {
                return TimeBand.EveningRush;
            }
            else
            {
                return TimeBand.Overnight;
            }
        }

    }
}
