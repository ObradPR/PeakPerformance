using PeakPerformance.Application.Dtos.Emails;
using PeakPerformance.Application.Dtos.Users.Auth;
using PeakPerformance.Application.Interfaces;
using ValidationException = PeakPerformance.Common.Exceptions.ValidationException;

namespace PeakPerformance.Application.BusinessLogic.Users.Commands;

public class ValidateUserCommand(ValidateUserDto user) : BaseCommand
{
    public ValidateUserDto User { get; set; } = user;

    // Handlers
    public class ValidateUserCommandHandler : BaseCommandHandler<ValidateUserCommand>
    {
        private readonly IVerificationCodeService _verificationCodeService;
        private readonly IEmailService _emailService;

        public ValidateUserCommandHandler(IUnitOfWork unitOfWork, IVerificationCodeService verificationCodeService, IEmailService emailService) : base(unitOfWork)
        {
            _verificationCodeService = verificationCodeService;
            _emailService = emailService;
        }

        public override async Task Handle(ValidateUserCommand request, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.UserRepository.GetExistingUserAsync(request.User.Email, request.User.Username, strict: true, cancellationToken) is null)
                throw new ValidationException();

            var code = _verificationCodeService.GenerateAndStoreCode(request.User.Email);

            await _emailService.SendEmailAsync(new EmailDto
            {
                ToEmail = request.User.Email,
                Subject = "Verification Code",
                Body = $"Your verification code is: {code}"
            });
        }
    }
}