using ExpandingUnits.Api.EF;
using ExpandingUnits.Api.Requests;
using ExpandingUnits.Api.Responses;
using ExpandingUnits.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IItemsService, ItemsService>();

var validationApiSettings = builder.Configuration.GetSection("ValidationApiSettings").Get<ValidationApiSettings>()!;
builder.Services.AddSingleton(validationApiSettings);
builder.Services.AddHttpClient(ValidationApiService.ClientName, client => { client.BaseAddress = new Uri(validationApiSettings.BaseUrl); });
builder.Services.AddSingleton<IValidationApiService, ValidationApiService>();

builder.Services.AddDbContext<ItemsDbContext>(opts =>
{
    opts.UseSqlServer(builder.Configuration["SqlConnectionString"]);
});
builder.Services.AddScoped<IItemsDataAccessService, ItemsDataAccessService>();
builder.Services.AddSingleton<IThirdPartyLibraryService>(new ThirdPartyLibraryService(new ThirdPartySdk()));
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/items", async (IItemsDataAccessService dataAccessService, IValidationApiService validationApiService, IThirdPartyLibraryService thirdPartyLibraryService, ILogger<ItemsService> logger) =>
    {
        var entityItems = await dataAccessService.GetItems();

        logger.LogInformation("Retrieved items from DB");

        await thirdPartyLibraryService.SendEvent(new ThirdPartyEvent("Items", $"Get {entityItems.Length}"));

        logger.LogInformation("Sent Items Get event");

        var items = entityItems.Select(item => new Item(item.ItemId, item.ItemName, item.ItemQuantity)).ToArray();

        return Results.Ok(new GetItemsResponse
        {
            Items = items.Select(item => new GetItemsResponse.Item
            {
                Id = item.Id,
                Name = item.Name,
                Quantity = item.Quantity
            }).ToArray()
        });
    })
    .WithOpenApi();

app.MapPost("/items", async ([FromBody] CreateItemRequest createItemRequest, IItemsService itemsService) =>
    {
        var createdItem = await itemsService.CreateItem(createItemRequest.Name, createItemRequest.Quantity);

        return Results.Ok(new CreateItemResponse
        {
            IsSuccessful = createdItem is not null,
            CreatedItem = createdItem is not null
                ? new CreateItemResponse.Item
                {
                    Id = createdItem.Id,
                    Name = createItemRequest.Name,
                    Quantity = createdItem.Quantity
                }
                : null
        });
    })
    .WithOpenApi();

app.Run();

public partial class Program;
