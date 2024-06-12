using ExpandingUnits.Api.EF;
using Microsoft.EntityFrameworkCore;

namespace ExpandingUnits.Api.Services;

internal interface IItemsDataAccessService
{
    Task<EntityItem[]> GetItems();

    Task<bool> CreateItem(EntityItem entityItem);
}

internal class ItemsDataAccessService : IItemsDataAccessService
{
    private readonly ItemsDbContext _itemsDbContext;

    public ItemsDataAccessService(ItemsDbContext itemsDbContext)
    {
        _itemsDbContext = itemsDbContext;
    }

    public async Task<EntityItem[]> GetItems()
    {
        return await _itemsDbContext.Items.ToArrayAsync();
    }

    public async Task<bool> CreateItem(EntityItem entityItem)
    {
        await _itemsDbContext.Items.AddAsync(entityItem);

        var updates = await _itemsDbContext.SaveChangesAsync();

        return updates > 0;
    }
}
