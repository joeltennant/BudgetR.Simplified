using BudgetR.Simplified.Domain.Entities;
using Microsoft.EntityFrameworkCore.Storage;

namespace BudgetR.Simplified.Application;
public abstract class BaseHandler
{
    protected readonly BudgetRDbContext _dbContext;
    protected readonly ServerContext _serverContext;
    protected IDbContextTransaction? transaction;

    protected BaseHandler(BudgetRDbContext dbContext, ServerContext ServerContext)
    {
        _dbContext = dbContext;
        _serverContext = ServerContext;
    }

    protected async Task<long> CreateBta()
    {
        long userId = _serverContext.UserId.HasValue
            ? _serverContext.UserId.Value
            : 1;

        var bta = new BusinessTransactionActivity
        {
            ProcessName = _serverContext.ProcessName,
            UserId = userId,
            CreatedAt = DateTime.UtcNow
        };

        await _dbContext.BusinessTransactionActivities.AddAsync(bta);
        await _dbContext.SaveChangesAsync();

        _serverContext.BtaId = bta.BusinessTransactionActivityId;

        return bta.BusinessTransactionActivityId;
    }
}
