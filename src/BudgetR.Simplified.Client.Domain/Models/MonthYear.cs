using System.Text.Json.Serialization;

namespace BudgetR.Simplified.Client.Domain.Models;
public class MonthYear
{
    public long BudgetMonthId { get; set; }
    public long MonthYearId { get; set; }

    public int Month { get; set; }
    public int Year { get; set; }
    public bool IsActive { get; set; }

    public int NumberOfDays { get; set; }

    [JsonIgnore]
    public DateOnly EndOfMonth => new(Year, Month, NumberOfDays);

    public string GetMonthName() => new DateTime(Year, Month, 1).ToString("MMMM");
}
