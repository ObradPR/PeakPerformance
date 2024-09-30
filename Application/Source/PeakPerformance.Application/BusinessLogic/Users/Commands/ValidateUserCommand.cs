using PeakPerformance.Application.Dtos.Emails;
using PeakPerformance.Application.Dtos.Users.Auth;
using PeakPerformance.Application.Interfaces;
using ValidationException = PeakPerformance.Common.Exceptions.ValidationException;

namespace PeakPerformance.Application.BusinessLogic.Users.Commands;

public class ValidateUserCommand(ValidateUserDto user) : BaseCommand
{
    public ValidateUserDto User { get; set; } = user;

    public class ValidateUserCommandHandler(IUnitOfWork unitOfWork, IVerificationCodeService verificationCodeService, IEmailService emailService)
        : BaseCommandHandler<ValidateUserCommand>(unitOfWork)
    {
        public override async Task Handle(ValidateUserCommand request, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.UserRepository.GetExistingUserAsync(request.User.Email, request.User.Username, strict: true) is null)
                throw new ValidationException();

            var code = verificationCodeService.GenerateAndStoreCode(request.User.Email);

            await emailService.SendEmailAsync(new EmailDto
            {
                ToEmail = request.User.Email,
                Subject = "Verification Code",
                Body = $"Your verification code is: {code}"
            });
        }
    }
}