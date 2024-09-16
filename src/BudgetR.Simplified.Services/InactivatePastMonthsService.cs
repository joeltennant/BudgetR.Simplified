using BudgetR.Simplified.Core;
using BudgetR.Simplified.Server.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BudgetR.Simplified.Server.Services;

public class InactivatePastMonthsService
{
    protected readonly BudgetRDbContext _context;

    public InactivatePastMonthsService(BudgetRDbContext context)
    {
        _context = context;
    }

    public async Task Execute()
    {
        try
        {
            var today = DateOnly.FromDateTime(DateTime.Now);
            IList<long> budgetMonthIds = new List<long>();

            var monthYears = _context.MonthYears
                .Where(x => x.IsActive)
                .OrderBy(x => x.Year)
                    .ThenBy(x => x.Month)
                .Take(36)
                .ToList();

            List<long> pastMonthYears = new();

            foreach (var monthYear in monthYears)
            {
                if (new DateOnly(monthYear.Year, monthYear.Month, monthYear.NumberOfDays) < today)
                {
                    pastMonthYears.Add(monthYear.MonthYearId);
                }
            }

            if (!pastMonthYears.IsPopulated())
            {
                return;
            }

            await _context.MonthYears
                .Where(x => pastMonthYears.Contains(x.MonthYearId))
                .ExecuteUpdateAsync(a => a.SetProperty(p => p.IsActive, false));

            //budgetMonthIds = _context.BudgetMonths
            //    .Where(x => pastMonthYears.Contains(x.MonthYearId))
            //    .Select(x => x.BudgetMonthId)
            //    .ToList();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }
}
