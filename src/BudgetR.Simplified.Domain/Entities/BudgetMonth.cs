namespace BudgetR.Simplified.Server.Domain.Entities;
public class BudgetMonth
{
    [Key]
    [Column(Order = 0)]
    public long BudgetMonthId { get; set; }

    [Column(Order = 1)]
    public long MonthYearId { get; set; }
    public MonthYear? MonthYear { get; set; }

    [Column(Order = 2)]
    [Precision(19, 2)]
    public decimal Spent { get; set; }

    [Column(Order = 3)]
    [Precision(19, 2)]
    public decimal Earned { get; set; }

    [Column(Order = 4)]
    public long UserId { get; set; }
    public User? User { get; set; }
}
