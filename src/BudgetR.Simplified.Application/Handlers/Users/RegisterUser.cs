using BudgetR.Simplified.Services;

namespace BudgetR.Simplified.Application.Handlers.Users;
public class RegisterUser
{
    public record Request(string? Email, string? FirstName, string? LastName) : IRequest<Result<NoValue>>;

    public class Validator : AbstractValidator<Request>
    {
        public Validator()
        {
            RuleFor(x => x.FirstName)
                .NotNull()
                .MinimumLength(3);
            RuleFor(x => x.LastName)
                .NotNull()
                .MinimumLength(3);
            RuleFor(x => x.Email)
                .NotNull()
                .EmailAddress();
        }
    }

    public class Handler : BaseHandler, IRequestHandler<Request, Result<NoValue>>
    {
        private readonly Validator _validator = new();

        public Handler(BudgetRDbContext context, ServerContext serverContext)
            : base(context, serverContext)
        {
        }

        public async Task<Result<NoValue>> Handle(Request request, CancellationToken cancellationToken)
        {
            var validation = await _validator.ValidateAsync(request);
            if (!validation.IsValid)
            {
                return Result.Invalid(validation.AsErrors());
            }

            try
            {
                transaction = await _dbContext.BeginTransactionContext();

                long btaId = await CreateBta();

                var user = new User
                {
                    Email = request.Email,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    IsActive = true,
                    UserType = UserType.User,
                    BusinessTransactionActivityId = btaId
                };

                await _dbContext.Users.AddAsync(user);
                await _dbContext.SaveChangesAsync();

                await _dbContext.AddRangeAsync(BuildMonthBudgetList(user.UserId));
                await _dbContext.SaveChangesAsync();

                var inactivatePastMonths = new InactivatePastMonthsService(_dbContext).Execute();

                await _dbContext.CommitTransactionContext(transaction);
                return Result.Success();
            }
            catch (Exception ex)
            {
                transaction.Dispose();
                return Result.Error(ex.Message);
            }
        }

        private List<BudgetMonth> BuildMonthBudgetList(long UserId)
        {
            List<MonthYear> monthYears = _dbContext.MonthYears
                .OrderBy(m => m.MonthYearId)
                .ToList();

            List<BudgetMonth> monthBudgets = new();

            foreach (var monthYear in monthYears)
            {
                monthBudgets.Add(new BudgetMonth
                {
                    MonthYearId = monthYear.MonthYearId,
                    UserId = UserId,
                });
            }

            return monthBudgets;
        }
    }
}
