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

                await _dbContext.CommitTransactionContext(transaction);
                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Error(ex.Message);
            }
        }
    }
}
