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
        IResult result = Result.InternalServerError();

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
        IResult<string> result = Result<string>.Accepted("Test");

        // Act
        _ = result.InternalServerError();

        // Assert
        Assert.True(result.IsFailure);
        Assert.True(string.IsNullOrEmpty(result.Value));
        Assert.Equal(StatusCode.InternalServerError, result.StatusCode);
    }

    /// <summary>
    /// Unit test to verify the behavior of the InternalServerError method when called with detail parameter.
    /// </summary>
    [Fact]
    public void InternalServerError_DetailParameter_ReturnsFailureWithStatusCode500()
    {
        // Arrange & Act
        IResult result = Result.InternalServerError("Detail");

        // Assert
        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Equal(StatusCode.InternalServerError, result.StatusCode);
        Assert.Null(result.Title);
        Assert.Equal("Detail", result.Detail);
    }

    /// <summary>
    /// Unit test to verify the behavior of the InternalServerError method when called with title and detail parameters.
    /// </summary>
    [Fact]
    public void InternalServerError_TitleAndDetailParameters_ReturnsFailureWithStatusCode500()
    {
        // Arrange & Act
        IResult result = Result.InternalServerError("Title", "Detail");

        // Assert
        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Equal(StatusCode.InternalServerError, result.StatusCode);
        Assert.Equal("Title", result.Title);
        Assert.Equal("Detail", result.Detail);
    }

    /// <summary>
    /// Unit test to verify the behavior of the InternalServerError method when called with detail parameter.
    /// </summary>
    [Fact]
    public void InternalServerError_GenericWithDetailParameter_ReturnsFailureWithStatusCode500()
    {
        // Arrange
        IResult<string> result = Result<string>.OK("Test");

        // Act
        result = result.InternalServerError("Detail");

        // Assert
        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Equal(StatusCode.InternalServerError, result.StatusCode);
        Assert.Null(result.Title);
        Assert.Equal("Detail", result.Detail);
    }

    /// <summary>
    /// Unit test to verify the behavior of the InternalServerError method when called with title and detail parameters.
    /// </summary>
    [Fact]
    public void InternalServerError_GenericWithTitleAndDetailParameters_ReturnsFailureWithStatusCode500()
    {
        // Arrange
        IResult<string> result = Result<string>.OK("Test");

        // Act
        result = result.InternalServerError("Title", "Detail");

        // Assert
        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Equal(StatusCode.InternalServerError, result.StatusCode);
        Assert.Equal("Title", result.Title);
        Assert.Equal("Detail", result.Detail);
    }
}