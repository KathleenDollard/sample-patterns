namespace TollCollectorLib;

public static class TollCalculator
{
    private const decimal carBase = 2.00m;
    private const decimal taxiBase = 3.50m;
    private const decimal busBase = 5.00m;
    private const decimal deliveryTruckBase = 10.00m;

    public static decimal GetBillAmount(TollGantryReading gantryReading)
        => CalculateToll(gantryReading) *
           PeakTimePremium(gantryReading.TimeOfPassing,
                           gantryReading.Direction==TravelDirectionAtGantry.WestOrSouth);

    private static decimal CalculateToll(TollGantryReading gantryReading)
    {

        if (gantryReading == null)
        {
            throw new ArgumentNullException(nameof(gantryReading));
        }
        if (gantryReading.Vehicle is CarGantryReading c)
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

        if (gantryReading.Vehicle is TaxiGantryReading t)
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

        if (gantryReading.Vehicle is BusGantryReading b)
        {
            if (((double)b.Riders / ((Bus)b.Vehicle).Capacity) < 0.50)
            {
                return busBase + 2.00m;
            }
            if (((double)b.Riders / ((Bus)b.Vehicle).Capacity) > 0.90)
            {
                return busBase - 1.00m;
            }
            else
            {
                return busBase; ;
            }
        }

        if (gantryReading.Vehicle is DeliveryTruckGantryReading tr)
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

    private static decimal PeakTimePremium(DateTime timeOfToll, bool inbound)
    {
        decimal retValue = 0;
        var isWeekDay = IsWeekDay(timeOfToll);
        var timeBand = GetTimeBand(timeOfToll);
        if (isWeekDay)
        {
            if (timeBand == TimeBand.MorningRush)
            {
                if (inbound)
                {
                    retValue = 2.00m;
                }
                else
                {
                    retValue = 1.00m;
                }
            }
            if (timeBand == TimeBand.Daytime)
            {
                retValue = 1.50m;
            }
            if (timeBand == TimeBand.EveningRush)
            {
                if (!inbound)
                {
                    retValue = 2.00m;
                }
                else
                {
                    retValue = 1.00m;
                }
            }
            if (timeBand == TimeBand.Overnight)
            {
                retValue = 0.75m;
            }
        }
        else
        {
            retValue = 1.00m;
        }
        return retValue;
    }

    private static bool IsWeekDay(DateTime timeOfToll)
    {
        bool isWeekDay;
        switch (timeOfToll.DayOfWeek)
        {
            case DayOfWeek.Monday:
                isWeekDay = true;
                break;
            case DayOfWeek.Tuesday:
                isWeekDay = true;
                break;
            case DayOfWeek.Wednesday:
                isWeekDay = true;
                break;
            case DayOfWeek.Thursday:
                isWeekDay = true;
                break;
            case DayOfWeek.Friday:
                isWeekDay = true;
                break;
            case DayOfWeek.Saturday:
                isWeekDay = false;
                break;
            case DayOfWeek.Sunday:
                isWeekDay = false;
                break;
            default:
                isWeekDay = true;
                break;
        }
        ;
        return isWeekDay;
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

    #region  Secret stash
    private readonly union DayType(DayType.WeekDay, DayType.Weekend)
    {
        internal record struct WeekDay;
        internal record struct Weekend;
    }

    internal readonly union VehicleType(Car, Taxi, Bus, DeliveryTruck);
    #endregion
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