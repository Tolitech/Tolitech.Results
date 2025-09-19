namespace Tolitech.Results.Guards.UnitTests;

/// <summary>
/// Unit tests for the Guid-related guard methods.
/// </summary>
public class GuidTests
{
    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfNull method with a null Guid value.
    /// </summary>
    [Fact]
    public void ErrorIfNull_WithNull_ReturnsFailureInResult()
    {
        // Arrange
        IResult result = Result.OK();
        Guid? id = null;

        // Act
        result.Guard(id).ErrorIfNull().End();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfNull method with a not null Guid value.
    /// </summary>
    [Fact]
    public void ErrorIfNull_WithNotNull_ReturnsSuccessInResult()
    {
        // Arrange
        IResult result = Result.OK();
        Guid? id = Guid.Empty;

        // Act
        result.Guard(id).ErrorIfNull().End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfNotNull method with a null Guid value.
    /// </summary>
    [Fact]
    public void ErrorIfNotNull_WithNull_ReturnsSuccessInResult()
    {
        // Arrange
        IResult result = Result.OK();
        Guid? id = null;

        // Act
        result.Guard(id).ErrorIfNotNull().End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfNotNull method with a not null Guid value.
    /// </summary>
    [Fact]
    public void ErrorIfNotNull_WithNotNull_ReturnsFailureInResult()
    {
        // Arrange
        IResult result = Result.OK();
        Guid? id = Guid.Empty;

        // Act
        result.Guard(id).ErrorIfNotNull().End();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfEqualTo method with a null Guid value.
    /// </summary>
    [Fact]
    public void ErrorIfEqualTo_WithNull_ReturnsFailureInResult()
    {
        // Arrange
        IResult result = Result.OK();
        Guid? id = null;

        // Act
        result.Guard(id).ErrorIfEqualTo(null).End();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfEqualTo method with a not null Guid value.
    /// </summary>
    [Fact]
    public void ErrorIfEqualTo_WithNull_ReturnsSuccessInResult()
    {
        // Arrange
        IResult result = Result.OK();
        Guid? id = null;

        // Act
        result.Guard(id).ErrorIfEqualTo(Guid.Empty).End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfEqualTo method with a not null Guid value.
    /// </summary>
    [Fact]
    public void ErrorIfEqualTo_WithEmpty_ReturnsFailureInResult()
    {
        // Arrange
        IResult result = Result.OK();
        Guid id = Guid.Empty;

        // Act
        result.Guard(id).ErrorIfEqualTo(Guid.Empty).End();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfEqualTo method with the same Guid data.
    /// </summary>
    [Fact]
    public void ErrorIfEqualTo_WithSameData_ReturnsFailureInResult()
    {
        // Arrange
        IResult result = Result.OK();
        Guid? id = Guid.Empty;

        // Act
        result.Guard(id).ErrorIfEqualTo(Guid.Empty).End();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfEqualTo method with different Guid data.
    /// </summary>
    [Fact]
    public void ErrorIfEqualTo_WithDifferentData_ReturnsSuccessInResult()
    {
        // Arrange
        IResult result = Result.OK();
        Guid? id = Guid.NewGuid();

        // Act
        result.Guard(id).ErrorIfEqualTo(Guid.NewGuid()).End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfNotEqualTo method with a null Guid value.
    /// </summary>
    [Fact]
    public void ErrorIfNotEqualTo_WithNull_ReturnsSucessInResult()
    {
        // Arrange
        IResult result = Result.OK();
        Guid? id = null;

        // Act
        result.Guard(id).ErrorIfNotEqualTo(null).End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfNotEqualTo method with a null Guid value.
    /// </summary>
    [Fact]
    public void ErrorIfNotEqualTo_WithNull_ReturnsFailureInResult()
    {
        // Arrange
        IResult result = Result.OK();
        Guid? id = null;

        // Act
        result.Guard(id).ErrorIfNotEqualTo(Guid.Empty).End();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfNotEqualTo method with a null Guid value.
    /// </summary>
    [Fact]
    public void ErrorIfNotEqualTo_WithEmpty_ReturnsFailureInResult()
    {
        // Arrange
        IResult result = Result.OK();
        Guid id = Guid.Empty;

        // Act
        result.Guard(id).ErrorIfNotEqualTo(Guid.NewGuid()).End();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfNotEqualTo method with the same Guid data.
    /// </summary>
    [Fact]
    public void ErrorIfNotEqualTo_WithSameData_ReturnsSuccessInResult()
    {
        // Arrange
        IResult result = Result.OK();
        Guid? id = Guid.NewGuid();

        // Act
        result.Guard(id).ErrorIfNotEqualTo(id).End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfNotEqualTo method with different Guid data.
    /// </summary>
    [Fact]
    public void ErrorIfNotEqualTo_WithDifferentData_ReturnsFailureInResult()
    {
        // Arrange
        IResult result = Result.OK();
        Guid? id = Guid.NewGuid();

        // Act
        result.Guard(id).ErrorIfNotEqualTo(Guid.NewGuid()).End();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfNullOrEmpty method with a null Guid value.
    /// </summary>
    [Fact]
    public void ErrorIfNullOrEmpty_WithNull_ReturnsFailureInResult()
    {
        // Arrange
        IResult result = Result.OK();
        Guid? id = null;

        // Act
        result.Guard(id).ErrorIfNullOrEmpty().End();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfNullOrEmpty method with an empty Guid value.
    /// </summary>
    [Fact]
    public void ErrorIfNullOrEmpty_WithEmpty_ReturnsFailureInResult()
    {
        // Arrange
        IResult result = Result.OK();
        Guid? id = Guid.Empty;

        // Act
        result.Guard(id).ErrorIfNullOrEmpty().End();

        // Assert
        Assert.True(result.IsFailure);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfNullOrEmpty method with a new Guid value.
    /// </summary>
    [Fact]
    public void ErrorIfNullOrEmpty_WithNewGuid_ReturnsSuccessInResult()
    {
        // Arrange
        IResult result = Result.OK();
        Guid? id = Guid.NewGuid();

        // Act
        result.Guard(id).ErrorIfNullOrEmpty().End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfNotNullOrNotEmpty method with a null Guid value.
    /// </summary>
    [Fact]
    public void ErrorIfNotNullOrNotEmpty_WithNull_ReturnsSuccessInResult()
    {
        // Arrange
        IResult result = Result.OK();
        Guid? id = null;

        // Act
        result.Guard(id).ErrorIfNotNullOrNotEmpty().End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfNotNullOrNotEmpty method with an empty Guid value.
    /// </summary>
    [Fact]
    public void ErrorIfNotNullOrNotEmpty_WithEmpty_ReturnsSuccessInResult()
    {
        // Arrange
        IResult result = Result.OK();
        Guid? id = Guid.Empty;

        // Act
        result.Guard(id).ErrorIfNotNullOrNotEmpty().End();

        // Assert
        Assert.True(result.IsSuccess);
    }

    /// <summary>
    /// Unit test to verify the behavior of the ErrorIfNotNullOrNotEmpty method with a new Guid value.
    /// </summary>
    [Fact]
    public void ErrorIfNotNullOrNotEmpty_WithNewGuid_ReturnsFailureInResult()
    {
        // Arrange
        IResult result = Result.OK();
        Guid? id = Guid.NewGuid();

        // Act
        result.Guard(id).ErrorIfNotNullOrNotEmpty().End();

        // Assert
        Assert.True(result.IsFailure);
    }
}