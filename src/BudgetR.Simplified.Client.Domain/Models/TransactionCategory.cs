﻿namespace BudgetR.Simplified.Client.Domain.Models;
public class TransactionCategory
{
    public long TransactionCategoryId { get; set; }
    public string CategoryName { get; set; }
    public DateTime ModifiedAt { get; set; }
    public DateTime CreatedAt { get; set; }
}
