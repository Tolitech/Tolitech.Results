namespace Tolitech.Results.UnitTests;

/// <summary>
/// Unit tests for the Result class with scenarios related to results indicating a service unavailable (Result.ServiceUnavaiable()).
/// </summary>
public class ResultServiceUnavailableTest
{
    /// <summary>
    /// Unit test to verify the behavior of the ServiceUnavailable method when called with no parameters.
    /// </summary>
    [Fact]
    public void ServiceUnavailable_NoParameters_ReturnsFailureWithStatusCode503()
    {
        // Arrange & Act
        Result result = Result.ServiceUnavailable();

        // Assert
        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Equal(StatusCode.ServiceUnavailable, result.StatusCode);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ServiceUnavailable method when called with a value as a string parameter.
    /// </summary>
    [Fact]
    public void ServiceUnavailable_ValueAsString_ReturnsFailureWithStatusCode503AndCorrectValue()
    {
        // Arrange & Act
        Result<string> result = Result.ServiceUnavailable("Hello, world!");

        // Assert
        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Equal(StatusCode.ServiceUnavailable, result.StatusCode);
        Assert.Equal("Hello, world!", result.Value);
    }

    /// <summary>
    /// Unit test to verify that calling ServiceUnavailable from Accedpted status should result in IsFailure.
    /// </summary>
    [Fact]
    public void ServiceUnavailable_FromAcceptedWithValue_ShouldResultInIsFailureWithNoContent()
    {
        // Arrange
        Result<string> result = Result.Accepted("Test");

        // Act
        _ = result.ServiceUnavailable();

        // Assert
        Assert.True(result.IsFailure);
        Assert.True(string.IsNullOrEmpty(result.Value));
        Assert.Equal(StatusCode.ServiceUnavailable, result.StatusCode);
    }
}