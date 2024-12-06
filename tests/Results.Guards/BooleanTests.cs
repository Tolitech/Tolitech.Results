using System.Globalization;

namespace Tolitech.Results.Guards.UnitTests;

/// <summary>
/// Unit tests for the boolean-related guard methods.
/// </summary>
public class BooleanTests
{
    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfNull method when called with a null value.
    /// </summary>
    [Fact]
    public void ErrorIfNull_WithNull_ReturnsFailureInResult()
    {
        // Arrange
        Result result = Result.OK();
        bool? approved = null;

        // Act
        result.Guard(approved).ErrorIfNull().End();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfNull method when called with a non-null value.
    /// </summary>
    [Fact]
    public void ErrorIfNull_WithTrue_ReturnsSuccessInResult()
    {
        // Arrange
        Result result = Result.OK();
        bool? approved = true;

        // Act
        result.Guard(approved).ErrorIfNull().End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfNotNull method when called with a null value.
    /// </summary>
    [Fact]
    public void ErrorIfNotNull_WithNull_ReturnsSuccessInResult()
    {
        // Arrange
        Result result = Result.OK();
        bool? approved = null;

        // Act
        result.Guard(approved).ErrorIfNotNull().End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfNotNull method when called with a non-null value.
    /// </summary>
    [Fact]
    public void ErrorIfNotNull_WithTrue_ReturnsFailureInResult()
    {
        // Arrange
        Result result = Result.OK();
        bool? approved = true;

        // Act
        result.Guard(approved).ErrorIfNotNull().End();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfTrue method when called with a null value.
    /// </summary>
    [Fact]
    public void ErrorIfTrue_WithNull_ReturnsSuccessInResult()
    {
        // Arrange
        Result result = Result.OK();
        bool? approved = null;

        // Act
        result.Guard(approved).ErrorIfTrue().End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfTrue method when called with a null value.
    /// </summary>
    [Fact]
    public void ErrorIfTrue_WithTrueNullable_ReturnsFailureInResult()
    {
        // Arrange
        Result result = Result.OK();
        bool? approved = true;

        // Act
        result.Guard(approved).ErrorIfTrue().End();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfTrue method when called with a false value.
    /// </summary>
    [Fact]
    public void ErrorIfTrue_WithFalseNullable_ReturnsSuccessInResult()
    {
        // Arrange
        Result result = Result.OK();
        bool? approved = false;

        // Act
        result.Guard(approved).ErrorIfTrue().End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfTrue method when called with a false value.
    /// </summary>
    [Fact]
    public void ErrorIfTrue_WithFalse_ReturnsSuccessInResult()
    {
        // Arrange
        Result result = Result.OK();
        const bool approved = false;

        // Act
        result.Guard(approved).ErrorIfTrue().End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfTrue method when called with a true value.
    /// </summary>
    [Fact]
    public void ErrorIfTrue_WithTrue_ReturnsFailureInResult()
    {
        // Arrange
        Result result = Result.OK();
        const bool approved = true;

        // Act
        result.Guard(approved).ErrorIfTrue().End();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfFalse method when called with a null value.
    /// </summary>
    [Fact]
    public void ErrorIfFalse_WithNull_ReturnsSuccessInResult()
    {
        // Arrange
        Result result = Result.OK();
        bool? approved = null;

        // Act
        result.Guard(approved).ErrorIfFalse().End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfFalse method when called with a false value.
    /// </summary>
    [Fact]
    public void ErrorIfFalse_WithFalse_ReturnsFailureInResult()
    {
        // Arrange
        Result result = Result.OK();
        const bool approved = false;

        // Act
        result.Guard(approved).ErrorIfFalse().End();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfFalse method when called with a false value.
    /// </summary>
    [Fact]
    public void ErrorIfFalse_WithFalseNullable_ReturnsFailureInResult()
    {
        // Arrange
        Result result = Result.OK();
        bool? approved = false;

        // Act
        result.Guard(approved).ErrorIfFalse().End();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfFalse method when called with a true value.
    /// </summary>
    [Fact]
    public void ErrorIfFalse_WithTrue_ReturnsSuccessInResult()
    {
        // Arrange
        Result result = Result.OK();
        const bool approved = true;

        // Act
        result.Guard(approved).ErrorIfFalse().End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Theory test to verify the behavior of the ErrorIfFalseOrNull method with various values.
    /// </summary>
    /// <param name="approved">The boolean value to check.</param>
    [Theory]
    [InlineData(null)]
    [InlineData(false)]
    public void ErrorIfFalseOrNull_WithNullOrFalse_ReturnsFailureInResult(bool? approved)
    {
        // Arrange
        Result result = Result.OK();

        // Act
        result.Guard(approved).ErrorIfFalseOrNull().End();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Theory test to verify the behavior of the ErrorIfFalseOrNull method when called with a true value.
    /// </summary>
    [Fact]
    public void ErrorIfFalseOrNull_WithTrue_ReturnsSuccessInResult()
    {
        // Arrange
        Result result = Result.OK();
        bool? approved = true;

        // Act
        result.Guard(approved).ErrorIfFalseOrNull().End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Theory test to verify the behavior of the ErrorIfTrueOrNull method when called with a null value.
    /// </summary>
    /// <param name="approved">The boolean value to check.</param>
    [Theory]
    [InlineData(null)]
    [InlineData(true)]
    public void ErrorIfTrueOrNull_WithNull_ReturnsFailureInResult(bool? approved)
    {
        // Arrange
        Result result = Result.OK();

        // Act
        result.Guard(approved).ErrorIfTrueOrNull().End();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Theory test to verify the behavior of the ErrorIfTrueOrNull method when called with a false value.
    /// </summary>
    [Fact]
    public void ErrorIfTrueOrNull_WithFalse_ReturnsSuccessInResult()
    {
        // Arrange
        Result result = Result.OK();
        bool? approved = false;

        // Act
        result.Guard(approved).ErrorIfTrueOrNull().End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfEqualTo method when called with a false value.
    /// </summary>
    [Fact]
    public void ErrorIfEqualTo_WithFalseNullable_ReturnsFailureInResult()
    {
        // Arrange
        Result result = Result.OK();
        bool? approved = false;

        // Act
        result.Guard(approved).ErrorIfEqualTo(false).End();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfEqualTo method when called with a false value.
    /// </summary>
    [Fact]
    public void ErrorIfEqualTo_WithFalse_ReturnsFailureInResult()
    {
        // Arrange
        Result result = Result.OK();
        const bool approved = false;

        // Act
        result.Guard(approved).ErrorIfEqualTo(false).End();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfEqualTo method when called with a true value.
    /// </summary>
    [Fact]
    public void ErrorIfEqualTo_WithTrue_ReturnsSuccessInResult()
    {
        // Arrange
        Result result = Result.OK();
        const bool approved = true;

        // Act
        result.Guard(approved).ErrorIfEqualTo(false).End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfNotEqualTo method when called with a false value.
    /// </summary>
    [Fact]
    public void ErrorIfNotEqualTo_WithFalseNullable_ReturnsFailureInResult()
    {
        // Arrange
        Result result = Result.OK();
        bool? approved = false;

        // Act
        result.Guard(approved).ErrorIfNotEqualTo(true).End();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfNotEqualTo method when called with a false value.
    /// </summary>
    [Fact]
    public void ErrorIfNotEqualTo_WithFalse_ReturnsFailureInResult()
    {
        // Arrange
        Result result = Result.OK();
        const bool approved = false;

        // Act
        result.Guard(approved).ErrorIfNotEqualTo(true).End();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfNotEqualTo method when called with a true value.
    /// </summary>
    [Fact]
    public void ErrorIfNotEqualTo_WithTrue_ReturnsSuccessInResult()
    {
        // Arrange
        Result result = Result.OK();
        const bool approved = true;

        // Act
        result.Guard(approved).ErrorIfNotEqualTo(true).End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Theory test to verify the behavior of the ErrorIfNull method with null value, property name, and culture.
    /// </summary>
    /// <param name="cultureName">The culture name to use for the error message.</param>
    [Theory]
    [InlineData("en-US")]
    [InlineData("es-ES")]
    [InlineData("pt-BR")]
    [InlineData("fr")]
    [InlineData("de")]
    [InlineData("ru")]
    [InlineData("zh")]
    public void ErrorIfNull_WithNullAndPropertyNameAndCulture_ReturnsFailureInResult(string cultureName)
    {
        // Arrange
        CultureInfo culture = new(cultureName);
        CultureInfo.DefaultThreadCurrentCulture = culture;
        CultureInfo.DefaultThreadCurrentUICulture = culture;

        Result result = Result.OK();
        bool? approved = null;

        // Act
        result.Guard(approved).ErrorIfNull(StatusCode.InternalServerError).End();

        // Assert
        Assert.True(result.IsFailure);
        Assert.Equal(StatusCode.InternalServerError, result.StatusCode);
        Assert.Contains(result.Messages, m => m.Type == MessageType.Error);
        Assert.Contains("approved", result.Messages.First().Message, StringComparison.CurrentCulture);
    }
}