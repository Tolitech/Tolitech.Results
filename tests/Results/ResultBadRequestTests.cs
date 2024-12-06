namespace Tolitech.Results.UnitTests;

/// <summary>
/// Unit tests for the ResultBadRequest class with various scenarios.
/// </summary>
public class ResultBadRequestTests
{
    /// <summary>
    /// Unit test to verify the behavior of the BadRequest method when called with no parameters.
    /// </summary>
    [Fact]
    public void BadRequest_NoParameters_ReturnsFailureWithStatusCode400()
    {
        // Arrange & Act
        Result result = Result.BadRequest();

        // Assert
        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Equal(StatusCode.BadRequest, result.StatusCode);
    }

    /// <summary>
    /// Unit test to verify the behavior of the BadRequest method when called with a value as a string.
    /// </summary>
    [Fact]
    public void BadRequest_ValueAsString_ReturnsFailureWithStatusCode400AndCorrectValue()
    {
        // Arrange & Act
        Result<string> result = Result.BadRequest("Hello, world!");

        // Assert
        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Equal(StatusCode.BadRequest, result.StatusCode);
        Assert.Equal("Hello, world!", result.Value);
    }

    /// <summary>
    /// Unit test to verify the behavior of the BadRequest method when called with a StatusCode.OK parameter.
    /// </summary>
    [Fact]
    public void BadRequest_WithStatusCodeOK_ShouldResultInIsSuccess()
    {
        // Arrange & Act
        Result result = Result.BadRequest()
            .WithStatusCode(StatusCode.OK);

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the BadRequest method when called with a StatusCode.NoContent parameter.
    /// </summary>
    [Fact]
    public void BadRequest_WithStatusCodeNoContent_ShouldResultInIsSuccess()
    {
        // Arrange & Act
        Result result = Result.BadRequest()
            .WithStatusCode(StatusCode.NoContent);

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the BadRequest method when called with a StatusCode.Created parameter.
    /// </summary>
    [Fact]
    public void BadRequest_WithStatusCodeCreated_ShouldResultInIsSuccess()
    {
        // Arrange & Act
        Result result = Result.BadRequest()
            .WithStatusCode(StatusCode.Created);

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the BadRequest method when called with a StatusCode.InternalServerError parameter.
    /// </summary>
    [Fact]
    public void BadRequest_WithStatusCodeInternalServerError_ReturnsFailureWithStatusCode500()
    {
        // Arrange
        Result result = Result.BadRequest();

        // Act
        result = result.WithStatusCode(StatusCode.InternalServerError);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Equal(StatusCode.InternalServerError, result.StatusCode);
    }

    /// <summary>
    /// Unit test to verify the behavior of the BadRequest method when called with a Type parameter.
    /// </summary>
    [Fact]
    public void BadRequest_WithType_ReturnsFailureWithType()
    {
        // Arrange
        Result result = Result.BadRequest();

        // Act
        result = result.WithType("ValidationError");

        // Assert
        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Equal(StatusCode.BadRequest, result.StatusCode);
        Assert.Equal("ValidationError", result.Type);
    }

    /// <summary>
    /// Unit test to verify that calling BadRequest from Accedpted status should result in IsFailure.
    /// </summary>
    [Fact]
    public void BadRequest_FromAcceptedWithValue_ShouldResultInIsFailureWithNoContent()
    {
        // Arrange
        Result<string> result = Result.Accepted("Test");

        // Act
        _ = result.BadRequest();

        // Assert
        Assert.True(result.IsFailure);
        Assert.True(string.IsNullOrEmpty(result.Value));
        Assert.Equal(StatusCode.BadRequest, result.StatusCode);
    }
}