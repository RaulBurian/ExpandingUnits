namespace ExpandingUnits.Api.Services;

/// <summary>
/// This simulates the use case where we are using a type that normally has no substitute so we have a controllable wrapper around it
/// </summary>
internal interface IThirdPartyLibraryService
{
    Task SendEvent(ThirdPartyEvent evt);
}

internal class ThirdPartyLibraryService : IThirdPartyLibraryService
{
    private ThirdPartySdk _thirdPartySdk;

    public ThirdPartyLibraryService(ThirdPartySdk thirdPartySdk)
    {
        _thirdPartySdk = thirdPartySdk;
    }

    public Task SendEvent(ThirdPartyEvent evt)
    {
        // here the app will use the Third Party sdk directly
        return _thirdPartySdk.UnMockableMethod(evt);
    }
}

#region Hidden
public record ThirdPartyEvent(string Name, string Action);

public class ThirdPartySdk
{
    public Task UnMockableMethod(ThirdPartyEvent evt)
    {
        return Task.CompletedTask;
    }
}
#endregion
