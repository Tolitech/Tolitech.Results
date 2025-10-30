namespace Tolitech.Results.UnitTests;

/// <summary>
/// Unit tests for the Result class with scenarios related to results indicating no content (Result.NoContent()).
/// </summary>
public class ResultNoContentTests
{
    /// <summary>
    /// Unit test to verify the behavior of the NoContent method when called with no parameters.
    /// </summary>
    [Fact]
    public void NoContent_NoParameters_ReturnsSuccessWithStatusCode204()
    {
        // Arrange & Act
        IResult result = Result.NoContent();

        // Assert
        Assert.True(result.IsSuccess);
        Assert.False(result.IsFailure);
        Assert.Equal(StatusCode.NoContent, result.StatusCode);
    }

    /// <summary>
    /// Unit test to verify the behavior of the NoContent method when called with no value as a string parameter.
    /// </summary>
    [Fact]
    public void NoContent_NoValueAsString_ReturnsSuccessWithStatusCode204AndNullValue()
    {
        // Arrange & Act
        IResult<string> result = Result<string>.NoContent();

        // Assert
        Assert.True(result.IsSuccess);
        Assert.False(result.IsFailure);
        Assert.Equal(StatusCode.NoContent, result.StatusCode);
        Assert.Null(result.Value);
    }

    /// <summary>
    /// Unit test to verify that calling NoContent with NoContent status should result in IsSuccess.
    /// </summary>
    [Fact]
    public void NoContent_FromNoContent_ShouldResultInIsSuccess()
    {
        // Arrange
        IResult<string> result = Result<string>.NoContent();

        // Act
        _ = result.NoContent();

        // Assert
        Assert.True(result.IsSuccess);
        Assert.True(string.IsNullOrEmpty(result.Value));
        Assert.Equal(StatusCode.NoContent, result.StatusCode);
    }

    /// <summary>
    /// Unit test to verify the behavior of the NoContent method when called with no parameters.
    /// </summary>
    [Fact]
    public void NoContent_Extensions_ReturnsSuccessWithStatusCode204()
    {
        // Arrange & Act
        IResult result = Result.OK().NoContent();

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(StatusCode.NoContent, result.StatusCode);
    }
}