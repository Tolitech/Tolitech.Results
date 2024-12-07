# Tolitech.Results

The Results pattern is a design approach used for handling errors and outcomes in a structured manner. Instead of relying solely on exceptions, this pattern involves returning an object that encapsulates both the result and any potential errors that may have occurred during the operation.

## Overview

The `Result` object represents the result of an operation with optional metadata and messages. It is designed for handling errors and outcomes in a structured manner, providing information about the operation's status and associated details.

## Properties

- **`Title`**: Gets the title metadata associated with the result.
- **`Detail`**: Gets the detail metadata associated with the result.
- **`StatusCode`**: Gets the status code associated with the result.
- **`IsSuccess`**: Gets a value indicating whether the result indicates success.
- **`IsFailure`**: Gets a value indicating whether the result indicates failure.
- **`Messages`**: Gets a collection of message results associated with the result.

## Factory Methods

### Success

- `OK()`: Represents a successful result.
- `OK<T>(T value)`: Represents a successful result with a typed value.
- `OK<T>()`: Represents a successful result with the default value for type `T`.

### Created

- `Created()`: Represents a result indicating successful creation.
- `Created<T>(T value)`: Represents a result indicating successful creation with a typed value.
- `Created<T>()`: Represents a result indicating successful creation with the default value for type `T`.

### No Content

- `NoContent()`: Represents a result indicating no content.
- `NoContent<T>()`: Represents a result indicating no content with the default value for type `T`.

### Bad Request

- `BadRequest()`: Represents a result indicating a bad request.
- `BadRequest<T>(T value)`: Represents a result indicating a bad request with a typed value.
- `BadRequest<T>()`: Represents a result indicating a bad request with the default value for type `T`.

### Forbidden

- `Forbidden()`: Represents a result indicating forbidden access.
- `Forbidden<T>(T value)`: Represents a result indicating forbidden access with a typed value.
- `Forbidden<T>()`: Represents a result indicating forbidden access with the default value for type `T`.

### Not Found

- `NotFound()`: Represents a result indicating a resource not found.
- `NotFound<T>(T value)`: Represents a result indicating a resource not found with a typed value.
- `NotFound<T>()`: Represents a result indicating a resource not found with the default value for type `T`.

### Internal Server Error

- `InternalServerError()`: Represents a result indicating an internal server error.
- `InternalServerError<T>(T value)`: Represents a result indicating an internal server error with a typed value.
- `InternalServerError<T>()`: Represents a result indicating an internal server error with the default value for type `T`.

## Methods

### Message Handling

- `AddInformation(string message)`: Adds an informational message to the result.
- `AddInformation(string? key, string message)`: Adds an informational message to the result with an optional key.
- `AddWarning(string message)`: Adds a warning message to the result.
- `AddWarning(string? key, string message)`: Adds a warning message to the result with an optional key.
- `AddError(string message, StatusCode statusCode = StatusCode.BadRequest, Exception? exception = null)`: Adds an error message to the result with optional status code and exception.
- `AddError(string? key, string message, StatusCode statusCode = StatusCode.BadRequest, Exception? exception = null)`: Adds an error message to the result with optional key, status code, and exception.


# Example

Consider a scenario where we have an operation to divide two numbers. We can use the Results pattern to handle the outcome of this operation:

```csharp
// Example implementation of a class using the Results pattern

public class MathOperation
{
    public Result<int> Divide(int dividend, int divisor)
    {
        try
        {
            if (divisor == 0)
            {
                // Handling division by zero
                return Result.BadRequest<int>()
                    .WithTitle("Cannot divide by zero");
            }

            int result = dividend / divisor;

            // Returning a successful result with the quotient
            return Result.OK(result);
        }
        catch (Exception ex)
        {
            // Handling other exceptions
            return Result.InternalServerError<int>()
                .WithTitle(ex.Message)
                .WithDetail(ex.ToString());
        }
    }
}
```