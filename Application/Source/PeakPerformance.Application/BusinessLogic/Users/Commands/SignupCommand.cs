using PeakPerformance.Application.Dtos.Users.Auth;

namespace PeakPerformance.Application.BusinessLogic.Users.Commands;

public class SignupCommand(SignupDto user) : BaseCommand<AuthorizationDto>
{
    public SignupDto User { get; set; } = user;

    // Validators

    public class SignupValidator : AbstractValidator<SignupCommand>
    {
        public SignupValidator()
        {
            var firstName = Extensions.GetPropertyDescription<SignupDto>(_ => _.FirstName);
            var middleName = Extensions.GetPropertyDescription<SignupDto>(_ => _.MiddleName);
            var lastName = Extensions.GetPropertyDescription<SignupDto>(_ => _.LastName);
            var username = Extensions.GetPropertyDescription<SignupDto>(_ => _.Username);
            var email = Extensions.GetPropertyDescription<SignupDto>(_ => _.Email);
            var password = Extensions.GetPropertyDescription<SignupDto>(_ => _.Password);
            var confirmPassword = Extensions.GetPropertyDescription<SignupDto>(_ => _.ConfirmPassword);
            var dob = Extensions.GetPropertyDescription<SignupDto>(_ => _.DateOfBirth);
            var phoneNumber = Extensions.GetPropertyDescription<SignupDto>(_ => _.PhoneNumber);

            RuleFor(_ => _.User.FirstName)
                .NotEmpty()
                .WithMessage(ResourceValidation.Required.AppendArgument(firstName))
                .MaximumLength(20)
                .WithMessage(ResourceValidation.Maximum_Characters.AppendArgument(firstName, "20"))
                .MinimumLength(2)
                .WithMessage(ResourceValidation.Minimum_Characters.AppendArgument(firstName, "2"));

            RuleFor(_ => _.User.MiddleName)
                .MaximumLength(20)
                .When(_ => !_.User.MiddleName.IsNullOrWhiteSpace())
                .WithMessage(ResourceValidation.Maximum_Characters.AppendArgument(middleName, "20"))
                .MinimumLength(2)
                .When(_ => !_.User.MiddleName.IsNullOrWhiteSpace())
                .WithMessage(ResourceValidation.Minimum_Characters.AppendArgument(middleName, "2"));

            RuleFor(_ => _.User.LastName)
                .NotEmpty()
                .WithMessage(ResourceValidation.Required.AppendArgument(lastName))
                .MaximumLength(30)
                .WithMessage(ResourceValidation.Maximum_Characters.AppendArgument(lastName, "30"))
                .MinimumLength(2)
                .WithMessage(ResourceValidation.Minimum_Characters.AppendArgument(lastName, "2"));

            RuleFor(_ => _.User.Username)
                .NotEmpty()
                .WithMessage(ResourceValidation.Required.AppendArgument(username))
                .MaximumLength(30)
                .WithMessage(ResourceValidation.Maximum_Characters.AppendArgument(username, "30"))
                .MinimumLength(2)
                .WithMessage(ResourceValidation.Minimum_Characters.AppendArgument(username, "2"));

            RuleFor(_ => _.User.Email)
                .NotEmpty()
                .WithMessage(ResourceValidation.Required.AppendArgument(email))
                .EmailAddress()
                .WithMessage(ResourceValidation.Wrong_Format.AppendArgument(email))
                .MaximumLength(100)
                .WithMessage(ResourceValidation.Maximum_Characters.AppendArgument(email, "100"));

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

            RuleFor(_ => _.User.DateOfBirth)
                .NotEmpty()
                .WithMessage(ResourceValidation.Required.AppendArgument(dob))
                .Must(_ => _.BeAtLeastEighteenYearsOld())
                .WithMessage(ResourceValidation.Minimum_Age.AppendArgument("18"));

            RuleFor(_ => _.User.PhoneNumber)
                .NotEmpty()
                .WithMessage(ResourceValidation.Required.AppendArgument(phoneNumber))
                .Matches(Constants.REGEX_PHONE_NUMBER)
                .WithMessage(ResourceValidation.Phone_Number.AppendArgument(phoneNumber));
        }
    }

    // Handlers

    public class SignupCommandHandler : BaseCommandHandler<SignupCommand, AuthorizationDto>
    {
        private readonly ITokenService _tokenService;
        private readonly IUserManager _userManager;

        public SignupCommandHandler(IUnitOfWork unitOfWork, ITokenService tokenService, IUserManager userManager) : base(unitOfWork)
        {
            _tokenService = tokenService;
            _userManager = userManager;
        }

        public override async Task<AuthorizationDto> Handle(SignupCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await _unitOfWork.UserRepository.GetExistingUserAsync(request.User.Email, request.User.Username, strict: false, cancellationToken);

            if (existingUser is not null)
            {
                if (existingUser.Email.Equals(request.User.Email))
                    throw new FluentValidationException(nameof(request.User.Email), ResourceValidation.Already_Exist.AppendArgument(nameof(User)));
                else if (existingUser.Username.Equals(request.User.Username))
                    throw new FluentValidationException(nameof(request.User.Username), ResourceValidation.Already_Exist.AppendArgument(nameof(User)));
            }

            User user = new();

            request.User.ToModel(user, _userManager);

            await _unitOfWork.UserRepository.AddAsync(user, cancellationToken);

            return await _unitOfWork.SaveAsync()
                ? new AuthorizationDto
                {
                    Token = _tokenService.GenerateJwtToken(
                    user.Id,
                    Extensions.GetStringValues(eSystemRole.User),
                    Extensions.GetUserFullName(user.FirstName, user.LastName, user.MiddleName),
                    user.Email,
                    user.Username)
                }
                : throw new ServerErrorException();
        }
    }
}