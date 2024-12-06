namespace Tolitech.Results.UnitTests;

/// <summary>
/// Unit tests for the ErrorResult class with various scenarios.
/// </summary>
public class ErrorResultTests
{
    /// <summary>
    /// Unit test to verify the behavior of the Error method when called with a message parameter.
    /// </summary>
    [Fact]
    public void Error_WithMessage_ReturnsErrorWithMessage()
    {
        // Arrange & Act
        ErrorResult errorResult = MessageResult.Error("Error");

        // Assert
        Assert.Equal(MessageType.Error, errorResult.Type);
    }

    /// <summary>
    /// Unit test to verify the behavior of the Error method when called with a message and exception parameters.
    /// </summary>
    [Fact]
    public void Error_WithMessageAndException_ReturnsErrorWithMessage()
    {
        // Arrange & Act
        ErrorResult errorResult = MessageResult.Error("Error", new InvalidOperationException("Error"));

        // Assert
        Assert.Equal(MessageType.Error, errorResult.Type);
        Assert.NotNull(errorResult.Exception);
    }

    /// <summary>
    /// Unit test to verify the behavior of the Error method when called with a key and message parameters.
    /// </summary>
    [Fact]
    public void Error_WithKeyAndMessage_ReturnsErrorWithMessageAndKey()
    {
        // Arrange & Act
        ErrorResult errorResult = MessageResult.Error("Person.Create", "Person cannot be created.");

        // Assert
        Assert.Equal("Person.Create", errorResult.Key);
        Assert.Equal(MessageType.Error, errorResult.Type);
    }

    /// <summary>
    /// Unit test to verify the behavior of the Error method when called with a context name, key, and message parameters.
    /// </summary>
    [Fact]
    public void Error_WithContextNameAndKeyAndMessage_ReturnsErrorWithMessageAndContextName()
    {
        // Arrange & Act
        ErrorResult errorResult = MessageResult.Error("Root", "Person.Create", "Person cannot be created.");

        // Assert
        Assert.Equal("Root", errorResult.ContextName);
        Assert.Equal("Person.Create", errorResult.Key);
        Assert.Equal(MessageType.Error, errorResult.Type);
    }
}