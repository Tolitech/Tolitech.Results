namespace Tolitech.Results.UnitTests;

/// <summary>
/// Unit tests for the Result class with scenarios related to results indicating a resource was not found (Result.NotFound()).
/// </summary>
public class ResultNotFoundTests
{
    /// <summary>
    /// Unit test to verify the behavior of the NotFound method when called with no parameters.
    /// </summary>
    [Fact]
    public void NotFound_NoParameters_ReturnsFailureWithStatusCode404()
    {
        // Arrange & Act
        Result result = Result.NotFound();

        // Assert
        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Equal(StatusCode.NotFound, result.StatusCode);
    }

    /// <summary>
    /// Unit test to verify the behavior of the NotFound method when called with a value as a string parameter.
    /// </summary>
    [Fact]
    public void NotFound_ValueAsString_ReturnsFailureWithStatusCode404AndCorrectValue()
    {
        // Arrange & Act
        Result<string> result = Result.NotFound("Hello, world!");

        // Assert
        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Equal(StatusCode.NotFound, result.StatusCode);
        Assert.Equal("Hello, world!", result.Value);
    }

    /// <summary>
    /// Unit test to verify that calling NotFound from Accedpted status should result in IsFailure.
    /// </summary>
    [Fact]
    public void NotFound_FromAcceptedWithValue_ShouldResultInIsFailureWithNoContent()
    {
        // Arrange
        Result<string> result = Result.Accepted("Test");

        // Act
        _ = result.NotFound();

        // Assert
        Assert.True(result.IsFailure);
        Assert.True(string.IsNullOrEmpty(result.Value));
        Assert.Equal(StatusCode.NotFound, result.StatusCode);
    }
}