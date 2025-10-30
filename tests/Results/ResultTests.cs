namespace Tolitech.Results.UnitTests;

/// <summary>
/// Unit tests for the Result class.
/// </summary>
public class ResultTests
{
    /// <summary>
    /// Unit test to verify the behavior of the AddError method when providing an error message.
    /// </summary>
    [Fact]
    public void AddError_WithMessage_ShouldContainErrorMessage()
    {
        // Arrange
        IResult result = Result.OK();

        // Act
        result.AddError("Hello, world!");

        // Assert
        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.True(result.Errors.Count > 0);
    }

    /// <summary>
    /// Unit test to verify the behavior of the AddError method when providing an error message and a key.
    /// </summary>
    [Fact]
    public void AddError_WithMessageAndKey_ShouldContainErrorMessageAndKey()
    {
        // Arrange
        IResult result = Result.OK();

        // Act
        result.AddError("Welcome", "Hello, world!");

        // Assert
        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.True(result.Errors.Count > 0);
        Assert.True(result.Errors.All(m => m.Key == "Welcome"));
    }

    /// <summary>
    /// Unit test to verify the behavior of the AddError method when providing an error message and StatusCode.Forbidden.
    /// </summary>
    [Fact]
    public void AddError_WithMessageAndStatusCodeForbidden_ShouldContainErrorMessageAndStatusCode403()
    {
        // Arrange
        IResult result = Result.OK();

        // Act
        result.AddError("Hello, world!", StatusCode.Forbidden);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Equal(StatusCode.Forbidden, result.StatusCode);
        Assert.True(result.Errors.Count > 0);
    }

    /// <summary>
    /// Unit test to verify that calling AddError with StatusCode.OK should throw an exception.
    /// </summary>
    [Fact]
    public void AddError_WithStatusCodeOK_ShouldThrowException()
    {
        // Arrange
        IResult result = Result.OK();

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
        IResult<string> result = Result<string>.OK("Hello, world!");
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
        IResult<string> oldResult = Result<string>.OK("test");
        oldResult.AddError("Hello, world!", StatusCode.Forbidden);
        oldResult.AddError("Hello, world!");

        // Act
        IResult<int> new1Result = oldResult.ToResult<int>();
        IResult<int> new2Result = oldResult.ToResult(1);

        // Assert
        Assert.False(new1Result.IsSuccess);
        Assert.True(new1Result.IsFailure);
        Assert.Equal(2, new1Result.Errors.Count);

        Assert.False(new2Result.IsSuccess);
        Assert.True(new2Result.IsFailure);
        Assert.Equal(2, new2Result.Errors.Count);

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
        IResult resultOld = Result.OK();
        IResult resultNew = Result.OK();

        // Act
        resultNew.AddErrors(resultOld);

        // Assert
        Assert.True(resultNew.IsSuccess);
        Assert.False(resultNew.IsFailure);
        Assert.Empty(resultNew.Errors);
    }

    /// <summary>
    /// Unit test to verify the behavior of the AddMessages method.
    /// </summary>
    [Fact]
    public void AddMessages_WithErrorMessage_ShouldContainErrorMessage()
    {
        // Arrange
        IResult resultOld = Result.OK();
        resultOld.AddError("Hello, world 3!");

        IResult resultNew = Result.OK();

        // Act
        resultNew.AddErrors(resultOld);

        // Assert
        Assert.False(resultNew.IsSuccess);
        Assert.True(resultNew.IsFailure);
        Assert.True(resultNew.Errors.Count > 0);
        Assert.Equal(resultNew.StatusCode, resultOld.StatusCode);
    }

    /// <summary>
    /// Unit test to verify the behavior of the AddMessages method.
    /// </summary>
    [Fact]
    public void AddMessages_WithGenericResult_ShouldContainInformationMessage()
    {
        // Arrange
        IResult<string> resultOld = Result<string>.OK("Test");
        IResult<int> resultNew = Result<int>.OK(10);

        // Act
        resultNew.AddErrors(resultOld);

        // Assert
        Assert.True(resultNew.IsSuccess);
        Assert.False(resultNew.IsFailure);
        Assert.Empty(resultNew.Errors);
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
        IResult resultOld = Result.OK();
        resultOld.AddError("Hello, world 3!");

        IResult resultNew = Result.OK();
        resultNew.AddError("Hello, world 4!");

        // Act
        resultNew.AddErrors(resultOld);

        // Assert
        Assert.False(resultNew.IsSuccess);
        Assert.True(resultNew.IsFailure);
        Assert.True(resultNew.Errors.Count > 0);
        Assert.Equal(resultNew.StatusCode, resultOld.StatusCode);
        Assert.Equal(2, resultNew.Errors.Count);
    }

    /// <summary>
    /// Verifies that adding an error to a result sets the status code and marks the result as a failure.
    /// </summary>
    [Fact]
    public void AddError_WithStatusCode_BadRequest()
    {
        // Arrange
        IResult result = Result.OK();

        // Act
        result.AddError("Error", StatusCode.BadRequest);

        // Assert
        Assert.True(result.IsFailure);
        Assert.Equal(StatusCode.BadRequest, result.StatusCode);
    }

    /// <summary>
    /// Verifies that adding an error to a result sets the status code and marks the result as a failure.
    /// </summary>
    [Fact]
    public void AddError_WithStatusCode_BadGateway()
    {
        // Arrange
        IResult result = Result.OK();

        // Act
        result.AddError("Error", StatusCode.BadGateway);

        // Assert
        Assert.True(result.IsFailure);
        Assert.Equal(StatusCode.BadGateway, result.StatusCode);
    }

    /// <summary>
    /// Verifies that adding an error to a result sets the status code and marks the result as a failure.
    /// </summary>
    [Fact]
    public void AddError_WithStatusCode_Conflict()
    {
        // Arrange
        IResult result = Result.OK();

        // Act
        result.AddError("Error", StatusCode.Conflict);

        // Assert
        Assert.True(result.IsFailure);
        Assert.Equal(StatusCode.Conflict, result.StatusCode);
    }

    /// <summary>
    /// Verifies that adding an error to a result sets the status code and marks the result as a failure.
    /// </summary>
    [Fact]
    public void AddError_WithStatusCode_Forbidden()
    {
        // Arrange
        IResult result = Result.OK();

        // Act
        result.AddError("Error", StatusCode.Forbidden);

        // Assert
        Assert.True(result.IsFailure);
        Assert.Equal(StatusCode.Forbidden, result.StatusCode);
    }

    /// <summary>
    /// Verifies that adding an error to a result sets the status code and marks the result as a failure.
    /// </summary>
    [Fact]
    public void AddError_WithStatusCode_GatewayTimeout()
    {
        // Arrange
        IResult result = Result.OK();

        // Act
        result.AddError("Error", StatusCode.GatewayTimeout);

        // Assert
        Assert.True(result.IsFailure);
        Assert.Equal(StatusCode.GatewayTimeout, result.StatusCode);
    }

    /// <summary>
    /// Verifies that adding an error to a result sets the status code and marks the result as a failure.
    /// </summary>
    [Fact]
    public void AddError_WithStatusCode_InternalServerError()
    {
        // Arrange
        IResult result = Result.OK();

        // Act
        result.AddError("Error", StatusCode.InternalServerError);

        // Assert
        Assert.True(result.IsFailure);
        Assert.Equal(StatusCode.InternalServerError, result.StatusCode);
    }

    /// <summary>
    /// Verifies that adding an error to a result sets the status code and marks the result as a failure.
    /// </summary>
    [Fact]
    public void AddError_WithStatusCode_MethodNotAllowed()
    {
        // Arrange
        IResult result = Result.OK();

        // Act
        result.AddError("Error", StatusCode.MethodNotAllowed);

        // Assert
        Assert.True(result.IsFailure);
        Assert.Equal(StatusCode.MethodNotAllowed, result.StatusCode);
    }

    /// <summary>
    /// Verifies that adding an error to a result sets the status code and marks the result as a failure.
    /// </summary>
    [Fact]
    public void AddError_WithStatusCode_NotFound()
    {
        // Arrange
        IResult result = Result.OK();

        // Act
        result.AddError("Error", StatusCode.NotFound);

        // Assert
        Assert.True(result.IsFailure);
        Assert.Equal(StatusCode.NotFound, result.StatusCode);
    }

    /// <summary>
    /// Verifies that adding an error to a result sets the status code and marks the result as a failure.
    /// </summary>
    [Fact]
    public void AddError_WithStatusCode_RequestTimeout()
    {
        // Arrange
        IResult result = Result.OK();

        // Act
        result.AddError("Error", StatusCode.RequestTimeout);

        // Assert
        Assert.True(result.IsFailure);
        Assert.Equal(StatusCode.RequestTimeout, result.StatusCode);
    }

    /// <summary>
    /// Verifies that adding an error to a result sets the status code and marks the result as a failure.
    /// </summary>
    [Fact]
    public void AddError_WithStatusCode_ServiceUnavailable()
    {
        // Arrange
        IResult result = Result.OK();

        // Act
        result.AddError("Error", StatusCode.ServiceUnavailable);

        // Assert
        Assert.True(result.IsFailure);
        Assert.Equal(StatusCode.ServiceUnavailable, result.StatusCode);
    }

    /// <summary>
    /// Verifies that adding an error to a result sets the status code and marks the result as a failure.
    /// </summary>
    [Fact]
    public void AddError_WithStatusCode_TooManyRequests()
    {
        // Arrange
        IResult result = Result.OK();

        // Act
        result.AddError("Error", StatusCode.TooManyRequests);

        // Assert
        Assert.True(result.IsFailure);
        Assert.Equal(StatusCode.TooManyRequests, result.StatusCode);
    }

    /// <summary>
    /// Verifies that adding an error to a result sets the status code and marks the result as a failure.
    /// </summary>
    [Fact]
    public void AddError_WithStatusCode_Unauthorized()
    {
        // Arrange
        IResult result = Result.OK();

        // Act
        result.AddError("Error", StatusCode.Unauthorized);

        // Assert
        Assert.True(result.IsFailure);
        Assert.Equal(StatusCode.Unauthorized, result.StatusCode);
    }
}