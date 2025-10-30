# Tolitech.Results - Solução Completa para Resultados, HTTP e Guards em .NET

Esta solução reúne três bibliotecas especializadas para tratamento de resultados, manipulação de respostas HTTP e validação fluente em aplicações .NET modernas. Cada projeto é independente, mas pode ser utilizado em conjunto para criar APIs e sistemas robustos, previsíveis e altamente manuteníveis.

## Visão Geral dos Projetos

- **Tolitech.Results**: Núcleo do padrão Results, encapsula o resultado de operações, erros, mensagens e metadados.
- **Tolitech.Results.Http**: Extensões para integração fluida entre respostas HTTP e objetos Result.
- **Tolitech.Results.Guards**: Cláusulas de guarda fluentes para validação de parâmetros e estados, integradas ao padrão Results.

---

## Tolitech.Results

### Principais Funcionalidades
- Encapsulamento de sucesso, falha e erro em operações.
- Metadados ricos: título, detalhe, tipo, status code, mensagens.
- Métodos de fábrica para todos os principais status HTTP e cenários de negócio.
- API fluente para adicionar mensagens, títulos, detalhes e erros.
- Suporte a resultados genéricos (`Result<T>`).

### Exemplos de Uso

#### Resultado de Sucesso
```csharp
var result = Result.OK();
var resultComValor = Result<int>.OK>(42);
```

#### Resultado de Erro com Detalhes
```csharp
var result = Result.BadRequest()
    .WithTitle("Erro de Validação")
    .WithDetail("O campo 'Nome' é obrigatório.")
    .AddError("Nome não informado");
```

#### Métodos de Fábrica Disponíveis
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

#### Manipulação de Mensagens
```csharp
result.AddInformation("Processamento concluído com sucesso.");
result.AddWarning("Atenção: campo opcional não preenchido.");
result.AddError("Erro inesperado.", StatusCode.InternalServerError);
```

#### Propriedades Importantes
- `IsSuccess`, `IsFailure`
- `StatusCode`, `Title`, `Detail`, `Type`
- `Messages` (coleção de mensagens associadas ao resultado)

Veja mais exemplos e detalhes em [`src/Results/README.pt.md`](src/Results/README.pt.md)

---

## Tolitech.Results.Http

### Principais Funcionalidades
- Métodos de extensão para ler e mapear detalhes de problemas de um `HttpResponseMessage` para um objeto `Result`.
- Facilita o tratamento de erros de APIs REST e microserviços.
- Integração transparente com o padrão Results.

### Exemplo de Uso
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

#### Método Principal
- `ReadProblemDetailsAsync(HttpResponseMessage response)`

Veja mais exemplos e detalhes em [`src/Results.Http/README.pt.md`](src/Results.Http/README.pt.md)

---

## Tolitech.Results.Guards

### Principais Funcionalidades
- Cláusulas de guarda fluentes para validação de strings, coleções, números, datas, booleanos e genéricos.
- Encadeamento de múltiplas validações de forma legível e expressiva.
- Integração direta com objetos Result para tratamento padronizado de erros.

### Exemplos de Uso

#### Validação de String
```csharp
result.Guard(nome)
    .ErrorIfNullOrEmpty()
    .ErrorIfLengthGreaterThan(50);
```

#### Validaçao Numérica
```csharp
result.Guard(idade)
    .ErrorIfLessThan(18);
```

#### Validação de Boolean
```csharp
result.Guard(aprovado)
    .ErrorIfFalse();
```

#### Validação de Guid
```csharp
result.Guard(id)
    .ErrorIfNotEqualTo(Guid.Empty);
```

#### Validação de Coleção
```csharp
result.Guard(lista)
    .ErrorIfEmpty()
    .ErrorIfCountGreaterThan(100);
```

#### Validação de Data
```csharp
result.Guard(dataNascimento)
    .ErrorIfFuture();
```

#### Validação Genérica
```csharp
result.Guard(value)
    .ErrorIfNull()
    .ErrorIfEqualTo(valorEsperado);
```

#### Principais Guards Disponíveis
- **String:** `ErrorIfNull`, `ErrorIfNullOrEmpty`, `ErrorIfNullOrWhiteSpace`, `ErrorIfNotNull`, `ErrorIfNotNullOrNotEmpty`, `ErrorIfEqualTo`, `ErrorIfNotEqualTo`, `ErrorIfLengthEqualTo`, `ErrorIfLengthNotEqualTo`, `ErrorIfLengthGreaterThan`, `ErrorIfLengthGreaterThanOrEqualTo`, `ErrorIfLengthLessThan`, `ErrorIfLengthLessThanOrEqualTo`, `ErrorIfNotValidEmail`, `ErrorIfContains`, `ErrorIfNotContains`.
- **Boolean:** `ErrorIfNull`, `ErrorIfNotNull`, `ErrorIfTrue`, `ErrorIfFalse`, `ErrorIfFalseOrNull`, `ErrorIfTrueOrNull`, `ErrorIfEqualTo`, `ErrorIfNotEqualTo`.
- **Guid:** `ErrorIfNull`, `ErrorIfNotNull`, `ErrorIfEqualTo`, `ErrorIfNotEqualTo`, `ErrorIfNullOrEmpty`, `ErrorIfNotNullOrNotEmpty`.
- **Coleções:** `ErrorIfNull`, `ErrorIfNotNull`, `ErrorIfEmpty`, `ErrorIfNotEmpty`, `ErrorIfCountEqualTo`, `ErrorIfCountNotEqualTo`, `ErrorIfCountGreaterThan`, `ErrorIfCountGreaterThanOrEqualTo`, `ErrorIfCountLessThan`, `ErrorIfCountLessThanOrEqualTo`.
- **DateTime:** `ErrorIfFuture`, `ErrorIfFutureUtc`, `ErrorIfNotFuture`, `ErrorIfNotFutureUtc`, `ErrorIfPast`, `ErrorIfPastUtc`, `ErrorIfNotPast`, `ErrorIfNotPastUtc`.
- **Genéricos:** `ErrorIfNull`, `ErrorIfNotNull`, `ErrorIfEqualTo`, `ErrorIfNotEqualTo`, `ErrorIfLessThan`, `ErrorIfLessThanOrEqualTo`, `ErrorIfGreaterThan`, `ErrorIfGreaterThanOrEqualTo`, `ErrorIfBetween`, `ErrorIfNotBetween`.

Veja mais exemplos e detalhes em [`src/Results.Guards/README.pt.md`](src/Results.Guards/README.pt.md)

---

## Estrutura do Repositório

```
/README.pt.md (este arquivo)
/src/Results/README.pt.md
/src/Results.Http/README.pt.md
/src/Results.Guards/README.pt.md
```

Cada projeto possui um README detalhado com exemplos e documentação técnica aprofundada.

---

Para detalhes completos, consulte os READMEs específicos de cada projeto.