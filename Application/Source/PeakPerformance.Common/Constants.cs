using System.Text.RegularExpressions;

namespace PeakPerformance.Common;

public class Constants
{
    public const string SOLUTION_NAME = "PeakPerformance";

    // System User

    public const long SYSTEM_USER_ID = -1;
    public const string SYSTEM_USER_USERNAME = "PeakPerformance";
    public const string SYSTEM_USER_EMAIL = "peakperformance690@gmail.com";

    // Token

    public const int TOKEN_EXPIRATION_TIME = 12;

    // Claims

    public const string CLAIM_ID = "ID";
    public const string CLAIM_FULLNAME = "FULLNAME";
    public const string CLAIM_USERNAME = "USERNAME";
    public const string CLAIM_ROLES = "ROLES";
    public const string CLAIM_EMAIL = "EMAIL";
    public const string CLAIM_ISSUER = "ISSUER";

    // Policies

    public const string ADMIN = "Admin";
    public const string MEMBER = "Member";

    // Params

    public const int DEFAULT_PAGE_SIZE = 10;
    public const int MAX_PAGE_SIZE = 50;

    // Sorting

    public const string SORTING_ORDER_DESC = "desc";
    public const string SORTING_ORDER_ASC = "asc";

    // Image

    public const long IMAGE_MAX_SIZE_MB = 5 * 1024 * 1024;

    public static readonly string[] IMAGE_ALLOWED_EXTENSIONS =
    [
        ".jpg",
        ".jpeg",
        ".png"
    ];

    // Validations

    public static readonly Regex REGEX_PASSWORD = new(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[^a-zA-Z0-9]).{8,}$");
    public static readonly Regex REGEX_ZIPCODE = new(@"^\d{5}(-\d{4})?$");
    public static readonly Regex REGEX_PHONE_NUMBER = new(@"^\d{3}-\d{3}-\d{4}$");

    // DB Types

    public const string DB_TYPE_DATE = "date";
}