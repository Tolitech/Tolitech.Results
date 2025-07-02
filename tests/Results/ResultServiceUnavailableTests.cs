namespace Tolitech.Results.UnitTests;

/// <summary>
/// Unit tests for the Result class with scenarios related to results indicating a service unavailable (Result.ServiceUnavaiable()).
/// </summary>
public class ResultServiceUnavailableTests
{
    /// <summary>
    /// Unit test to verify the behavior of the ServiceUnavailable method when called with no parameters.
    /// </summary>
    [Fact]
    public void ServiceUnavailable_NoParameters_ReturnsFailureWithStatusCode503()
    {
        // Arrange & Act
        Result result = Result.ServiceUnavailable();

        // Assert
        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Equal(StatusCode.ServiceUnavailable, result.StatusCode);
    }

    /// <summary>
    /// Unit test to verify that calling ServiceUnavailable from Accedpted status should result in IsFailure.
    /// </summary>
    [Fact]
    public void ServiceUnavailable_FromAcceptedWithValue_ShouldResultInIsFailureWithNoContent()
    {
        // Arrange
        Result<string> result = Result.Accepted("Test");

        // Act
        _ = result.ServiceUnavailable();

        // Assert
        Assert.True(result.IsFailure);
        Assert.True(string.IsNullOrEmpty(result.Value));
        Assert.Equal(StatusCode.ServiceUnavailable, result.StatusCode);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ServiceUnavailable method when called with detail parameter.
    /// </summary>
    [Fact]
    public void ServiceUnavailable_DetailParameter_ReturnsFailureWithStatusCode503()
    {
        // Arrange & Act
        Result result = Result.ServiceUnavailable("Detail");

        // Assert
        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Equal(StatusCode.ServiceUnavailable, result.StatusCode);
        Assert.Null(result.Title);
        Assert.Equal("Detail", result.Detail);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ServiceUnavailable method when called with no parameters.
    /// </summary>
    [Fact]
    public void ServiceUnavailable_TitleAndDetailParameters_ReturnsFailureWithStatusCode503()
    {
        // Arrange & Act
        Result result = Result.ServiceUnavailable("Title", "Detail");

        // Assert
        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Equal(StatusCode.ServiceUnavailable, result.StatusCode);
        Assert.Equal("Title", result.Title);
        Assert.Equal("Detail", result.Detail);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ServiceUnavailable method when called with detail parameter.
    /// </summary>
    [Fact]
    public void ServiceUnavailable_GenericWithDetailParameter_ReturnsFailureWithStatusCode503()
    {
        // Arrange
        Result<string> result = Result.OK("Test");

        // Act
        result = result.ServiceUnavailable("Detail");

        // Assert
        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Equal(StatusCode.ServiceUnavailable, result.StatusCode);
        Assert.Null(result.Title);
        Assert.Equal("Detail", result.Detail);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ServiceUnavailable method when called with no parameters.
    /// </summary>
    [Fact]
    public void ServiceUnavailable_GenericWithTitleAndDetailParameters_ReturnsFailureWithStatusCode503()
    {
        // Arrange
        Result<string> result = Result.OK("Test");

        // Act
        result = result.ServiceUnavailable("Title", "Detail");

        // Assert
        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Equal(StatusCode.ServiceUnavailable, result.StatusCode);
        Assert.Equal("Title", result.Title);
        Assert.Equal("Detail", result.Detail);
    }
}