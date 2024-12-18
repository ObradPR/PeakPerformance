﻿using PeakPerformance.Application.Dtos.Users.Auth;

namespace PeakPerformance.Application.BusinessLogic.Users.Commands;

public class SigninCommand(SigninDto user) : BaseCommand<AuthorizationDto>
{
    public SigninDto User { get; set; } = user;

    public class SigninCommandHandler(IUnitOfWork unitOfWork, ITokenService tokenService, IUserManager userManager)
        : BaseCommandHandler<SigninCommand, AuthorizationDto>(unitOfWork)
    {
        public override async Task<AuthorizationDto> Handle(SigninCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await _unitOfWork.UserRepository.GetByUsernameAsync(request.User.Username)
                ?? throw new FluentValidationException(nameof(request.User), ResourceValidation.Wrong_Credentials);

            bool passwordMatch = userManager.VerifyPassword(request.User.Password, existingUser.Password);

            if (!passwordMatch)
                throw new FluentValidationException(nameof(request.User), ResourceValidation.Wrong_Credentials);

            UserActivityLog userActivityLog = new()
            {
                UserId = existingUser.Id,
                ActionTypeId = eActionType.Signin
            };

            await _unitOfWork.UserActivityLogRepository.AddAsync(userActivityLog);

            await _unitOfWork.SaveAsync();
            return new AuthorizationDto
            {
                Token = tokenService.GenerateJwtToken(
                existingUser.Id,
                existingUser.UserRoles.Select(_ => _.Role.Name).ToArray(),
                Common.Extensions.Extensions.GetUserFullName(existingUser.FirstName, existingUser.LastName, existingUser.MiddleName),
                existingUser.Email,
                existingUser.Username)
            };
        }
    }
}