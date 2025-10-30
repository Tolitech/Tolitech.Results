# Tolitech.Results - Complete Solution for Results, HTTP, and Guards in .NET

This solution brings together three specialized libraries for result handling, HTTP response mapping, and fluent validation in modern .NET applications. Each project is independent but can be used together to build robust, predictable, and highly maintainable APIs and systems.

## Project Overview

- **Tolitech.Results**: Core Results pattern library, encapsulating operation outcomes, errors, messages, and metadata.
- **Tolitech.Results.Http**: Extensions for seamless integration between HTTP responses and Result objects.
- **Tolitech.Results.Guards**: Fluent guard clauses for parameter and state validation, integrated with the Results pattern.

---

## Tolitech.Results

### Key Features
- Encapsulates success, failure, and error in operations.
- Rich metadata: title, detail, type, status code, messages.
- Factory methods for all major HTTP statuses and business scenarios.
- Fluent API for adding messages, titles, details, and errors.
- Support for generic results (`Result<T>`).

### Usage Examples

#### Success Result
```csharp
var result = Result.OK();
var resultWithValue = Result<int>.OK(42);
```

#### Error Result with Details
```csharp
var result = Result.BadRequest()
    .WithTitle("Validation Error")
    .WithDetail("The 'Name' field is required.")
    .AddError("Name not provided");
```

#### Available Factory Methods
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
- `MethodNotAllowed()`, `MethodNotAllowed(string detail)`, `MethodNotAllowed(string title, string detail)`
- `RequestTimeout()`, `RequestTimeout(string detail)`, `RequestTimeout(string title, string detail)`
- `Conflict()`, `Conflict(string detail)`, `Conflict(string title, string detail)`
- `TooManyRequests()`, `TooManyRequests(string detail)`, `TooManyRequests(string title, string detail)`
- `InternalServerError()`, `InternalServerError(string detail)`, `InternalServerError(string title, string detail)`
- `BadGateway()`, `BadGateway(string detail)`, `BadGateway(string title, string detail)`
- `ServiceUnavailable()`, `ServiceUnavailable(string detail)`, `ServiceUnavailable(string title, string detail)`
- `GatewayTimeout()`, `GatewayTimeout(string detail)`, `GatewayTimeout(string title, string detail)`

#### Message Handling
```csharp
result.AddInformation("Processing completed successfully.");
result.AddWarning("Warning: optional field not filled.");
result.AddError("Unexpected error.", StatusCode.InternalServerError);
```

#### Important Properties
- `IsSuccess`, `IsFailure`
- `StatusCode`, `Title`, `Detail`, `Type`
- `Messages` (collection of messages associated with the result)

See more examples and details in [`src/Results/README.en.md`](src/Results/README.en.md)

---

## Tolitech.Results.Http

### Key Features
- Extension methods to read and map problem details from an `HttpResponseMessage` to a `Result` object.
- Facilitates error handling for REST APIs and microservices.
- Transparent integration with the Results pattern.

### Usage Example
```csharp
using Tolitech.Results.Http;

Result<MyResponse> result = new();
var response = await httpClient.SendAsync(request);

if (response.IsSuccessStatusCode)
{
    var data = await response.Content.ReadFromJsonAsync<MyResponse>();
    return result.OK(data!);
}

await result.ReadProblemDetailsAsync(response);
return result;
```

#### Main Method
- `ReadProblemDetailsAsync(HttpResponseMessage response)`

See more examples and details in [`src/Results.Http/README.en.md`](src/Results.Http/README.en.md)

---

## Tolitech.Results.Guards

### Key Features
- Fluent guard clauses for validation of strings, collections, numbers, dates, booleans, and generics.
- Chaining of multiple validations in a readable and expressive way.
- Direct integration with Result objects for standardized error handling.

### Usage Examples

#### String Validation
```csharp
result.Guard(name)
    .ErrorIfNullOrEmpty()
    .ErrorIfLengthGreaterThan(50);
```

#### Numeric Validation
```csharp
result.Guard(age)
    .ErrorIfLessThan(18);
```

#### Boolean Validation
```csharp
result.Guard(approved)
    .ErrorIfFalse();
```

#### Guid Validation
```csharp
result.Guard(id)
    .ErrorIfNotEqualTo(Guid.Empty);
```

#### Collection Validation
```csharp
result.Guard(list)
    .ErrorIfEmpty()
    .ErrorIfCountGreaterThan(100);
```

#### Date Validation
```csharp
result.Guard(birthDate)
    .ErrorIfFuture();
```

#### Generic Validation
```csharp
result.Guard(value)
    .ErrorIfNull()
    .ErrorIfEqualTo(expectedValue);
```

#### Main Available Guards
- **String:** `ErrorIfNull`, `ErrorIfNullOrEmpty`, `ErrorIfNullOrWhiteSpace`, `ErrorIfNotNull`, `ErrorIfNotNullOrNotEmpty`, `ErrorIfEqualTo`, `ErrorIfNotEqualTo`, `ErrorIfLengthEqualTo`, `ErrorIfLengthNotEqualTo`, `ErrorIfLengthGreaterThan`, `ErrorIfLengthGreaterThanOrEqualTo`, `ErrorIfLengthLessThan`, `ErrorIfLengthLessThanOrEqualTo`, `ErrorIfNotValidEmail`, `ErrorIfContains`, `ErrorIfNotContains`.
- **Boolean:** `ErrorIfNull`, `ErrorIfNotNull`, `ErrorIfTrue`, `ErrorIfFalse`, `ErrorIfFalseOrNull`, `ErrorIfTrueOrNull`, `ErrorIfEqualTo`, `ErrorIfNotEqualTo`.
- **Guid:** `ErrorIfNull`, `ErrorIfNotNull`, `ErrorIfEqualTo`, `ErrorIfNotEqualTo`, `ErrorIfNullOrEmpty`, `ErrorIfNotNullOrNotEmpty`.
- **Collections:** `ErrorIfNull`, `ErrorIfNotNull`, `ErrorIfEmpty`, `ErrorIfNotEmpty`, `ErrorIfCountEqualTo`, `ErrorIfCountNotEqualTo`, `ErrorIfCountGreaterThan`, `ErrorIfCountGreaterThanOrEqualTo`, `ErrorIfCountLessThan`, `ErrorIfCountLessThanOrEqualTo`.
- **DateTime:** `ErrorIfFuture`, `ErrorIfFutureUtc`, `ErrorIfNotFuture`, `ErrorIfNotFutureUtc`, `ErrorIfPast`, `ErrorIfPastUtc`, `ErrorIfNotPast`, `ErrorIfNotPastUtc`.
- **Generics:** `ErrorIfNull`, `ErrorIfNotNull`, `ErrorIfEqualTo`, `ErrorIfNotEqualTo`, `ErrorIfLessThan`, `ErrorIfLessThanOrEqualTo`, `ErrorIfGreaterThan`, `ErrorIfGreaterThanOrEqualTo`, `ErrorIfBetween`, `ErrorIfNotBetween`.

See more examples and details in [`src/Results.Guards/README.en.md`](src/Results.Guards/README.en.md)

---

## Repository Structure

```
/README.md (this file)
/src/Results/README.en.md
/src/Results.Http/README.en.md
/src/Results.Guards/README.en.md
```

Each project has a detailed README with in-depth technical documentation and examples.

---

For complete details, see the specific READMEs for each project.
