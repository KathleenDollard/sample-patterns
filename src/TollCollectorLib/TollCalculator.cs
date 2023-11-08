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

        public static decimal CalculateToll(object vehicle)
        => vehicle switch
        {
            Car { Passengers: 0 } => carBase + 0.5m,
            Car { Passengers: 1 } => carBase,
            Car { Passengers: 2 } => carBase - 0.5m,
            Car => carBase - 1.0m,

            Taxi { Fares: 0 } => taxiBase + 0.5m,
            Taxi { Fares: 1 } => taxiBase,
            Taxi { Fares: 2 } => taxiBase - 0.5m,
            Taxi => taxiBase - 1.0m,

            Bus b when ((double)b.Riders / (double)b.Capacity) < 0.50 => busBase + 2.00m,
            Bus b when ((double)b.Riders / (double)b.Capacity) > 0.90 => busBase - 1.00m,
            Bus => busBase,

            DeliveryTruck { GrossWeightClass: > 5000, } => deliveryTruckBase + 5.00m,
            DeliveryTruck { GrossWeightClass: < 3000 } => deliveryTruckBase - 2.00m,
            DeliveryTruck => deliveryTruckBase,

            null or { } => throw new ArgumentNullException(nameof(vehicle))
        };


        public static decimal PeakTimePremium(DateTime timeOfToll, bool inbound)
        => (IsWeekDay(timeOfToll), GetTimeBand(timeOfToll), inbound) switch
        {
            (true, TimeBand.MorningRush, true) => 2.00m,
            (true, TimeBand.MorningRush, false) => 1.00m,
            (true, TimeBand.Daytime, true) => 1.50m,
            (true, TimeBand.Daytime, false) => 1.50m,
            (true, TimeBand.EveningRush, true) => 1.00m,
            (true, TimeBand.EveningRush, false) => 2.00m,
            (true, TimeBand.Overnight, true) => 0.75m,
            (true, TimeBand.Overnight, false) => 0.75m,

            (false, _, _) => 1.00m,

            _ => throw new ArgumentException("Bad time band", "timeBand")
        };

        private static bool IsWeekDay(DateTime timeOfToll)
        {
            return timeOfToll.DayOfWeek switch
            {
                DayOfWeek.Saturday or DayOfWeek.Sunday => false,
                _ => true,
            };
            ;
        }

        private enum TimeBand
        {
            MorningRush,
            Daytime,
            EveningRush,
            Overnight
        }

        private static TimeBand GetTimeBand(DateTime timeOfToll)
        => timeOfToll.Hour switch
        {
            < 6 => TimeBand.Overnight,
            < 10 => TimeBand.MorningRush,
            < 16 => TimeBand.Daytime,
            < 20 => TimeBand.EveningRush,
            _ => TimeBand.Overnight
        };



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