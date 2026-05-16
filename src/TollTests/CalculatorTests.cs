using CommercialRegistration;
using ConsumerVehicleRegistration;
using LiveryRegistration;
using TollCollectorLib;

namespace TollTests;

public class CalculatorTests
{
    [Theory]
    [ClassData(typeof(CalculatorTestData))]
    public void TestCalculationTuesdayMorningIn(object vehicle,
        (decimal, decimal, decimal, decimal) tuple)

    {
        var (morningIn, _, _, _) = tuple;
        var weekDay = GetDayOfWeek(DayOfWeek.Tuesday,
                                   8,
                                   15,
                                   DateOnly.FromDateTime(DateTime.Now.AddDays(21)));

        var result = TollCalculator.GetBillAmount(vehicle, weekDay, true);

        Assert.Equal(morningIn, result);
    }
    private static DateTime GetDayOfWeek(DayOfWeek targetDay,
                                         int hourOfDay,
                                         int minutes,
                                         DateOnly seedDate)
    {
        for (var i = 0; i < 7;i++)
        {
            var testDay = seedDate.AddDays(i);
            if (testDay.DayOfWeek == targetDay)
            {
                return testDay.ToDateTime(new TimeOnly(hourOfDay, minutes));
            }
        }
        return DateTime.MinValue;
    }
}

[Serializable]

public class CalculatorTestData
    : TheoryData<object, (decimal morningIn, decimal weekend, decimal overnight, decimal midday)>
{
    public CalculatorTestData()
    {
        Add(new Car(2), (morningIn: 3, weekend: 0, overnight: 0, midday: 0));
        Add(new Taxi(1), (morningIn: 7, weekend: 0, overnight: 0, midday: 0));
        Add(new Bus(50, 3), (morningIn: 14, weekend: 0, overnight: 0, midday: 0));
        Add(new DeliveryTruck(1), (morningIn: 16, weekend: 0, overnight: 0, midday: 0));
    }

}

