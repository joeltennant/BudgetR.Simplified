using Microsoft.EntityFrameworkCore;

namespace BudgetR.Simplified.Server.Application.Handlers.MonthYears;
public class RetrieveMonths
{
    public record Request() : IRequest<Result<List<MonthYearDto>>>;

    public record MonthYearDto(long BudgetMonthId, long MonthYearId, int Month, int Year, bool IsActive, int NumberOfDays);

    public class Handler : BaseHandler, IRequestHandler<Request, Result<List<MonthYearDto>>>
    {
        public Handler(BudgetRDbContext context, ServerContext serverContext)
            : base(context, serverContext)
        {
        }

        public async Task<Result<List<MonthYearDto>>> Handle(Request request, CancellationToken cancellationToken)
        {
            var inactivatePastMonths = new InactivatePastMonthsService(_dbContext).Execute();

            List<MonthYearDto> months = new();
            long? userId = _serverContext.UserId;

            var pastMonths = await _dbContext.BudgetMonths
                .Where(x => x.UserId == userId && !x.MonthYear.IsActive)
                .OrderByDescending(x => x.MonthYear.Year)
                    .ThenBy(x => x.MonthYear.Month)
                .Take(36)
                .Select(x => new MonthYearDto
                (
                    x.BudgetMonthId
                    , x.MonthYearId
                    , x.MonthYear.Month
                    , x.MonthYear.Year
                    , x.MonthYear.IsActive
                    , x.MonthYear.NumberOfDays
                 ))
                .ToListAsync();

            var futureMonths = await _dbContext.BudgetMonths
               .Where(x => x.UserId == userId && x.MonthYear.IsActive)
                .OrderBy(x => x.MonthYear.Year)
                    .ThenBy(x => x.MonthYear.Month)
                .Take(36)
                .Select(x => new MonthYearDto
                (
                    x.BudgetMonthId
                    , x.MonthYearId
                    , x.MonthYear.Month
                    , x.MonthYear.Year
                    , x.MonthYear.IsActive
                    , x.MonthYear.NumberOfDays
                 ))
                .ToListAsync();

            months.AddRange(pastMonths);
            months.AddRange(futureMonths);

            return Result.Success(months);
        }
    }
}
