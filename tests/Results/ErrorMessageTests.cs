namespace Tolitech.Results.UnitTests;

/// <summary>
/// Unit tests for the ErrorMessage class with various scenarios.
/// </summary>
public class ErrorMessageTests
{
    /// <summary>
    /// Unit test to verify the behavior of the Error method when called with a message parameter.
    /// </summary>
    [Fact]
    public void Error_WithMessage_ReturnsErrorWithMessage()
    {
        // Arrange & Act
        const string message = "Error";
        ErrorMessage errorMessage = ErrorMessage.Create(message);

        // Assert
        Assert.Equal(message, errorMessage.Message);
    }

    /// <summary>
    /// Unit test to verify the behavior of the Error method when called with a key and message parameters.
    /// </summary>
    [Fact]
    public void Error_WithKeyAndMessage_ReturnsErrorWithMessageAndKey()
    {
        // Arrange & Act
        const string key = "Person.Create";
        const string message = "Person cannot be created.";
        ErrorMessage errorMessage = ErrorMessage.Create(key, message);

        // Assert
        Assert.Equal(key, errorMessage.Key);
        Assert.Equal(message, errorMessage.Message);
    }
}