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
