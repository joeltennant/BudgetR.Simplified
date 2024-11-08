namespace BudgetR.Simplified.Server.Application.Handlers.Accounts;
public class GetAccountTypes
{
    public record Request() : IRequest<Result<List<Response>>>;

    public record Response
    {
        public long AccountTypeId { get; set; }
        public string Name { get; set; }
    }

    public class Handler : BaseHandler, IRequestHandler<Request, Result<List<Response>>>
    {
        public Handler(BudgetRDbContext context, ServerContext serverContext)
            : base(context, serverContext)
        {
        }

        public async Task<Result<List<Response>>> Handle(Request request, CancellationToken cancellationToken)
        {
            try
            {
                var accountsTypes = await _dbContext.AccountTypes
                    .Select(x => new Response
                    {
                        AccountTypeId = x.AccountTypeId,
                        Name = x.Name
                    })
                    .ToListAsync();

                return Result.Success(accountsTypes);
            }
            catch (Exception ex)
            {
                return Result.Error(ex.Message);
            }
        }
    }
}
