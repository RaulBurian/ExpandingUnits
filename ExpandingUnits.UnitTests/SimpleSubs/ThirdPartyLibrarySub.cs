using ExpandingUnits.Api.Services;

namespace ExpandingUnits.UnitTests.SimpleSubs;

public class ThirdPartyLibrarySub : IThirdPartyLibraryService
{
    public List<ThirdPartyEvent> SentEvents { get; } = [];

    public Task SendEvent(ThirdPartyEvent evt)
    {
        SentEvents.Add(evt);

        return Task.CompletedTask;
    }
}

#region Hidden
public class ThirdPartyLibrarySubEx : IThirdPartyLibraryService
{
    public Task SendEvent(ThirdPartyEvent evt)
    {
        throw new Exception();
    }
}
#endregion
