using static BudgetR.Simplified.Application.Handlers.MonthYears.RetrieveMonths;

namespace BudgetR.Simplified.Controllers;

public class MonthYearsController : BaseController
{
    public MonthYearsController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet]
    [Route("retrieveMonths")]
    [TranslateResultToActionResult]
    public async Task<Result<Result<List<MonthYearDto>>>> RetrieveMonths()
    {
        return await _mediator.Send(new Request());
    }
}
