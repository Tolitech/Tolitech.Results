namespace Tolitech.Results.Guards.UnitTests;

/// <summary>
/// Unit tests for the numeric-related guard methods.
/// </summary>
public class NumericTests
{
    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfNull method with a null value.
    /// </summary>
    [Fact]
    public void ErrorIfLessThan_WithMessage_ReturnsFailureInResult()
    {
        // Arrange
        IResult result = Result.OK();
        const int age = 17;

        // Act
        result.Guard(age).ErrorIfLessThan(18, message: "Invalid age.").End();

        // Assert
        Assert.True(result.IsFailure);
        Assert.Equal("age", result.Errors.First().Key);
        Assert.Equal("Invalid age.", result.Errors.First().Message);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfNull method with a null value.
    /// </summary>
    [Fact]
    public void ErrorIfLessThan_WithoutMessage_ReturnsFailureInResult()
    {
        // Arrange
        IResult result = Result.OK();
        const int age = 17;

        // Act
        result.Guard(age).ErrorIfLessThan(18).End();

        // Assert
        Assert.True(result.IsFailure);
        Assert.Equal("age", result.Errors.First().Key);
    }
}