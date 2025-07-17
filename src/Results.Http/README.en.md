# Tolitech.Results.Http

Tolitech.Results.Http provides extension methods to map HTTP responses to Result objects, making error handling and REST API integration seamless.

## Features

- Asynchronous reading of problem details from an `HttpResponseMessage` into a `Result` object.
- Automatic mapping of HTTP status, title, detail, and error messages.
- Transparent integration with the Results pattern.

## Basic Usage Example

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

## Main Method

### ReadProblemDetailsAsync

```csharp
Task ReadProblemDetailsAsync(HttpResponseMessage response)
```

- Reads the HTTP response content and fills the Result object with title, detail, status code, and error messages.

## Complete Integration Example

```csharp
public async Task<Result<CreateOrderResponse>> CreateOrder(CreateOrderRequest request)
{
    Result<CreateOrderResponse> result = new();
    var response = await httpClient.PostAsJsonAsync("/orders", request);

    if (response.IsSuccessStatusCode)
    {
        var resp = await response.Content.ReadFromJsonAsync<CreateOrderResponse>();
        return result.OK(resp!);
    }

    await result.ReadProblemDetailsAsync(response);
    return result;
}
```

## Advanced Tips

- Use together with Tolitech.Results to standardize error handling in APIs.
- Allows customization of the details read from HTTP into the Result.
