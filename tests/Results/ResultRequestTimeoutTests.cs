namespace Tolitech.Results.UnitTests;

/// <summary>
/// Unit tests for the Result class with scenarios related to results indicating a request timeout (Result.RequestTimeout()).
/// </summary>
public class ResultRequestTimeoutTests
{
    /// <summary>
    /// Unit test to verify the behavior of the RequestTimeout method when called with no parameters.
    /// </summary>
    [Fact]
    public void RequestTimeout_NoParameters_ReturnsFailureWithStatusCode408()
    {
        // Arrange & Act
        Result result = Result.RequestTimeout();

        // Assert
        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Equal(StatusCode.RequestTimeout, result.StatusCode);
    }

    /// <summary>
    /// Unit test to verify that calling RequestTimeout from Accedpted status should result in IsFailure.
    /// </summary>
    [Fact]
    public void RequestTimeout_FromAcceptedWithValue_ShouldResultInIsFailureWithNoContent()
    {
        // Arrange
        Result<string> result = Result.Accepted("Test");

        // Act
        _ = result.RequestTimeout();

        // Assert
        Assert.True(result.IsFailure);
        Assert.True(string.IsNullOrEmpty(result.Value));
        Assert.Equal(StatusCode.RequestTimeout, result.StatusCode);
    }

    /// <summary>
    /// Unit test to verify the behavior of the RequestTimeout method when called with detail parameter.
    /// </summary>
    [Fact]
    public void RequestTimeout_DetailParameter_ReturnsFailureWithStatusCode408()
    {
        // Arrange & Act
        Result result = Result.RequestTimeout("Detail");

        // Assert
        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Equal(StatusCode.RequestTimeout, result.StatusCode);
        Assert.Null(result.Title);
        Assert.Equal("Detail", result.Detail);
    }

    /// <summary>
    /// Unit test to verify the behavior of the RequestTimeout method when called with title and detail parameters.
    /// </summary>
    [Fact]
    public void RequestTimeout_TitleAndDetailParameters_ReturnsFailureWithStatusCode408()
    {
        // Arrange & Act
        Result result = Result.RequestTimeout("Title", "Detail");

        // Assert
        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Equal(StatusCode.RequestTimeout, result.StatusCode);
        Assert.Equal("Title", result.Title);
        Assert.Equal("Detail", result.Detail);
    }

    /// <summary>
    /// Unit test to verify the behavior of the RequestTimeout method when called with detail parameter.
    /// </summary>
    [Fact]
    public void RequestTimeout_GenericWithDetailParameter_ReturnsFailureWithStatusCode408()
    {
        // Arrange
        Result<string> result = Result.OK("Test");

        // Act
        result = result.RequestTimeout("Detail");

        // Assert
        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Equal(StatusCode.RequestTimeout, result.StatusCode);
        Assert.Null(result.Title);
        Assert.Equal("Detail", result.Detail);
    }

    /// <summary>
    /// Unit test to verify the behavior of the RequestTimeout method when called with title and detail parameters.
    /// </summary>
    [Fact]
    public void RequestTimeout_GenericWithTitleAndDetailParameters_ReturnsFailureWithStatusCode408()
    {
        // Arrange
        Result<string> result = Result.OK("Test");

        // Act
        result = result.RequestTimeout("Title", "Detail");

        // Assert
        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Equal(StatusCode.RequestTimeout, result.StatusCode);
        Assert.Equal("Title", result.Title);
        Assert.Equal("Detail", result.Detail);
    }
}