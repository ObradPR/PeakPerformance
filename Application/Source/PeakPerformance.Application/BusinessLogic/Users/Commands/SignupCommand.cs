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
            var existingUser = await _unitOfWork.UserRepository.GetExistingUserAsync(request.User.Email, request.User.Username, strict: false, cancellationToken);

            if (existingUser is not null)
            {
                if (existingUser.Email.Equals(request.User.Email))
                {
                    throw new FluentValidationException(nameof(request.User.Email), ResourceValidation.Already_Exist.AppendArgument(nameof(User)));
                }
                else if (existingUser.Username.Equals(request.User.Username))
                {
                    throw new FluentValidationException(nameof(request.User.Username), ResourceValidation.Already_Exist.AppendArgument(nameof(User)));
                }
            }

            var user = new User();

            request.User.ToModel(user, userManager);

            await _unitOfWork.UserRepository.AddAsync(user, cancellationToken);

            return await _unitOfWork.SaveAsync()
                ? new AuthorizationDto
                {
                    Token = tokenService.GenerateJwtToken(
                    user.Id,
                    Common.Extensions.Extensions.GetStringValues(eSystemRole.User),
                    Common.Extensions.Extensions.GetUserFullName(user.FirstName, user.LastName, user.MiddleName),
                    user.Email,
                    user.Username)
                }
                : throw new ServerErrorException();
        }
    }
}