using System.Globalization;

namespace ExpandingUnitNonAPI;

public class Runner
{
    private readonly IValidationApiService _validationApiService;
    private readonly IIOService _ioService;
    private readonly IDateService _dateService;

    public Runner(IValidationApiService validationApiService, IIOService ioService, IDateService dateService)
    {
        _validationApiService = validationApiService;
        _ioService = ioService;
        _dateService = dateService;
    }

    public async Task Run()
    {
        _ioService.Write("Input date ISO:");

        var date = _ioService.ReadLine()!;

        if (DateTimeOffset.TryParse(date, CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal,
                out var dateTimeOffset))
        {
            if (dateTimeOffset < _dateService.UtcNow)
            {
                var isValid = await _validationApiService.ValidateItem();

                _ioService.Write(isValid ? "Valid" : "Invalid");
            }
            else
            {
                _ioService.Write("Invalid date");
            }
        }
    }
}