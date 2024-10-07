using PeakPerformance.Application.Dtos.Users.Auth;
using ValidationException = PeakPerformance.Common.Exceptions.ValidationException;

namespace PeakPerformance.Application.BusinessLogic.Users.Commands;

public class ChangePasswordCommand(ChangePasswordDto user) : BaseCommand<Unit>
{
    public ChangePasswordDto User { get; set; } = user;

    public class ChangePasswordCommandHandler(IUnitOfWork unitOfWork, IUserManager userManager)
        : BaseCommandHandler<ChangePasswordCommand, Unit>(unitOfWork)
    {
        public override async Task<Unit> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.GetExistingAsync(request.User.Email, request.User.Username, strict: true)
                ?? throw new ValidationException();

            request.User.ChangePassword(user, userManager);

            await _unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}