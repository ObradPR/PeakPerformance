using PeakPerformance.Application.Dtos.Users.Auth;

namespace PeakPerformance.Application.BusinessLogic.Users.Commands;

public class SignupCommand(SignupDto user) : BaseCommand<AuthorizationDto>
{
    public SignupDto User { get; set; } = user;

    public class SignupCommandHandler(IUnitOfWork unitOfWork, ITokenService tokenService, IUserManager userManager)
        : BaseCommandHandler<SignupCommand, AuthorizationDto>(unitOfWork)
    {
        public override async Task<AuthorizationDto> Handle(SignupCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await _unitOfWork.UserRepository.GetExistingUserAsync(request.User.Email, request.User.Username, strict: false);

            if (existingUser != null)
            {
                if (existingUser.Email == request.User.Email)
                {
                    throw new FluentValidationException(nameof(request.User.Email), ResourceValidation.Already_Exist.AppendArgument(nameof(User)));
                }
                else if (existingUser.Username == request.User.Username)
                {
                    throw new FluentValidationException(nameof(request.User.Username), ResourceValidation.Already_Exist.AppendArgument(nameof(User)));
                }
            }

            var user = new User();

            request.User.ToModel(user, userManager);

            await _unitOfWork.UserRepository.AddAsync(user);

            return await _unitOfWork.SaveAsync()
                ? new AuthorizationDto
                {
                    Token = tokenService.GenerateJwtToken(
                    user.Id,
                    (new[] { eSystemRole.User }).GetNames(),
                    user.FullName,
                    user.Email,
                    user.Username)
                }
                : throw new ServerErrorException();
        }
    }
}