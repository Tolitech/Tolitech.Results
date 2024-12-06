# Results

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

# Results.Guards

Results.Guards is a utility library that provides fluent and expressive guard clauses for result-oriented programming. Simplify validation and error handling with these extension methods:

## Why Use Guards?

Guards serve as robust sentinels in your code, ensuring that only valid and expected values proceed. Here's why integrating guards, such as Results.Guards, is beneficial:
- **`Expressive Validation`**:  Guards offer a clear and expressive way to validate input parameters, making your code self-documenting and easy to understand.
- **`Error Prevention`**: By catching invalid inputs early, guards help prevent errors before they can propagate through the system, leading to more stable and reliable software.
- **`Readability and Maintainability`**: Integrating guards improves the overall readability of your code, making it easier to maintain and reducing the cognitive load on developers.
- **`Fluent API`**: Results.Guards provides a fluent API, allowing you to chain multiple validation checks in a concise and readable manner.
- **`Result-Oriented Programming`**: Guards seamlessly align with a result-oriented programming paradigm, where the outcome of operations is explicitly represented, enhancing code clarity.
- **`Consistent Error Handling`**: Guards promote consistency in error handling by providing a standardized way to raise errors when validation conditions are not met.
- **`Enhanced Debugging`**: With guards, you can easily identify the source of issues related to invalid input, simplifying the debugging process and reducing time-to-resolution.

By incorporating guards into your codebase, you not only strengthen its integrity but also contribute to a more maintainable and developer-friendly project.

## String

### ErrorIfNullOrEmpty
```csharp
result.Guard()
    .ErrorIfNullOrEmpty(categoryName);
```

### ErrorIfNullOrWhiteSpace
```csharp
result.Guard()
    .ErrorIfNullOrEmpty(categoryName);
```

### ErrorIfNotNullOrNotEmpty
```csharp
result.Guard()
    .ErrorIfNotNullOrNotEmpty(categoryName);
```

### ErrorIfLengthEqualTo
```csharp
result.Guard()
    .ErrorIfLengthEqualTo(text, length);
```

### ErrorIfLengthNotEqualTo
```csharp
result.Guard()
    .ErrorIfLengthNotEqualTo(text, length);
```

### ErrorIfLengthGreaterThan
```csharp
result.Guard()
    .ErrorIfLengthGreaterThan(text, length);
```

### ErrorIfLengthGreaterThanOrEqualTo
```csharp
result.Guard()
    .ErrorIfLengthGreaterThanOrEqualTo(text, length);
```

### ErrorIfLengthLessThan
```csharp
result.Guard()
    .ErrorIfLengthLessThan(text, length);
```

### ErrorIfLengthLessThanOrEqualTo
```csharp
result.Guard()
    .ErrorIfLengthLessThanOrEqualTo(text, length);
```

### ErrorIfNotValidEmail
```csharp
result.Guard()
    .ErrorIfNotValidEmail(email);
```

## DateTime

### ErrorIfFuture
```csharp
result.Guard()
    .ErrorIfFuture(date);
```

### ErrorIfFutureUtc
```csharp
result.Guard()
    .ErrorIfFutureUtc(date);
```

### ErrorIfNotFuture
```csharp
result.Guard()
    .ErrorIfNotFuture(date);
```

### ErrorIfNotFutureUtc
```csharp
result.Guard()
    .ErrorIfNotFutureUtc(date);
```

### ErrorIfPast
```csharp
result.Guard()
    .ErrorIfPast(date);
```

### ErrorIfPastUtc
```csharp
result.Guard()
    .ErrorIfPastUtc(date);
```

### ErrorIfNotPast
```csharp
result.Guard()
    .ErrorIfNotPast(date);
```

### ErrorIfNotPastUtc
```csharp
result.Guard()
    .ErrorIfNotPastUtc(date);
```

## Boolean

### ErrorIfTrue
```csharp
result.Guard()
    .ErrorIfTrue(approved);
```

### ErrorIfFalse
```csharp
result.Guard()
    .ErrorIfFalse(approved);
```

### ErrorIfFalseOrNull
```csharp
result.Guard()
    .ErrorIfFalseOrNull(approved);
```

### ErrorIfTrueOrNull
```csharp
result.Guard()
    .ErrorIfTrueOrNull(approved);
```

## Collections

### ErrorIfEmpty\<T>
```csharp
result.Guard()
    .ErrorIfEmpty(list);
```

### ErrorIfNotEmpty\<T>
```csharp
result.Guard()
    .ErrorIfNotEmpty(list);
```

### ErrorIfCountEqualTo\<T>
```csharp
result.Guard()
    .ErrorIfCountEqualTo(list, count);
```

### ErrorIfCountNotEqualTo\<T>
```csharp
result.Guard()
    .ErrorIfCountNotEqualTo(list, count);
```

### ErrorIfCountGreaterThan\<T>
```csharp
result.Guard()
    .ErrorIfCountGreaterThan(list, count);
```

### ErrorIfCountGreaterThanOrEqualTo\<T>
```csharp
result.Guard()
    .ErrorIfCountGreaterThanOrEqualTo(list, count);
```

### ErrorIfCountLessThan\<T>
```csharp
result.Guard()
    .ErrorIfCountLessThan(list, count);
```

### ErrorIfCountLessThanOrEqualTo\<T>
```csharp
result.Guard()
    .ErrorIfCountLessThanOrEqualTo(list, count);
```

## Generics

### ErrorIfNull\<T>
```csharp
result.Guard()
    .ErrorIfNull(amount);
```

### ErrorIfNotNull\<T>
```csharp
result.Guard()
    .ErrorIfNotNull(amount);
```

### ErrorIfEqualTo\<T>
```csharp
result.Guard()
    .ErrorIfEqualTo(amount, target);
```

### ErrorIfNotEqualTo\<T>
```csharp
result.Guard()
    .ErrorIfEqualTo(amount, target);
```

### ErrorIfLessThan\<T>
```csharp
result.Guard()
    .ErrorIfLessThan(amount, maximum);
```

### ErrorIfLessThanOrEqualTo\<T>
```csharp
result.Guard()
    .ErrorIfLessThanOrEqualTo(amount, maximum);
```

### ErrorIfGreaterThan\<T>
```csharp
result.Guard()
    .ErrorIfGreaterThan(amount, minimum);
```

### ErrorIfGreaterThanOrEqualTo\<T>
```csharp
result.Guard()
    .ErrorIfGreaterThanOrEqualTo(amount, minimum);
```

### ErrorIfBetween\<T>
```csharp
result.Guard()
    .ErrorIfBetween(amount, minimum, maximum);
```

### ErrorIfNotBetween\<T>
```csharp
result.Guard()
    .ErrorIfNotBetween(amount, minimum, maximum);
```

# Results.Http

## Overview

The `Results.Http` library provides extension methods for handling HTTP responses and populating a `Result` object. It contains a method `ReadProblemDetailsAsync` that reads the content of an `HttpResponseMessage` asynchronously and populates the provided `Result` object with the details extracted from the response.

## Usage

To use the `ReadProblemDetailsAsync` method, follow these steps:

1. Ensure you have a valid `Result` object to populate with response details.
2. Obtain an `HttpResponseMessage` containing the response from an HTTP request.
3. Call the `ReadProblemDetailsAsync` extension method on the `Result` object, passing the `HttpResponseMessage` as a parameter.

```csharp
using Tolitech.Results.Http;

namespace Store.Ordering.Orders;

public sealed class OrderService : IOrderService
{
    private readonly HttpClient httpClient;

    public OrderService(OrderingHttpClient orderingHttpClient)
    {
        httpClient = orderingHttpClient.HttpClient;
    }

    public async Task<Result<CreateOrderResponse>> CreateOrder(CreateOrderRequest request, CancellationToken cancellationToken)
    {
        Result<CreateOrderResponse> result = new();

        string url = $"/orders";
        using var requestMessage = new HttpRequestMessage(HttpMethod.Post, url);
        requestMessage.Content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");

        var response = await httpClient.SendAsync(requestMessage, cancellationToken);
        
        if (response.IsSuccessStatusCode)
        {
            var resp = await response.Content.ReadFromJsonAsync<CreateOrderResponse>();
            return result.OK(resp!);
        }

        await result.ReadProblemDetailsAsync(response);

        return result;
    }
```