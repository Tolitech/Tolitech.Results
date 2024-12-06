using System.Net;
using System.Text;

namespace Tolitech.Results.Http.UnitTests;

/// <summary>
/// Unit tests for the ResultHttp extensions.
/// </summary>
public class ProblemDetailsResponseTests
{
    /// <summary>
    /// Verifies that the ReadProblemDetailsAsync method properly populates the Result object when provided with a valid ProblemDetails message.
    /// </summary>
    /// <returns> A task representing the asynchronous operation.</returns>
    [Fact]
    public async Task ReadProblemDetailsAsync_WithValidProblemDetailsMessage_ShouldPopulateResultObject()
    {
        // Arrange
        Result result = Result.BadRequest();
        using HttpResponseMessage response = new(HttpStatusCode.BadRequest);
        const string json = /*lang=json,strict*/ "{\"errors\": [{\"message\": \"message1\", \"key\": \"key1\", \"contextName\": \"contextName1\" }, { \"message\": \"message2\", \"key\": \"key2\", \"contextName\": \"contextName2\" } ], \"status\": 400, \"detail\": \"message detail\", \"title\": \"message title\", \"type\": \"message type\"}";
        response.Content = new StringContent(json, Encoding.UTF8, "application/json");

        // Act
        await result.ReadProblemDetailsAsync(response)
            .ConfigureAwait(true);

        // Assert
        Assert.Equal("message type", result.Type);
        Assert.Equal("message title", result.Title);
        Assert.Equal("message detail", result.Detail);
        Assert.Equal(StatusCode.BadRequest, result.StatusCode);
        Assert.Equal(2, result.Messages.Count);
        Assert.Equal(2, result.Errors.Count());
        Assert.Equal("contextName1", result.Messages.First().ContextName);
        Assert.Equal("key1", result.Messages.First().Key);
        Assert.Equal("message1", result.Messages.First().Message);
        Assert.Equal("contextName2", result.Messages.Last().ContextName);
        Assert.Equal("key2", result.Messages.Last().Key);
        Assert.Equal("message2", result.Messages.Last().Message);
    }

    /// <summary>
    /// Verifies that the ReadProblemDetailsAsync method properly populates the Result object when provided with a valid ProblemDetails message.
    /// </summary>
    /// <returns> A task representing the asynchronous operation.</returns>
    [Fact]
    public async Task ReadProblemDetailsAsync_WithValidProblemDetailsMessageWithoutKeyAndContext_ShouldPopulateResultObject()
    {
        // Arrange
        Result result = Result.BadRequest();
        using HttpResponseMessage response = new(HttpStatusCode.BadRequest);
        const string json = /*lang=json,strict*/ "{\"errors\": [{\"message\": \"message1\" }, { \"message\": \"message2\" } ], \"status\": 400, \"detail\": \"message detail\", \"title\": \"message title\", \"type\": \"message type\"}";
        response.Content = new StringContent(json, Encoding.UTF8, "application/json");

        // Act
        await result.ReadProblemDetailsAsync(response)
            .ConfigureAwait(true);

        // Assert
        Assert.Equal("message type", result.Type);
        Assert.Equal("message title", result.Title);
        Assert.Equal("message detail", result.Detail);
        Assert.Equal(StatusCode.BadRequest, result.StatusCode);
        Assert.Equal(2, result.Messages.Count);
        Assert.Equal(2, result.Errors.Count());
        Assert.Equal("message1", result.Messages.First().Message);
        Assert.Equal("message2", result.Messages.Last().Message);
    }

    /// <summary>
    /// Executes the test method to ensure that calling <c>ReadProblemDetailsAsync</c> with a response containing no content throws an exception.
    /// </summary>
    /// <returns> A task representing the asynchronous operation.</returns>
    [Fact]
    public async Task ReadProblemDetailsAsync_WithNoContentMessage_ShouldThrowsAnException()
    {
        // Arrange
        Result result = Result.BadRequest();
        using HttpResponseMessage response = new(HttpStatusCode.BadRequest);

        // Act
        await result.ReadProblemDetailsAsync(response)
            .ConfigureAwait(true);

        // Assert
        Assert.True(result.IsFailure);
        Assert.Single(result.Messages);
    }

    /// <summary>
    /// Verifies that the ReadProblemDetailsAsync method exits without modifying the Result object when provided with a success HTTP response.
    /// </summary>
    /// <returns> A task representing the asynchronous operation.</returns>
    [Fact]
    public async Task ReadProblemDetailsAsync_WithInvalidMessage_ShouldHaveEmptyMessages()
    {
        // Arrange
        Result result = Result.BadRequest();
        using HttpResponseMessage response = new(HttpStatusCode.BadRequest);
        const string json = /*lang=json,strict*/ "{\"property\": \"value\"}";
        response.Content = new StringContent(json, Encoding.UTF8, "application/json");

        // Act
        await result.ReadProblemDetailsAsync(response)
            .ConfigureAwait(true);

        // Assert
        Assert.True(result.IsFailure);
        Assert.Empty(result.Messages);
    }

    /// <summary>
    /// Verifies that the ReadProblemDetailsAsync method exits without modifying the Result object when provided with a success HTTP response.
    /// </summary>
    /// <returns> A task representing the asynchronous operation.</returns>
    [Fact]
    public async Task ReadProblemDetailsAsync_WithSuccessResult_ShouldExit()
    {
        // Arrange
        Result result = Result.OK().WithTitle("Hello, world!");
        using HttpResponseMessage response = new(HttpStatusCode.OK);

        // Act
        await result.ReadProblemDetailsAsync(response)
            .ConfigureAwait(true);

        // Assert
        Assert.Equal("Hello, world!", result.Title);
        Assert.Equal(StatusCode.OK, result.StatusCode);
        Assert.Empty(result.Messages);
    }
}