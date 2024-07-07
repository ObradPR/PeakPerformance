public abstract class BaseHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    #region Fields

    protected readonly IUnitOfWork _unitOfWork;
    protected readonly IMediator _mediator;
    protected readonly IMapper _mapper;
    protected IIdentityUser _identityUser;
    protected ILogger _logger;

    #endregion Fields

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

    protected BaseHandler(IUnitOfWork unitOfWork, IMapper mapper = null, IIdentityUser identityUser = null, IMediator mediator = null, ILogger logger = null)
        : this(unitOfWork, identityUser)
    {
        _mediator = mediator;
        _mapper = mapper;
        _logger = logger;
    }

    public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);

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