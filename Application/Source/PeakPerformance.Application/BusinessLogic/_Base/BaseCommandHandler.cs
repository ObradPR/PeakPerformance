namespace PeakPerformance.Application.BusinessLogic._Base;

public abstract class BaseCommandHandler<TCommand> : BaseHandler<TCommand>
    where TCommand : BaseCommand
{
    protected BaseCommandHandler()
    {
    }

    protected BaseCommandHandler(IUnitOfWork unitOfWork)
        : base(unitOfWork)
    {
    }

    protected BaseCommandHandler(IUnitOfWork unitOfWork, IIdentityUser identityUser = null)
        : base(unitOfWork, identityUser)
    {
    }
}

public abstract class BaseCommandHandler<TCommand, TResponse> : BaseHandler<TCommand, TResponse>
    where TCommand : BaseCommand<TResponse>
{
    protected BaseCommandHandler()
    {
    }

    protected BaseCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    protected BaseCommandHandler(IUnitOfWork unitOfWork, IIdentityUser identityUser = null)
        : base(unitOfWork, identityUser)
    {
    }

    protected BaseCommandHandler(IUnitOfWork unitOfWork, IMapper mapper = null, IIdentityUser identityUser = null, IMediator mediator = null, ILogger logger = null)
        : base(unitOfWork, mapper, identityUser, mediator, logger)
    {
    }
}