using System.Text.Json.Serialization;

namespace ExpandingUnits.Api.Requests;

public class CreateItemRequest
{
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("quantity")]
    public required int Quantity { get; set; }
}
