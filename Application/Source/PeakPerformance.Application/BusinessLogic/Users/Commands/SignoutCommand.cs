namespace PeakPerformance.Application.BusinessLogic.Users.Commands;

public class SignoutCommand : BaseCommand
{
    public class SignoutCommandHandler(IUnitOfWork unitOfWork, IIdentityUser identityUser) : BaseCommandHandler<SignoutCommand>(unitOfWork, identityUser)
    {
        public override async Task Handle(SignoutCommand request, CancellationToken cancellationToken)
        {
            var userId = _identityUser.Id;

            UserActivityLog userActivityLog = new()
            {
                UserId = userId,
                ActionTypeId = (int)eActionType.Signout
            };

            await _unitOfWork.UserActivityLogRepository.AddAsync(userActivityLog, cancellationToken);

            if (!await _unitOfWork.SaveAsync())
                throw new ServerErrorException();
        }
    }
}