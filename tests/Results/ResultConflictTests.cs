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
        IResult result = Result.Conflict();

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
        IResult<string> result = Result<string>.Accepted("Test");

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
        IResult result = Result.Conflict("Detail");

        // Assert
        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Equal(StatusCode.Conflict, result.StatusCode);
        Assert.NotNull(result.Title);
        Assert.Equal("Detail", result.Detail);
    }

    /// <summary>
    /// Unit test to verify the behavior of the Conflict method when called with title and detail parameters.
    /// </summary>
    [Fact]
    public void Conflict_TitleAndDetailParameters_ReturnsFailureWithStatusCode409()
    {
        // Arrange & Act
        IResult result = Result.Conflict("Title", "Detail");

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
        IResult<string> result = Result<string>.OK("Test");

        // Act
        result = result.Conflict("Detail");

        // Assert
        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Equal(StatusCode.Conflict, result.StatusCode);
        Assert.Equal("Detail", result.Detail);
    }

    /// <summary>
    /// Unit test to verify the behavior of the Conflict method when called with title and detail parameters.
    /// </summary>
    [Fact]
    public void Conflict_GenericWithTitleAndDetailParameters_ReturnsFailureWithStatusCode409()
    {
        // Arrange
        IResult<string> result = Result<string>.OK("Test");

        // Act
        result = result.Conflict("Title", "Detail");

        // Assert
        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Equal(StatusCode.Conflict, result.StatusCode);
        Assert.Equal("Title", result.Title);
        Assert.Equal("Detail", result.Detail);
    }

    /// <summary>
    /// Unit test to verify the behavior of the Conflict method when called with no parameters.
    /// </summary>
    [Fact]
    public void Conflict_T_ReturnsFailure()
    {
        // Arrange & Act
        IResult result = Result<bool>.Conflict();

        // Assert
        Assert.True(result.IsFailure);
        Assert.Equal(StatusCode.Conflict, result.StatusCode);
    }

    /// <summary>
    /// Unit test to verify the behavior of the Conflict method when called with detail parameter.
    /// </summary>
    [Fact]
    public void Conflict_T_WithDetailParameter_ReturnsFailure()
    {
        // Arrange & Act
        IResult result = Result<bool>.Conflict("Detail");

        // Assert
        Assert.True(result.IsFailure);
        Assert.Equal(StatusCode.Conflict, result.StatusCode);
        Assert.Equal("Detail", result.Detail);
    }

    /// <summary>
    /// Unit test to verify the behavior of the Conflict method when called with title and detail parameter.
    /// </summary>
    [Fact]
    public void Conflict_T_WithTitleAndDetailParameters_ReturnsFailure()
    {
        // Arrange & Act
        IResult result = Result<bool>.Conflict("Title", "Detail");

        // Assert
        Assert.True(result.IsFailure);
        Assert.Equal(StatusCode.Conflict, result.StatusCode);
        Assert.Equal("Title", result.Title);
        Assert.Equal("Detail", result.Detail);
    }

    /// <summary>
    /// Unit test to verify the behavior of the Conflict method when called with no parameters.
    /// </summary>
    [Fact]
    public void Conflict_Extensions_ReturnsFailure()
    {
        // Arrange & Act
        IResult result = Result.NoContent().Conflict();

        // Assert
        Assert.True(result.IsFailure);
        Assert.Equal(StatusCode.Conflict, result.StatusCode);
    }
}