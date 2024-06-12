using ExpandingUnitNonAPI;

namespace ExpandingUnitsNonAPI.UnitTests.TestObjects;

public class TestDateService : IDateService
{
    public DateTimeOffset UtcNow { get; set; } = DateTimeOffset.UtcNow;
}