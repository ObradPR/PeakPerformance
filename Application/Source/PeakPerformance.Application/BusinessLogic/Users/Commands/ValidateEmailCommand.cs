using PeakPerformance.AbstractAPI.Handlers;
using PeakPerformance.Application.Dtos.Emails;
using PeakPerformance.Application.Dtos.Users.Auth;
using PeakPerformance.Application.Interfaces;

namespace PeakPerformance.Application.BusinessLogic.Users.Commands;

public class ValidateEmailCommand(ValidateUserDto user) : BaseCommand
{
    public ValidateUserDto User { get; set; } = user;

    public class ValidateEmailCommandHandler(IUnitOfWork unitOfWork, EmailValidation emailValidation, IVerificationCodeService verificationCodeService, IEmailService emailService)
        : BaseCommandHandler<ValidateEmailCommand>(unitOfWork)
    {
        public override async Task Handle(ValidateEmailCommand request, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.UserRepository.GetExistingUserAsync(request.User.Email, request.User.Username, strict: false) != null)
                throw new AccountExistsException();

            if (!await emailValidation.ValidateEmailAsync(request.User.Email))
                throw new EmailValidationException();

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