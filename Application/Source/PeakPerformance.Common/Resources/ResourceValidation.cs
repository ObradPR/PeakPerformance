namespace PeakPerformance.Common.Resources;

public static class ResourceValidation
{
    public static string Already_Exist => "{0} already exist.";

    public static string Date_After => "Provided {0} must be after {1}.";

    public static string Date_Before => "Provided {0} must be before {1}.";

    public static string Date_InBetween => "Provided {0} must be in between {1} and {2}.";

    public static string Date_Invalid => "Provided date is invalid.";

    public static string Dont_Match => "{0} and {1} don't match.";

    public static string File_Allowed_Extensions => "Invalid {0} format. Allowed formats: {1}.";

    public static string File_Maximum_Size => "{0} size must be {1} MB or less";

    public static string Greater_Than => "{0} must be greater than {1}.";

    public static string Invalid_Social_Media_Link => "{0} is not in valid format for {1}.";

    public static string Is_Phone_Based_Platform => "Platform requires a valid {0}. Please ensure the {0} is in the correct format";

    public static string Is_Url_Based_Platform => "PLatform requires a valid {0}. Please ensure the {0} starts with 'https://' and contains the platform name.";

    public static string Less_Than => "{0} must be less than {1}.";

    public static string Maximum_Characters => "{0} can't be more than {1} characters long.";

    public static string Minimum_Age => "Person must be at least 18 years old. {0} must be before {1}.";

    public static string Minimum_Characters => "{0} must be at least {1} characters long.";

    public static string Not_Expected_Enum_Type => "The {0} is not included in {1} enum type.";

    public static string Not_Expected_Type => "The {0} is not of the expected type.";

    public static string Not_Numeric_Type => "The type {0} is not a numeric type.";

    public static string Password => "{0} must consist of at least one uppercase letter, one lowercase letter, one digit, one special character and must be at least 8 characters long.";

    public static string Phone_Number => "{0} must be in format 333-333-3333.";

    public static string Required => "{0} is required.";

    public static string Wrong_Credentials => "User credentials are wrong. Please try again.";

    public static string Wrong_Format => "{0} is in the wrong format.";
}