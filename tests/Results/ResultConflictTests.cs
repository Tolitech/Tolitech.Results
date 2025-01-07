namespace Tolitech.Results.UnitTests;

/// <summary>
/// Unit tests for the Result class with scenarios related to results indicating a conflict (Result.Conflict()).
/// </summary>
public class ResultConflictTests
{
    /// <summary>
    /// Unit test to verify the behavior of the Conflict method when called with no parameters.
    /// </summary>
    [Fact]
    public void Conflict_NoParameters_ReturnsFailureWithStatusCode409()
    {
        // Arrange & Act
        Result result = Result.Conflict();

        // Assert
        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Equal(StatusCode.Conflict, result.StatusCode);
    }

    /// <summary>
    /// Unit test to verify that calling Conflict from Accedpted status should result in IsFailure.
    /// </summary>
    [Fact]
    public void Conflict_FromAcceptedWithValue_ShouldResultInIsFailureWithNoContent()
    {
        // Arrange
        Result<string> result = Result.Accepted("Test");

        // Act
        _ = result.Conflict();

        // Assert
        Assert.True(result.IsFailure);
        Assert.True(string.IsNullOrEmpty(result.Value));
        Assert.Equal(StatusCode.Conflict, result.StatusCode);
    }
}