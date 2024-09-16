using BudgetR.Simplified.Core.Enums;

namespace BudgetR.Simplified.Server.Domain.Entities;
public class User
{
    [Key]
    [Column(Order = 0)]
    public long UserId { get; set; }

    [Column(Order = 1)]
    public string? AuthenticationId { get; set; }

    [Column(Order = 2)]
    public string? Email { get; set; }

    [Column(Order = 3)]
    public string? FirstName { get; set; }

    [Column(Order = 4)]
    public string? LastName { get; set; }

    [Column(Order = 5)]
    public UserType UserType { get; set; }

    [Column(Order = 6)]
    public bool IsActive { get; set; }

    [Column(Order = 7)]
    public long? BusinessTransactionActivityId { get; set; }
    public BusinessTransactionActivity? BusinessTransactionActivity { get; set; }
}
