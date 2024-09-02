using System.ComponentModel.DataAnnotations.Schema;

namespace BudgetR.Simplified.Client.Domain.Models;
public class MonthYear
{
    [Column(Order = 0)]
    public long MonthYearId { get; set; }

    [Column(Order = 1)]
    public int Month { get; set; }
    [Column(Order = 2)]
    public int Year { get; set; }
    [Column(Order = 3)]
    public bool IsActive { get; set; }

    [Column(Order = 4)]
    public int NumberOfDays { get; set; }

    public DateOnly EndOfMonth => new(Year, Month, NumberOfDays);
    public string GetMonthName() => new DateTime(Year, Month, 1).ToString("MMMM");
}
