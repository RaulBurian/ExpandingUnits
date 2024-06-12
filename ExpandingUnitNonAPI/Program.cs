using ExpandingUnitNonAPI;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

services.AddSingleton<Runner>();
services.AddSingleton<IValidationApiService, ValidationApiService>();
services.AddSingleton<IDateService, DateService>();
services.AddSingleton<IIOService, IOService>();
services.AddSingleton(new ValidationApiSettings("http://localhost:8080", "/validateItem"));
services.AddHttpClient(ValidationApiService.ClientName,
    client => { client.BaseAddress = new Uri("http://localhost:8080"); });

var sp = services.BuildServiceProvider();

var runner = sp.GetRequiredService<Runner>();

await runner.Run();