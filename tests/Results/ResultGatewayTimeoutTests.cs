namespace Tolitech.Results.UnitTests;

/// <summary>
/// Unit tests for the Result class with scenarios related to results indicating a gateway timeout (Result.GatewayTimeout()).
/// </summary>
public class ResultGatewayTimeoutTests
{
    /// <summary>
    /// Unit test to verify the behavior of the GatewayTimeout method when called with no parameters.
    /// </summary>
    [Fact]
    public void GatewayTimeout_NoParameters_ReturnsFailureWithStatusCode504()
    {
        // Arrange & Act
        Result result = Result.GatewayTimeout();

        // Assert
        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Equal(StatusCode.GatewayTimeout, result.StatusCode);
    }

    /// <summary>
    /// Unit test to verify that calling GatewayTimeout from Accedpted status should result in IsFailure.
    /// </summary>
    [Fact]
    public void GatewayTimeout_FromAcceptedWithValue_ShouldResultInIsFailureWithNoContent()
    {
        // Arrange
        Result<string> result = Result.Accepted("Test");

        // Act
        _ = result.GatewayTimeout();

        // Assert
        Assert.True(result.IsFailure);
        Assert.True(string.IsNullOrEmpty(result.Value));
        Assert.Equal(StatusCode.GatewayTimeout, result.StatusCode);
    }

    /// <summary>
    /// Unit test to verify the behavior of the GatewayTimeout method when called with detail parameter.
    /// </summary>
    [Fact]
    public void GatewayTimeout_DetailParameter_ReturnsFailureWithStatusCode504()
    {
        // Arrange & Act
        Result result = Result.GatewayTimeout("Detail");

        // Assert
        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Equal(StatusCode.GatewayTimeout, result.StatusCode);
        Assert.Null(result.Title);
        Assert.Equal("Detail", result.Detail);
    }

    /// <summary>
    /// Unit test to verify the behavior of the GatewayTimeout method when called with title and detail parameters.
    /// </summary>
    [Fact]
    public void GatewayTimeout_TitleAndDetailParameters_ReturnsFailureWithStatusCode504()
    {
        // Arrange & Act
        Result result = Result.GatewayTimeout("Title", "Detail");

        // Assert
        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Equal(StatusCode.GatewayTimeout, result.StatusCode);
        Assert.Equal("Title", result.Title);
        Assert.Equal("Detail", result.Detail);
    }

    /// <summary>
    /// Unit test to verify the behavior of the GatewayTimeout method when called with detail parameter.
    /// </summary>
    [Fact]
    public void GatewayTimeout_GenericWithDetailParameter_ReturnsFailureWithStatusCode504()
    {
        // Arrange
        Result<string> result = Result.OK("Test");

        // Act
        result = result.GatewayTimeout("Detail");

        // Assert
        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Equal(StatusCode.GatewayTimeout, result.StatusCode);
        Assert.Null(result.Title);
        Assert.Equal("Detail", result.Detail);
    }

    /// <summary>
    /// Unit test to verify the behavior of the GatewayTimeout method when called with title and detail parameters.
    /// </summary>
    [Fact]
    public void GatewayTimeout_GenericWithTitleAndDetailParameters_ReturnsFailureWithStatusCode504()
    {
        // Arrange
        Result<string> result = Result.OK("Test");

        // Act
        result = result.GatewayTimeout("Title", "Detail");

        // Assert
        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Equal(StatusCode.GatewayTimeout, result.StatusCode);
        Assert.Equal("Title", result.Title);
        Assert.Equal("Detail", result.Detail);
    }
}