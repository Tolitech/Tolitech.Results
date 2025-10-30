# Tolitech.Results

Tolitech.Results is the core Results pattern library for .NET, enabling you to encapsulate operation outcomes, errors, messages, and metadata in a structured and predictable way.

## Features

- Encapsulates success, failure, and error in operations.
- Rich metadata: title, detail, type, status code, messages.
- Factory methods for all major HTTP statuses and business scenarios.
- Fluent API for adding messages, titles, details, and errors.
- Support for generic results (`Result<T>`).

## Usage Examples

### Success Result
```csharp
IResult result = Result.OK();
IResult resultWithValue = Result<int>.OK(42);
```

### Error Result with Details
```csharp
var result = Result.BadRequest(
    "Validation Error",
    "The 'Name' field is required.")
        .AddError("Name not provided");
```

### Available Factory Methods
- `OK()`, `OK(T value)`
- `Created()`, `Created(T value)`
- `Accepted()`, `Accepted(T value)`
- `NoContent()`,
- `Found()`, `Found(T value)`
- `NotModified()`, `NotModified(T value)`
- `BadRequest()`, `BadRequest(string detail)`, `BadRequest(string title, string detail)`
- `Unauthorized()`, `Unauthorized(string detail)`, `Unauthorized(string title, string detail)`
- `Forbidden()`, `Forbidden(string detail)`, `Forbidden(string title, string detail)`
- `NotFound()`, `NotFound(string detail)`, `NotFound(string title, string detail)`
- `Conflict()`, `Conflict(string detail)`, `Conflict(string title, string detail)`
- `InternalServerError()`, `InternalServerError(string detail)`, `InternalServerError(string title, string detail)`

### Message Handling
```csharp
result.AddError("Unexpected error.", StatusCode.InternalServerError);
```

### Important Properties
- `IsSuccess`, `IsFailure`
- `StatusCode`, `Title`, `Detail`, `Type`
- `Messages` (collection of messages associated with the result)

### Complete Example
```csharp
public class MathOperation
{
    public IResult<int> Divide(int dividend, int divisor)
    {
        if (divisor == 0)
            return Result<int>.BadRequest()
                .WithTitle("Division by zero not allowed")
                .AddError("The divisor cannot be zero.");

        return Result<int>.OK(dividend / divisor);
    }
}
```

---

For HTTP integration and fluent validations, see the Tolitech.Results.Http and Tolitech.Results.Guards projects.
