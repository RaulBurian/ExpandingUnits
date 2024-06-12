using ExpandingUnitNonAPI;
using Xunit.Abstractions;

namespace ExpandingUnitsNonAPI.UnitTests.TestObjects;

public class TestIOService : IIOService
{
    private readonly ITestOutputHelper _output;

    public string ReadLineValue { get; set; } = string.Empty;

    public List<string> Texts { get; } = [];

    public TestIOService(ITestOutputHelper output)
    {
        _output = output;
    }

    public string ReadLine()
    {
        return ReadLineValue;
    }

    public void Write(string text)
    {
        _output.WriteLine($"Test output: {text}");
        Texts.Add(text);
    }
}