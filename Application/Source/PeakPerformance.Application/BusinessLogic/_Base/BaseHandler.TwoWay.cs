namespace PeakPerformance.Application.BusinessLogic._Base;

public abstract class BaseHandler<TRequest, TResponse> : BaseHandlerProcess, IRequestHandler<TRequest, TResponse>
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

    protected BaseHandler(IUnitOfWork unitOfWork, IIdentityUser identityUser)
        : this(unitOfWork)
    {
        _identityUser = identityUser;
    }

    protected BaseHandler(IUnitOfWork unitOfWork, IMapper mapper, IIdentityUser identityUser, IMediator mediator, ILogger logger)
        : this(unitOfWork, identityUser)
    {
        _mediator = mediator;
        _mapper = mapper;
        _logger = logger;
    }

    public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
}