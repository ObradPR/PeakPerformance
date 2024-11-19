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

    protected BaseQueryHandler(IUnitOfWork unitOfWork, IIdentityUser identityUser, IMapper mapper)
       : base(unitOfWork, identityUser, mapper)
    {
    }

    protected BaseQueryHandler(IUnitOfWork unitOfWork, IIdentityUser identityUser, IMapper mapper, IMediator mediator, ILogger logger)
        : base(unitOfWork, identityUser, mapper, mediator, logger)
    {
    }
}