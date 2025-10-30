namespace Tolitech.Results.UnitTests;

/// <summary>
/// Unit tests for the Result class with scenarios related to results indicating a forbidden request (Result.Forbidden()).
/// </summary>
public class ResultForbiddenTests
{
    /// <summary>
    /// Unit test to verify the behavior of the Forbidden method when called with no parameters.
    /// </summary>
    [Fact]
    public void Forbidden_NoParameters_ReturnsFailureWithStatusCode403()
    {
        // Arrange & Act
        IResult result = Result.Forbidden();

        // Assert
        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Equal(StatusCode.Forbidden, result.StatusCode);
    }

    /// <summary>
    /// Unit test to verify that calling Forbidden from Accedpted status should result in IsFailure.
    /// </summary>
    [Fact]
    public void Forbidden_FromAcceptedWithValue_ShouldResultInIsFailureWithNoContent()
    {
        // Arrange
        IResult<string> result = Result<string>.Accepted("Test");

        // Act
        _ = result.Forbidden();

        // Assert
        Assert.True(result.IsFailure);
        Assert.True(string.IsNullOrEmpty(result.Value));
        Assert.Equal(StatusCode.Forbidden, result.StatusCode);
    }

    /// <summary>
    /// Unit test to verify the behavior of the Forbidden method when called with detail parameter.
    /// </summary>
    [Fact]
    public void Forbidden_DetailParameter_ReturnsFailureWithStatusCode403()
    {
        // Arrange & Act
        IResult result = Result.Forbidden("Detail");

        // Assert
        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Equal(StatusCode.Forbidden, result.StatusCode);
        Assert.NotNull(result.Title);
        Assert.Equal("Detail", result.Detail);
    }

    /// <summary>
    /// Unit test to verify the behavior of the Forbidden method when called with title and detail parameters.
    /// </summary>
    [Fact]
    public void Forbidden_TitleAndDetailParameters_ReturnsFailureWithStatusCode403()
    {
        // Arrange & Act
        IResult result = Result.Forbidden("Title", "Detail");

        // Assert
        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Equal(StatusCode.Forbidden, result.StatusCode);
        Assert.Equal("Title", result.Title);
        Assert.Equal("Detail", result.Detail);
    }

    /// <summary>
    /// Unit test to verify the behavior of the Forbidden method when called with detail parameter.
    /// </summary>
    [Fact]
    public void Forbidden_GenericWithDetailParameter_ReturnsFailureWithStatusCode403()
    {
        // Arrange
        IResult<string> result = Result<string>.OK("Test");

        // Act
        result = result.Forbidden("Detail");

        // Assert
        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Equal(StatusCode.Forbidden, result.StatusCode);
        Assert.Equal("Detail", result.Detail);
    }

    /// <summary>
    /// Unit test to verify the behavior of the Forbidden method when called with title and detail parameters.
    /// </summary>
    [Fact]
    public void Forbidden_GenericWithTitleAndDetailParameters_ReturnsFailureWithStatusCode403()
    {
        // Arrange
        IResult<string> result = Result<string>.OK("Test");

        // Act
        result = result.Forbidden("Title", "Detail");

        // Assert
        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Equal(StatusCode.Forbidden, result.StatusCode);
        Assert.Equal("Title", result.Title);
        Assert.Equal("Detail", result.Detail);
    }

    /// <summary>
    /// Unit test to verify the behavior of the Forbidden method when called with no parameters.
    /// </summary>
    [Fact]
    public void Forbidden_T_ReturnsFailure()
    {
        // Arrange & Act
        IResult result = Result<bool>.Forbidden();

        // Assert
        Assert.True(result.IsFailure);
        Assert.Equal(StatusCode.Forbidden, result.StatusCode);
    }

    /// <summary>
    /// Unit test to verify the behavior of the Forbidden method when called with detail parameter.
    /// </summary>
    [Fact]
    public void Forbidden_T_WithDetailParameter_ReturnsFailure()
    {
        // Arrange & Act
        IResult result = Result<bool>.Forbidden("Detail");

        // Assert
        Assert.True(result.IsFailure);
        Assert.Equal(StatusCode.Forbidden, result.StatusCode);
        Assert.Equal("Detail", result.Detail);
    }

    /// <summary>
    /// Unit test to verify the behavior of the Forbidden method when called with title and detail parameter.
    /// </summary>
    [Fact]
    public void Forbidden_T_WithTitleAndDetailParameters_ReturnsFailure()
    {
        // Arrange & Act
        IResult result = Result<bool>.Forbidden("Title", "Detail");

        // Assert
        Assert.True(result.IsFailure);
        Assert.Equal(StatusCode.Forbidden, result.StatusCode);
        Assert.Equal("Title", result.Title);
        Assert.Equal("Detail", result.Detail);
    }

    /// <summary>
    /// Unit test to verify the behavior of the Forbidden method when called with no parameters.
    /// </summary>
    [Fact]
    public void Forbidden_Extensions_ReturnsFailure()
    {
        // Arrange & Act
        IResult result = Result.NoContent().Forbidden();

        // Assert
        Assert.True(result.IsFailure);
        Assert.Equal(StatusCode.Forbidden, result.StatusCode);
    }
}