namespace Tolitech.Results.UnitTests;

/// <summary>
/// Unit tests for the Result class.
/// </summary>
public class ResultTests
{
    /// <summary>
    /// Unit test to verify the behavior of the AddInformation method.
    /// </summary>
    [Fact]
    public void AddInformation_WithMessage_ShouldContainInformationMessage()
    {
        // Arrange
        Result result = Result.OK();

        // Act
        result.AddInformation("Hello, world!");

        // Assert
        Assert.True(result.IsSuccess);
        Assert.False(result.IsFailure);
        Assert.True(result.Messages.Count > 0);
        Assert.True(result.Messages.All(m => m.Type == MessageType.Information));
    }

    /// <summary>
    /// Unit test to verify the behavior of the AddInformation method when providing a message and a key.
    /// </summary>
    [Fact]
    public void AddInformation_WithMessageAndKey_ShouldContainInformationMessageAndKey()
    {
        // Arrange
        Result result = Result.OK();

        // Act
        result.AddInformation("Welcome", "Hello, world!");

        // Assert
        Assert.True(result.IsSuccess);
        Assert.False(result.IsFailure);
        Assert.True(result.Messages.Count > 0);
        Assert.True(result.Messages.All(m => m.Type == MessageType.Information));
        Assert.True(result.Messages.All(m => m.Key == "Welcome"));
    }

    /// <summary>
    /// Unit test to verify the behavior of the AddWarning method when providing a warning message.
    /// </summary>
    [Fact]
    public void AddWarning_WithMessage_ShouldContainWarningMessage()
    {
        // Arrange
        Result result = Result.OK();

        // Act
        result.AddWarning("Hello, world!");

        // Assert
        Assert.True(result.IsSuccess);
        Assert.False(result.IsFailure);
        Assert.True(result.Messages.Count > 0);
        Assert.True(result.Messages.All(m => m.Type == MessageType.Warning));
    }

    /// <summary>
    /// Unit test to verify the behavior of the AddWarning method when providing a warning message and a key.
    /// </summary>
    [Fact]
    public void AddWarning_WithMessageAndKey_ShouldContainWarningMessageAndKey()
    {
        // Arrange
        Result result = Result.OK();

        // Act
        result.AddWarning("Welcome", "Hello, world!");

        // Assert
        Assert.True(result.IsSuccess);
        Assert.False(result.IsFailure);
        Assert.True(result.Messages.Count > 0);
        Assert.True(result.Messages.All(m => m.Type == MessageType.Warning));
        Assert.True(result.Messages.All(m => m.Key == "Welcome"));
    }

    /// <summary>
    /// Unit test to verify the behavior of the AddError method when providing an error message.
    /// </summary>
    [Fact]
    public void AddError_WithMessage_ShouldContainErrorMessage()
    {
        // Arrange
        Result result = Result.OK();

        // Act
        result.AddError("Hello, world!");

        // Assert
        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.True(result.Messages.Count > 0);
        Assert.True(result.Messages.All(m => m.Type == MessageType.Error));
    }

    /// <summary>
    /// Unit test to verify the behavior of the AddError method when providing an error message and a key.
    /// </summary>
    [Fact]
    public void AddError_WithMessageAndKey_ShouldContainErrorMessageAndKey()
    {
        // Arrange
        Result result = Result.OK();

        // Act
        result.AddError("Welcome", "Hello, world!");

        // Assert
        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.True(result.Messages.Count > 0);
        Assert.True(result.Messages.All(m => m.Type == MessageType.Error));
        Assert.True(result.Messages.All(m => m.Key == "Welcome"));
    }

    /// <summary>
    /// Unit test to verify the behavior of the AddError method when providing an error message and StatusCode.Forbidden.
    /// </summary>
    [Fact]
    public void AddError_WithMessageAndStatusCodeForbidden_ShouldContainErrorMessageAndStatusCode403()
    {
        // Arrange
        Result result = Result.OK();

        // Act
        result.AddError("Hello, world!", StatusCode.Forbidden);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Equal(StatusCode.Forbidden, result.StatusCode);
        Assert.True(result.Messages.Count > 0);
        Assert.True(result.Messages.All(m => m.Type == MessageType.Error));
    }

    /// <summary>
    /// Unit test to verify the behavior of the AddError method when providing an error message and an exception.
    /// </summary>
    [Fact]
    public void AddError_WithMessageAndException_ShouldContainErrorMessageAndException()
    {
        // Arrange
        Result result = Result.OK();

        // Act
        result.AddError("Hello, world!", exception: new InvalidCastException("Exception Test"));

        // Assert
        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Equal(StatusCode.BadRequest, result.StatusCode);
        Assert.True(result.Messages.Count > 0);
        Assert.True(result.Messages.All(m => m.Type == MessageType.Error));
        Assert.True(result.Messages.All(m => m is ErrorResult));
        Assert.True(result.Messages.All(m => ((ErrorResult)m).Exception is not null));
    }

    /// <summary>
    /// Unit test to verify that calling AddError with StatusCode.OK should throw an exception.
    /// </summary>
    [Fact]
    public void AddError_WithStatusCodeOK_ShouldThrowException()
    {
        // Arrange
        Result result = Result.OK();

        // Act & Assert
        _ = Assert.Throws<InvalidOperationException>(() => result.AddError("Hello, world!", StatusCode.OK));
    }

    /// <summary>
    /// Unit test to verify that calling status code success with errors should throw an exception.
    /// </summary>
    [Fact]
    public void AddError_CallingSuccessMethod_ShouldThrowException()
    {
        // Arrange
        Result<string> result = Result.OK("Hello, world!");
        result.AddError("Hello, world!");

        // Act & Assert
        _ = Assert.Throws<InvalidOperationException>(() => result.OK("Hi!"));
    }

    /// <summary>
    /// Unit test to verify the behavior of the ToResult method.
    /// </summary>
    [Fact]
    public void ToResult_WithMessages_ShouldContainSameMessages()
    {
        // Arrange
        Result<string> oldResult = Result.OK("test");
        oldResult.AddInformation("Hello, world!");
        oldResult.AddWarning("Hello, world!");
        oldResult.AddError("Hello, world!", StatusCode.Forbidden, new ArgumentException("Test"));

        // Act
        Result<int> new1Result = oldResult.ToResult<int>();
        Result<int> new2Result = oldResult.ToResult(1);

        // Assert
        Assert.False(new1Result.IsSuccess);
        Assert.True(new1Result.IsFailure);
        Assert.Equal(3, new1Result.Messages.Count);
        Assert.Equal(1, new1Result.Messages.Count(m => m.Type == MessageType.Information));
        Assert.Equal(1, new1Result.Messages.Count(m => m.Type == MessageType.Warning));
        Assert.Equal(1, new1Result.Messages.Count(m => m.Type == MessageType.Error));

        Assert.False(new2Result.IsSuccess);
        Assert.True(new2Result.IsFailure);
        Assert.Equal(3, new2Result.Messages.Count);
        Assert.Equal(1, new2Result.Messages.Count(m => m.Type == MessageType.Information));
        Assert.Equal(1, new2Result.Messages.Count(m => m.Type == MessageType.Warning));
        Assert.Equal(1, new2Result.Messages.Count(m => m.Type == MessageType.Error));

        Assert.Equal(oldResult.StatusCode, new1Result.StatusCode);
        Assert.Equal(oldResult.StatusCode, new2Result.StatusCode);
    }

    /// <summary>
    /// Unit test to verify the behavior of the AddMessages method.
    /// </summary>
    [Fact]
    public void AddMessages_WithMessage_ShouldContainInformationMessage()
    {
        // Arrange
        Result resultOld = Result.OK();
        resultOld.AddInformation("Hello, world 1!");
        resultOld.AddInformation("Hello, world 2!");
        resultOld.AddInformation("Hello, world 3!");

        Result resultNew = Result.OK();

        // Act
        resultNew.AddMessages(resultOld);

        // Assert
        Assert.True(resultNew.IsSuccess);
        Assert.False(resultNew.IsFailure);
        Assert.True(resultNew.Messages.Count > 0);
        Assert.True(resultNew.Messages.All(m => m.Type == MessageType.Information));
    }

    /// <summary>
    /// Unit test to verify the behavior of the AddMessages method.
    /// </summary>
    [Fact]
    public void AddMessages_WithErrorMessage_ShouldContainErrorMessage()
    {
        // Arrange
        Result resultOld = Result.OK();
        resultOld.AddInformation("Hello, world 1!");
        resultOld.AddWarning("Hello, world 2!");
        resultOld.AddError("Hello, world 3!");

        Result resultNew = Result.OK();

        // Act
        resultNew.AddMessages(resultOld);

        // Assert
        Assert.False(resultNew.IsSuccess);
        Assert.True(resultNew.IsFailure);
        Assert.True(resultNew.Messages.Count > 0);
        Assert.Equal(resultNew.StatusCode, resultOld.StatusCode);
        Assert.Contains(resultNew.Messages, m => m.Type == MessageType.Information);
        Assert.Contains(resultNew.Messages, m => m.Type == MessageType.Warning);
        Assert.Contains(resultNew.Messages, m => m.Type == MessageType.Error);
    }

    /// <summary>
    /// Unit test to verify the behavior of the AddMessages method.
    /// </summary>
    [Fact]
    public void AddMessages_WithGenericResult_ShouldContainInformationMessage()
    {
        // Arrange
        Result<string> resultOld = Result.OK("Test");
        resultOld.AddInformation("Hello, world 1!");
        resultOld.AddInformation("Hello, world 2!");
        resultOld.AddInformation("Hello, world 3!");

        Result<int> resultNew = Result.OK(10);

        // Act
        resultNew.AddMessages(resultOld);

        // Assert
        Assert.True(resultNew.IsSuccess);
        Assert.False(resultNew.IsFailure);
        Assert.True(resultNew.Messages.Count > 0);
        Assert.True(resultNew.Messages.All(m => m.Type == MessageType.Information));
        Assert.Equal(10, resultNew.Value);
        Assert.Empty(resultNew.Errors);
    }

    /// <summary>
    /// Unit test to verify the behavior of the AddMessages method.
    /// </summary>
    [Fact]
    public void AddMessages_WithInformationMessage_ShouldContainErrorMessage()
    {
        // Arrange
        Result resultOld = Result.OK();
        resultOld.AddInformation("Hello, world 1!");
        resultOld.AddWarning("Hello, world 2!");
        resultOld.AddError("Hello, world 3!");

        Result resultNew = Result.OK();
        resultNew.AddError("Hello, world 4!");

        // Act
        resultNew.AddMessages(resultOld);

        // Assert
        Assert.False(resultNew.IsSuccess);
        Assert.True(resultNew.IsFailure);
        Assert.True(resultNew.Messages.Count > 0);
        Assert.Equal(resultNew.StatusCode, resultOld.StatusCode);
        Assert.Contains(resultNew.Messages, m => m.Type == MessageType.Information);
        Assert.Contains(resultNew.Messages, m => m.Type == MessageType.Warning);
        Assert.Contains(resultNew.Messages, m => m.Type == MessageType.Error);
        Assert.Equal(2, resultNew.Errors.Count());
    }
}