using System.Net.Http.Json;
using System.Text.Json.Nodes;
using ExpandingUnits.Api.EF;
using ExpandingUnits.UnitTests.Fixture;
using FluentAssertions;
using Xunit.Abstractions;

namespace ExpandingUnits.UnitTests.Tests;

public class GetItemsTests : BaseTest
{
    public GetItemsTests(SqlFixture fixture, ITestOutputHelper testOutputHelper) : base(fixture, testOutputHelper)
    {
    }

    [Fact]
    public async Task GetItems_ReturnsNoItems_WhenDbIsEmpty()
    {
        // Act
        var response = await Client.GetFromJsonAsync<JsonNode>("/items");

        // Assert
        response["items"].AsArray().Should().BeEmpty();
    }

    [Fact]
    public async Task GetItems_ReturnsPresentItems_WhenItemsExist()
    {
        // Arrange
        await ItemsDbContext.Items.AddAsync(new EntityItem
        {
            ItemId = 0,
            ItemName = "name",
            ItemQuantity = 5
        });
        await ItemsDbContext.SaveChangesAsync();

        // Act
        var response = await Client.GetFromJsonAsync<JsonNode>("/items");

        // Assert
        response["items"].AsArray().Should().HaveCount(1);
        var item = response["items"][0];

        item["id"].GetValue<int>().Should().NotBe(0);
        item["name"].GetValue<string>().Should().Be("name");
        item["quantity"].GetValue<int>().Should().Be(5);
    }

    [Fact]
    public async Task GetItems_ReturnsNoItems_WhenDbIsEmpty_Again()
    {
        // Act
        var response = await Client.GetFromJsonAsync<JsonNode>("/items");

        // Assert
        response["items"].AsArray().Should().BeEmpty();
    }

    [Fact]
    public async Task GetItems_ReturnsPresentItems_WhenItemsExistAgain()
    {
        // Arrange
        await ItemsDbContext.Items.AddAsync(new EntityItem
        {
            ItemId = 0,
            ItemName = "name",
            ItemQuantity = 5
        });
        await ItemsDbContext.SaveChangesAsync();

        // Act
        var response = await Client.GetFromJsonAsync<JsonNode>("/items");

        // Assert
        response["items"].AsArray().Should().HaveCount(1);
        var item = response["items"][0];

        item["id"].GetValue<int>().Should().NotBe(0);
        item["name"].GetValue<string>().Should().Be("name");
        item["quantity"].GetValue<int>().Should().Be(5);
    }
}
