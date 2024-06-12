using ExpandingUnitNonAPI;
using ExpandingUnitsNonAPI.UnitTests.TestObjects;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Xunit.Abstractions;

namespace ExpandingUnitsNonAPI.UnitTests;

public class UnitTest
{
    public TestDateService DateService { get; } = new();
    
    public HttpServer ValidationServer { get; } = new();
    
    public TestIOService IoService { get; }
    
    public Runner Runner { get; }

    public UnitTest(ITestOutputHelper output)
    {
        IoService = new TestIOService(output);
        
        // Careful if you construct the graph separately in tests as it may drift from the real app if not paying attention
        var services = new ServiceCollection();

        services.AddSingleton<Runner>();
        services.AddSingleton<IDateService>(DateService);
        services.AddSingleton<IIOService>(IoService);

        services.AddSingleton(new ValidationApiSettings("dummy", "dummy"));
        services.AddSingleton<IValidationApiService, ValidationApiService>();
        services.AddSingleton<IHttpClientFactory>(new TestHttpClientFactory(new Dictionary<string, TestHttpClientFactory.HttpServerInfo>
        {
            [ValidationApiService.ClientName] = new (ValidationServer, "http://test.com")
        }));

        var sp = services.BuildServiceProvider();

        Runner = sp.GetRequiredService<Runner>();
    }

    [Fact]
    public async Task Test()
    {
        // Arrange
        DateService.UtcNow = new DateTimeOffset(2024, 06, 06, 0, 0, 0, TimeSpan.Zero);
        IoService.ReadLineValue = "2024-05-05";
        
        ValidationServer.ResponsesQueue.Enqueue(HttpServer.Response.Ok(
            """
            {
                "isValid": true
            }
            """
        ));
        
        // Act
        await Runner.Run();

        // Assert
        IoService.Texts[1].Should().Be("Valid");
    }
}