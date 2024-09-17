using BudgetR.Simplified.Server.Infrastructure.Data;

namespace BudgetR.Simplified.Server.Transactions.File;
public class FileLoader
{
    private readonly BudgetRDbContext _context;

    public FileLoader(BudgetRDbContext context)
    {
        _context = context;
    }

    public async Task LoadTransactionsAsync()
    {
        //var transactions = await ReadTransactionsFromFileAsync(filePath);
        //await SaveTransactionsAsync(transactions);
    }
}