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