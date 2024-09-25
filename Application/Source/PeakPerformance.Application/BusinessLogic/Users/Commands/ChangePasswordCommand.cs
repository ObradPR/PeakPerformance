using PeakPerformance.Application.Dtos.Users.Auth;
using ValidationException = PeakPerformance.Common.Exceptions.ValidationException;

namespace PeakPerformance.Application.BusinessLogic.Users.Commands;

public class ChangePasswordCommand(ChangePasswordDto user) : BaseCommand
{
    public ChangePasswordDto User { get; set; } = user;

    public class ChangePasswordCommandHandler(IUnitOfWork unitOfWork, IUserManager userManager)
        : BaseCommandHandler<ChangePasswordCommand>(unitOfWork)
    {
        public override async Task Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.GetExistingUserAsync(request.User.Email, request.User.Username, strict: true, cancellationToken)
                ?? throw new ValidationException();

            request.User.ChangePassword(user, userManager);

            if (!await _unitOfWork.SaveAsync())
                throw new ServerErrorException();
        }
    }
}