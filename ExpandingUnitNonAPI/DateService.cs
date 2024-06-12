namespace ExpandingUnitNonAPI;

public interface IDateService
{
    public DateTimeOffset UtcNow { get; }
}

public class DateService : IDateService
{
    public DateTimeOffset UtcNow => DateTimeOffset.UtcNow;
}