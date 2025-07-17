# Tolitech.Results.Http

Tolitech.Results.Http oferece métodos de extensão para mapear respostas HTTP para objetos Result, facilitando o tratamento de erros e integração com APIs REST.

## Funcionalidades

- Leitura assíncrona de detalhes de problemas de um `HttpResponseMessage` para um objeto `Result`.
- Mapeamento automático de status HTTP, título, detalhe e mensagens de erro.
- Integração transparente com o padrão Results.

## Exemplo de Uso Básico

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

## Método Principal

### ReadProblemDetailsAsync

```csharp
Task ReadProblemDetailsAsync(HttpResponseMessage response)
```

- Lê o conteúdo da resposta HTTP e preenche o objeto Result com título, detalhe, status code e mensagens de erro.

## Exemplo Completo de Integração

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

## Dicas Avançadas

- Use em conjunto com Tolitech.Results para padronizar o tratamento de erros em APIs.
- Permite customização dos detalhes lidos do HTTP para o Result.