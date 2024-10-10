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

    public const long IMAGE_MAX_SIZE_MB = 5; // 5 * 1024 * 1024

    public static readonly string[] IMAGE_ALLOWED_EXTENSIONS =
    [
        ".jpg",
        ".jpeg",
        ".png"
    ];

    // Date

    /// <summary>
    /// Date in format: 10. Jan 2024
    /// </summary>
    public static readonly string DATE_FORMAT_LONG = "dd. MMM yyyy";

    /// <summary>
    /// Date in format: January 10, 2024
    /// </summary>
    public static readonly string DATE_FORMAT_FULL_MONTH = "MMMM dd, yyyy";

    /// <summary>
    /// Date in format: 10/01/2024 (MM/dd/yyyy)
    /// </summary>
    public static readonly string DATE_FORMAT_SLASH = "MM/dd/yyyy";

    /// <summary>
    /// Date in format: 10-Jan-2024
    /// </summary>
    public static readonly string DATE_FORMAT_SHORT_MONTH_DASH = "dd-MMM-yyyy";

    /// <summary>
    /// Date in format: 10 January 2024
    /// </summary>
    public static readonly string DATE_FORMAT_FULL = "dd MMMM yyyy";

    /// <summary>
    /// Date in format: 2024-01-10 (ISO format)
    /// </summary>
    public static readonly string DATE_FORMAT_ISO = "yyyy-MM-dd";

    /// <summary>
    /// Date in format: Wednesday, January 10, 2024
    /// </summary>
    public static readonly string DATE_FORMAT_DAY_FULL = "dddd, MMMM dd, yyyy";

    /// <summary>
    /// Date in format: Jan 10, 2024
    /// </summary>
    public static readonly string DATE_FORMAT_SHORT_MONTH_COMMA = "MMM dd, yyyy";

    // Validations

    public static readonly Regex REGEX_PASSWORD = new(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[^a-zA-Z0-9]).{8,}$");
    public static readonly Regex REGEX_ZIPCODE = new(@"^\d{5}(-\d{4})?$");
    public static readonly Regex REGEX_PHONE_NUMBER = new(@"^\d{3}-\d{3}-\d{4}$");

    // Weight

    public const decimal WEIGHT_DEFAULT = 50m;

    // DB Types

    public const string DB_TYPE_DATE = "date";

    // Cloudinary

    public const string CLOUDINARY_STORAGE_NAME = "peak-performance-app";
}