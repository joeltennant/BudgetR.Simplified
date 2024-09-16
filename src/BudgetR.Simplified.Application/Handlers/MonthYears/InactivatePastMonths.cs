namespace BudgetR.Simplified.Server.Application.Handlers.MonthYears;
public class InactivatePastMonths
{
    public class Request : IRequest<Result<NoValue>>;

    public class Handler : BaseHandler, IRequestHandler<Request, Result<NoValue>>
    {
        public Handler(BudgetRDbContext context, ServerContext serverContext)
            : base(context, serverContext)
        {
        }

        public async Task<Result<NoValue>> Handle(Request request, CancellationToken cancellationToken)
        {
            transaction = await _dbContext.BeginTransactionContext();

            var inactivatePastMonths = new InactivatePastMonthsService(_dbContext).Execute();

            await _dbContext.CommitTransactionContext(transaction);

            return Result.Success();
        }
    }
}
