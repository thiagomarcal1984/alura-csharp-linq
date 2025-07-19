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
dotnet solution add ScreenSound
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

## Try Catch
Implementação do try/catch no programa principal:

```CSharp
// Program.cs
using (HttpClient client = new())
{
    try
    {
        string resposta = await client.GetStringAsync(
            "https://guilhermeonrails.github.io/api-csharp-songs/songs.json"
        );
        Console.WriteLine(resposta);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Temos um problema: {ex.Message}");
    }
}
```
## Desafio: hora da prática
1. Escrever um programa que faça uma requisição para a API de games CheapShark e mostre na tela a lista de promoções cadastrada na ferramenta (Você pode utilizar o endpoint: https://www.cheapshark.com/api/1.0/deals).

2. Escrever um programa que solicite dois números a e b lidos do teclado e realize a divisão de a por b. Caso essa operação não seja possível, mostrar uma mensagem no console que deixe claro o erro ocorrido.

3. Declarar uma lista de inteiros e tente acessar um elemento em um índice inexistente. Tratar a exceção apropriada.

4. Criar uma classe simples com um método e chame esse método em um objeto nulo. Tratar a exceção de método em objeto nulo.

Resposta:
```CSharp
Console.WriteLine("Questão 1");
using (HttpClient client = new())
{
    try
    {
        Console.WriteLine(
            await client.GetStringAsync(
                "https://www.cheapshark.com/api/1.0/deals"
            )
        );
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Exceção: {ex.Message}");
    }
}
```

```CSharp
Console.WriteLine("\n\nQuestão 2");
try
{
    Console.Write("Informe um numerador inteiro: ");
    int a = int.Parse(Console.ReadLine());
    Console.Write("Informe um denominador inteiro: ");
    int b = int.Parse(Console.ReadLine());
    Console.WriteLine(a / b);
}
catch (DivideByZeroException ex)
{
    Console.WriteLine("Não é possível dividir um número por zero.");
    Console.WriteLine($"Exceção: {ex.Message}");
}

```

```CSharp
Console.WriteLine("\n\nQuestão 3");
List<int> lista = new() { 1, 2, 3 };
try
{
    Console.WriteLine(lista[4]);
}
catch (ArgumentOutOfRangeException ex)
{
    Console.WriteLine("Não é possível acessar o elemento na lista.");
    Console.WriteLine(ex.Message);
}

```

```CSharp
Console.WriteLine("\n\nQuestão 4");

try
{
    Simples objeto = null;
    objeto.Metodo();
}
catch (NullReferenceException ex)
{
    Console.WriteLine("O objeto é nulo: não é possível acesar métodos ou campos.");
    Console.WriteLine($"Exceção: {ex.Message}");
}
```
# Linq e ordenação
## Modelo de música
Vamos criar uma classe de modelo. Esse modelo conterá anotações que associam os campos do Json às propriedades de classe de modelo.

```CSharp
// Modelos\Musica.cs
using System.Text.Json.Serialization;

namespace ScreenSound.Modelos;

internal class Musica
{
    [JsonPropertyName("song")]
    public string? Nome { get; set; }
    [JsonPropertyName("artist")]
    public string? Artista { get; set; }
    [JsonPropertyName("duration_ms")]
    public int Duracao { get; set; }
    [JsonPropertyName("genre")]
    public string? Genero { get; set; }

    public void ExibirDetalhesDaMusica()
    {
        Console.WriteLine($"Artista: {Artista}");
        Console.WriteLine($"Música: {Nome}");
        Console.WriteLine($"Duração em segundos: {Duracao / 1000}");
        Console.WriteLine($"Gênero musical: {Genero}");
    }
}
```
> Note a anotação `[JsonPropertyName("nome_no_json")]`. A anotação vem do namespace `System.Text.Json.Serialization`.

## Deserializando os dados
Vamos usar o desserializador no programa principal.
> **Desserializar** significa converter um Json em um objeto nativo da linguagem usada. No caso, vamos converter o Json para objetos do C#.

```CSharp
// Program.cs
using System.Text.Json;
using ScreenSound.Modelos;

using (HttpClient client = new())
{
    try
    {
        string resposta = await client.GetStringAsync(
            "https://guilhermeonrails.github.io/api-csharp-songs/songs.json"
        );
        var musicas = JsonSerializer.Deserialize<List<Musica>>(resposta)!;
        musicas[0].ExibirDetalhesDaMusica();
    }
    // Resto do código.
}
```
> Dois pontos:
> 1. O desserializador é o método `Deserialize` do objeto `JsonSerializer`, do namespace `System.Text.Json`;
> 2. Depois da chamada do método, colocamos uma exclamação. Isso serve para informarmos ao compilador que ele não precisa se preocupar se o resultado vai ser nulo, pois o desenvolvedor garante que o código sempre vai retornar alguma coisa. No exemplo, o método retorna um objeto do tipo `List<Musica>?` (que pode ser nulo, repare a interrogação).
