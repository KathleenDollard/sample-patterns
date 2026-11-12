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
        var readings = GetEmptyReadings();

        (string description, DateTime time) = ("Tuesday morning", Find(DayOfWeek.Tuesday, 8, 15));

        Add(new CalculatorTestScenario(description,
                                       readings.CarReading with
                                       {
                                           TimeOfPassing = time,
                                           Direction = TravelDirectionAtGantry.WestOrSouth
                                       },
             3));

        Add(new CalculatorTestScenario(description,
                                       readings.TaxiReading with
                                       {
                                           TimeOfPassing = time,
                                           Direction = TravelDirectionAtGantry.WestOrSouth
                                       },
             7));

        Add(new CalculatorTestScenario(description,
             readings.BusReading with
             {
                 TimeOfPassing = time,
                 Direction = TravelDirectionAtGantry.WestOrSouth
             },
             14));

        Add(new CalculatorTestScenario(description,
             readings.TruckReading with
             {
                 TimeOfPassing = time,
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
    }

    private static (TollGantryReading CarReading,
                    TollGantryReading TaxiReading,
                    TollGantryReading BusReading,
                    TollGantryReading TruckReading)
               GetEmptyReadings()
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

