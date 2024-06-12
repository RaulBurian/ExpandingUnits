var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/validateItem", () => Results.Ok(new
{
    IsValid = Random.Shared.Next() % 2 == 0
}));
app.Run();
