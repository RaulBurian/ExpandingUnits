using System.Text.Json.Serialization;

namespace ExpandingUnits.Api.Services;

internal record ValidationApiSettings(string BaseUrl, string ValidationRoute);

internal interface IValidationApiService
{
    Task<bool> ValidateItem();
}

internal class ValidationApiService : IValidationApiService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ValidationApiSettings _apiSettings;

    public static string ClientName => "Validation";

    public ValidationApiService(IHttpClientFactory httpClientFactory, ValidationApiSettings apiSettings)
    {
        _httpClientFactory = httpClientFactory;
        _apiSettings = apiSettings;
    }

    public async Task<bool> ValidateItem()
    {
        var client = _httpClientFactory.CreateClient(ClientName);

        try
        {
            var validationResponse = await client.GetFromJsonAsync<ValidationDto>(_apiSettings.ValidationRoute);

            return validationResponse.IsValid;
        }
        catch (Exception e)
        {
            return false;
        }
    }
}

internal class ValidationDto
{
    [JsonPropertyName("isValid")]
    public required bool IsValid { get; init; }
}
