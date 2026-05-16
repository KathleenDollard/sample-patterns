public static class DateExtensions
{
    public static DateOnly GetDayOfWeek(this DateOnly seedDate, DayOfWeek targetDay)
        => seedDate.GetPreviousSunday().AddDays((int)targetDay - (int)DayOfWeek.Sunday);

    public static DateOnly GetPreviousSunday(this DateOnly seedDate)
        => seedDate.DayOfWeek == DayOfWeek.Sunday
            ? seedDate.AddDays(-7)
            : seedDate.AddDays((int)DayOfWeek.Sunday - (int)seedDate.DayOfWeek);
}