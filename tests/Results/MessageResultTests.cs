namespace Tolitech.Results.UnitTests;

/// <summary>
/// Unit tests for the MessageResult class with various scenarios.
/// </summary>
public class MessageResultTests
{
    /// <summary>
    /// Unit test to verify the behavior of the Information method when called with a message parameter.
    /// </summary>
    [Fact]
    public void Information_WithMessage_ReturnsMessage()
    {
        // Arrange & Act
        MessageResult messageResult = MessageResult.Information("Hello, world!");

        // Assert
        Assert.Equal(MessageType.Information, messageResult.Type);
        Assert.Equal("Hello, world!", messageResult.Message);
    }

    /// <summary>
    /// Unit test to verify the behavior of the Information method when called with a key and message parameters.
    /// </summary>
    [Fact]
    public void Information_WithKeyAndMessage_ReturnsMessageWithKey()
    {
        // Arrange & Act
        MessageResult messageResult = MessageResult.Information("Welcome", "Hello, world!");

        // Assert
        Assert.Equal(MessageType.Information, messageResult.Type);
        Assert.Equal("Welcome", messageResult.Key);
    }

    /// <summary>
    /// Unit test to verify the behavior of the Information method when called with a context name, key, and message parameters.
    /// </summary>
    [Fact]
    public void Information_WithContextNameAndKeyAndMessage_ReturnsMessageWithKeyAndContextName()
    {
        // Arrange & Act
        MessageResult messageResult = MessageResult.Information("Root", "Welcome", "Hello, world!");

        // Assert
        Assert.Equal(MessageType.Information, messageResult.Type);
        Assert.Equal("Welcome", messageResult.Key);
        Assert.Equal("Root", messageResult.ContextName);
    }

    /// <summary>
    /// Unit test to verify the behavior of the Warning method when called with a message parameter.
    /// </summary>
    [Fact]
    public void Warning_WithMessage_ReturnsMessage()
    {
        // Arrange & Act
        MessageResult messageResult = MessageResult.Warning("Hello, world!");

        // Assert
        Assert.Equal(MessageType.Warning, messageResult.Type);
        Assert.Equal("Hello, world!", messageResult.Message);
    }

    /// <summary>
    /// Unit test to verify the behavior of the Warning method when called with a key and message parameters.
    /// </summary>
    [Fact]
    public void Warning_WithKeyAndMessage_ReturnsMessageWithKey()
    {
        // Arrange & Act
        MessageResult messageResult = MessageResult.Warning("Welcome", "Hello, world!");

        // Assert
        Assert.Equal(MessageType.Warning, messageResult.Type);
        Assert.Equal("Welcome", messageResult.Key);
    }
}