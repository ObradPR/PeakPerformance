namespace PeakPerformance.Application.BusinessLogic.Users.Commands;

public class SignoutCommand : BaseCommand
{
    public class SignoutCommandHandler(IUnitOfWork unitOfWork, IIdentityUser identityUser) : BaseCommandHandler<SignoutCommand>(unitOfWork, identityUser)
    {
        public override async Task Handle(SignoutCommand request, CancellationToken cancellationToken)
        {
            var userId = _identityUser.Id;

            var userActivityLog = new UserActivityLog()
            {
                UserId = userId,
                ActionTypeId = eActionType.Signout
            };

            await _unitOfWork.UserActivityLogRepository.AddAsync(userActivityLog);

            await _unitOfWork.SaveAsync();
        }
    }
}