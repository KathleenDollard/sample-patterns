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

        public static decimal CalculateToll(object vehicle)
        {
            return vehicle switch
            {
                null => throw new ArgumentNullException(nameof(vehicle)),

                Car c => c.Passengers switch 
                {
                    0 => carBase + 0.5m,
                    1 => carBase ,
                    2 => carBase - 0.5m,
                    _ => carBase - 1m,

                },

                Taxi { Fares: 0 } => taxiBase + 1m,
                Taxi { Fares: 1 } => taxiBase,
                Taxi { Fares: 2 } => taxiBase - 0.5m,
                Taxi => carBase - 1m,

                Bus(var capacity, var riders) when ((double)riders / capacity) < 0.5 => busBase + 2.0m,
                Bus(var capacity, var riders) when ((double)riders / capacity) > 0.5 => busBase - 1.0m,
                Bus => busBase,

                DeliveryTruck tr =>  tr.GrossWeightClass switch 
                { 
                    > 5000 => deliveryTruckBase + 5.00m,
                    < 3000 => deliveryTruckBase - 2.00m,
                    _ => deliveryTruckBase,
                },
                _ => throw new ArgumentException("Not a known vehicle type", paramName: nameof(vehicle))
            };
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
            => timeOfToll.DayOfWeek switch
            {
                DayOfWeek.Monday => true,
                DayOfWeek.Tuesday => true,
                DayOfWeek.Wednesday => true,
                DayOfWeek.Thursday => true,
                DayOfWeek.Friday => true,
                DayOfWeek.Saturday => false,
                DayOfWeek.Sunday => false,
                _ => true,
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
                    < 6 => TimeBand.Overnight,
                    < 10 => TimeBand.MorningRush,
                    < 16 => TimeBand.Daytime,
                    < 20 => TimeBand.EveningRush,
                    _ => TimeBand.Overnight
                };

    }
}
