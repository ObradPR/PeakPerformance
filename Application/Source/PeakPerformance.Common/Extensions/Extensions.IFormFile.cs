using Microsoft.AspNetCore.Http;

namespace PeakPerformance.Common.Extensions;

public static partial class Extensions
{
    public static long ToBytes(this long MB) => MB * 1024L * 1024L; // using long to prevent integer overflow

    public static double SizeInMB(this IFormFile file) => file.Length / 1024.0 / 1024.0;

    public static bool IsSizeWithinLimit(this IFormFile file, long maxSizeInMB) => file.Length <= maxSizeInMB.ToBytes();

    public static string GetFileExtension(this IFormFile file) => Path.GetExtension(file.FileName).ToLowerInvariant();

    public static bool HasValidExtension(this IFormFile file, params string[] allowedExtensions)
    {
        string extension = file.GetFileExtension();
        return allowedExtensions.Contains(extension);
    }

    public static async Task<byte[]> ReadAsByteArrayAsync(this IFormFile file)
    {
        using (var memoryStream = new MemoryStream())
        {
            await file.CopyToAsync(memoryStream);
            return memoryStream.ToArray();
        }
    }
}