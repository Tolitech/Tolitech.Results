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

    /// <summary>
    /// Unit test to verify the behavior of the Conflict method when called with detail parameter.
    /// </summary>
    [Fact]
    public void Conflict_DetailParameter_ReturnsFailureWithStatusCode409()
    {
        // Arrange & Act
        Result result = Result.Conflict("Detail");

        // Assert
        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Equal(StatusCode.Conflict, result.StatusCode);
        Assert.Null(result.Title);
        Assert.Equal("Detail", result.Detail);
    }

    /// <summary>
    /// Unit test to verify the behavior of the Conflict method when called with title and detail parameters.
    /// </summary>
    [Fact]
    public void Conflict_TitleAndDetailParameters_ReturnsFailureWithStatusCode409()
    {
        // Arrange & Act
        Result result = Result.Conflict("Title", "Detail");

        // Assert
        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Equal(StatusCode.Conflict, result.StatusCode);
        Assert.Equal("Title", result.Title);
        Assert.Equal("Detail", result.Detail);
    }

    /// <summary>
    /// Unit test to verify the behavior of the Conflict method when called with detail parameter.
    /// </summary>
    [Fact]
    public void Conflict_GenericWithDetailParameter_ReturnsFailureWithStatusCode409()
    {
        // Arrange
        Result<string> result = Result.OK("Test");

        // Act
        result = result.Conflict("Detail");

        // Assert
        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Equal(StatusCode.Conflict, result.StatusCode);
        Assert.Null(result.Title);
        Assert.Equal("Detail", result.Detail);
    }

    /// <summary>
    /// Unit test to verify the behavior of the Conflict method when called with title and detail parameters.
    /// </summary>
    [Fact]
    public void Conflict_GenericWithTitleAndDetailParameters_ReturnsFailureWithStatusCode409()
    {
        // Arrange
        Result<string> result = Result.OK("Test");

        // Act
        result = result.Conflict("Title", "Detail");

        // Assert
        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Equal(StatusCode.Conflict, result.StatusCode);
        Assert.Equal("Title", result.Title);
        Assert.Equal("Detail", result.Detail);
    }
}