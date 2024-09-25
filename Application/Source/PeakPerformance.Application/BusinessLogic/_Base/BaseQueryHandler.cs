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

    protected BaseQueryHandler(IUnitOfWork unitOfWork, IIdentityUser identityUser)
        : base(unitOfWork, identityUser)
    {
    }

    protected BaseQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IIdentityUser identityUser, IMediator mediator, ILogger logger)
        : base(unitOfWork, mapper, identityUser, mediator, logger)
    {
    }
}