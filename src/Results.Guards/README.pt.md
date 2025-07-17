# Tolitech.Results.Guards

Tolitech.Results.Guards fornece cláusulas de guarda fluentes para validação de parâmetros e estados, integrando-se ao padrão Results para tratamento padronizado de erros.

## Funcionalidades

- Validação fluente de strings, coleções, números, datas, booleanos e genéricos.
- Encadeamento de múltiplas validações de forma legível e expressiva.
- Integração direta com objetos Result.

## Exemplos de Uso

### Validação de String

```csharp
result.Guard(nome)
    .ErrorIfNullOrEmpty()
    .ErrorIfLengthGreaterThan(50);
```

### Validaçao Numérica
```csharp
result.Guard(idade)
    .ErrorIfLessThan(18);
```

### Validação de Boolean
```csharp
result.Guard(aprovado)
    .ErrorIfFalse();
```

### Validação de Guid
```csharp
result.Guard(id)
    .ErrorIfNotEqualTo(Guid.Empty);
```

### Validação de Coleção

```csharp
result.Guard(lista)
    .ErrorIfEmpty()
    .ErrorIfCountGreaterThan(100);
```

### Validação de Data

```csharp
result.Guard(dataNascimento)
    .ErrorIfFuture();
```

### Validação Genérica

```csharp
result.Guard(value)
    .ErrorIfNull()
    .ErrorIfEqualTo(valorEsperado);
```

## Guards Disponíveis

- **String:** `ErrorIfNull`, `ErrorIfNullOrEmpty`, `ErrorIfNullOrWhiteSpace`, `ErrorIfNotNull`, `ErrorIfNotNullOrNotEmpty`, `ErrorIfEqualTo`, `ErrorIfNotEqualTo`, `ErrorIfLengthEqualTo`, `ErrorIfLengthNotEqualTo`, `ErrorIfLengthGreaterThan`, `ErrorIfLengthGreaterThanOrEqualTo`, `ErrorIfLengthLessThan`, `ErrorIfLengthLessThanOrEqualTo`, `ErrorIfNotValidEmail`, `ErrorIfContains`, `ErrorIfNotContains`.
- **Boolean:** `ErrorIfNull`, `ErrorIfNotNull`, `ErrorIfTrue`, `ErrorIfFalse`, `ErrorIfFalseOrNull`, `ErrorIfTrueOrNull`, `ErrorIfEqualTo`, `ErrorIfNotEqualTo`.
- **Guid:** `ErrorIfNull`, `ErrorIfNotNull`, `ErrorIfEqualTo`, `ErrorIfNotEqualTo`, `ErrorIfNullOrEmpty`, `ErrorIfNotNullOrNotEmpty`.
- **Coleções:** `ErrorIfNull`, `ErrorIfNotNull`, `ErrorIfEmpty`, `ErrorIfNotEmpty`, `ErrorIfCountEqualTo`, `ErrorIfCountNotEqualTo`, `ErrorIfCountGreaterThan`, `ErrorIfCountGreaterThanOrEqualTo`, `ErrorIfCountLessThan`, `ErrorIfCountLessThanOrEqualTo`.
- **DateTime:** `ErrorIfFuture`, `ErrorIfFutureUtc`, `ErrorIfNotFuture`, `ErrorIfNotFutureUtc`, `ErrorIfPast`, `ErrorIfPastUtc`, `ErrorIfNotPast`, `ErrorIfNotPastUtc`.
- **Genéricos:** `ErrorIfNull`, `ErrorIfNotNull`, `ErrorIfEqualTo`, `ErrorIfNotEqualTo`, `ErrorIfLessThan`, `ErrorIfLessThanOrEqualTo`, `ErrorIfGreaterThan`, `ErrorIfGreaterThanOrEqualTo`, `ErrorIfBetween`, `ErrorIfNotBetween`.

## Exemplo Completo

```csharp
result.Guard()
    .ErrorIfNullOrEmpty(email)
    .ErrorIfNotValidEmail(email)
    .ErrorIfLengthGreaterThan(email, 100)
    .ErrorIfNull(valor)
    .ErrorIfLessThan(valor, 10);
```

## Dicas Avançadas

- Encadeie quantas validações forem necessárias.
- Use em conjunto com Tolitech.Results para padronizar o tratamento de erros.