namespace Tolitech.Results.Guards.UnitTests;

/// <summary>
/// Unit tests for the string-related guard methods.
/// </summary>
public class StringTests
{
    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfNull method with a null value.
    /// </summary>
    [Fact]
    public void ErrorIfNull_WithNull_ReturnsFailureInResult()
    {
        // Arrange
        IResult result = Result.OK();
        const string? categoryName = null;

        // Act
        result.Guard(categoryName).ErrorIfNull().End();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfNull method with a null value and property name.
    /// </summary>
    [Fact]
    public void ErrorIfNull_WithNullAndPropertyName_ReturnsFailureInResult()
    {
        // Arrange
        IResult result = Result.OK();
        const string? categoryName = null;

        // Act
        result.Guard(categoryName).ErrorIfNull(message: "{0} not found.").End();

        // Assert
        Assert.True(result.IsFailure);
        Assert.Contains(result.Errors, m => m.Key == nameof(categoryName));
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfNull method with an empty string.
    /// </summary>
    [Fact]
    public void ErrorIfNull_WithEmpty_ReturnsSuccessInResult()
    {
        // Arrange
        IResult result = Result.OK();
        string categoryName = string.Empty;

        // Act
        result.Guard(categoryName).ErrorIfNull().End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfNullOrEmpty method with an empty string.
    /// </summary>
    [Fact]
    public void ErrorIfNullOrEmpty_WithEmpty_ReturnsFailureInResult()
    {
        // Arrange
        IResult result = Result.OK();
        string? categoryName = string.Empty;

        // Act
        result.Guard(categoryName).ErrorIfNullOrEmpty().End();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfNullOrEmpty method with whitespace.
    /// </summary>
    [Fact]
    public void ErrorIfNullOrEmpty_WithWhiteSpace_ReturnsSuccessInResult()
    {
        // Arrange
        IResult result = Result.OK();
        const string categoryName = " ";

        // Act
        result.Guard(categoryName).ErrorIfNullOrEmpty().End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfNullOrWhiteSpace method with whitespace.
    /// </summary>
    [Fact]
    public void ErrorIfNullOrWhiteSpace_WithWhiteSpace_ReturnsFailureInResult()
    {
        // Arrange
        IResult result = Result.OK();
        const string? categoryName = "   ";

        // Act
        result.Guard(categoryName).ErrorIfNullOrWhiteSpace().End();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfNullOrWhiteSpace method with data.
    /// </summary>
    [Fact]
    public void ErrorIfNullOrWhiteSpace_WithData_ReturnsSuccessInResult()
    {
        // Arrange
        IResult result = Result.OK();
        const string categoryName = "Hello, world!";

        // Act
        result.Guard(categoryName).ErrorIfNullOrWhiteSpace().End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfNotNull method with a null value.
    /// </summary>
    [Fact]
    public void ErrorIfNotNull_WithNull_ReturnsSuccessInResult()
    {
        // Arrange
        IResult result = Result.OK();
        const string? categoryName = null;

        // Act
        result.Guard(categoryName).ErrorIfNotNull().End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfNotNull method with an empty string.
    /// </summary>
    [Fact]
    public void ErrorIfNotNull_WithEmpty_ReturnsFailureInResult()
    {
        // Arrange
        IResult result = Result.OK();
        string categoryName = string.Empty;

        // Act
        result.Guard(categoryName).ErrorIfNotNull().End();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfNotNullOrNotEmpty method with data.
    /// </summary>
    [Fact]
    public void ErrorIfNotNullOrNotEmpty_WithData_ReturnsFailureInResult()
    {
        // Arrange
        IResult result = Result.OK();
        const string? categoryName = "Hello, world!";

        // Act
        result.Guard(categoryName).ErrorIfNotNullOrNotEmpty().End();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfNotNullOrNotEmpty method with a null value.
    /// </summary>
    [Fact]
    public void ErrorIfNotNullOrNotEmpty_WithNull_ReturnsSuccessInResult()
    {
        // Arrange
        IResult result = Result.OK();
        const string? categoryName = null;

        // Act
        result.Guard(categoryName).ErrorIfNotNullOrNotEmpty().End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfEqualTo method with equal data.
    /// </summary>
    [Fact]
    public void ErrorIfEqualTo_WithSameData_ReturnsFailureInResult()
    {
        // Arrange
        IResult result = Result.OK();
        const string categoryName = "Hello, world!";

        // Act
        result.Guard(categoryName).ErrorIfEqualTo("Hello, world!").End();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfEqualTo method with non-equal data.
    /// </summary>
    [Fact]
    public void ErrorIfEqualTo_WithNoSameData_ReturnsSuccessInResult()
    {
        // Arrange
        IResult result = Result.OK();
        const string categoryName = "Hello, world!";

        // Act
        result.Guard(categoryName).ErrorIfEqualTo("Hello, world.").End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfNotEqualTo method with equal data.
    /// </summary>
    [Fact]
    public void ErrorIfNotEqualTo_WithSameData_ReturnsSuccessInResult()
    {
        // Arrange
        IResult result = Result.OK();
        const string categoryName = "Hello, world!";

        // Act
        result.Guard(categoryName).ErrorIfNotEqualTo("Hello, world!").End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfNotEqualTo method with non-equal data.
    /// </summary>
    [Fact]
    public void ErrorIfNotEqualTo_WithNoSameData_ReturnsFailureInResult()
    {
        // Arrange
        IResult result = Result.OK();
        const string categoryName = "Hello, world!";

        // Act
        result.Guard(categoryName).ErrorIfNotEqualTo("Hello, world.").End();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfLengthEqualTo method with equal length.
    /// </summary>
    /// <param name="text">The text to check the length.</param>
    /// <param name="length">The expected length.</param>
    [Theory]
    [InlineData("Hello, world!", 13)]
    [InlineData("Hi", 2)]
    public void ErrorIflengthEqualTo_WithEqualslength_ReturnsFailureInResult(string text, int length)
    {
        // Arrange
        IResult result = Result.OK();

        // Act
        result.Guard(text).ErrorIfLengthEqualTo(length).End();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfLengthEqualTo method with non-equal length.
    /// </summary>
    /// <param name="text">The text to check the length.</param>
    /// <param name="length">The expected length.</param>
    [Theory]
    [InlineData("Hello, world!", 12)]
    [InlineData("Hi", 3)]
    [InlineData(null, 2)]
    public void ErrorIflengthEqualTo_WithNotEqualslength_ReturnsSuccessInResult(string? text, int length)
    {
        // Arrange
        IResult result = Result.OK();

        // Act
        result.Guard(text).ErrorIfLengthEqualTo(length).End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfLengthNotEqualTo method with equal length.
    /// </summary>
    /// <param name="text">The text to check the length.</param>
    /// <param name="length">The expected length.</param>
    [Theory]
    [InlineData("Hello, world!", 13)]
    [InlineData("Hi", 2)]
    [InlineData(null, 2)]
    public void ErrorIflengthNotEqualTo_WithEqualslength_ReturnsSuccessInResult(string? text, int length)
    {
        // Arrange
        IResult result = Result.OK();

        // Act
        result.Guard(text).ErrorIfLengthNotEqualTo(length).End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfLengthNotEqualTo method with non-equal length.
    /// </summary>
    /// <param name="text">The text to check the length.</param>
    /// <param name="length">The expected length.</param>
    [Theory]
    [InlineData("Hello, world!", 14)]
    [InlineData("Hi", 1)]
    public void ErrorIflengthNotEqualTo_WithNotEqualslength_ReturnsFailureInResult(string text, int length)
    {
        // Arrange
        IResult result = Result.OK();

        // Act
        result.Guard(text).ErrorIfLengthNotEqualTo(length).End();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfLengthGreaterThan method with equal length.
    /// </summary>
    /// <param name="text">The text to check the length.</param>
    /// <param name="length">The expected length.</param>
    [Theory]
    [InlineData("Hello, world!", 13)]
    [InlineData("Hi", 2)]
    [InlineData(null, 2)]
    public void ErrorIflengthGreaterThan_WithEqualslength_ReturnsSuccessInResult(string? text, int length)
    {
        // Arrange
        IResult result = Result.OK();

        // Act
        result.Guard(text).ErrorIfLengthGreaterThan(length).End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfLengthGreaterThan method with less length.
    /// </summary>
    /// <param name="text">The text to check the length.</param>
    /// <param name="length">The expected length.</param>
    [Theory]
    [InlineData("Hello, world!", 12)]
    [InlineData("Hi", 1)]
    public void ErrorIflengthGreaterThan_WithLesslength_ReturnsFailureInResult(string text, int length)
    {
        // Arrange
        IResult result = Result.OK();

        // Act
        result.Guard(text).ErrorIfLengthGreaterThan(length).End();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfLengthGreaterThanOrEqualTo method with equal length.
    /// </summary>
    /// <param name="text">The text to check the length.</param>
    /// <param name="length">The expected length.</param>
    [Theory]
    [InlineData("Hello, world!", 13)]
    [InlineData("Hi", 2)]
    public void ErrorIflengthGreaterThanOrEqualTo_WithEqualslength_ReturnsFailureInResult(string text, int length)
    {
        // Arrange
        IResult result = Result.OK();

        // Act
        result.Guard(text).ErrorIfLengthGreaterThanOrEqualTo(length).End();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfLengthGreaterThanOrEqualTo method with less length.
    /// </summary>
    /// <param name="text">The text to check the length.</param>
    /// <param name="length">The expected length.</param>
    [Theory]
    [InlineData("Hello, world!", 14)]
    [InlineData("Hi", 3)]
    [InlineData(null, 2)]
    public void ErrorIflengthGreaterThanOrEqualTo_WithLesslength_ReturnsSuccessInResult(string? text, int length)
    {
        // Arrange
        IResult result = Result.OK();

        // Act
        result.Guard(text).ErrorIfLengthGreaterThanOrEqualTo(length).End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfLengthLessThan method with equal length.
    /// </summary>
    /// <param name="text">The text to check the length.</param>
    /// <param name="length">The expected length.</param>
    [Theory]
    [InlineData("Hello, world!", 13)]
    [InlineData("Hi", 2)]
    [InlineData(null, 2)]
    public void ErrorIflengthLessThan_WithEqualslength_ReturnsSuccessInResult(string? text, int length)
    {
        // Arrange
        IResult result = Result.OK();

        // Act
        result.Guard(text).ErrorIfLengthLessThan(length).End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfLengthLessThan method with less length.
    /// </summary>
    /// <param name="text">The text to check the length.</param>
    /// <param name="length">The expected length.</param>
    [Theory]
    [InlineData("Hello, world!", 14)]
    [InlineData("Hi", 3)]
    public void ErrorIflengthLessThan_WithLesslength_ReturnsFailureInResult(string text, int length)
    {
        // Arrange
        IResult result = Result.OK();

        // Act
        result.Guard(text).ErrorIfLengthLessThan(length).End();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfLengthLessThanOrEqualTo method with equal length.
    /// </summary>
    /// <param name="text">The text to check the length.</param>
    /// <param name="length">The expected length.</param>
    [Theory]
    [InlineData("Hello, world!", 13)]
    [InlineData("Hi", 2)]
    public void ErrorIflengthLessThanOrEqualTo_WithEqualslength_ReturnsFailureInResult(string text, int length)
    {
        // Arrange
        IResult result = Result.OK();

        // Act
        result.Guard(text).ErrorIfLengthLessThanOrEqualTo(length).End();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfLengthLessThanOrEqualTo method with less length.
    /// </summary>
    /// <param name="text">The text to check the length.</param>
    /// <param name="length">The expected length.</param>
    [Theory]
    [InlineData("Hello, world!", 12)]
    [InlineData("Hi", 1)]
    [InlineData(null, 2)]
    public void ErrorIflengthLessThanOrEqualTo_WithLesslength_ReturnsSuccessInResult(string? text, int length)
    {
        // Arrange
        IResult result = Result.OK();

        // Act
        result.Guard(text).ErrorIfLengthLessThanOrEqualTo(length).End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfNotValidEmail method with valid email.
    /// </summary>
    /// <param name="email">The email address to check.</param>
    [Theory]
    [InlineData("test@test")]
    [InlineData("test@test.com")]
    [InlineData("")]
    public void ErrorIfNotValidEmail_WithValidEmail_ReturnsSuccessInResult(string email)
    {
        // Arrange
        IResult result = Result.OK();

        // Act
        result.Guard(email).ErrorIfNotValidEmail().End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfNotValidEmail method with invalid email.
    /// </summary>
    /// <param name="email">The email address to check.</param>
    [Theory]
    [InlineData("test")]
    [InlineData("test@")]
    public void ErrorIfNotValidEmail_WithInvalidEmail_ReturnsFailureInResult(string email)
    {
        // Arrange
        IResult result = Result.OK();

        // Act
        result.Guard(email).ErrorIfNotValidEmail().End();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Tests the ErrorIfContains method when the target string is contained in the value.
    /// </summary>
    /// <param name="value">The input string.</param>
    /// <param name="target">The target string to check for containment.</param>
    [Theory]
    [InlineData("test", "te")]
    [InlineData("test", "es")]
    public void ErrorIfContains_WithContainsString_ReturnsFailureInResult(string value, string target)
    {
        // Arrange
        IResult result = Result.OK();

        // Act
        result.Guard(value).ErrorIfContains(target).End();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Tests the ErrorIfContains method when the target string is contained in the value.
    /// </summary>
    [Fact]
    public void ErrorIfContains_WithContainsString_ReturnsSuccessInResult()
    {
        // Arrange
        IResult result = Result.OK();
        const string value = "test";
        const string? target = null;

        // Act
        result.Guard(value).ErrorIfContains(target).End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Tests the ErrorIfNotContains method when the target string is not contained in the value.
    /// </summary>
    /// <param name="value">The input string.</param>
    /// <param name="target">The target string to check for non-containment.</param>
    [Theory]
    [InlineData("test", "Tes")]
    [InlineData("test", "t ")]
    public void ErrorIfNotContains_WithNotContainsString_ReturnsFailureInResult(string value, string target)
    {
        // Arrange
        IResult result = Result.OK();

        // Act
        result.Guard(value).ErrorIfNotContains(target).End();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Tests the ErrorIfNotContains method when the target string is not contained in the value.
    /// </summary>
    /// <param name="value">The input string.</param>
    /// <param name="target">The target string to check for non-containment.</param>
    [Theory]
    [InlineData("test", null)]
    [InlineData(null, "test")]
    public void ErrorIfNotContains_WithNotContainsStringNullable_ReturnsFailureInResult(string? value, string? target)
    {
        // Arrange
        IResult result = Result.OK();

        // Act
        result.Guard(value).ErrorIfNotContains(target).End();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Tests the ErrorIfNotContains method when the target string is not contained in the value.
    /// </summary>
    [Fact]
    public void ErrorIfNotContains_WithNotContainsNullable_ReturnsSuccessInResult()
    {
        // Arrange
        IResult result = Result.OK();
        const string? value = null;
        const string? target = null;

        // Act
        result.Guard(value).ErrorIfNotContains(target).End();

        // Assert
        Assert.True(result.IsSuccess);
    }
}