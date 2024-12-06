namespace Tolitech.Results.UnitTests;

/// <summary>
/// Unit tests for the Result class with scenarios related to successful results (Result.OK()).
/// </summary>
public class ResultOKTests
{
    /// <summary>
    /// Unit test to verify the behavior of the OK method when called with no parameters.
    /// </summary>
    [Fact]
    public void OK_NoParameters_ReturnsSuccessWithStatusCode200()
    {
        // Arrange & Act
        Result result = Result.OK();

        // Assert
        Assert.True(result.IsSuccess);
        Assert.False(result.IsFailure);
        Assert.Equal(StatusCode.OK, result.StatusCode);
    }

    /// <summary>
    /// Unit test to verify the behavior of the OK method when called with a value as a string parameter.
    /// </summary>
    [Fact]
    public void OK_ValueAsString_ReturnsSuccessWithStatusCode200AndCorrectValue()
    {
        // Arrange & Act
        Result<string> result = Result.OK("Hello, world!");

        // Assert
        Assert.True(result.IsSuccess);
        Assert.False(result.IsFailure);
        Assert.Equal(StatusCode.OK, result.StatusCode);
        Assert.Equal("Hello, world!", result.Value);
    }

    /// <summary>
    /// Unit test to verify the behavior of the OK method when called with a title parameter.
    /// </summary>
    [Fact]
    public void OK_WithTitle_ReturnsResultWithTitle()
    {
        // Arrange & Act
        Result result = Result.OK()
            .WithTitle("Everything is OK.");

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal("Everything is OK.", result.Title);
    }

    /// <summary>
    /// Unit test to verify the behavior of the OK method when called with a detail parameter.
    /// </summary>
    [Fact]
    public void OK_WithDetail_ReturnsResultWithDetail()
    {
        // Arrange & Act
        Result result = Result.OK()
            .WithDetail("Everything is OK.");

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal("Everything is OK.", result.Detail);
    }

    /// <summary>
    /// Unit test to verify the behavior of the OK method when called with a context name parameter.
    /// </summary>
    [Fact]
    public void OK_WithContextName_ReturnsMessagesWithContextName()
    {
        // Arrange
        Result result = Result.OK()
            .WithContext("Root");

        // Act
        result.AddInformation("Hello, World.");

        // Assert
        Assert.True(result.IsSuccess);
        Assert.True(result.Messages.Where(m => m.ContextName == "Root").ToList().Count > 0);
    }

    /// <summary>
    /// Unit test to verify that calling OK with StatusCode.BadRequest should result in IsFailure.
    /// </summary>
    [Fact]
    public void OK_WithStatusCodeBadRequest_ShouldResultInIsFailure()
    {
        // Arrange & Act
        Result result = Result.OK()
            .WithStatusCode(StatusCode.BadRequest);

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify that calling OK with StatusCode.Forbidden should result in IsFalure.
    /// </summary>
    [Fact]
    public void OK_WithStatusCodeForbidden_ShouldResultInIsFailure()
    {
        // Arrange & Act
        Result result = Result.OK()
            .WithStatusCode(StatusCode.Forbidden);

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify that calling OK with StatusCode.NotFound should result in IsFailure.
    /// </summary>
    [Fact]
    public void OK_WithStatusCodeNotFound_ShouldResultInIsFailure()
    {
        // Arrange & Act
        Result result = Result.OK()
            .WithStatusCode(StatusCode.NotFound);

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify that calling OK with StatusCode.InternalServerError should result in IsFailure.
    /// </summary>
    [Fact]
    public void OK_WithStatusCodeInternalServerError_ShouldResultInIsFailure()
    {
        // Arrange & Act
        Result result = Result.OK()
            .WithStatusCode(StatusCode.InternalServerError);

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify that calling OK from NoContent status should result in IsSuccess.
    /// </summary>
    [Fact]
    public void OK_FromNoContent_ShouldResultInIsSuccess()
    {
        // Arrange
        Result<string> result = new();

        // Act
        _ = result.OK("Test");

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal("Test", result.Value);
        Assert.Equal(StatusCode.OK, result.StatusCode);
    }
}