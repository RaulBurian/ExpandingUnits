using ExpandingUnits.Api.EF;
using ExpandingUnits.Api.Services;
using ExpandingUnits.UnitTests.Fixture;
using ExpandingUnits.UnitTests.HttpSubs;
using ExpandingUnits.UnitTests.SimpleSubs;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Testcontainers.MsSql;
using Xunit.Abstractions;
using Xunit.Extensions.AssemblyFixture;

namespace ExpandingUnits.UnitTests;

public class BaseTest : IAsyncLifetime, IAssemblyFixture<SqlFixture>
{
    private readonly MsSqlContainer _msSqlContainer;

    public HttpClient Client { get; private set; }

    public ItemsDbContext ItemsDbContext { get; private set; }

    public ITestOutputHelper Output { get; set; }

    public ThirdPartyLibrarySub ThirdPartyLibrarySub { get; } = new();

    public HttpServer ValidationApiServer { get; } = new();

    public BaseTest(SqlFixture fixture, ITestOutputHelper testOutputHelper)
    {
        _msSqlContainer = fixture.MsSqlContainer;
        Output = testOutputHelper;
    }

    public async Task InitializeAsync()
    {
        var connectionString = await InitialiseDbSchema();

        var waf = new WebApplicationFactory<Program>()
            .WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    // services.AddSingleton<ILoggerProvider>(new TestOutputHelperLoggingProvider(Output));

                    var dbContextDescriptor = services
                        .First(s => s.ServiceType == typeof(DbContextOptions<ItemsDbContext>));
                    var itemsDbContext = services
                        .First(s => s.ServiceType == typeof(ItemsDbContext));

                    services.Remove(dbContextDescriptor);
                    services.Remove(itemsDbContext);

                    services.AddDbContext<ItemsDbContext>(opts => { opts.UseSqlServer(connectionString); });

                    services.AddSingleton<IThirdPartyLibraryService>(ThirdPartyLibrarySub);
                    // services.AddSingleton<IThirdPartyLibraryService>(new ThirdPartyLibrarySubEx());

                    services.AddSingleton<IHttpClientFactory>(new TestHttpClientFactory(new Dictionary<string, TestHttpClientFactory.HttpServerInfo>
                    {
                        [ValidationApiService.ClientName] = new (ValidationApiServer, "http://test.com")
                    }));
                });
            });

        Client = waf.CreateClient();

        var scope = waf.Services.CreateScope();

        ItemsDbContext = scope.ServiceProvider.GetRequiredService<ItemsDbContext>();
    }

    public Task DisposeAsync()
    {
        return Task.CompletedTask;
    }

    private async Task<string> InitialiseDbSchema()
    {
        var guid = Guid.NewGuid().ToString();

        await using var sqlConnection = new SqlConnection(_msSqlContainer.GetConnectionString());

        await using var createDbCommand = new SqlCommand($"create database [{guid}];", sqlConnection);
        await using var createTableCommand = new SqlCommand(
            $"""
            use [{guid}];
            create table Item(
            id int primary key identity,
            name varchar(16) not null,
            quantity int not null
            );
            """, sqlConnection);

        await sqlConnection.OpenAsync();

        await createDbCommand.ExecuteNonQueryAsync();
        await createTableCommand.ExecuteNonQueryAsync();

        await sqlConnection.CloseAsync();

        return _msSqlContainer.GetConnectionString().Replace("Database=master", $"Database={guid}");
    }
}
