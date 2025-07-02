namespace Tolitech.Results.UnitTests;

/// <summary>
/// Unit tests for the Result class with scenarios related to results indicating a too many requests (Result.TooManyRequests()).
/// </summary>
public class ResultTooManyRequestsTests
{
    /// <summary>
    /// Unit test to verify the behavior of the TooManyRequests method when called with no parameters.
    /// </summary>
    [Fact]
    public void TooManyRequests_NoParameters_ReturnsFailureWithStatusCode429()
    {
        // Arrange & Act
        Result result = Result.TooManyRequests();

        // Assert
        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Equal(StatusCode.TooManyRequests, result.StatusCode);
    }

    /// <summary>
    /// Unit test to verify that calling TooManyRequests from Accedpted status should result in IsFailure.
    /// </summary>
    [Fact]
    public void TooManyRequests_FromAcceptedWithValue_ShouldResultInIsFailureWithNoContent()
    {
        // Arrange
        Result<string> result = Result.Accepted("Test");

        // Act
        _ = result.TooManyRequests();

        // Assert
        Assert.True(result.IsFailure);
        Assert.True(string.IsNullOrEmpty(result.Value));
        Assert.Equal(StatusCode.TooManyRequests, result.StatusCode);
    }

    /// <summary>
    /// Unit test to verify the behavior of the TooManyRequests method when called with detail parameter.
    /// </summary>
    [Fact]
    public void TooManyRequests_DetailParameter_ReturnsFailureWithStatusCode429()
    {
        // Arrange & Act
        Result result = Result.TooManyRequests("Detail");

        // Assert
        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Equal(StatusCode.TooManyRequests, result.StatusCode);
        Assert.Null(result.Title);
        Assert.Equal("Detail", result.Detail);
    }

    /// <summary>
    /// Unit test to verify the behavior of the TooManyRequests method when called with title and detail parameters.
    /// </summary>
    [Fact]
    public void TooManyRequests_TitleAndDetailParameters_ReturnsFailureWithStatusCode429()
    {
        // Arrange & Act
        Result result = Result.TooManyRequests("Title", "Detail");

        // Assert
        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Equal(StatusCode.TooManyRequests, result.StatusCode);
        Assert.Equal("Title", result.Title);
        Assert.Equal("Detail", result.Detail);
    }

    /// <summary>
    /// Unit test to verify the behavior of the TooManyRequests method when called with detail parameter.
    /// </summary>
    [Fact]
    public void TooManyRequests_GenericWithDetailParameter_ReturnsFailureWithStatusCode429()
    {
        // Arrange
        Result<string> result = Result.OK("Test");

        // Act
        result = result.TooManyRequests("Detail");

        // Assert
        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Equal(StatusCode.TooManyRequests, result.StatusCode);
        Assert.Null(result.Title);
        Assert.Equal("Detail", result.Detail);
    }

    /// <summary>
    /// Unit test to verify the behavior of the TooManyRequests method when called with title and detail parameters.
    /// </summary>
    [Fact]
    public void TooManyRequests_GenericWithTitleAndDetailParameters_ReturnsFailureWithStatusCode429()
    {
        // Arrange
        Result<string> result = Result.OK("Test");

        // Act
        result = result.TooManyRequests("Title", "Detail");

        // Assert
        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Equal(StatusCode.TooManyRequests, result.StatusCode);
        Assert.Equal("Title", result.Title);
        Assert.Equal("Detail", result.Detail);
    }
}