

namespace BudgetR.Simplified.Application.Handlers.Users;
public static class Loginuser
{
    public class Request : IRequest<Result<long?>>;

    public class Handler : BaseHandler<long?>, IRequestHandler<Request, Result<long?>>
    {
        public Handler(BudgetRDbContext context, ServerContext serverContext)
            : base(context, serverContext)
        {
        }

        public async Task<Result<long?>> Handle(Request request, CancellationToken cancellationToken)
        {
            long? userId = _serverContext.UserId;

            if (userId.HasValue && _serverContext.IsActive)
            {
                return Result.Success(userId);
            }

            userId = null;

            return Result.Success(userId);
        }
    }
}