namespace BudgetR.Simplified.Server.Application.Handlers.Accounts;
public class GetAllAccounts
{
    public record Request() : IRequest<Result<List<Response>>>;

    public record Response
    {
        public long AccountId { get; set; }
        public string DisplayName { get; set; }
        public string LongName { get; set; }
        public decimal Balance { get; set; }
        public long AccountTypeId { get; set; }
        public string AccountType { get; set; }
        public BalanceType BalanceType { get; set; }
        public DateTime CreatedAt { get; set; }
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
                var userId = _serverContext.UserId;
                var accounts = await _dbContext.Accounts
                    .Where(a => a.UserId == userId)
                    .Select(a => new Response
                    {
                        AccountId = a.AccountId,
                        DisplayName = a.DisplayName,
                        LongName = a.LongName,
                        Balance = a.Balance,
                        AccountTypeId = a.AccountTypeId,
                        AccountType = a.AccountType.Name,
                        BalanceType = a.AccountType.BalanceType,
                        CreatedAt = a.CreatedAt
                    })
                    .ToListAsync();

                return Result.Success(accounts);
            }
            catch (Exception ex)
            {
                return Result.Error(ex.Message);
            }
        }
    }
}
