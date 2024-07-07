namespace PeakPerformance.Common.Exceptions;

public class NotFoundException() : Exception("The requested resource was not found.")
{ }

public class ServerErrorException() : Exception("An unexpected server error occurred.")
{ }

public class UnauthorizedException() : Exception("Unauthorized access. Authentication is required.")
{ }

public class ValidationException() : Exception("Validation failed for the request.");

public class ForbiddenException() : Exception("Access forbidden.");