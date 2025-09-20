namespace Tolitech.Results.Guards.UnitTests;

/// <summary>
/// Unit tests for the generic guard methods.
/// </summary>
public class GenericTests
{
    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfNull method with a null value.
    /// </summary>
    [Fact]
    public void ErrorIfNull_WithNull_ReturnsFailureResult()
    {
        // Arrange
        IResult result = Result.OK();
        decimal? amount = null;

        // Act
        result.Guard(amount).ErrorIfNull().End();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfNull method with a non-null value.
    /// </summary>
    [Fact]
    public void ErrorIfNull_WithNotNull_ReturnsSuccessResult()
    {
        // Arrange
        IResult result = Result.OK();
        decimal? amount = 10.50M;

        // Act
        result.Guard(amount).ErrorIfNull().End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfNotNull method with a null value.
    /// </summary>
    [Fact]
    public void ErrorIfNotNull_WithNull_ReturnsSuccessResult()
    {
        // Arrange
        IResult result = Result.OK();
        decimal? amount = null;

        // Act
        result.Guard(amount).ErrorIfNotNull().End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfNotNull method with a non-null value.
    /// </summary>
    [Fact]
    public void ErrorIfNotNull_WithNotNull_ReturnsFailureResult()
    {
        // Arrange
        IResult result = Result.OK();
        decimal? amount = 10.50M;

        // Act
        result.Guard(amount).ErrorIfNotNull().End();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfEqualTo method with a null value.
    /// </summary>
    [Fact]
    public void ErrorIfEqualTo_WithNull_ReturnsFailureResult()
    {
        // Arrange
        IResult result = Result.OK();
        decimal? amount = null;

        // Act
        result.Guard(amount).ErrorIfEqualTo(null).End();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfEqualTo method with a null value.
    /// </summary>
    [Fact]
    public void ErrorIfEqualTo_WithValueAndNull_ReturnsSuccessResult()
    {
        // Arrange
        IResult result = Result.OK();
        decimal? amount = 10;

        // Act
        result.Guard(amount).ErrorIfEqualTo(null).End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfEqualTo method with a null value.
    /// </summary>
    [Fact]
    public void ErrorIfEqualTo_WithValue_ReturnsFailureResult()
    {
        // Arrange
        IResult result = Result.OK();
        const decimal amount = 10;

        // Act
        result.Guard(amount).ErrorIfEqualTo(10).End();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfEqualTo method with a non-null value.
    /// </summary>
    [Fact]
    public void ErrorIfEqualTo_WithNull_ReturnsSuccessResult()
    {
        // Arrange
        IResult result = Result.OK();
        decimal? amount = null;

        // Act
        result.Guard(amount).ErrorIfEqualTo(10.50M).End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfEqualTo method with equal values.
    /// </summary>
    [Fact]
    public void ErrorIfEqualTo_WithEqual_ReturnsFailureResult()
    {
        // Arrange
        IResult result = Result.OK();
        decimal? amount = 10.50M;

        // Act
        result.Guard(amount).ErrorIfEqualTo(10.50M).End();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfEqualTo method with not equal values.
    /// </summary>
    [Fact]
    public void ErrorIfEqualTo_WithNotEqual_ReturnsSuccessResult()
    {
        // Arrange
        IResult result = Result.OK();
        decimal? amount = 10.50M;

        // Act
        result.Guard(amount).ErrorIfEqualTo(10.51M).End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfNotEqualTo method with a null value.
    /// </summary>
    [Fact]
    public void ErrorIfNotEqualTo_WithNull_ReturnsSuccessResult()
    {
        // Arrange
        IResult result = Result.OK();
        decimal? amount = null;

        // Act
        result.Guard(amount).ErrorIfNotEqualTo(null).End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfNotEqualTo method with a null value.
    /// </summary>
    [Fact]
    public void ErrorIfNotEqualTo_WithNull_ReturnsFailureResult()
    {
        // Arrange
        IResult result = Result.OK();
        decimal? amount = null;

        // Act
        result.Guard(amount).ErrorIfNotEqualTo(10.50M).End();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfNotEqualTo method with a null value.
    /// </summary>
    [Fact]
    public void ErrorIfNotEqualTo_WithValue_ReturnsFailureResult()
    {
        // Arrange
        IResult result = Result.OK();
        const decimal amount = 10;

        // Act
        result.Guard(amount).ErrorIfNotEqualTo(10.01M).End();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfNotEqualTo method with not equal values.
    /// </summary>
    [Fact]
    public void ErrorIfNotEqualTo_WithNotEqual_ReturnsFailureResult()
    {
        // Arrange
        IResult result = Result.OK();
        decimal? amount = 10.50M;

        // Act
        result.Guard(amount).ErrorIfNotEqualTo(10.51M).End();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfNotEqualTo method with equal values.
    /// </summary>
    [Fact]
    public void ErrorIfNotEqualTo_WithEqual_ReturnsSuccessResult()
    {
        // Arrange
        IResult result = Result.OK();
        decimal? amount = 10.50M;

        // Act
        result.Guard(amount).ErrorIfNotEqualTo(10.50M).End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfLessThan method with a null value.
    /// </summary>
    [Fact]
    public void ErrorIfLessThan_WithNull_ReturnsSuccessResult()
    {
        // Arrange
        IResult result = Result.OK();
        decimal? amount = null;

        // Act
        result.Guard(amount).ErrorIfLessThan(10.51M).End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfLessThan method with a value less than the threshold.
    /// </summary>
    [Fact]
    public void ErrorIfLessThan_WithLess_ReturnsFailureResult()
    {
        // Arrange
        IResult result = Result.OK();
        decimal? amount = 10.50M;

        // Act
        result.Guard(amount).ErrorIfLessThan(10.51M).End();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfLessThan method with a value equal to the threshold.
    /// </summary>
    [Fact]
    public void ErrorIfLessThan_WithEqual_ReturnsSuccessResult()
    {
        // Arrange
        IResult result = Result.OK();
        decimal? amount = 10.50M;

        // Act
        result.Guard(amount).ErrorIfLessThan(10.50M).End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfLessThanOrEqualTo method with a null value.
    /// </summary>
    [Fact]
    public void ErrorIfLessThanOrEqualTo_WithNull_ReturnsSuccessResult()
    {
        // Arrange
        IResult result = Result.OK();
        decimal? amount = null;

        // Act
        result.Guard(amount).ErrorIfLessThanOrEqualTo(10.51M).End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfLessThanOrEqualTo method with a value equal to the threshold.
    /// </summary>
    [Fact]
    public void ErrorIfLessThanOrEqualTo_WithEqual_ReturnsFailureResult()
    {
        // Arrange
        IResult result = Result.OK();
        decimal? amount = 10.50M;

        // Act
        result.Guard(amount).ErrorIfLessThanOrEqualTo(10.50M).End();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfLessThanOrEqualTo method with a value equal to the threshold.
    /// </summary>
    [Fact]
    public void ErrorIfLessThanOrEqualTo_WithValue_ReturnsFailureResult()
    {
        // Arrange
        IResult result = Result.OK();
        const decimal amount = 10.50M;

        // Act
        result.Guard(amount).ErrorIfLessThanOrEqualTo(10.50M).End();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfLessThanOrEqualTo method with a value greater than the threshold.
    /// </summary>
    [Fact]
    public void ErrorIfLessThanOrEqualTo_WithGreater_ReturnsSuccessResult()
    {
        // Arrange
        IResult result = Result.OK();
        decimal? amount = 10.50M;

        // Act
        result.Guard(amount).ErrorIfLessThanOrEqualTo(10.49M).End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfGreaterThan method with a null value.
    /// </summary>
    [Fact]
    public void ErrorIfGreaterThan_WithNull_ReturnsSuccessResult()
    {
        // Arrange
        IResult result = Result.OK();
        decimal? amount = null;

        // Act
        result.Guard(amount).ErrorIfGreaterThan(10.50M).End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfGreaterThan method with a value equal to the threshold.
    /// </summary>
    [Fact]
    public void ErrorIfGreaterThan_WithEqual_ReturnsSuccessResult()
    {
        // Arrange
        IResult result = Result.OK();
        decimal? amount = 10.50M;

        // Act
        result.Guard(amount).ErrorIfGreaterThan(10.50M).End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfGreaterThan method with a value greater than the threshold.
    /// </summary>
    [Fact]
    public void ErrorIfGreaterThan_WithGreaterNullable_ReturnsFailureResult()
    {
        // Arrange
        IResult result = Result.OK();
        decimal? amount = 10.50M;

        // Act
        result.Guard(amount).ErrorIfGreaterThan(10.49M).End();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfGreaterThan method with a value greater than the threshold.
    /// </summary>
    [Fact]
    public void ErrorIfGreaterThan_WithGreater_ReturnsFailureResult()
    {
        // Arrange
        IResult result = Result.OK();
        const decimal amount = 10.50M;

        // Act
        result.Guard(amount).ErrorIfGreaterThan(10.49M).End();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfGreaterThanOrEqualTo method with a null value.
    /// </summary>
    [Fact]
    public void ErrorIfGreaterThanOrEqualTo_WithNull_ReturnsSuccessResult()
    {
        // Arrange
        IResult result = Result.OK();
        decimal? amount = null;

        // Act
        result.Guard(amount).ErrorIfGreaterThanOrEqualTo(10.50M).End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfGreaterThanOrEqualTo method with a value equal to the threshold.
    /// </summary>
    [Fact]
    public void ErrorIfGreaterThanOrEqualTo_WithEqualNullable_ReturnsFailureResult()
    {
        // Arrange
        IResult result = Result.OK();
        decimal? amount = 10.50M;

        // Act
        result.Guard(amount).ErrorIfGreaterThanOrEqualTo(10.50M).End();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfGreaterThanOrEqualTo method with a value equal to the threshold.
    /// </summary>
    [Fact]
    public void ErrorIfGreaterThanOrEqualTo_WithEqual_ReturnsFailureResult()
    {
        // Arrange
        IResult result = Result.OK();
        const decimal amount = 10.50M;

        // Act
        result.Guard(amount).ErrorIfGreaterThanOrEqualTo(10.50M).End();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfGreaterThanOrEqualTo method with a value less than the threshold.
    /// </summary>
    [Fact]
    public void ErrorIfGreaterThanOrEqualTo_WithLess_ReturnsSuccessResult()
    {
        // Arrange
        IResult result = Result.OK();
        decimal? amount = 10.50M;

        // Act
        result.Guard(amount).ErrorIfGreaterThanOrEqualTo(10.51M).End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfBetween method with a null value.
    /// </summary>
    [Fact]
    public void ErrorIfBetween_WithNull_ReturnsSuccessResult()
    {
        // Arrange
        IResult result = Result.OK();
        decimal? amount = null;

        // Act
        result.Guard(amount).ErrorIfBetween(9, 11).End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfBetween method with a value within the specified range.
    /// </summary>
    [Fact]
    public void ErrorIfBetween_WithBetweenNullable_ReturnsFailureResult()
    {
        // Arrange
        IResult result = Result.OK();
        decimal? amount = 10M;

        // Act
        result.Guard(amount).ErrorIfBetween(9, 11).End();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfBetween method with a value within the specified range.
    /// </summary>
    [Fact]
    public void ErrorIfBetween_WithBetween_ReturnsFailureResult()
    {
        // Arrange
        IResult result = Result.OK();
        const decimal amount = 10M;

        // Act
        result.Guard(amount).ErrorIfBetween(9, 11).End();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfBetween method with a value outside the specified range.
    /// </summary>
    [Fact]
    public void ErrorIfBetween_WithNotBetweenNullable_ReturnsSuccessResult()
    {
        // Arrange
        IResult result = Result.OK();
        decimal? amount = 10;

        // Act
        result.Guard(amount).ErrorIfBetween(10.01M, 11).End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfBetween method with a value outside the specified range.
    /// </summary>
    [Fact]
    public void ErrorIfBetween_WithNotBetween_ReturnsSuccessResult()
    {
        // Arrange
        IResult result = Result.OK();
        const decimal amount = 10;

        // Act
        result.Guard(amount).ErrorIfBetween(10.01M, 11).End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfNotBetween method with a null value.
    /// </summary>
    [Fact]
    public void ErrorIfNotBetween_WithNull_ReturnsSuccessResult()
    {
        // Arrange
        IResult result = Result.OK();
        decimal? amount = null;

        // Act
        result.Guard(amount).ErrorIfNotBetween(9, 11).End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfNotBetween method with a value within the specified range.
    /// </summary>
    [Fact]
    public void ErrorIfNotBetween_WithBetweenNullable_ReturnsSuccessResult()
    {
        // Arrange
        IResult result = Result.OK();
        decimal? amount = 10M;

        // Act
        result.Guard(amount).ErrorIfNotBetween(1, 10).End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfNotBetween method with a value within the specified range.
    /// </summary>
    [Fact]
    public void ErrorIfNotBetween_WithBetween_ReturnsSuccessResult()
    {
        // Arrange
        IResult result = Result.OK();
        const decimal amount = 10M;

        // Act
        result.Guard(amount).ErrorIfNotBetween(1, 10).End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfNotBetween method with a value outside the specified range.
    /// </summary>
    [Fact]
    public void ErrorIfNotBetween_WithNotBetweenNullable_ReturnsSuccessFailure()
    {
        // Arrange
        IResult result = Result.OK();
        decimal? amount = 10M;

        // Act
        result.Guard(amount).ErrorIfNotBetween(12, 9).End();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfNotBetween method with a value outside the specified range.
    /// </summary>
    [Fact]
    public void ErrorIfNotBetween_WithNotBetween_ReturnsSuccessFailure()
    {
        // Arrange
        IResult result = Result.OK();
        const decimal amount = 10M;

        // Act
        result.Guard(amount).ErrorIfNotBetween(12, 9).End();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfNotBetween method with a value outside the specified range.
    /// </summary>
    [Fact]
    public void ErrorIfNotBetween_WithNotBetween_ReturnsFailureResult()
    {
        // Arrange
        IResult result = Result.OK();
        decimal? amount = 10M;

        // Act
        result.Guard(amount).ErrorIfNotBetween(9, 9.9M).End();

        // Assert
        Assert.True(result.IsFailure);
    }
}