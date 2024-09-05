using BudgetR.Simplified.Core.Enums;
using BudgetR.Simplified.Core.StateManagement;
using BudgetR.Simplified.Domain.Entities;
using BudgetR.Simplified.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BudgetR.Simplified.Services.Transactions;

public class TransactionService
{
    protected readonly BudgetRDbContext _dbContext;
    protected readonly ServerContext _serverContext;

    public TransactionService(BudgetRDbContext context, ServerContext serverContext)
    {
        _dbContext = context;
        _serverContext = serverContext;
    }

    public async Task ProcessTransactions(List<Transaction> transactions, long btaId)
    {
        foreach (var transaction in transactions)
        {
            transaction.UserId = _serverContext.UserId.Value;

            transaction.TransactionType ??= SetTransactionType(transaction.Amount, transaction.Description);

            var today = DateTime.Now;

            transaction.TransactionMonth = today.Month;
            transaction.TransactionYear = today.Year;

            transaction.BudgetMonthId = await _dbContext.BudgetMonths
                .Where(x => x.MonthYear.Month == transaction.TransactionMonth && x.MonthYear.Year == transaction.TransactionYear)
                .Select(x => x.BudgetMonthId)
                .FirstAsync();
        }

        await _dbContext.Transactions.AddRangeAsync(transactions);
        await _dbContext.SaveChangesAsync();
    }

    private TransactionType? SetTransactionType(decimal amount, string? description)
    {
        if (IsTransferRecord(description))
        {
            if (amount > 0)
            {
                return TransactionType.TransferIn;
            }
            else
            {
                return TransactionType.TransferOut;
            }
        }
        else if (amount > 0)
        {
            return TransactionType.Income;
        }
        else if (amount < 0)
        {
            return TransactionType.Expense;
        }

        throw new Exception("Transaction type could not be determined.");
    }

    private bool IsTransferRecord(string name)
    {
        name = name.ToLower();
        return name.Contains("transfer from") || name.Contains("transfer to") || name.Contains("payment from") || name.Contains("payment to");
    }
}
