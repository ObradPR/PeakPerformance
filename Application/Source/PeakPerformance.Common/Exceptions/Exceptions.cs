namespace PeakPerformance.Common.Exceptions;

public class NotFoundException() : Exception("The requested resource was not found.")
{ }

public class ServerErrorException() : Exception("An unexpected server error occurred.")
{ }

public class UnauthorizedException() : Exception("Unauthorized access. Authentication is required.")
{ }

public class ValidationException() : Exception("Validation failed for the request.");

public class ForbiddenException() : Exception("Access forbidden.");

public class EmailValidationException() : Exception("Email does not exist.");

public class VerificationCodeException() : Exception("Verification code does not match the one provided.");

public class AccountExistsException() : Exception("Account with given email or username already exists.");