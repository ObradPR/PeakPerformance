namespace PeakPerformance.AbstractAPI._Base;

public abstract class BaseClient
{
    private readonly HttpClient _httpClient;
    protected string _apiKey = string.Empty;
    protected string _apiUrl = string.Empty;

    public BaseClient(string credentials)
    {
        GetCredentials(credentials);

        _httpClient = new HttpClient
        {
            BaseAddress = new Uri(_apiUrl)
        };
    }

    private void GetCredentials(string credentials)
    {
        string[] creds = credentials.Split('|');

        _apiKey = creds[0];
        _apiUrl = creds[1];
    }

    protected async Task<HttpResponseMessage> GetAsync(string endpoint)
        => await _httpClient.GetAsync($"?api_key={_apiKey}{endpoint}");

    protected async Task<string> GetStringAsync(string endpoint)
    {
        var response = await _httpClient.GetAsync($"?api_key={_apiKey}{endpoint}");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }
}