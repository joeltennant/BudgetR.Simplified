using Microsoft.EntityFrameworkCore;

namespace BudgetR.Simplified.Server.Application.Handlers.Users;
public static class LoginUser
{
    public record Request : IRequest<Result<Response>>;
    public record Response(bool IsActive, string FirstName);
    //Result<(string? FirstName, bool IsActive)>
    public class Handler : BaseHandler, IRequestHandler<Request, Result<Response>>
    {
        public Handler(BudgetRDbContext context, ServerContext serverContext)
            : base(context, serverContext)
        {
        }

        public async Task<Result<Response>> Handle(Request request, CancellationToken cancellationToken)
        {
            if (_serverContext.UserId == null || !_serverContext.IsActive)
            {
                return Result.Success(new Response(false, string.Empty));
            }

            string FirstName = await _dbContext.Users
                .AsNoTracking()
                .Where(u => u.UserId == _serverContext.UserId)
                .Select(u => u.FirstName)
                .SingleAsync();

            var inactivatePastMonths = new InactivatePastMonthsService(_dbContext).Execute();

            return Result.Success(new Response(_serverContext.IsActive, FirstName));
        }
    }
}