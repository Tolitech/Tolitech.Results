namespace Tolitech.Results.UnitTests;

/// <summary>
/// Unit tests for the Result class with scenarios related to successful results (Result.NotModfified()).
/// </summary>
public class ResultNotModifiedTests
{
    /// <summary>
    /// Unit test to verify the behavior of the NotModified method when called with no parameters.
    /// </summary>
    [Fact]
    public void NotModified_NoParameters_ReturnsSuccessWithStatusCode304()
    {
        // Arrange & Act
        IResult result = Result.NotModified();

        // Assert
        Assert.True(result.IsSuccess);
        Assert.False(result.IsFailure);
        Assert.Equal(StatusCode.NotModified, result.StatusCode);
    }

    /// <summary>
    /// Unit test to verify the behavior of the NotModified method when called with a value as a string parameter.
    /// </summary>
    [Fact]
    public void NotModified_ValueAsString_ReturnsSuccessWithStatusCode304AndCorrectValue()
    {
        // Arrange & Act
        IResult<string> result = Result<string>.NotModified("Hello, world!");

        // Assert
        Assert.True(result.IsSuccess);
        Assert.False(result.IsFailure);
        Assert.Equal(StatusCode.NotModified, result.StatusCode);
        Assert.Equal("Hello, world!", result.Value);
    }

    /// <summary>
    /// Unit test to verify the behavior of the NotModified method when called with StatusCode.NotModified.
    /// </summary>
    [Fact]
    public void NotModified_WithStatusNotModified_ReturnsSuccess()
    {
        // Arrange & Act
        IResult<string> result = Result<string>.NotModified("Hello, world!")
            .WithStatusCode(StatusCode.NotModified);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.False(result.IsFailure);
        Assert.Equal(StatusCode.NotModified, result.StatusCode);
        Assert.Equal("Hello, world!", result.Value);
    }

    /// <summary>
    /// Unit test to verify the behavior of the NotModified method when called with StatusCode.OK.
    /// </summary>
    [Fact]
    public void NotModified_WithStatusOK_ReturnsSuccess()
    {
        // Arrange & Act
        IResult result = Result.NotModified()
            .WithStatusCode(StatusCode.OK);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.False(result.IsFailure);
        Assert.Equal(StatusCode.OK, result.StatusCode);
    }

    /// <summary>
    /// Unit test to verify the behavior of the NotModified method when called with a value, title, detail, and context name parameters.
    /// </summary>
    [Fact]
    public void NotModified_WithValueAndTitleAndDetail_ReturnsSuccessWithValueAndTitleAndDetail()
    {
        // Arrange
        IResult<string> result = Result<string>.NoContent();

        // Act
        result = result
            .NotModified("Hello, world!")
            .WithTitle("Title")
            .WithDetail("Detail")
            .WithType("OK");

        // Assert
        Assert.True(result.IsSuccess);
        Assert.False(result.IsFailure);
        Assert.Equal(StatusCode.NotModified, result.StatusCode);
        Assert.Equal("Title", result.Title);
        Assert.Equal("Detail", result.Detail);
        Assert.Equal("Hello, world!", result.Value);
        Assert.Equal("OK", result.Type);
    }

    /// <summary>
    /// Unit test to verify that calling NotModified with StatusCode.BadRequest should result in IsFailure.
    /// </summary>
    [Fact]
    public void NotModified_WithStatusCodeBadRequest_ShouldResultInIsFailure()
    {
        // Arrange & Act
        IResult result = Result<string>.NotModified("test")
            .WithTitle("Title")
            .WithDetail("Detail")
            .WithStatusCode(StatusCode.BadRequest);

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify that calling NotModified from NoContent status should result in IsSuccess.
    /// </summary>
    [Fact]
    public void NotModified_FromNoContent_ShouldResultInIsSuccess()
    {
        // Arrange
        IResult<string> result = Result<string>.NoContent();

        // Act
        _ = result.NotModified("Test");

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal("Test", result.Value);
        Assert.Equal(StatusCode.NotModified, result.StatusCode);
    }
}