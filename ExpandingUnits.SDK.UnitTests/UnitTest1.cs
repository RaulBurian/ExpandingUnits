using FluentAssertions;

namespace ExpandingUnits.SDK.UnitTests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        // Arrange
        var fizBuz = new FizzBuzz();

        // Act
        var result = fizBuz.Fizzbuzz(15);

        // Assert
        result.Should().Be("1 2 Fizz 4 Buzz Fizz 7 8 Fizz Buzz 11 Fizz 13 14 FizzBuzz ");
    }
}
