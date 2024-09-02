namespace BudgetR.Simplified.Client.Domain.Models;
public class BudgetMonth
{
    public long BudgetMonthId { get; set; }
    public long MonthYearId { get; set; }

    public int Month { get; set; }
    public int Year { get; set; }
    public bool IsActive { get; set; }

    public int NumberOfDays { get; set; }

    public DateOnly EndOfMonth => new(Year, Month, NumberOfDays);
    public string GetMonthName() => new DateTime(Year, Month, 1).ToString("MMMM");
}
