using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using PeakPerformance.Common;
using PeakPerformance.Infrastructure.Storage.Interfaces;

namespace PeakPerformance.Infrastructure.Storage.Services;

public class CloudinaryService : BaseCloudinaryService, ICloudinaryService
{
    public CloudinaryService(string credentials) : base(credentials)
    {
    }

    public async Task<ImageUploadResult> UploadPhotoAsync(IFormFile file)
    {
        if (file.Length < 1)
            return new();

        using var stream = file.OpenReadStream();
        var uploadParams = new ImageUploadParams
        {
            File = new FileDescription(file.FileName, stream),
            Transformation = new Transformation().Height(300).Width(300).Crop("fill").Gravity(Gravity.Face),
            Folder = Constants.CLOUDINARY_STORAGE_NAME
        };

        return await _cloudinary.UploadAsync(uploadParams);
    }

    public async Task<DeletionResult> DeletePhotoAsync(string publicId) => await _cloudinary.DestroyAsync(new DeletionParams(publicId));
}