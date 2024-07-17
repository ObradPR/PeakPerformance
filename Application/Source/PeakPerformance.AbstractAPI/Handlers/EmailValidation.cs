using Newtonsoft.Json.Linq;
using PeakPerformance.AbstractAPI._Base;

namespace PeakPerformance.AbstractAPI.Handlers;

public class EmailValidation : BaseClient
{
    public EmailValidation(string credentials) : base(credentials)
    {
    }

    public async Task<bool> ValidateEmailAsync(string email)
    {
        var endpoint = $"&email={email}";
        var responseString = await GetStringAsync(endpoint);
        var jsonResponse = JObject.Parse(responseString);

        var deliverability = jsonResponse["deliverability"]?.ToString();
        bool isFreeEmail = jsonResponse["is_free_email"]?["value"]?.ToObject<bool>() ?? false;
        bool isSmtpValid = jsonResponse["is_smtp_valid"]?["value"]?.ToObject<bool>() ?? false;

        return deliverability == "DELIVERABLE" && isFreeEmail && isSmtpValid;
    }
}