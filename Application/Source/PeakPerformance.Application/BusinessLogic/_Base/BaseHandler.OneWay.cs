namespace PeakPerformance.Application.BusinessLogic._Base;

public abstract class BaseHandler<TRequest> : BaseHandlerProcess, IRequestHandler<TRequest>
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

    protected BaseHandler(IUnitOfWork unitOfWork, IIdentityUser identityUser)
        : this(unitOfWork)
    {
        _identityUser = identityUser;
    }

    public abstract Task Handle(TRequest request, CancellationToken cancellationToken);
}