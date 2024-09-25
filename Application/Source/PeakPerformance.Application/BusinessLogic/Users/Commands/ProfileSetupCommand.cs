using PeakPerformance.Application.Dtos.Users;

namespace PeakPerformance.Application.BusinessLogic.Users.Commands;

public class ProfileSetupCommand(ProfileSetupDto settings) : BaseCommand
{
    public ProfileSetupDto Settings { get; set; } = settings;

    public class ProfileSetupCommandHandler(IUnitOfWork unitOfWork, IIdentityUser identityUser)
        : BaseCommandHandler<ProfileSetupCommand>(unitOfWork, identityUser)
    {
        public override Task Handle(ProfileSetupCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}