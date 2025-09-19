namespace Tolitech.Results.UnitTests;

/// <summary>
/// Unit tests for the Result class with scenarios related to results indicating an unauthorized (Result.Unauthorized()).
/// </summary>
public class ResultUnauthorizedTests
{
    /// <summary>
    /// Unit test to verify the behavior of the Unauthorized method when called with no parameters.
    /// </summary>
    [Fact]
    public void Unauthorized_NoParameters_ReturnsFailureWithStatusCode401()
    {
        // Arrange & Act
        IResult result = Result.Unauthorized();

        // Assert
        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Equal(StatusCode.Unauthorized, result.StatusCode);
    }

    /// <summary>
    /// Unit test to verify that calling Unauthorized from Accedpted status should result in IsFailure.
    /// </summary>
    [Fact]
    public void Unauthorized_FromAcceptedWithValue_ShouldResultInIsFailureWithNoContent()
    {
        // Arrange
        IResult<string> result = Result<string>.Accepted("Test");

        // Act
        _ = result.Unauthorized();

        // Assert
        Assert.True(result.IsFailure);
        Assert.True(string.IsNullOrEmpty(result.Value));
        Assert.Equal(StatusCode.Unauthorized, result.StatusCode);
    }

    /// <summary>
    /// Unit test to verify the behavior of the Unauthorized method when called with detail parameter.
    /// </summary>
    [Fact]
    public void Unauthorized_DetailParameter_ReturnsFailureWithStatusCode401()
    {
        // Arrange & Act
        IResult result = Result.Unauthorized("Detail");

        // Assert
        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Equal(StatusCode.Unauthorized, result.StatusCode);
        Assert.Null(result.Title);
        Assert.Equal("Detail", result.Detail);
    }

    /// <summary>
    /// Unit test to verify the behavior of the Unauthorized method when called with title and detail parameters.
    /// </summary>
    [Fact]
    public void Unauthorized_TitleAndDetailParameters_ReturnsFailureWithStatusCode401()
    {
        // Arrange & Act
        IResult result = Result.Unauthorized("Title", "Detail");

        // Assert
        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Equal(StatusCode.Unauthorized, result.StatusCode);
        Assert.Equal("Title", result.Title);
        Assert.Equal("Detail", result.Detail);
    }

    /// <summary>
    /// Unit test to verify the behavior of the Unauthorized method when called with detail parameter.
    /// </summary>
    [Fact]
    public void Unauthorized_GenericWithDetailParameter_ReturnsFailureWithStatusCode401()
    {
        // Arrange
        IResult<string> result = Result<string>.OK("Test");

        // Act
        result = result.Unauthorized("Detail");

        // Assert
        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Equal(StatusCode.Unauthorized, result.StatusCode);
        Assert.Null(result.Title);
        Assert.Equal("Detail", result.Detail);
    }

    /// <summary>
    /// Unit test to verify the behavior of the Unauthorized method when called with title and detail parameters.
    /// </summary>
    [Fact]
    public void Unauthorized_GenericWithTitleAndDetailParameters_ReturnsFailureWithStatusCode401()
    {
        // Arrange
        IResult<string> result = Result<string>.OK("Test");

        // Act
        result = result.Unauthorized("Title", "Detail");

        // Assert
        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Equal(StatusCode.Unauthorized, result.StatusCode);
        Assert.Equal("Title", result.Title);
        Assert.Equal("Detail", result.Detail);
    }
}