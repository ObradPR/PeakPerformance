using CloudinaryDotNet;

namespace PeakPerformance.Infrastructure.Storage.Services;

public abstract class BaseCloudinaryService
{
    protected readonly Cloudinary _cloudinary;
    protected string _apiKey = string.Empty;
    protected string _apiSecret = string.Empty;
    protected string _cloudName = string.Empty;

    protected BaseCloudinaryService(string credentials)
    {
        GetCredentials(credentials);

        var account = new Account(_cloudName, _apiKey, _apiSecret);
        _cloudinary = new Cloudinary(account);
    }

    private void GetCredentials(string credentials)
    {
        string[] creds = credentials.Split('|');

        _apiKey = creds[0];
        _apiSecret = creds[1];
        _cloudName = creds[2];
    }
}