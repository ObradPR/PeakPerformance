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

    protected BaseCommandHandler(IUnitOfWork unitOfWork, IIdentityUser identityUser)
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

    protected BaseCommandHandler(IUnitOfWork unitOfWork, IIdentityUser identityUser)
        : base(unitOfWork, identityUser)
    {
    }

    protected BaseCommandHandler(IUnitOfWork unitOfWork, IIdentityUser identityUser, IMapper mapper)
        : base(unitOfWork, identityUser, mapper)
    {
    }

    protected BaseCommandHandler(IUnitOfWork unitOfWork, IIdentityUser identityUser, IMapper mapper, IMediator mediator, ILogger logger)
        : base(unitOfWork, identityUser, mapper, mediator, logger)
    {
    }
}