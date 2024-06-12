using System.Collections.Concurrent;
using Microsoft.Extensions.Logging;
using Xunit.Abstractions;

namespace ExpandingUnits.UnitTests.Logging;

public class TestOutputHelperLoggingProvider : ILoggerProvider
{
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly ConcurrentDictionary<string, TestOutputLogger> _loggers = new();

    public TestOutputHelperLoggingProvider(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
        _loggers.Clear();
    }

    public ILogger CreateLogger(string categoryName)
    {
        return _loggers.GetOrAdd(categoryName, new TestOutputLogger(_testOutputHelper, categoryName));
    }
}

public class TestOutputLogger : ILogger
{
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly string _categoryName;

    public TestOutputLogger(ITestOutputHelper testOutputHelper, string categoryName)
    {
        _testOutputHelper = testOutputHelper;
        _categoryName = categoryName;
    }

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
    {
        _testOutputHelper.WriteLine($"{_categoryName}: [{logLevel}] {formatter(state, exception)}");
    }

    public bool IsEnabled(LogLevel logLevel)
    {
        return true;
    }

    public IDisposable BeginScope<TState>(TState state) where TState : notnull
    {
        return new Disposable();
    }

    private class Disposable : IDisposable
    {
        public void Dispose()
        {
        }
    }
}
