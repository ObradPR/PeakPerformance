using System.Text.RegularExpressions;

namespace PeakPerformance.Common;

public class Constants
{
    public const string SOULUTION_NAME = "PeakPerformance";
    public const long SYSTEM_USER_ID = -1;

    // Token

    public const int TOKEN_EXPIRATION_TIME = 12;

    // Policies

    public const string ADMIN = "Admin";
    public const string MEMBER = "Member";

    // Params

    public const int DEFAULT_PAGE_SIZE = 10;
    public const int MAX_PAGE_SIZE = 50;

    // Validations

    public static readonly Regex REGEX_PASSWORD = new(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[^a-zA-Z0-9]).{8,}$");
    public static readonly Regex REGEX_ZIPCODE = new(@"^\d{5}(-\d{4})?$");
    public static readonly Regex REGEX_PHONE_NUMBER = new(@"^\d{3}-\d{3}-\d{4}$");
}