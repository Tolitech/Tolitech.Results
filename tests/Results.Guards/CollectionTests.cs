namespace Tolitech.Results.Guards.UnitTests;

/// <summary>
/// Unit tests for the collection-related guard methods.
/// </summary>
public class CollectionTests
{
    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfNull method with a null value.
    /// </summary>
    [Fact]
    public void ErrorIfNull_WithNull_ReturnsFailureInResult()
    {
        // Arrange
        IResult result = Result.OK();
        List<int>? list = null;

        // Act
        result.Guard<IEnumerable<int>>(list).ErrorIfNull().End();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfNull method with a non-null value.
    /// </summary>
    [Fact]
    public void ErrorIfNull_WithNotNull_ReturnsSuccessInResult()
    {
        // Arrange
        IResult result = Result.OK();
        List<int>? list = [];

        // Act
        result.Guard<IEnumerable<int>>(list).ErrorIfNull().End();

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
        List<int>? list = null;

        // Act
        result.Guard<IEnumerable<int>>(list).ErrorIfNotNull().End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfNotNull method with a non-null value.
    /// </summary>
    [Fact]
    public void ErrorIfNotNull_WithNotNull_ReturnsFailureInResult()
    {
        // Arrange
        IResult result = Result.OK();
        List<int>? list = [];

        // Act
        result.Guard<IEnumerable<int>>(list).ErrorIfNotNull().End();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfEmpty method with an empty string.
    /// </summary>
    [Fact]
    public void ErrorIfEmpty_WithEmpty_ReturnsFailureInResult()
    {
        // Arrange
        IResult result = Result.OK();
        List<int>? list = [];

        // Act
        result.Guard<IEnumerable<int>>(list).ErrorIfEmpty().End();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfEmpty method with a null string.
    /// </summary>
    [Fact]
    public void ErrorIfEmpty_WithNull_ReturnsSuccessInResult()
    {
        // Arrange
        IResult result = Result.OK();
        List<int>? list = null;

        // Act
        result.Guard<IEnumerable<int>>(list).ErrorIfEmpty().End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfEmpty method with a non-empty string.
    /// </summary>
    [Fact]
    public void ErrorIfEmpty_WithNotEmpty_ReturnsSuccessInResult()
    {
        // Arrange
        IResult result = Result.OK();
        List<int>? list = [10, 20, 30];

        // Act
        result.Guard<IEnumerable<int>>(list).ErrorIfEmpty().End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfNotEmpty method with an empty string.
    /// </summary>
    [Fact]
    public void ErrorIfNotEmpty_WithEmpty_ReturnsSuccessInResult()
    {
        // Arrange
        IResult result = Result.OK();
        List<int>? list = [];

        // Act
        result.Guard<IEnumerable<int>>(list).ErrorIfNotEmpty().End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfNotEmpty method with a null string.
    /// </summary>
    [Fact]
    public void ErrorIfNotEmpty_WithNull_ReturnsSuccessInResult()
    {
        // Arrange
        IResult result = Result.OK();
        List<int>? list = null;

        // Act
        result.Guard<IEnumerable<int>>(list).ErrorIfNotEmpty().End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfNotEmpty method with a non-empty string.
    /// </summary>
    [Fact]
    public void ErrorIfNotEmpty_WithNotEmpty_ReturnsFailureInResult()
    {
        // Arrange
        IResult result = Result.OK();
        List<int>? list = [10, 20, 30];

        // Act
        result.Guard<IEnumerable<int>>(list).ErrorIfNotEmpty().End();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfCountEqualTo method with a count equal to the specified value.
    /// </summary>
    [Fact]
    public void ErrorIfCountEqualTo_WithCountEqual_ReturnsFailureInResult()
    {
        // Arrange
        IResult result = Result.OK();
        List<int>? list = [10, 20, 30];

        // Act
        result.Guard<IEnumerable<int>>(list).ErrorIfCountEqualTo(3).End();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfCountEqualTo method with a count not equal to the specified value.
    /// </summary>
    [Fact]
    public void ErrorIfCountEqualTo_CountNoEqual_ReturnsSuccessInResult()
    {
        // Arrange
        IResult result = Result.OK();
        List<int>? list = [10, 20, 30];

        // Act
        result.Guard<IEnumerable<int>>(list).ErrorIfCountEqualTo(4).End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfCountEqualTo method with a null collection.
    /// </summary>
    [Fact]
    public void ErrorIfCountEqualTo_WithNull_ReturnsSuccessInResult()
    {
        // Arrange
        IResult result = Result.OK();
        List<int>? list = null;

        // Act
        result.Guard<IEnumerable<int>>(list).ErrorIfCountEqualTo(4).End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfCountNotEqualTo method with a count not equal to the specified value.
    /// </summary>
    [Fact]
    public void ErrorIfCountNotEqualTo_WithCountNoEqual_ReturnsFailureInResult()
    {
        // Arrange
        IResult result = Result.OK();
        List<int>? list = [10, 20, 30];

        // Act
        result.Guard<IEnumerable<int>>(list).ErrorIfCountNotEqualTo(4).End();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfCountNotEqualTo method with a count equal to the specified value.
    /// </summary>
    [Fact]
    public void ErrorIfCountNotEqualTo_WithCountEqual_ReturnsSuccessInResult()
    {
        // Arrange
        IResult result = Result.OK();
        List<int>? list = [10, 20, 30];

        // Act
        result.Guard<IEnumerable<int>>(list).ErrorIfCountNotEqualTo(3).End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfCountNotEqualTo method with a null collection.
    /// </summary>
    [Fact]
    public void ErrorIfCountNotEqualTo_WithNull_ReturnsSuccessInResult()
    {
        // Arrange
        IResult result = Result.OK();
        List<int>? list = null;

        // Act
        result.Guard<IEnumerable<int>>(list).ErrorIfCountNotEqualTo(3).End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfCountGreaterThan method with a count greater than the specified value.
    /// </summary>
    [Fact]
    public void ErrorIfCountGreaterThan_WithCountGreater_ReturnsFailureInResult()
    {
        // Arrange
        IResult result = Result.OK();
        List<int>? list = [10, 20, 30];

        // Act
        result.Guard<IEnumerable<int>>(list).ErrorIfCountGreaterThan(2).End();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfCountGreaterThan method with a count equal to the specified value.
    /// </summary>
    [Fact]
    public void ErrorIfCountGreaterThan_WithCountEqual_ReturnsSuccessInResult()
    {
        // Arrange
        IResult result = Result.OK();
        List<int>? list = [10, 20, 30];

        // Act
        result.Guard<IEnumerable<int>>(list).ErrorIfCountGreaterThan(3).End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfCountGreaterThan method with a null collection.
    /// </summary>
    [Fact]
    public void ErrorIfCountGreaterThan_WithNull_ReturnsSuccessInResult()
    {
        // Arrange
        IResult result = Result.OK();
        List<int>? list = null;

        // Act
        result.Guard<IEnumerable<int>>(list).ErrorIfCountGreaterThan(3).End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfCountGreaterThanOrEqualTo method with a count equal to the specified value.
    /// </summary>
    [Fact]
    public void ErrorIfCountGreaterThanOrEqualTo_WithCountEqual_ReturnsFailureInResult()
    {
        // Arrange
        IResult result = Result.OK();
        List<int>? list = [10, 20, 30];

        // Act
        result.Guard<IEnumerable<int>>(list).ErrorIfCountGreaterThanOrEqualTo(3).End();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfCountGreaterThanOrEqualTo method with a count less than the specified value.
    /// </summary>
    [Fact]
    public void ErrorIfCountGreaterThanOrEqualTo_WithCountLess_ReturnsSuccessInResult()
    {
        // Arrange
        IResult result = Result.OK();
        List<int>? list = [10, 20, 30];

        // Act
        result.Guard<IEnumerable<int>>(list).ErrorIfCountGreaterThanOrEqualTo(4).End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfCountGreaterThanOrEqualTo method with a null collection.
    /// </summary>
    [Fact]
    public void ErrorIfCountGreaterThanOrEqualTo_WithNull_ReturnsSuccessInResult()
    {
        // Arrange
        IResult result = Result.OK();
        List<int>? list = null;

        // Act
        result.Guard<IEnumerable<int>>(list).ErrorIfCountGreaterThanOrEqualTo(4).End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfCountLessThan method with a count less than the specified value.
    /// </summary>
    [Fact]
    public void ErrorIfCountLessThan_WithCountLess_ReturnsFailureInResult()
    {
        // Arrange
        IResult result = Result.OK();
        List<int>? list = [10, 20, 30];

        // Act
        result.Guard<IEnumerable<int>>(list).ErrorIfCountLessThan(4).End();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfCountLessThan method with a count equal to the specified value.
    /// </summary>
    [Fact]
    public void ErrorIfCountLessThan_WithCountEqual_ReturnsSuccessInResult()
    {
        // Arrange
        IResult result = Result.OK();
        List<int>? list = [10, 20, 30];

        // Act
        result.Guard<IEnumerable<int>>(list).ErrorIfCountLessThan(3).End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfCountLessThan method with a null collection.
    /// </summary>
    [Fact]
    public void ErrorIfCountLessThan_WithNull_ReturnsSuccessInResult()
    {
        // Arrange
        IResult result = Result.OK();
        List<int>? list = null;

        // Act
        result.Guard<IEnumerable<int>>(list).ErrorIfCountLessThan(3).End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfCountLessThanOrEqualTo method with a count equal to the specified value.
    /// </summary>
    [Fact]
    public void ErrorIfCountLessThanOrEqualTo_WithEqual_ReturnsFailureInResult()
    {
        // Arrange
        IResult result = Result.OK();
        List<int>? list = [10, 20, 30];

        // Act
        result.Guard<IEnumerable<int>>(list).ErrorIfCountLessThanOrEqualTo(3).End();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfCountLessThanOrEqualTo method with a count greater than the specified value.
    /// </summary>
    [Fact]
    public void ErrorIfCountLessThanOrEqualTo_WithGreater_ReturnsSuccessInResult()
    {
        // Arrange
        IResult result = Result.OK();
        List<int>? list = [10, 20, 30];

        // Act
        result.Guard<IEnumerable<int>>(list).ErrorIfCountLessThanOrEqualTo(2).End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfCountLessThanOrEqualTo method with a null collection.
    /// </summary>
    [Fact]
    public void ErrorIfCountLessThanOrEqualTo_WithNull_ReturnsSuccessInResult()
    {
        // Arrange
        IResult result = Result.OK();
        List<int>? list = null;

        // Act
        result.Guard<IEnumerable<int>>(list).ErrorIfCountLessThanOrEqualTo(2).End();

        // Assert
        Assert.True(result.IsSuccess);
    }
}