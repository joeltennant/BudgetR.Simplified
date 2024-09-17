using Microsoft.EntityFrameworkCore.Storage;
using System.Reflection;

namespace BudgetR.Simplified.Server.Infrastructure.Data;
public class BudgetRDbContext : DbContext
{
    public BudgetRDbContext()
    {
    }

    public BudgetRDbContext(DbContextOptions<BudgetRDbContext> options) : base(options)
    {
    }

    public bool IsTestMode { get; set; } = false;

    public DbSet<User> Users { get; set; }
    public DbSet<BusinessTransactionActivity> BusinessTransactionActivities { get; set; }
    public DbSet<MonthYear> MonthYears { get; set; }
    public DbSet<BudgetMonth> BudgetMonths { get; set; }
    public DbSet<TransactionCategory> TransactionCategories { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<TransactionBatch> TransactionBatches { get; set; }
    public DbSet<UserParameter> UserParameters { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            entityType.GetForeignKeys()
                      .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade)
                      .ToList()
                      .ForEach(fk => fk.DeleteBehavior = DeleteBehavior.Restrict);
        }
    }

    public async Task<IDbContextTransaction?> BeginTransactionContext()
    {
        IDbContextTransaction? transaction = Database.CurrentTransaction;
        if (transaction is null)
        {
            return await Database.BeginTransactionAsync();
        }
        else
        {
            return transaction;
        }
    }

    public async Task CommitTransactionContext(IDbContextTransaction? transaction)
    {
        if (transaction is not null)
        {
            await transaction.CommitAsync();
        }
    }
}
