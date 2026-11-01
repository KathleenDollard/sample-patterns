using CommercialRegistration;
using ConsumerVehicleRegistration;
using LiveryRegistration;
using TollCollectorLib;

namespace TollTests;

[Serializable]
public record class CalculatorTestScenario(string TimeDescription,
                                            TollGantryReading GantryReading,
                                            decimal ExpectedResult)
{
    public override string ToString()
    {
        return $"{TimeDescription}: {GantryReading}";
    }
}

[Serializable]

public class CalculatorTestData
    : TheoryData<CalculatorTestScenario>
{
    public CalculatorTestData()
    {
        var (carReading, taxiReading, busReading, deliveryTruckReading) = GetEmptyReadings();

        (string description, DateTime time) tuesdayMorning = ("Tuesday morning", Find(DayOfWeek.Tuesday, 8, 15));

        Add(new CalculatorTestScenario(tuesdayMorning.description, 
                                       carReading with
                                       {
                 TimeOfPassing = tuesdayMorning.time,
                 Direction = TravelDirectionAtGantry.WestOrSouth
             }, 
             3));

        Add(new CalculatorTestScenario(tuesdayMorning.description,
             taxiReading with
             {
                 TimeOfPassing = tuesdayMorning.time,
                 Direction = TravelDirectionAtGantry.WestOrSouth
             },
             7));

        Add(new CalculatorTestScenario(tuesdayMorning.description,
             busReading with
             {
                 TimeOfPassing = tuesdayMorning.time,
                 Direction = TravelDirectionAtGantry.WestOrSouth
             },
             14));

        Add(new CalculatorTestScenario(tuesdayMorning.description,
             deliveryTruckReading with
             {
                 TimeOfPassing = tuesdayMorning.time,
                 Direction = TravelDirectionAtGantry.WestOrSouth
             },
             16));

        static DateTime Find(DayOfWeek day, int hour, int minute)
        {
            var now = DateTime.Now;
            var daysUntilNext = ((int)day - (int)now.DayOfWeek + 7) % 7;
            var nextDay = now.AddDays(daysUntilNext);
            return new DateTime(nextDay.Year, nextDay.Month, nextDay.Day, hour, minute, 0);
        }

        //Add(new CarGantryReading(new Car(),
        //                         DateTime.MinValue,
        //                         0,
        //                         2),
        //                         (morningIn: 3, weekend: 0, overnight: 0, midday: 0));
        //Add(new TaxiGantryReading
        //{
        //    Vehicle = new Taxi(),
        //    TimeOfPassing = DateTime.MinValue,
        //    Direction = 0,
        //    Fares = 2
        //}, (morningIn: 7, weekend: 0, overnight: 0, midday: 0));
        //Add(new BusGantryReading
        //{
        //    Bus = new Bus(50),
        //    Riders = 3
        //}, (morningIn: 14, weekend: 0, overnight: 0, midday: 0));
        //Add(new DeliveryTruckGantryReading(1), (morningIn: 16, weekend: 0, overnight: 0, midday: 0));
    }

    private static (TollGantryReading, TollGantryReading, TollGantryReading, TollGantryReading) GetEmptyReadings()
    {
        return (new CarGantryReading(new Car(),
                                     DateTime.MinValue,
                                     0,
                                     2),
                new TaxiGantryReading
                {
                    Taxi = new Taxi(),
                    TimeOfPassing = DateTime.MinValue,
                    Direction = 0,
                    Fares = 1
                },
               new BusGantryReading
                {
                    Bus = new Bus(50),
                    TimeOfPassing = DateTime.MinValue,
                    Direction = 0,
                    Riders = 3
                },
                new DeliveryTruckGantryReading
                {
                    DeliveryTruck = new DeliveryTruck(1),
                    Direction = 0,
                    TimeOfPassing = DateTime.MinValue,
                    GrossWeightClass = 1
                });
    }

}

