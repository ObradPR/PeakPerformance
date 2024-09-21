namespace PeakPerformance.Common.Resources;

public static class ResourceValidation
{
    public static string Already_Exist => "{0} already exist.";

    public static string Dont_Match => "{0} and {1} don't match.";

    public static string Maximum_Characters => "{0} can't be more than {1} characters long.";

    public static string Minimum_Age => "Person must be at least {0} years old.";

    public static string Minimum_Characters => "{0} must be at least {1} characters long.";

    public static string Password => "Password must consist of at least one uppercase letter, one lowercase letter, one digit, one special character and must be at least 8 characters long.";

    public static string Phone_Number => "{0} must be in format 333-333-3333.";

    public static string Required => "{0} is required.";

    public static string Wrong_Credentials => "User credentials are wrong. Please try again.";

    public static string Wrong_Format => "{0} is in the wrong format.";

    public static string Greater_Than => "{0} must be greater than {1}.";

    public static string Less_Than => "{0} must be less than {1}.";
}