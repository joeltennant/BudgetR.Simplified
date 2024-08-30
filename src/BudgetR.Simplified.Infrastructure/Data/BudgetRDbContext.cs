using BudgetR.Simplified.Domain.Entities;
using Microsoft.EntityFrameworkCore.Storage;
using System.Reflection;

namespace BudgetR.Simplified.Infrastructure.Data;
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
        if (!IsTestMode)
        {
            if (transaction is null)
            {
                return await Database.BeginTransactionAsync();
            }
            else
            {
                return transaction;
            }
        }
        else
        {
            return null;
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
