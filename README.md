# Integrando uma API Externa
## Realizando uma requisição
[Link para projeto da API de onde vamos consumir](https://github.com/guilhermeonrails/api-csharp-songs/tree/main).

[Link para a API em si (que é apenas um JSON)](https://guilhermeonrails.github.io/api-csharp-songs/songs.json)

Criando a solução na linha de comando: 
```
dotnet new solution -n ScreenSound
```

Criando o projeto de linha de comando:
```
dotnet new console -n ScreenSound
```
> O arquivo `Program.cs` é gerado automaticamente quando criamos um novo projeto de Console.

Código do programa principal:
```CSharp
// Program.cs
using (HttpClient client = new())
{
    string resposta = await client.GetStringAsync(
        "https://guilhermeonrails.github.io/api-csharp-songs/songs.json"
    );
    Console.WriteLine(resposta);
}
```
> 1. A palavra reservada `using` neste caso é algo parecido como o with do Python: ela cria um contexto onde um objeto será usado e descartado em seguida. Neste caso, o objeto que será criado e descartado é o `HttpClient` de nome `client`.
>
> 2. Note que, como a requisição HTTP é obtida por um método assíncrono (`GetStringAsync`), precisamos fazer com que o programa aguarde a conclusão do método assíncrono por meio da palavra reservada `await`.
