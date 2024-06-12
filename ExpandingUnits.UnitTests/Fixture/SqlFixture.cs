using Testcontainers.MsSql;

namespace ExpandingUnits.UnitTests.Fixture;

public class SqlFixture : IAsyncLifetime
{
    public MsSqlContainer MsSqlContainer { get; } = new MsSqlBuilder().Build();

    public async Task InitializeAsync()
    {
        await MsSqlContainer.StartAsync();
    }

    public async Task DisposeAsync()
    {
        await MsSqlContainer.DisposeAsync();
    }
}
