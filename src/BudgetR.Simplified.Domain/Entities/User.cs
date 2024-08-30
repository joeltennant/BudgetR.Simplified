using BudgetR.Simplified.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace BudgetR.Simplified.Domain.Entities;
public class User
{
    [Key]
    [Column(Order = 0)]
    public long UserId { get; set; }

    [Column(Order = 1)]
    public string? AuthenticationId { get; set; }

    [Column(Order = 2)]
    public string? FirstName { get; set; }

    [Column(Order = 3)]
    public string? LastName { get; set; }

    [Column(Order = 4)]
    public UserType UserType { get; set; }

    [Column(Order = 5)]
    public bool IsActive { get; set; }

    [Column(Order = 6)]
    public long? BusinessTransactionActivityId { get; set; }
    public BusinessTransactionActivity? BusinessTransactionActivity { get; set; }
}
