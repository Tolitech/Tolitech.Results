namespace Tolitech.Results.UnitTests;

/// <summary>
/// Unit tests for the Result class with scenarios related to results indicating a successful creation (Result.Created()).
/// </summary>
public class ResultCreatedTests
{
    /// <summary>
    /// Unit test to verify the behavior of the Created method when called with no parameters.
    /// </summary>
    [Fact]
    public void Created_NoParameters_ReturnsSuccessWithStatusCode201()
    {
        // Arrange & Act
        IResult result = Result.Created();

        // Assert
        Assert.True(result.IsSuccess);
        Assert.False(result.IsFailure);
        Assert.Equal(StatusCode.Created, result.StatusCode);
    }

    /// <summary>
    /// Unit test to verify the behavior of the Created method when called with a value as a string parameter.
    /// </summary>
    [Fact]
    public void Created_ValueAsString_ReturnsSuccessWithStatusCode201AndCorrectValue()
    {
        // Arrange & Act
        IResult<string> result = Result<string>.Created("Hello, world!");

        // Assert
        Assert.True(result.IsSuccess);
        Assert.False(result.IsFailure);
        Assert.Equal(StatusCode.Created, result.StatusCode);
        Assert.Equal("Hello, world!", result.Value);
    }

    /// <summary>
    /// Unit test to verify the behavior of the Created method when called with StatusCode.Created.
    /// </summary>
    [Fact]
    public void Created_WithStatusCreated_ReturnsSuccess()
    {
        // Arrange & Act
        IResult<string> result = Result<string>.Created("Hello, world!")
            .WithStatusCode(StatusCode.Created);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.False(result.IsFailure);
        Assert.Equal(StatusCode.Created, result.StatusCode);
        Assert.Equal("Hello, world!", result.Value);
    }

    /// <summary>
    /// Unit test to verify the behavior of the Created method when called with StatusCode.OK.
    /// </summary>
    [Fact]
    public void Created_WithStatusOK_ReturnsSuccess()
    {
        // Arrange & Act
        IResult result = Result.Created()
            .WithStatusCode(StatusCode.OK);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.False(result.IsFailure);
        Assert.Equal(StatusCode.OK, result.StatusCode);
    }

    /// <summary>
    /// Unit test to verify the behavior of the Created method when called with a value, title, detail parameters.
    /// </summary>
    [Fact]
    public void Created_WithValueAndTitleAndDetail_ReturnsSuccessWithValueAndTitleAndDetail()
    {
        // Arrange
        IResult<string> result = Result<string>.NoContent();

        // Act
        result = result
            .Created("Hello, world!")
            .WithTitle("Title")
            .WithDetail("Detail")
            .WithType("OK");

        // Assert
        Assert.True(result.IsSuccess);
        Assert.False(result.IsFailure);
        Assert.Equal(StatusCode.Created, result.StatusCode);
        Assert.Equal("Title", result.Title);
        Assert.Equal("Detail", result.Detail);
        Assert.Equal("Hello, world!", result.Value);
        Assert.Equal("OK", result.Type);
    }

    /// <summary>
    /// Unit test to verify that calling Created with StatusCode.BadRequest should result in IsFailure.
    /// </summary>
    [Fact]
    public void Created_WithStatusCodeBadRequest_ShouldResultInIsFailure()
    {
        // Arrange & Act
        IResult result = Result<string>.Created("test")
            .WithTitle("Title")
            .WithDetail("Detail")
            .WithStatusCode(StatusCode.BadRequest);

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify that calling Created from NoContent status should result in IsSuccess.
    /// </summary>
    [Fact]
    public void Created_FromNoContent_ShouldResultInIsSuccess()
    {
        // Arrange
        IResult<string> result = Result<string>.NoContent();

        // Act
        _ = result.Created("Test");

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal("Test", result.Value);
        Assert.Equal(StatusCode.Created, result.StatusCode);
    }
}