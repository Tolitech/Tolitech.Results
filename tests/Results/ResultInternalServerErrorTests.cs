namespace Tolitech.Results.UnitTests;

/// <summary>
/// Unit tests for the Result class with scenarios related to results indicating an internal server error (Result.InternalServerError()).
/// </summary>
public class ResultInternalServerErrorTests
{
    /// <summary>
    /// Unit test to verify the behavior of the InternalServerError method when called with no parameters.
    /// </summary>
    [Fact]
    public void InternalServerError_NoParameters_ReturnsFailureWithStatusCode500()
    {
        // Arrange & Act
        Result result = Result.InternalServerError();

        // Assert
        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Equal(StatusCode.InternalServerError, result.StatusCode);
    }

    /// <summary>
    /// Unit test to verify that calling InternalServerError from Accedpted status should result in IsFailure.
    /// </summary>
    [Fact]
    public void InternalServerError_FromAcceptedWithValue_ShouldResultInIsFailureWithNoContent()
    {
        // Arrange
        Result<string> result = Result.Accepted("Test");

        // Act
        _ = result.InternalServerError();

        // Assert
        Assert.True(result.IsFailure);
        Assert.True(string.IsNullOrEmpty(result.Value));
        Assert.Equal(StatusCode.InternalServerError, result.StatusCode);
    }
}