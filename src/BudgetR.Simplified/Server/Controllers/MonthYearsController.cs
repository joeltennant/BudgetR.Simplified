
using BudgetR.Simplified.Application.Handlers.MonthYears;

namespace BudgetR.Simplified.Controllers;

public class MonthYearsController : BaseController
{
    public MonthYearsController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet]
    [Route("retrieveMonths")]
    [TranslateResultToActionResult]
    public async Task<Result<List<RetrieveMonths.MonthYearDto>>> RetrieveMonths()
    {
        return await _mediator.Send(new RetrieveMonths.Request());
    }
}
