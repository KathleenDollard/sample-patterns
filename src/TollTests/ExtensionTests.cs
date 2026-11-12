namespace TollTests;

public class ExtensionTests
{
    [Theory]
    [ClassData(typeof(ExtensionTestData))]
    public void TestGetPreviousOrThisSunday(DateOnly seedDate, DateOnly expected)
    {
        var result = seedDate.GetPreviousSunday();
        Assert.Equal(expected, result);
    }
}

public class ExtensionTestData
    : TheoryData<DateOnly, DateOnly>
{
    public ExtensionTestData()
    {
        Add(new DateOnly(2026, 05, 15), new DateOnly(2026, 05, 10));
        Add(new DateOnly(2026, 05, 17), new DateOnly(2026, 05, 10));
    }

}
