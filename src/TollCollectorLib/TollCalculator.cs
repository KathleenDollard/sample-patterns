using System;
using System.Runtime.Intrinsics.Arm;
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

        public static decimal GetBillAmount(object vehicle, DateTime timeOfToll, bool inbound) 
            => CalculateToll(vehicle) * PeakTimePremium(timeOfToll, inbound);

        public static decimal CalculateToll(object vehicle)
        {
            if (vehicle == null)
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

            var t = vehicle as Taxi;
            if (t != null)
            {
                if (t.Fares == 0)
                {
                    return taxiBase + 1.0m; ;
                }
                if (t.Fares == 1)
                {
                    return taxiBase;
                }
                if (t.Fares == 2)
                {
                    return taxiBase - 0.50m; ;
                }
                else
                {
                    return taxiBase - 1.0m; ;
                }
            }

            var b = vehicle as Bus;
            if (b != null)
            {
                if (((double)b.Riders / b.Capacity) < 0.50)
                {
                    return busBase + 2.00m;
                }
                if (((double)b.Riders / b.Capacity) > 0.90)
                {
                    return busBase - 1.00m;
                }
                else
                {
                    return busBase; ;
                }
            }

            var tr = vehicle as DeliveryTruck;
            if (tr != null)
            {
                if (tr.GrossWeightClass > 5000)
                {
                    return deliveryTruckBase + 5.00m;
                }
                if (tr.GrossWeightClass < 3000)
                {
                    return deliveryTruckBase - 2.00m;
                }
                else
                {
                    return deliveryTruckBase;
                }
            }
            return int.MinValue;
        }


        public static decimal PeakTimePremium(DateTime timeOfToll, bool inbound)
        {
            if (IsWeekDay(timeOfToll))
            {
                if (GetTimeBand(timeOfToll) == TimeBand.MorningRush)
                {
                    if (inbound)
                    {
                        return 2.00m;
                    }
                    else
                    {
                        return 1.00m;
                    }
                }
                if (GetTimeBand(timeOfToll) == TimeBand.Daytime)
                {
                    return 1.50m;
                }
                if (GetTimeBand(timeOfToll) == TimeBand.EveningRush)
                {
                    if (!inbound)
                    {
                        return 2.00m;
                    }
                    else
                    {
                        return 1.00m;
                    }
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


// Final code to speed things up in talk 
//public static decimal CalculateToll(object vehicle)
//=> vehicle switch
//{
//    Car { Passengers: 0 } => carBase + 0.5m,
//    Car { Passengers: 1 } => carBase,
//    Car { Passengers: 2 } => carBase - 0.5m,
//    Car => carBase - 1.0m,

//    Taxi { Fares: 0 } => taxiBase + 0.5m,
//    Taxi { Fares: 1 } => taxiBase,
//    Taxi { Fares: 2 } => taxiBase - 0.5m,
//    Taxi => taxiBase - 1.0m,

//    Bus b when ((double)b.Riders / (double)b.Capacity) < 0.50 => busBase + 2.00m,
//    Bus b when ((double)b.Riders / (double)b.Capacity) > 0.90 => busBase - 1.00m,
//    Bus => busBase,

//    DeliveryTruck { GrossWeightClass: > 5000, } => deliveryTruckBase + 5.00m,
//    DeliveryTruck { GrossWeightClass: < 3000 } => deliveryTruckBase - 2.00m,
//    DeliveryTruck => deliveryTruckBase,

//    null or { } => throw new ArgumentNullException(nameof(vehicle))
//};



//public static decimal PeakTimePremium(DateTime timeOfToll, bool inbound)
//=> (IsWeekDay(timeOfToll), GetTimeBand(timeOfToll), inbound) switch
//{
//    (true, TimeBand.MorningRush, true) => 2.00m,
//    (true, TimeBand.MorningRush, false) => 1.00m,
//    (true, TimeBand.Daytime, true) => 1.50m,
//    (true, TimeBand.Daytime, false) => 1.50m,
//    (true, TimeBand.EveningRush, true) => 1.00m,
//    (true, TimeBand.EveningRush, false) => 2.00m,
//    (true, TimeBand.Overnight, true) => 0.75m,
//    (true, TimeBand.Overnight, false) => 0.75m,

//    (false, _, _) => 1.00m,

//    _ => throw new ArgumentException("Bad time band", "timeBand")
//};