using Narnia.Tolls;

namespace TollTests;

public class CalculatorTests
{
    [Theory]
    [ClassData(typeof(CalculatorTestData))]
    public void TestCalculationTuesdayMorningIn(CalculatorTestScenario scenario)
    {
        var result = TollCalculator.GetBillAmount(scenario.GantryReading);

        Assert.Equal(scenario.ExpectedResult, result);
    }
}

