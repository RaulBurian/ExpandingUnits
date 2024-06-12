using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Nodes;
using ExpandingUnits.UnitTests.Fixture;
using ExpandingUnits.UnitTests.HttpSubs;
using FluentAssertions;
using Xunit.Abstractions;

namespace ExpandingUnits.UnitTests.Tests;

public class CreateItemTests : BaseTest
{
    public CreateItemTests(SqlFixture fixture, ITestOutputHelper testOutputHelper) : base(fixture, testOutputHelper)
    {
    }

    [Fact]
    public async Task CreateItem_WhenCreationSucceeds()
    {
        // Arrange
        ValidationApiServer.ResponsesQueue.Enqueue(HttpServer.Response.Ok(
            """
            {
                "isValid": true
            }
            """
            ));

        // Act
        var response = await Client.PostAsync("/items", new StringContent(
            """
            {
                "name": "item1",
                "quantity": 8
            }
            """, Encoding.UTF8, "application/json"
            ));

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var responseAsJson = await response.Content.ReadFromJsonAsync<JsonNode>();

        responseAsJson["isSuccessful"].GetValue<bool>().Should().BeTrue();
        responseAsJson["item"]["name"].GetValue<string>().Should().Be("item1");
        responseAsJson["item"]["quantity"].GetValue<int>().Should().Be(8);

        ItemsDbContext.Items.Count().Should().Be(1);
        ThirdPartyLibrarySub.SentEvents.Should().HaveCount(1);

        var sentEvent = ThirdPartyLibrarySub.SentEvents[0];
        sentEvent.Name.Should().Be("Items");
        sentEvent.Action.Should().Be("Create success");
    }

    [Theory]
    [MemberData(nameof(FailureData))]
    public async Task CreateItem_WhenCreationFails(HttpServer.Response validationResponse)
    {
        // Arrange
        ValidationApiServer.ResponsesQueue.Enqueue(validationResponse);

        // Act
        var response = await Client.PostAsync("/items", new StringContent(
            """
            {
                "name": "item1",
                "quantity": 8
            }
            """, Encoding.UTF8, "application/json"
        ));

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var responseAsJson = await response.Content.ReadFromJsonAsync<JsonNode>();

        responseAsJson["isSuccessful"].GetValue<bool>().Should().BeFalse();
        responseAsJson["item"].Should().BeNull();

        ItemsDbContext.Items.Count().Should().Be(0);
        ThirdPartyLibrarySub.SentEvents.Should().HaveCount(0);
    }

    public static IEnumerable<object[]> FailureData()
    {
        yield return
        [
            HttpServer.Response.Ok(
                """
                {
                    "isValid": false
                }
                """
            )
        ];

        yield return
        [
            HttpServer.Response.InternalServerError()
        ];

        yield return
        [
            HttpServer.Response.WithOperationCanceledException()
        ];
    }
}
