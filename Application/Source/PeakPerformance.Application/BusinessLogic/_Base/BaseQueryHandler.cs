namespace PeakPerformance.Application.BusinessLogic._Base;

public abstract class BaseQueryHandler<TQuery, TResponse> : BaseHandler<TQuery, TResponse>
    where TQuery : BaseQuery<TResponse>
{
    protected BaseQueryHandler()
    {
    }

    protected BaseQueryHandler(IUnitOfWork unitOfWork)
        : base(unitOfWork)
    {
    }

    protected BaseQueryHandler(IUnitOfWork unitOfWork, IIdentityUser identityUser = null)
        : base(unitOfWork, identityUser)
    {
    }

    protected BaseQueryHandler(IUnitOfWork unitOfWork, IMapper mapper = null, IIdentityUser identityUser = null, IMediator mediator = null, ILogger logger = null)
        : base(unitOfWork, mapper, identityUser, mediator, logger)
    {
    }
}