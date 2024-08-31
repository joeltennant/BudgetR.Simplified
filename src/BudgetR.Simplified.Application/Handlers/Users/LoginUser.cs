using Microsoft.EntityFrameworkCore;

namespace BudgetR.Simplified.Application.Handlers.Users;
public static class LoginUser
{
    public class Request : IRequest<Result<(string? FirstName, bool IsActive)>>;

    public class Handler : BaseHandler, IRequestHandler<Request, Result<(string? FirstName, bool IsActive)>>
    {
        public Handler(BudgetRDbContext context, ServerContext serverContext)
            : base(context, serverContext)
        {
        }

        public async Task<Result<(string? FirstName, bool IsActive)>> Handle(Request request, CancellationToken cancellationToken)
        {
            long? userId = _serverContext.UserId;
            (string? FirstName, bool IsActive) user = (null, false);

            if (_serverContext.UserId == null || !_serverContext.IsActive)
            {
                user.IsActive = false;
                return Result.Success(user);
            }

            user.FirstName = await _dbContext.Users
                .AsNoTracking()
                .Where(u => u.UserId == userId)
                .Select(u => u.FirstName)
                .SingleOrDefaultAsync();

            user.IsActive = _serverContext.IsActive;

            return Result.Success(user);
        }
    }
}