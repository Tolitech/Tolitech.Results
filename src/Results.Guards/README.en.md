# Tolitech.Results.Guards

Tolitech.Results.Guards provides fluent guard clauses for parameter and state validation, integrating with the Results pattern for standardized error handling.

## Features

- Fluent validation for strings, collections, numbers, dates, booleans, and generics.
- Chaining of multiple validations in a readable and expressive way.
- Direct integration with Result objects.

## Usage Examples

### String Validation

```csharp
result.Guard(name)
    .ErrorIfNullOrEmpty()
    .ErrorIfLengthGreaterThan(50);
```

### Numeric Validation
```csharp
result.Guard(age)
    .ErrorIfLessThan(18);
```

### Boolean Validation
```csharp
result.Guard(approved)
    .ErrorIfFalse();
```

### Guid Validation
```csharp
result.Guard(id)
    .ErrorIfNotEqualTo(Guid.Empty);
```

### Collection Validation

```csharp
result.Guard(list)
    .ErrorIfEmpty()
    .ErrorIfCountGreaterThan(100);
```

### Date Validation

```csharp
result.Guard(birthDate)
    .ErrorIfFuture();
```

### Generic Validation

```csharp
result.Guard(value)
    .ErrorIfNull()
    .ErrorIfEqualTo(expectedValue);
```

## Available Guards

- **String:** `ErrorIfNull`, `ErrorIfNullOrEmpty`, `ErrorIfNullOrWhiteSpace`, `ErrorIfNotNull`, `ErrorIfNotNullOrNotEmpty`, `ErrorIfEqualTo`, `ErrorIfNotEqualTo`, `ErrorIfLengthEqualTo`, `ErrorIfLengthNotEqualTo`, `ErrorIfLengthGreaterThan`, `ErrorIfLengthGreaterThanOrEqualTo`, `ErrorIfLengthLessThan`, `ErrorIfLengthLessThanOrEqualTo`, `ErrorIfNotValidEmail`, `ErrorIfContains`, `ErrorIfNotContains`.
- **Boolean:** `ErrorIfNull`, `ErrorIfNotNull`, `ErrorIfTrue`, `ErrorIfFalse`, `ErrorIfFalseOrNull`, `ErrorIfTrueOrNull`, `ErrorIfEqualTo`, `ErrorIfNotEqualTo`.
- **Guid:** `ErrorIfNull`, `ErrorIfNotNull`, `ErrorIfEqualTo`, `ErrorIfNotEqualTo`, `ErrorIfNullOrEmpty`, `ErrorIfNotNullOrNotEmpty`.
- **Collections:** `ErrorIfNull`, `ErrorIfNotNull`, `ErrorIfEmpty`, `ErrorIfNotEmpty`, `ErrorIfCountEqualTo`, `ErrorIfCountNotEqualTo`, `ErrorIfCountGreaterThan`, `ErrorIfCountGreaterThanOrEqualTo`, `ErrorIfCountLessThan`, `ErrorIfCountLessThanOrEqualTo`.
- **DateTime:** `ErrorIfFuture`, `ErrorIfFutureUtc`, `ErrorIfNotFuture`, `ErrorIfNotFutureUtc`, `ErrorIfPast`, `ErrorIfPastUtc`, `ErrorIfNotPast`, `ErrorIfNotPastUtc`.
- **Generics:** `ErrorIfNull`, `ErrorIfNotNull`, `ErrorIfEqualTo`, `ErrorIfNotEqualTo`, `ErrorIfLessThan`, `ErrorIfLessThanOrEqualTo`, `ErrorIfGreaterThan`, `ErrorIfGreaterThanOrEqualTo`, `ErrorIfBetween`, `ErrorIfNotBetween`.

## Complete Example

```csharp
result.Guard()
    .ErrorIfNullOrEmpty(email)
    .ErrorIfNotValidEmail(email)
    .ErrorIfLengthGreaterThan(email, 100)
    .ErrorIfNull(value)
    .ErrorIfLessThan(value, 10);
```

## Advanced Tips

- Chain as many validations as needed.
- Use together with Tolitech.Results to standardize error handling.
