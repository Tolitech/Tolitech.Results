namespace Tolitech.Results.UnitTests;

/// <summary>
/// Unit tests for the Result class with scenarios related to successful results (Result.Found()).
/// </summary>
public class ResultFoundTests
{
    /// <summary>
    /// Unit test to verify the behavior of the Found method when called with no parameters.
    /// </summary>
    [Fact]
    public void Found_NoParameters_ReturnsSuccessWithStatusCode302()
    {
        // Arrange & Act
        Result result = Result.Found();

        // Assert
        Assert.True(result.IsSuccess);
        Assert.False(result.IsFailure);
        Assert.Equal(StatusCode.Found, result.StatusCode);
    }

    /// <summary>
    /// Unit test to verify the behavior of the Found method when called with a value as a string parameter.
    /// </summary>
    [Fact]
    public void Found_ValueAsString_ReturnsSuccessWithStatusCode302AndCorrectValue()
    {
        // Arrange & Act
        Result<string> result = Result.Found("Hello, world!");

        // Assert
        Assert.True(result.IsSuccess);
        Assert.False(result.IsFailure);
        Assert.Equal(StatusCode.Found, result.StatusCode);
        Assert.Equal("Hello, world!", result.Value);
    }

    /// <summary>
    /// Unit test to verify the behavior of the Found method when called with StatusCode.Found.
    /// </summary>
    [Fact]
    public void Found_WithStatusFound_ReturnsSuccess()
    {
        // Arrange & Act
        Result<string> result = Result.Found("Hello, world!")
            .WithStatusCode(StatusCode.Found);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.False(result.IsFailure);
        Assert.Equal(StatusCode.Found, result.StatusCode);
        Assert.Equal("Hello, world!", result.Value);
    }

    /// <summary>
    /// Unit test to verify the behavior of the Found method when called with StatusCode.OK.
    /// </summary>
    [Fact]
    public void Found_WithStatusOK_ReturnsSuccess()
    {
        // Arrange & Act
        Result result = Result.Found()
            .WithStatusCode(StatusCode.OK);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.False(result.IsFailure);
        Assert.Equal(StatusCode.OK, result.StatusCode);
    }

    /// <summary>
    /// Unit test to verify the behavior of the Found method when called with a value, title, detail, and context name parameters.
    /// </summary>
    [Fact]
    public void Found_WithValueAndTitleAndDetailAndContextName_ReturnsSuccessWithValueAndTitleAndDetail()
    {
        // Arrange
        Result<string> result = Result.NoContent<string>()
            .WithContext("Root");

        // Act
        result = result
            .Found("Hello, world!")
            .WithTitle("Title")
            .WithDetail("Detail")
            .WithType("OK");

        // Assert
        Assert.True(result.IsSuccess);
        Assert.False(result.IsFailure);
        Assert.Equal(StatusCode.Found, result.StatusCode);
        Assert.Equal("Title", result.Title);
        Assert.Equal("Detail", result.Detail);
        Assert.Equal("Hello, world!", result.Value);
        Assert.Equal("OK", result.Type);
    }

    /// <summary>
    /// Unit test to verify that calling Found with StatusCode.BadRequest should result in IsFailure.
    /// </summary>
    [Fact]
    public void Found_WithStatusCodeBadRequest_ShouldResultInIsFailure()
    {
        // Arrange & Act
        Result result = Result.Found("test")
            .WithContext("Test")
            .WithTitle("Title")
            .WithDetail("Detail")
            .WithStatusCode(StatusCode.BadRequest);

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify that calling Found from NoContent status should result in IsSuccess.
    /// </summary>
    [Fact]
    public void Found_FromNoContent_ShouldResultInIsSuccess()
    {
        // Arrange
        Result<string> result = new();

        // Act
        _ = result.Found("Test");

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal("Test", result.Value);
        Assert.Equal(StatusCode.Found, result.StatusCode);
    }
}