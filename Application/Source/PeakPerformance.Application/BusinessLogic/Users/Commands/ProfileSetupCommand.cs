using PeakPerformance.Application.Dtos.Users;

namespace PeakPerformance.Application.BusinessLogic.Users.Commands;

public class ProfileSetupCommand(ProfileSetupDto data) : BaseCommand
{
    public ProfileSetupDto Data { get; set; } = data;

    public class ProfileSetupCommandHandler(IUnitOfWork unitOfWork, IIdentityUser identityUser)
        : BaseCommandHandler<ProfileSetupCommand>(unitOfWork, identityUser)
    {
        public override Task Handle(ProfileSetupCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}