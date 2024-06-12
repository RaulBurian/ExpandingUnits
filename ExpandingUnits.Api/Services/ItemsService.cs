using ExpandingUnits.Api.EF;

namespace ExpandingUnits.Api.Services;

internal interface IItemsService
{
    Task<Item[]> GetItems();

    Task<Item?> CreateItem(string name, int quantity);
}

internal class ItemsService : IItemsService
{
    private readonly IItemsDataAccessService _dataAccessService;
    private readonly IValidationApiService _validationApiService;
    private readonly IThirdPartyLibraryService _thirdPartyLibraryService;
    private readonly ILogger<ItemsService> _logger;

    public ItemsService(IItemsDataAccessService dataAccessService, IValidationApiService validationApiService, IThirdPartyLibraryService thirdPartyLibraryService, ILogger<ItemsService> logger)
    {
        _dataAccessService = dataAccessService;
        _validationApiService = validationApiService;
        _thirdPartyLibraryService = thirdPartyLibraryService;
        _logger = logger;
    }

    public async Task<Item[]> GetItems()
    {
        var entityItems = await _dataAccessService.GetItems();

        _logger.LogInformation("Retrieved items from DB");

        await _thirdPartyLibraryService.SendEvent(new ThirdPartyEvent("Items", $"Get {entityItems.Length}"));

        _logger.LogInformation("Sent Items Get event");

        return entityItems.Select(item => new Item(item.ItemId, item.ItemName, item.ItemQuantity)).ToArray();
    }

    public async Task<Item?> CreateItem(string name, int quantity)
    {
        var isValid = await _validationApiService.ValidateItem();

        if (!isValid)
        {
            _logger.LogInformation("Item is invalid");

            return null;
        }

        _logger.LogInformation("Item is valid");

        var entityItem = new EntityItem
        {
            ItemId = 0,
            ItemName = name,
            ItemQuantity = quantity
        };

        var isCreated = await _dataAccessService.CreateItem(entityItem);

        _logger.LogInformation("Item is created");

        await _thirdPartyLibraryService.SendEvent(new ThirdPartyEvent("Items", "Create success"));

        _logger.LogInformation("Event sent");

        return isCreated
            ? new Item(entityItem.ItemId, entityItem.ItemName, entityItem.ItemQuantity)
            : null;
    }
}

public record Item(int Id, string Name, int Quantity);
