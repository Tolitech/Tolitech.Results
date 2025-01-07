namespace Tolitech.Results.UnitTests;

/// <summary>
/// Unit tests for the Result class with scenarios related to results indicating a forbidden request (Result.Forbidden()).
/// </summary>
public class ResultForbiddenTests
{
    /// <summary>
    /// Unit test to verify the behavior of the Forbidden method when called with no parameters.
    /// </summary>
    [Fact]
    public void Forbidden_NoParameters_ReturnsFailureWithStatusCode403()
    {
        // Arrange & Act
        Result result = Result.Forbidden();

        // Assert
        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Equal(StatusCode.Forbidden, result.StatusCode);
    }

    /// <summary>
    /// Unit test to verify that calling Forbidden from Accedpted status should result in IsFailure.
    /// </summary>
    [Fact]
    public void Forbidden_FromAcceptedWithValue_ShouldResultInIsFailureWithNoContent()
    {
        // Arrange
        Result<string> result = Result.Accepted("Test");

        // Act
        _ = result.Forbidden();

        // Assert
        Assert.True(result.IsFailure);
        Assert.True(string.IsNullOrEmpty(result.Value));
        Assert.Equal(StatusCode.Forbidden, result.StatusCode);
    }
}