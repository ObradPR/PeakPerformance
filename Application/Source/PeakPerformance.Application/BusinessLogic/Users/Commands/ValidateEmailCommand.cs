using PeakPerformance.AbstractAPI.Handlers;
using PeakPerformance.Application.Dtos.Emails;
using PeakPerformance.Application.Interfaces;

namespace PeakPerformance.Application.BusinessLogic.Users.Commands;

public class ValidateEmailCommand(string email, string username) : BaseCommand
{
    public string Email { get; set; } = email;

    public string Username { get; set; } = username;

    // Handlers
    public class ValidateEmailCommandHandler : BaseCommandHandler<ValidateEmailCommand>
    {
        private readonly EmailValidation _emailValidation;
        private readonly IVerificationCodeService _verificationCodeService;
        private readonly IEmailService _emailService;

        public ValidateEmailCommandHandler(IUnitOfWork unitOfWork, EmailValidation emailValidation, IVerificationCodeService verificationCodeService, IEmailService emailService) : base(unitOfWork)
        {
            _emailValidation = emailValidation;
            _verificationCodeService = verificationCodeService;
            _emailService = emailService;
        }

        public override async Task Handle(ValidateEmailCommand request, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.UserRepository.GetExistingUserAsync(request.Email, request.Username, cancellationToken) is not null)
                throw new AccountExistsException();

            if ((await _emailValidation.ValidateEmailAsync(request.Email)).Not())
                throw new EmailValidationException();

            var code = _verificationCodeService.GenerateAndStoreCode(request.Email);

            await _emailService.SendEmailAsync(new EmailDto
            {
                ToEmail = request.Email,
                Subject = "Verification Code",
                Body = $"Your verification code is: {code}"
            });
        }
    }
}