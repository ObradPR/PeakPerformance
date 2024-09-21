using PeakPerformance.Application.Dtos.Users.Auth;

namespace PeakPerformance.Application.BusinessLogic.Users.Commands;

public class SigninCommand(SigninDto user) : BaseCommand<AuthorizationDto>
{
    public SigninDto User { get; set; } = user;

    // Validators

    public class SigninValidator : AbstractValidator<SigninCommand>
    {
        public SigninValidator()
        {
            var username = Extensions.GetPropertyDescription<SigninDto>(_ => _.Username);
            var password = Extensions.GetPropertyDescription<SigninDto>(_ => _.Password);

            RuleFor(_ => _.User.Username)
                .NotEmpty()
                .WithMessage(ResourceValidation.Required.AppendArgument(username))
                .MaximumLength(30)
                .WithMessage(ResourceValidation.Maximum_Characters.AppendArgument(username, "30"))
                .MinimumLength(2)
                .WithMessage(ResourceValidation.Minimum_Characters.AppendArgument(username, "2"));

            RuleFor(_ => _.User.Password)
                .NotEmpty()
                .WithMessage(ResourceValidation.Required.AppendArgument(password))
                .Matches(Constants.REGEX_PASSWORD)
                .WithMessage(ResourceValidation.Password);
        }
    }

    // Handlers

    public class SigninCommandHandler : BaseCommandHandler<SigninCommand, AuthorizationDto>
    {
        private readonly ITokenService _tokenService;
        private readonly IUserManager _userManager;

        public SigninCommandHandler(IUnitOfWork unitOfWork, ITokenService tokenService, IUserManager userManager) : base(unitOfWork)
        {
            _tokenService = tokenService;
            _userManager = userManager;
        }

        public override async Task<AuthorizationDto> Handle(SigninCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await _unitOfWork.UserRepository.GetUserByUsernameAsync(request.User.Username, cancellationToken)
                ?? throw new FluentValidationException(nameof(request.User), ResourceValidation.Wrong_Credentials);

            bool passwordMatch = _userManager.VerifyPassword(request.User.Password, existingUser.Password);

            if (!passwordMatch)
                throw new FluentValidationException(nameof(request.User), ResourceValidation.Wrong_Credentials);

            UserActivityLog userActivityLog = new()
            {
                UserId = existingUser.Id,
                ActionTypeId = (int)eActionType.Signin
            };

            await _unitOfWork.UserActivityLogRepository.AddAsync(userActivityLog, cancellationToken);

            return await _unitOfWork.SaveAsync()
                ? new AuthorizationDto
                {
                    Token = _tokenService.GenerateJwtToken(
                    existingUser.Id,
                    existingUser.UserRoles.Select(_ => _.Role.Name).ToArray(),
                    Extensions.GetUserFullName(existingUser.FirstName, existingUser.LastName, existingUser.MiddleName),
                    existingUser.Email,
                    existingUser.Username)
                }
                : throw new ServerErrorException();
        }
    }
}