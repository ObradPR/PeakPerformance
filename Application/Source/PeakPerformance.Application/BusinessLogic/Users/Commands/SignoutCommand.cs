namespace PeakPerformance.Application.BusinessLogic.Users.Commands;

public class SignoutCommand : BaseCommand
{
    // Handlers

    public class SignoutCommandHandler : BaseCommandHandler<SignoutCommand>
    {
        public SignoutCommandHandler(IUnitOfWork unitOfWork, IIdentityUser identityUser = null) : base(unitOfWork, identityUser)
        {
        }

        public override async Task Handle(SignoutCommand request, CancellationToken cancellationToken)
        {
            var userId = _identityUser.Id;

            UserActivityLog userActivityLog = new()
            {
                UserId = userId,
                ActionTypeId = eActionType.Signout.ToInt()
            };

            await _unitOfWork.UserActivityLogRepository.AddAsync(userActivityLog, cancellationToken);

            if ((await _unitOfWork.SaveAsync()).Not())
                throw new ServerErrorException();
        }
    }
}