namespace Tolitech.Results.UnitTests;

/// <summary>
/// Unit tests for the Result class with scenarios related to successful results (Result.Accepted()).
/// </summary>
public class ResultAcceptedTests
{
    /// <summary>
    /// Unit test to verify the behavior of the Accepted method when called with no parameters.
    /// </summary>
    [Fact]
    public void Accept_NoParameters_ReturnsSuccessWithStatusCode202()
    {
        // Arrange & Act
        IResult result = Result.Accepted();

        // Assert
        Assert.True(result.IsSuccess);
        Assert.False(result.IsFailure);
        Assert.Equal(StatusCode.Accepted, result.StatusCode);
    }

    /// <summary>
    /// Unit test to verify the behavior of the Accepted method when called with a value as a string parameter.
    /// </summary>
    [Fact]
    public void Accepted_ValueAsString_ReturnsSuccessWithStatusCode202AndCorrectValue()
    {
        // Arrange & Act
        IResult<string> result = Result<string>.Accepted("Hello, world!");

        // Assert
        Assert.True(result.IsSuccess);
        Assert.False(result.IsFailure);
        Assert.Equal(StatusCode.Accepted, result.StatusCode);
        Assert.Equal("Hello, world!", result.Value);
    }

    /// <summary>
    /// Unit test to verify that calling Accepted from NoContent status should result in IsSuccess.
    /// </summary>
    [Fact]
    public void Accepted_FromNoContent_ShouldResultInIsSuccess()
    {
        // Arrange
        IResult<string> result = Result<string>.NoContent();

        // Act
        _ = result.Accepted("Test");

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal("Test", result.Value);
        Assert.Equal(StatusCode.Accepted, result.StatusCode);
    }

    /// <summary>
    /// Unit test to verify the behavior of the Accepted method when called with no parameters.
    /// </summary>
    [Fact]
    public void Accept_Extensions_ReturnsSuccessWithStatusCode202()
    {
        // Arrange & Act
        IResult result = Result.NoContent().Accepted();

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(StatusCode.Accepted, result.StatusCode);
    }
}