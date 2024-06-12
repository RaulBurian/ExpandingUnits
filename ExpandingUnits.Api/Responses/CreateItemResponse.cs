using System.Text.Json.Serialization;

namespace ExpandingUnits.Api.Responses;

public class CreateItemResponse
{
    [JsonPropertyName("isSuccessful")]
    public required bool IsSuccessful { get; init; }

    [JsonPropertyName("item")]
    public required Item? CreatedItem { get; init; }

    public class Item
    {
        [JsonPropertyName("ID")]
        public required int Id { get; init; }

        [JsonPropertyName("name")]
        public required string Name { get; init; }

        [JsonPropertyName("quantity")]
        public required int Quantity { get; init; }
    }
}
