using PeakPerformance.Application.Dtos.Users;

namespace PeakPerformance.Application.BusinessLogic.Users.Commands;

public class ProfileSetupCommand(ProfileSetupDto data) : BaseCommand<Unit>
{
    public ProfileSetupDto Data { get; set; } = data;

    public class ProfileSetupCommandHandler(IUnitOfWork unitOfWork, IIdentityUser identityUser)
        : BaseCommandHandler<ProfileSetupCommand, Unit>(unitOfWork, identityUser)
    {
        public override async Task<Unit> Handle(ProfileSetupCommand request, CancellationToken cancellationToken)
        {
            Console.WriteLine(request.Data.Weight.Weight.ToString());

            return Unit.Value;
        }
    }
}