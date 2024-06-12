using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ExpandingUnits.Api.EF;

public class ItemsDbContext : DbContext
{
    public ItemsDbContext(DbContextOptions<ItemsDbContext> options) : base(options)
    {
    }

    public DbSet<EntityItem> Items { get; set; }
}

[Table("Item")]
public class EntityItem
{
    [Key]
    [Column("id")]
    public required int ItemId { get; set; }

    [Column("name")]
    [MaxLength(16)]
    public required string ItemName { get; set; }

    [Column("quantity")]
    public required int ItemQuantity { get; set; }
}
