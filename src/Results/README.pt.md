# Tolitech.Results

Tolitech.Results é a biblioteca central do padrão Results para .NET, permitindo encapsular o resultado de operações, erros, mensagens e metadados de forma estruturada e previsível.

## Funcionalidades

- Encapsulamento de sucesso, falha e erro em operações.
- Metadados ricos: título, detalhe, tipo, status code, mensagens.
- Métodos de fábrica para todos os principais status HTTP e cenários de negócio.
- API fluente para adicionar mensagens, títulos, detalhes e erros.
- Suporte a resultados genéricos (`Result<T>`).

## Exemplos de Uso

### Resultado de Sucesso

```csharp
IResult result = Result.OK();
IResult resultComValor = Result<int>.OK(42);
```

### Resultado de Erro com Detalhes

```csharp
var result = Result.BadRequest(
    "Erro de Validação"
    "O campo 'Nome' é obrigatório.")
        .AddError("Nome não informado");
```

### Métodos de Fábrica Disponíveis

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

### Manipulação de Mensagens

```csharp
result.AddError("Erro inesperado.", StatusCode.InternalServerError);
```

### Propriedades Importantes

- `IsSuccess`, `IsFailure`
- `StatusCode`, `Title`, `Detail`, `Type`
- `Messages` (coleção de mensagens associadas ao resultado)

### Exemplo Completo

```csharp
public class MathOperation
{
    public IResult<int> Divide(int dividend, int divisor)
    {
        if (divisor == 0)
            return Result<int>.BadRequest()
                .WithTitle("Divisão por zero não permitida")
                .AddError("O divisor não pode ser zero.");

        return Result<int>.OK(dividend / divisor);
    }
}
```

---

Para integração com HTTP e validações fluentes, veja os projetos Tolitech.Results.Http e Tolitech.Results.Guards.
