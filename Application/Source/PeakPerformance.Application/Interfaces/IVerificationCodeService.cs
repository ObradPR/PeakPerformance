namespace PeakPerformance.Application.Interfaces;

public interface IVerificationCodeService
{
    int GenerateAndStoreCode(string email);

    bool ValidateCode(string email, int code);
}