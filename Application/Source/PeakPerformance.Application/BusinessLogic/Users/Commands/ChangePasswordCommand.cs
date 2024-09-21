using PeakPerformance.Application.Dtos.Users.Auth;
using ValidationException = PeakPerformance.Common.Exceptions.ValidationException;

namespace PeakPerformance.Application.BusinessLogic.Users.Commands;

public class ChangePasswordCommand(ChangePasswordDto user) : BaseCommand
{
    public ChangePasswordDto User { get; set; } = user;

    // Validators

    public class ChangePasswordValidator : AbstractValidator<ChangePasswordCommand>
    {
        public ChangePasswordValidator()
        {
            var password = Extensions.GetPropertyDescription<ChangePasswordDto>(_ => _.Password);
            var confirmPassword = Extensions.GetPropertyDescription<ChangePasswordDto>(_ => _.ConfirmPassword);

            RuleFor(_ => _.User.Password)
                .NotEmpty()
                .WithMessage(ResourceValidation.Required.AppendArgument(password))
                .Matches(Constants.REGEX_PASSWORD)
                .WithMessage(ResourceValidation.Password);

            RuleFor(_ => _.User.ConfirmPassword)
                .NotEmpty()
                .WithMessage(ResourceValidation.Required.AppendArgument(confirmPassword))
                .Equal(_ => _.User.Password)
                .WithMessage(ResourceValidation.Dont_Match.AppendArgument(password, confirmPassword));
        }
    }

    // Handlers
    public class ChangePasswordCommandHandler : BaseCommandHandler<ChangePasswordCommand>
    {
        private IUserManager _userManager;

        public ChangePasswordCommandHandler(IUnitOfWork unitOfWork, IUserManager userManager) : base(unitOfWork)
        {
            _userManager = userManager;
        }

        public override async Task Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.GetExistingUserAsync(request.User.Email, request.User.Username, strict: true, cancellationToken)
                ?? throw new ValidationException();

            request.User.ChangePassword(user, _userManager);

            if (!await _unitOfWork.SaveAsync())
                throw new ServerErrorException();
        }
    }
}