namespace PeakPerformance.Common;

public class Constants
{
    public const long SYSTEM_USER_ID = -1;

    public const int DEFAULT_SALT_LENGTH = 32;
    public const int TOKEN_EXPIRATION_TIME = 12;

    // Policies

    public const string ADMIN = "Admin";
    public const string MEMBER = "Member";

    // Params

    public const int DEFAULT_PAGE_SIZE = 10;
    public const int MAX_PAGE_SIZE = 50;
}