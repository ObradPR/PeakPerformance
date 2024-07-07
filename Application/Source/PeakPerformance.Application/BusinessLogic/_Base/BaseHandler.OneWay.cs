public abstract class BaseHandler<TRequest> : IRequestHandler<TRequest>
    where TRequest : IRequest
{
    protected readonly IUnitOfWork _unitOfWork;
    protected IIdentityUser _identityUser;

    protected BaseHandler()
    {
    }

    protected BaseHandler(IUnitOfWork unitOfWork) : this()
    {
        _unitOfWork = unitOfWork;
    }

    protected BaseHandler(IUnitOfWork unitOfWork, IIdentityUser identityUser = null)
        : this(unitOfWork)
    {
        _identityUser = identityUser;
    }

    public abstract Task Handle(TRequest request, CancellationToken cancellationToken);

    protected bool TryRun(Action action, ILogger logger)
    {
        try
        {
            action();
            return true;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, ex.Message);
            return false;
        }
    }

    protected async Task<bool> TryRunAsync(Func<Task> action, ILogger logger)
    {
        try
        {
            await action();
            return true;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, ex.Message);
            return false;
        }
    }

    protected void CheckUserAuthorization(IIdentityUser user, params eSystemRole[] requiredRoles)
    {
        if (!user.IsAuthenticated || !user.HasRole([.. requiredRoles]))
        {
            throw new UnauthorizedAccessException();
        }
    }
}
