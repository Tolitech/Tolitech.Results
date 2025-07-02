namespace Tolitech.Results.UnitTests;

/// <summary>
/// Unit tests for the Result class with scenarios related to results indicating a bad gateway (Result.BadGateway()).
/// </summary>
public class ResultBadGatewayTests
{
    /// <summary>
    /// Unit test to verify the behavior of the BadGateway method when called with no parameters.
    /// </summary>
    [Fact]
    public void BadGateway_NoParameters_ReturnsFailureWithStatusCode502()
    {
        // Arrange & Act
        Result result = Result.BadGateway();

        // Assert
        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Equal(StatusCode.BadGateway, result.StatusCode);
    }

    /// <summary>
    /// Unit test to verify that calling BadGateway from Accedpted status should result in IsFailure.
    /// </summary>
    [Fact]
    public void BadGateway_FromAcceptedWithValue_ShouldResultInIsFailureWithNoContent()
    {
        // Arrange
        Result<string> result = Result.Accepted("Test");

        // Act
        _ = result.BadGateway();

        // Assert
        Assert.True(result.IsFailure);
        Assert.True(string.IsNullOrEmpty(result.Value));
        Assert.Equal(StatusCode.BadGateway, result.StatusCode);
    }

    /// <summary>
    /// Unit test to verify the behavior of the BadGateway method when called with detail parameter.
    /// </summary>
    [Fact]
    public void BadGateway_DetailParameter_ReturnsFailureWithStatusCode502()
    {
        // Arrange & Act
        Result result = Result.BadGateway("Detail");

        // Assert
        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Equal(StatusCode.BadGateway, result.StatusCode);
        Assert.Null(result.Title);
        Assert.Equal("Detail", result.Detail);
    }

    /// <summary>
    /// Unit test to verify the behavior of the BadGateway method when called with title and detail parameters.
    /// </summary>
    [Fact]
    public void BadGateway_TitleAndDetailParameters_ReturnsFailureWithStatusCode502()
    {
        // Arrange & Act
        Result result = Result.BadGateway("Title", "Detail");

        // Assert
        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Equal(StatusCode.BadGateway, result.StatusCode);
        Assert.Equal("Title", result.Title);
        Assert.Equal("Detail", result.Detail);
    }

    /// <summary>
    /// Unit test to verify the behavior of the BadGateway method when called with detail parameter.
    /// </summary>
    [Fact]
    public void BadGateway_GenericWithDetailParameter_ReturnsFailureWithStatusCode502()
    {
        // Arrange
        Result<string> result = Result.OK("Test");

        // Act
        result = result.BadGateway("Detail");

        // Assert
        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Equal(StatusCode.BadGateway, result.StatusCode);
        Assert.Null(result.Title);
        Assert.Equal("Detail", result.Detail);
    }

    /// <summary>
    /// Unit test to verify the behavior of the BadGateway method when called with title and detail parameters.
    /// </summary>
    [Fact]
    public void BadGateway_GenericWithTitleAndDetailParameters_ReturnsFailureWithStatusCode502()
    {
        // Arrange
        Result<string> result = Result.OK("Test");

        // Act
        result = result.BadGateway("Title", "Detail");

        // Assert
        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Equal(StatusCode.BadGateway, result.StatusCode);
        Assert.Equal("Title", result.Title);
        Assert.Equal("Detail", result.Detail);
    }
}