using System;
using CommercialRegistration;
using ConsumerVehicleRegistration;
using LiveryRegistration;

namespace TollCollectorLib;


public static class TollCalculator
{
    private const decimal carBase = 2.00m;
    private const decimal taxiBase = 3.50m;
    private const decimal busBase = 5.00m;
    private const decimal deliveryTruckBase = 10.00m;

    public static decimal CalculateToll(object vehicle)
    {
        return vehicle switch
        {
            null => throw new ArgumentNullException(nameof(vehicle)),

            Car { Passengers: 0 } => carBase + 0.5m,
            Car { Passengers: 1 } => carBase,
            Car { Passengers: 2 } => carBase - 0.5m,
            Car => carBase - 1.00m,

            Taxi { Fares: 0 } => taxiBase + 01.0m,
            Taxi { Fares: 1 } => taxiBase,
            Taxi { Fares: 2 } => taxiBase - 0.5m,
            Taxi => taxiBase - 1.0m,

            Bus b when (double)b.Riders / b.Capacity < .5 => busBase + 2.0m,
            Bus b when (double)b.Riders / b.Capacity > .9 => busBase - 1.0m,
            Bus => busBase,

            DeliveryTruck t when t.GrossWeightClass > 5000 => deliveryTruckBase + 5.0m,
            DeliveryTruck t when t.GrossWeightClass < 3000 => deliveryTruckBase - 2.0m,
            DeliveryTruck => deliveryTruckBase,

            _ => throw new InvalidOperationException()
        };
    }


    public static decimal PeakTimePremium(DateTime timeOfToll, bool inbound)
        => (IsWeekDay(timeOfToll), GetTimeBand(timeOfToll), inbound) switch
        {
            (true, TimeBand.MorningRush, true) => 2.00m,
            (true, TimeBand.Daytime, _) => 1.5m,
            (true, TimeBand.EveningRush, false) => 2.00m,
            (true, TimeBand.Overnight, _) => .75m,
            _ => 1.00m,
        };

    private static bool IsWeekDay(DateTime timeOfToll)
        => timeOfToll.DayOfWeek switch
        {
            DayOfWeek.Saturday => false,
            DayOfWeek.Sunday => false,
            _ => true
        };

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
            < 6 or > 19 => TimeBand.Overnight,
            < 10 => TimeBand.MorningRush,
            < 16 => TimeBand.Daytime,
            < 20 => TimeBand.EveningRush,
        };

}
