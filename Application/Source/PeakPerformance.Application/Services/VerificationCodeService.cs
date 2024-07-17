using PeakPerformance.Application.Interfaces;

namespace PeakPerformance.Application.Services;

public class VerificationCodeService : IVerificationCodeService
{
    private static readonly Dictionary<string, int> _verificationCodes = [];

    public int GenerateAndStoreCode(string email)
    {
        var code = new Random().Next(100000, 999999);
        _verificationCodes[email] = code;
        return code;
    }

    public bool ValidateCode(string email, int code)
    {
        return _verificationCodes.ContainsKey(email) && _verificationCodes[email] == code;
    }
}