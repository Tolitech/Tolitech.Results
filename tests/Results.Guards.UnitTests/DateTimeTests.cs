namespace Tolitech.Results.Guards.UnitTests;

/// <summary>
/// Unit tests for the DateTime-related guard methods.
/// </summary>
public class DateTimeTests
{
    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfFuture method with a future DateTime.
    /// </summary>
    [Fact]
    public void ErrorIfFuture_WithFutureDateTime_ReturnsFailureInResult()
    {
        // Arrange
        Result result = Result.OK();
        DateTime date = DateTime.Today.AddDays(1);

        // Act
        result.Guard(date).ErrorIfFuture().End();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfFuture method with a future DateTime.
    /// </summary>
    [Fact]
    public void ErrorIfFuture_WithFutureDateTimeNullable_ReturnsFailureInResult()
    {
        // Arrange
        Result result = Result.OK();
        DateTime? date = DateTime.Today.AddDays(1);

        // Act
        result.Guard(date).ErrorIfFuture().End();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfFuture method with the current DateTime.
    /// </summary>
    [Fact]
    public void ErrorIfFuture_WithNow_ReturnsSuccessInResult()
    {
        // Arrange
        Result result = Result.OK();
        DateTime date = DateTime.Now;

        // Act
        result.Guard(date).ErrorIfFuture().End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfFuture method with a DateTime set to today.
    /// </summary>
    [Fact]
    public void ErrorIfFuture_WithTodayDateTime_ReturnsSuccessInResult()
    {
        // Arrange
        Result result = Result.OK();
        DateTime date = DateTime.Today;

        // Act
        result.Guard(date).ErrorIfFuture().End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfFuture method with a null DateTime.
    /// </summary>
    [Fact]
    public void ErrorIfFuture_WithNull_ReturnsSuccessInResult()
    {
        // Arrange
        Result result = Result.OK();
        DateTime? date = null;

        // Act
        result.Guard(date).ErrorIfFuture().End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfFuture method with a future DateOnly.
    /// </summary>
    [Fact]
    public void ErrorIfFuture_WithFutureDateOnly_ReturnsFailureInResult()
    {
        // Arrange
        Result result = Result.OK();
        DateOnly date = DateOnly.FromDateTime(DateTime.Today.AddDays(1));

        // Act
        result.Guard(date).ErrorIfFuture().End();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfFuture method with a future DateOnly.
    /// </summary>
    [Fact]
    public void ErrorIfFuture_WithFutureDateOnlyNullable_ReturnsFailureInResult()
    {
        // Arrange
        Result result = Result.OK();
        DateOnly? date = DateOnly.FromDateTime(DateTime.Today.AddDays(1));

        // Act
        result.Guard(date).ErrorIfFuture().End();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfFuture method with a DateOnly set to today.
    /// </summary>
    [Fact]
    public void ErrorIfFuture_WithTodayDateOnly_ReturnsSuccessInResult()
    {
        // Arrange
        Result result = Result.OK();
        DateOnly date = DateOnly.FromDateTime(DateTime.Today);

        // Act
        result.Guard(date).ErrorIfFuture().End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfFuture method with a null DateOnly.
    /// </summary>
    [Fact]
    public void ErrorIfFuture_WithNullDateOnly_ReturnsSuccessInResult()
    {
        // Arrange
        Result result = Result.OK();
        DateOnly? date = null;

        // Act
        result.Guard(date).ErrorIfFuture().End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfFutureUtc method with a future DateTime.
    /// </summary>
    [Fact]
    public void ErrorIfFutureUtc_WithFutureDateTime_ReturnsFailureInResult()
    {
        // Arrange
        Result result = Result.OK();
        DateTime date = DateTime.UtcNow.Date.AddDays(1);

        // Act
        result.Guard(date).ErrorIfFutureUtc().End();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfFutureUtc method with a future DateTime.
    /// </summary>
    [Fact]
    public void ErrorIfFutureUtc_WithFutureDateTimeNullable_ReturnsFailureInResult()
    {
        // Arrange
        Result result = Result.OK();
        DateTime? date = DateTime.UtcNow.Date.AddDays(1);

        // Act
        result.Guard(date).ErrorIfFutureUtc().End();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfFutureUtc method with the current DateTime.
    /// </summary>
    [Fact]
    public void ErrorIfFutureUtc_WithTodayDateTime_ReturnsSuccessInResult()
    {
        // Arrange
        Result result = Result.OK();
        DateTime date = DateTime.UtcNow.Date;

        // Act
        result.Guard(date).ErrorIfFutureUtc().End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfFutureUtc method with a null DateTime.
    /// </summary>
    [Fact]
    public void ErrorIfFutureUtc_WithNull_ReturnsSuccessInResult()
    {
        // Arrange
        Result result = Result.OK();
        DateTime? date = null;

        // Act
        result.Guard(date).ErrorIfFutureUtc().End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfFutureUtc method with a future DateOnly.
    /// </summary>
    [Fact]
    public void ErrorIfFutureUtc_WithFutureDateOnly_ReturnsFailureInResult()
    {
        // Arrange
        Result result = Result.OK();
        DateOnly date = DateOnly.FromDateTime(DateTime.UtcNow.Date.AddDays(1));

        // Act
        result.Guard(date).ErrorIfFutureUtc().End();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfFutureUtc method with a future DateOnly.
    /// </summary>
    [Fact]
    public void ErrorIfFutureUtc_WithFutureDateOnlyNullable_ReturnsFailureInResult()
    {
        // Arrange
        Result result = Result.OK();
        DateOnly? date = DateOnly.FromDateTime(DateTime.UtcNow.Date.AddDays(1));

        // Act
        result.Guard(date).ErrorIfFutureUtc().End();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfFutureUtc method with a null DateOnly.
    /// </summary>
    [Fact]
    public void ErrorIfFutureUtc_WithNullDateOnly_ReturnsSuccessInResult()
    {
        // Arrange
        Result result = Result.OK();
        DateOnly? date = null;

        // Act
        result.Guard(date).ErrorIfFutureUtc().End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfFutureUtc method with a DateOnly set to today.
    /// </summary>
    [Fact]
    public void ErrorIfFutureUtc_WithTodayDateOnly_ReturnsSuccessInResult()
    {
        // Arrange
        Result result = Result.OK();
        DateOnly date = DateOnly.FromDateTime(DateTime.UtcNow.Date);

        // Act
        result.Guard(date).ErrorIfFutureUtc().End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfPast method with a past DateTime.
    /// </summary>
    [Fact]
    public void ErrorIfPast_WithPastDateTime_ReturnsFailureInResult()
    {
        // Arrange
        Result result = Result.OK();
        DateTime date = DateTime.Today.AddDays(-1);

        // Act
        result.Guard(date).ErrorIfPast().End();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfPast method with a past DateTime.
    /// </summary>
    [Fact]
    public void ErrorIfPast_WithPastDateTimeNullable_ReturnsFailureInResult()
    {
        // Arrange
        Result result = Result.OK();
        DateTime? date = DateTime.Today.AddDays(-1);

        // Act
        result.Guard(date).ErrorIfPast().End();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfPast method with a DateTime set to tomorrow.
    /// </summary>
    [Fact]
    public void ErrorIfPast_WithTomorrowDateTime_ReturnsSuccessInResult()
    {
        // Arrange
        Result result = Result.OK();
        DateTime date = DateTime.Today.AddDays(1);

        // Act
        result.Guard(date).ErrorIfPast().End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfPast method with a null DateTime.
    /// </summary>
    [Fact]
    public void ErrorIfPast_WithNull_ReturnsSuccessInResult()
    {
        // Arrange
        Result result = Result.OK();
        DateTime? date = null;

        // Act
        result.Guard(date).ErrorIfPast().End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfPast method with a past DateOnly.
    /// </summary>
    [Fact]
    public void ErrorIfPast_WithPastDateOnly_ReturnsFailureInResult()
    {
        // Arrange
        Result result = Result.OK();
        DateOnly date = DateOnly.FromDateTime(DateTime.Today.AddDays(-1));

        // Act
        result.Guard(date).ErrorIfPast().End();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfPast method with a past DateOnly.
    /// </summary>
    [Fact]
    public void ErrorIfPast_WithPastDateOnlyNullable_ReturnsFailureInResult()
    {
        // Arrange
        Result result = Result.OK();
        DateOnly? date = DateOnly.FromDateTime(DateTime.Today.AddDays(-1));

        // Act
        result.Guard(date).ErrorIfPast().End();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfPast method with a DateOnly set to today.
    /// </summary>
    [Fact]
    public void ErrorIfPast_WithTodayDateOnly_ReturnsSuccessInResult()
    {
        // Arrange
        Result result = Result.OK();
        DateOnly date = DateOnly.FromDateTime(DateTime.Today);

        // Act
        result.Guard(date).ErrorIfPast().End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfPast method with a null DateOnly.
    /// </summary>
    [Fact]
    public void ErrorIfPast_WithNullDateOnly_ReturnsSuccessInResult()
    {
        // Arrange
        Result result = Result.OK();
        DateOnly? date = null;

        // Act
        result.Guard(date).ErrorIfPast().End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfPastUtc method with a past DateTime.
    /// </summary>
    [Fact]
    public void ErrorIfPastUtc_WithPastDateTime_ReturnsFailureInResult()
    {
        // Arrange
        Result result = Result.OK();
        DateTime date = DateTime.UtcNow.Date.AddDays(-1);

        // Act
        result.Guard(date).ErrorIfPastUtc().End();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfPastUtc method with a past DateTime.
    /// </summary>
    [Fact]
    public void ErrorIfPastUtc_WithPastDateTimeNullable_ReturnsFailureInResult()
    {
        // Arrange
        Result result = Result.OK();
        DateTime? date = DateTime.UtcNow.Date.AddDays(-1);

        // Act
        result.Guard(date).ErrorIfPastUtc().End();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfPastUtc method with a DateTime set to tomorrow.
    /// </summary>
    [Fact]
    public void ErrorIfPastUtc_WithTomorrowDateTime_ReturnsSuccessInResult()
    {
        // Arrange
        Result result = Result.OK();
        DateTime date = DateTime.UtcNow.Date.AddDays(1);

        // Act
        result.Guard(date).ErrorIfPastUtc().End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfPastUtc method with a null DateTime.
    /// </summary>
    [Fact]
    public void ErrorIfPastUtc_WithNull_ReturnsSuccessInResult()
    {
        // Arrange
        Result result = Result.OK();
        DateTime? date = null;

        // Act
        result.Guard(date).ErrorIfPastUtc().End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfPastUtc method with a past DateOnly.
    /// </summary>
    [Fact]
    public void ErrorIfPastUtc_WithPastDateOnly_ReturnsFailureInResult()
    {
        // Arrange
        Result result = Result.OK();
        DateOnly date = DateOnly.FromDateTime(DateTime.UtcNow.Date.AddDays(-1));

        // Act
        result.Guard(date).ErrorIfPastUtc().End();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfPastUtc method with a past DateOnly.
    /// </summary>
    [Fact]
    public void ErrorIfPastUtc_WithPastDateOnlyNullable_ReturnsFailureInResult()
    {
        // Arrange
        Result result = Result.OK();
        DateOnly? date = DateOnly.FromDateTime(DateTime.UtcNow.Date.AddDays(-1));

        // Act
        result.Guard(date).ErrorIfPastUtc().End();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfPastUtc method with a DateOnly set to today.
    /// </summary>
    [Fact]
    public void ErrorIfPastUtc_WithTodayDateOnly_ReturnsSuccessInResult()
    {
        // Arrange
        Result result = Result.OK();
        DateOnly date = DateOnly.FromDateTime(DateTime.UtcNow.Date);

        // Act
        result.Guard(date).ErrorIfPastUtc().End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfPastUtc method with a null DateOnly.
    /// </summary>
    [Fact]
    public void ErrorIfPastUtc_WithNullDateOnly_ReturnsSuccessInResult()
    {
        // Arrange
        Result result = Result.OK();
        DateOnly? date = null;

        // Act
        result.Guard(date).ErrorIfPastUtc().End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfNotFuture method with a DateTime set to tomorrow.
    /// </summary>
    [Fact]
    public void ErrorIfNotFuture_WithFutureDateTime_ReturnsSuccessInResult()
    {
        // Arrange
        Result result = Result.OK();
        DateTime date = DateTime.Today.AddDays(1);

        // Act
        result.Guard(date).ErrorIfNotFuture().End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfNotFuture method with a null DateTime.
    /// </summary>
    [Fact]
    public void ErrorIfNotFuture_WithNull_ReturnsSuccessInResult()
    {
        // Arrange
        Result result = Result.OK();
        DateTime? date = null;

        // Act
        result.Guard(date).ErrorIfNotFuture().End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfNotFuture method with a DateTime set to today.
    /// </summary>
    [Fact]
    public void ErrorIfNotFuture_WithTodayDateTime_ReturnsFailureInResult()
    {
        // Arrange
        Result result = Result.OK();
        DateTime date = DateTime.Today;

        // Act
        result.Guard(date).ErrorIfNotFuture().End();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfNotFuture method with a DateTime set to today.
    /// </summary>
    [Fact]
    public void ErrorIfNotFuture_WithTodayDateTimeNullable_ReturnsFailureInResult()
    {
        // Arrange
        Result result = Result.OK();
        DateTime? date = DateTime.Today;

        // Act
        result.Guard(date).ErrorIfNotFuture().End();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfNotFuture method with a DateOnly set to tomorrow.
    /// </summary>
    [Fact]
    public void ErrorIfNotFuture_WithFutureDateOnly_ReturnsSuccessInResult()
    {
        // Arrange
        Result result = Result.OK();
        DateOnly date = DateOnly.FromDateTime(DateTime.Today.AddDays(1));

        // Act
        result.Guard(date).ErrorIfNotFuture().End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfNotFuture method with a null DateOnly.
    /// </summary>
    [Fact]
    public void ErrorIfNotFuture_WithNullDateOnly_ReturnsSuccessInResult()
    {
        // Arrange
        Result result = Result.OK();
        DateOnly? date = null;

        // Act
        result.Guard(date).ErrorIfNotFuture().End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfNotFuture method with a DateOnly set to today.
    /// </summary>
    [Fact]
    public void ErrorIfNotFuture_WithTodayDateOnly_ReturnsFailureInResult()
    {
        // Arrange
        Result result = Result.OK();
        DateOnly date = DateOnly.FromDateTime(DateTime.Today);

        // Act
        result.Guard(date).ErrorIfNotFuture().End();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfNotFuture method with a DateOnly set to today.
    /// </summary>
    [Fact]
    public void ErrorIfNotFuture_WithTodayDateOnlyNullable_ReturnsFailureInResult()
    {
        // Arrange
        Result result = Result.OK();
        DateOnly? date = DateOnly.FromDateTime(DateTime.Today);

        // Act
        result.Guard(date).ErrorIfNotFuture().End();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfNotFutureUtc method with a DateTime set to tomorrow.
    /// </summary>
    [Fact]
    public void ErrorIfNotFutureUtc_WithFutureDateTime_ReturnsSuccessInResult()
    {
        // Arrange
        Result result = Result.OK();
        DateTime date = DateTime.UtcNow.Date.AddDays(1);

        // Act
        result.Guard(date).ErrorIfNotFutureUtc().End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfNotFutureUtc method with a null DateTime.
    /// </summary>
    [Fact]
    public void ErrorIfNotFutureUtc_WithNull_ReturnsSuccessInResult()
    {
        // Arrange
        Result result = Result.OK();
        DateTime? date = null;

        // Act
        result.Guard(date).ErrorIfNotFutureUtc().End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfNotFutureUtc method with a DateTime set to today.
    /// </summary>
    [Fact]
    public void ErrorIfNotFutureUtc_WithTodayDateTime_ReturnsFailureInResult()
    {
        // Arrange
        Result result = Result.OK();
        DateTime date = DateTime.UtcNow.Date;

        // Act
        result.Guard(date).ErrorIfNotFutureUtc().End();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfNotFutureUtc method with a DateTime set to today.
    /// </summary>
    [Fact]
    public void ErrorIfNotFutureUtc_WithTodayDateTimeNullable_ReturnsFailureInResult()
    {
        // Arrange
        Result result = Result.OK();
        DateTime? date = DateTime.UtcNow.Date;

        // Act
        result.Guard(date).ErrorIfNotFutureUtc().End();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfNotFutureUtc method with a DateOnly set to tomorrow.
    /// </summary>
    [Fact]
    public void ErrorIfNotFutureUtc_WithFutureDateOnly_ReturnsSuccessInResult()
    {
        // Arrange
        Result result = Result.OK();
        DateOnly date = DateOnly.FromDateTime(DateTime.UtcNow.Date.AddDays(1));

        // Act
        result.Guard(date).ErrorIfNotFutureUtc().End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfNotFutureUtc method with a null DateOnly.
    /// </summary>
    [Fact]
    public void ErrorIfNotFutureUtc_WithNullDateOnly_ReturnsSuccessInResult()
    {
        // Arrange
        Result result = Result.OK();
        DateOnly? date = null;

        // Act
        result.Guard(date).ErrorIfNotFutureUtc().End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfNotFutureUtc method with a DateOnly set to today.
    /// </summary>
    [Fact]
    public void ErrorIfNotFutureUtc_WithTodayDateOnly_ReturnsFailureInResult()
    {
        // Arrange
        Result result = Result.OK();
        DateOnly date = DateOnly.FromDateTime(DateTime.UtcNow.Date);

        // Act
        result.Guard(date).ErrorIfNotFutureUtc().End();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfNotFutureUtc method with a DateOnly set to today.
    /// </summary>
    [Fact]
    public void ErrorIfNotFutureUtc_WithTodayDateOnlyNullable_ReturnsFailureInResult()
    {
        // Arrange
        Result result = Result.OK();
        DateOnly? date = DateOnly.FromDateTime(DateTime.UtcNow.Date);

        // Act
        result.Guard(date).ErrorIfNotFutureUtc().End();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfNotPast method with a DateTime set to yesterday.
    /// </summary>
    [Fact]
    public void ErrorIfNotPast_WithPastDateTime_ReturnsSuccessInResult()
    {
        // Arrange
        Result result = Result.OK();
        DateTime date = DateTime.Today.AddDays(-1);

        // Act
        result.Guard(date).ErrorIfNotPast().End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfNotPast method with a null DateTime.
    /// </summary>
    [Fact]
    public void ErrorIfNotPast_WithNull_ReturnsSuccessInResult()
    {
        // Arrange
        Result result = Result.OK();
        DateTime? date = null;

        // Act
        result.Guard(date).ErrorIfNotPast().End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfNotPast method with a DateTime set to tomorrow.
    /// </summary>
    [Fact]
    public void ErrorIfNotPast_WithTomorrowDateTime_ReturnsFailureInResult()
    {
        // Arrange
        Result result = Result.OK();
        DateTime date = DateTime.Today.AddDays(1);

        // Act
        result.Guard(date).ErrorIfNotPast().End();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfNotPast method with a DateTime set to tomorrow.
    /// </summary>
    [Fact]
    public void ErrorIfNotPast_WithTomorrowDateTimeNullable_ReturnsFailureInResult()
    {
        // Arrange
        Result result = Result.OK();
        DateTime? date = DateTime.Today.AddDays(1);

        // Act
        result.Guard(date).ErrorIfNotPast().End();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfNotPast method with a DateOnly set to a past date.
    /// </summary>
    [Fact]
    public void ErrorIfNotPast_WithPastDateOnly_ReturnsSuccessInResult()
    {
        // Arrange
        Result result = Result.OK();
        DateOnly date = DateOnly.FromDateTime(DateTime.Today.AddDays(-1));

        // Act
        result.Guard(date).ErrorIfNotPast().End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfNotPast method with a null DateOnly.
    /// </summary>
    [Fact]
    public void ErrorIfNotPast_WithNullDateOnly_ReturnsSuccessInResult()
    {
        // Arrange
        Result result = Result.OK();
        DateOnly? date = null;

        // Act
        result.Guard(date).ErrorIfNotPast().End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfNotPast method with a DateOnly set to today.
    /// </summary>
    [Fact]
    public void ErrorIfNotPast_WithTodayDateOnly_ReturnsFailureInResult()
    {
        // Arrange
        Result result = Result.OK();
        DateOnly date = DateOnly.FromDateTime(DateTime.Today);

        // Act
        result.Guard(date).ErrorIfNotPast().End();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfNotPast method with a DateOnly set to today.
    /// </summary>
    [Fact]
    public void ErrorIfNotPast_WithTodayDateOnlyNullable_ReturnsFailureInResult()
    {
        // Arrange
        Result result = Result.OK();
        DateOnly? date = DateOnly.FromDateTime(DateTime.Today);

        // Act
        result.Guard(date).ErrorIfNotPast().End();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfNotPastUtc method with a DateTime set to a past date.
    /// </summary>
    [Fact]
    public void ErrorIfNotPastUtc_WithPastDateTime_ReturnsSuccessInResult()
    {
        // Arrange
        Result result = Result.OK();
        DateTime date = DateTime.UtcNow.Date.AddDays(-1);

        // Act
        result.Guard(date).ErrorIfNotPastUtc().End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfNotPastUtc method with a null DateTime.
    /// </summary>
    [Fact]
    public void ErrorIfNotPastUtc_WithNull_ReturnsSuccessInResult()
    {
        // Arrange
        Result result = Result.OK();
        DateTime? date = null;

        // Act
        result.Guard(date).ErrorIfNotPastUtc().End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfNotPastUtc method with a DateTime set to tomorrow.
    /// </summary>
    [Fact]
    public void ErrorIfNotPastUtc_WithTomorrowDateTime_ReturnsFailureInResult()
    {
        // Arrange
        Result result = Result.OK();
        DateTime date = DateTime.UtcNow.Date.AddDays(1);

        // Act
        result.Guard(date).ErrorIfNotPastUtc().End();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfNotPastUtc method with a DateTime set to tomorrow.
    /// </summary>
    [Fact]
    public void ErrorIfNotPastUtc_WithTomorrowDateTimeNullable_ReturnsFailureInResult()
    {
        // Arrange
        Result result = Result.OK();
        DateTime? date = DateTime.UtcNow.Date.AddDays(1);

        // Act
        result.Guard(date).ErrorIfNotPastUtc().End();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfNotPastUtc method with a DateOnly set to a past date.
    /// </summary>
    [Fact]
    public void ErrorIfNotPastUtc_WithPastDateOnly_ReturnsSuccessInResult()
    {
        // Arrange
        Result result = Result.OK();
        DateOnly date = DateOnly.FromDateTime(DateTime.UtcNow.Date.AddDays(-1));

        // Act
        result.Guard(date).ErrorIfNotPastUtc().End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfNotPastUtc method with a null DateOnly.
    /// </summary>
    [Fact]
    public void ErrorIfNotPastUtc_WithNullDateOnly_ReturnsSuccessInResult()
    {
        // Arrange
        Result result = Result.OK();
        DateOnly? date = null;

        // Act
        result.Guard(date).ErrorIfNotPastUtc().End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfNotPastUtc method with a DateOnly set to today.
    /// </summary>
    [Fact]
    public void ErrorIfNotPastUtc_WithTodayDateOnly_ReturnsFailureInResult()
    {
        // Arrange
        Result result = Result.OK();
        DateOnly date = DateOnly.FromDateTime(DateTime.UtcNow.Date);

        // Act
        result.Guard(date).ErrorIfNotPastUtc().End();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfNotPastUtc method with a DateOnly set to today.
    /// </summary>
    [Fact]
    public void ErrorIfNotPastUtc_WithTodayDateOnlyNullable_ReturnsFailureInResult()
    {
        // Arrange
        Result result = Result.OK();
        DateOnly? date = DateOnly.FromDateTime(DateTime.UtcNow.Date);

        // Act
        result.Guard(date).ErrorIfNotPastUtc().End();

        // Assert
        Assert.True(result.IsFailure);
    }
}