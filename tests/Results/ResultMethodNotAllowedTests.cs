namespace Tolitech.Results.UnitTests;

/// <summary>
/// Unit tests for the Result class with scenarios related to results indicating a method not allowed (Result.MethodNotAllowed()).
/// </summary>
public class ResultMethodNotAllowedTests
{
    /// <summary>
    /// Unit test to verify the behavior of the MethodNotAllowed method when called with no parameters.
    /// </summary>
    [Fact]
    public void MethodNotAllowed_NoParameters_ReturnsFailureWithStatusCode405()
    {
        // Arrange & Act
        Result result = Result.MethodNotAllowed();

        // Assert
        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Equal(StatusCode.MethodNotAllowed, result.StatusCode);
    }

    /// <summary>
    /// Unit test to verify that calling MethodNotAllowed from Accedpted status should result in IsFailure.
    /// </summary>
    [Fact]
    public void MethodNotAllowed_FromAcceptedWithValue_ShouldResultInIsFailureWithNoContent()
    {
        // Arrange
        Result<string> result = Result.Accepted("Test");

        // Act
        _ = result.MethodNotAllowed();

        // Assert
        Assert.True(result.IsFailure);
        Assert.True(string.IsNullOrEmpty(result.Value));
        Assert.Equal(StatusCode.MethodNotAllowed, result.StatusCode);
    }

    /// <summary>
    /// Unit test to verify the behavior of the MethodNotAllowed method when called with detail parameter.
    /// </summary>
    [Fact]
    public void MethodNotAllowed_DetailParameter_ReturnsFailureWithStatusCode405()
    {
        // Arrange & Act
        Result result = Result.MethodNotAllowed("Detail");

        // Assert
        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Equal(StatusCode.MethodNotAllowed, result.StatusCode);
        Assert.Null(result.Title);
        Assert.Equal("Detail", result.Detail);
    }

    /// <summary>
    /// Unit test to verify the behavior of the MethodNotAllowed method when called with title and detail parameters.
    /// </summary>
    [Fact]
    public void MethodNotAllowed_TitleAndDetailParameters_ReturnsFailureWithStatusCode405()
    {
        // Arrange & Act
        Result result = Result.MethodNotAllowed("Title", "Detail");

        // Assert
        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Equal(StatusCode.MethodNotAllowed, result.StatusCode);
        Assert.Equal("Title", result.Title);
        Assert.Equal("Detail", result.Detail);
    }

    /// <summary>
    /// Unit test to verify the behavior of the MethodNotAllowed method when called with detail parameter.
    /// </summary>
    [Fact]
    public void MethodNotAllowed_GenericWithDetailParameter_ReturnsFailureWithStatusCode405()
    {
        // Arrange
        Result<string> result = Result.OK("Test");

        // Act
        result = result.MethodNotAllowed("Detail");

        // Assert
        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Equal(StatusCode.MethodNotAllowed, result.StatusCode);
        Assert.Null(result.Title);
        Assert.Equal("Detail", result.Detail);
    }

    /// <summary>
    /// Unit test to verify the behavior of the MethodNotAllowed method when called with title and detail parameters.
    /// </summary>
    [Fact]
    public void MethodNotAllowed_GenericWithTitleAndDetailParameters_ReturnsFailureWithStatusCode405()
    {
        // Arrange
        Result<string> result = Result.OK("Test");

        // Act
        result = result.MethodNotAllowed("Title", "Detail");

        // Assert
        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Equal(StatusCode.MethodNotAllowed, result.StatusCode);
        Assert.Equal("Title", result.Title);
        Assert.Equal("Detail", result.Detail);
    }
}