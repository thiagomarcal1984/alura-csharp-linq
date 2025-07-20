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

## Desafios
Desafio desenvolvido no projeto `SegundoDesafio`. Os quatro modelos propostos foram implementados, mas documentaremos apenas um dos modelos para exemplo.

Classe de modelo: 
```CSharp
// Modelos\Carro.cs
using System.Text.Json.Serialization;

namespace SegundoDesafio.Modelos;

internal class Carro
{
    [JsonPropertyName("marca")]
    public string? Marca { get; set; }
    [JsonPropertyName("modelo")]
    public string? Modelo { get; set; }
    [JsonPropertyName("ano")]
    public int Ano { get; set; }
    [JsonPropertyName("tipo")]
    public string? Tipo { get; set; }
    [JsonPropertyName("motor")]
    public string? Motor { get; set; }
    [JsonPropertyName("transmissao")]
    public string? Transmissao { get; set; }

    public override string ToString() => 
        $"Marca: {Marca}; Modelo: {Modelo}; Ano: {Ano}; Tipo: {Tipo}; Motor: {Motor}; Transmissão: {Transmissao}";
}
```
Programa principal: 
```CSharp
// Program.cs
using System.Text.Json;
using SegundoDesafio.Modelos;

using (HttpClient client = new())
{
    try
    {
        // Resto do código
        resposta = await client.GetStringAsync("https://raw.githubusercontent.com/ArthurOcFernandes/Exerc-cios-C-/curso-4-aula-2/Jsons/Carros.json");
        var carros = JsonSerializer.Deserialize<List<Carro>>(resposta)!;
        Console.WriteLine(carros[1]);
        // Resto do código
    }
    catch (Exception e)
    {
        Console.WriteLine(e);
    }
}
```
## Faça como eu fiz: refatorando uma função
Criando o projeto e inserindo-a na solução:

```bash
dotnet new console -n GOT
dotnet solution add GOT
```
Semelhante ao desafio anterior, mas a classe `Personagem` vai conter uma lista de apelidos do personagem.

Classe de modelo:
```CSharp
// GOT\Personagem.cs
using System.Text.Json.Serialization;

namespace GOT.Modelos;

internal class Personagem
{
    [JsonPropertyName("name")]
    public string? Nome { get; set; }
    [JsonPropertyName("gender")]
    public string? Genero { get; set; }
    [JsonPropertyName("culture")]
    public string? Cultura { get; set; }

    [JsonPropertyName("books")]
    public List<string?> Livros { get; set; } = new();
    [JsonPropertyName("aliases")]
    public List<string?> Apelidos { get; set; } = new();

    public void Descrever()
    {
        Console.WriteLine($"Nome: {Nome}");
        Console.WriteLine($"Gênero: {Genero}");
        Console.WriteLine($"Cultura: {Cultura}");
        
        Console.WriteLine("Livros:");
        Livros.ForEach(l => Console.WriteLine("\t" + l));
        
        Console.WriteLine("Apelidos:");
        Apelidos.ForEach(a => Console.WriteLine("\t" + a));
        
        Console.WriteLine("-*-*-*-*-*-*-*-*-*-*-*-*-*\n");
    }
}
```
Programa principal:
```CSharp
// Program.cs
using GOT.Modelos;
using System.Text.Json;

using (HttpClient client = new())
{
    // Obtendo uma lista
    string resposta = await client.GetStringAsync("https://anapioficeandfire.com/api/characters");
    var lista = JsonSerializer.Deserialize<List<Personagem>>(resposta)!;

    lista.ForEach(obj => obj.Descrever());

    // Obtendo um único personagem
    int numPersonagem = 16;
    resposta = await client.GetStringAsync($"https://anapioficeandfire.com/api/characters/{numPersonagem}");
    var personagem = JsonSerializer.Deserialize<Personagem>(resposta)!;
    Console.WriteLine($"Personagem {numPersonagem}: {personagem.Nome}");
    personagem.Descrever();
}
```
# Linq
## Selecionando gêneros musicais
Vamos implementar uma classe com um método estático que filtrará todos os tipos de gêneros musicais presentes nas músicas buscadas na API.

Código da classe de filtro:
```CSharp
// Filtros\LinqFilter.cs
using ScreenSound.Modelos;

namespace ScreenSound.Filtros;

internal class LinqFilter
{
    public static void FiltrarTodosOsGenerosMusicais(List<Musica> musicas)
    {
        var generosMusicais = musicas
            .Select(generos => generos.Genero)
            .Distinct()
            .ToList();
        generosMusicais.ForEach(genero => Console.WriteLine($"- {genero}"));
    }
}
```
> Note o encadeamento dos métodos chamados a partir da lista `musicas`:
> 1. `Select` escolhe qual propriedade será retornada;
> 2. `Distinct` remove as repetições;
> 3. `ToList` garante que o retorno será uma lista de objetos da classe `Musica`.

Programa principal:
```CSharp
// Program.cs
using System.Text.Json;
using ScreenSound.Filtros;
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

        // Invocação do método estático do Filtro.
        LinqFilter.FiltrarTodosOsGenerosMusicais(musicas); 
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Temos um problema: {ex.Message}");
    }
}
```
## Ordenando os artistas
Uma outra classe de Filtro foi criada. Vamos analisá-la:

```CSharp
// Filtro\LinqOrder.cs
namespace ScreenSound.Filtros;
using ScreenSound.Modelos;


internal class LinqOrder
{
    public static void ExibirListaDeArtistasOrdenados(List<Musica> musicas)
    {
        var artistasOrdenados = musicas
            // .OrderBy(musica => musica.Artista)
            .OrderByDescending(musica => musica.Artista)
            .Select(musica => musica.Artista)
            .Distinct()
            .ToList();
        artistasOrdenados.ForEach(artista => Console.WriteLine($"- {artista}"));
    }
}
```
1. `OrderBy` / `OrderByDescending` ordena a lista em função de uma propriedade de cada objeto iterado;
2. `Select` escolhe que elemento será selecionado para o retorno;
3. `Distinct` retorna elementos não repetidos;
4. `ToList` retorna a lista dos objetos selecionados pelo método `Select`.

## Artistas por gênero musical
A classe `LinqFilter` foi modificada para acrescentar outro filtro:

```CSharp
// Filtros\LinqFilter.cs
using ScreenSound.Modelos;

namespace ScreenSound.Filtros;

internal class LinqFilter
{
    // Resto do código
    public static void FiltrarArtistasPorGeneroMusical(
        List<Musica> musicas,
        string genero
    )
    {
        var artistasPorGeneroMusical = musicas
            .Where(musica => musica.Genero!.Contains(genero))
            .Select(musica => musica.Artista)
            .Distinct()
            .ToList();
        artistasPorGeneroMusical.ForEach(artista => Console.WriteLine($"- {artista}"));
    }
}
```
> A única diferença é o operador de exclamação em `musica.Genero!.Contains`. Ela é só um meio de forçar o compilador a não dar warning, porque o desenvolvedor garante que a propriedade `Genero` nunca será nula.

## Exibindo músicas por artistas
A classe `LinqFilter` foi modificada para acrescentar outro filtro:

```CSharp
// Filtros\LinqFilter.cs
using ScreenSound.Modelos;

namespace ScreenSound.Filtros;

internal class LinqFilter
{
    // Resto do código

    public static void FiltrarMusicasPorArtista(
        List<Musica> musicas,
        string artista
    )
    {
        var musicasDoArtista = musicas
            .Where(musica => musica.Artista!.Equals(artista))
            .ToList();
        musicasDoArtista.ForEach(musica => Console.WriteLine($"- {musica.Nome}"));
    }
}
```
> A única diferença é o operador de exclamação em `musica.Artista!.Equals`. Ela é só um meio de forçar o compilador a não dar warning, porque o desenvolvedor garante que a propriedade `Artista` nunca será nula.

## Desafio: hora da prática
Criando o projeto e inserindo-a na solução:

```bash
dotnet new console -n TerceiroDesafio
dotnet solution add TerceiroDesafio
```

Classes de Modelo:
```CSharp
// Modelos\Produto.cs
namespace TerceiroDesafio.Modelos;

class Produto
{
    public string? Nome { get; set; }
    public float Preco { get; set; }
}

// Modelos\Livro.cs
namespace TerceiroDesafio.Modelos;

class Livro
{
    public string? Titulo { get; set; }
    public string? Autor { get; set; }
    public int AnoPublicacao { get; set; }
}
```

Programa principal:
```CSharp
// Program.cs
using TerceiroDesafio.Modelos;

List<int> numeros = new() {
    1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
    2, 4, 6, 8, 10
};

Console.WriteLine(@"
1.  Dada uma lista de números, criar uma consulta LINQ para retornar 
    apenas os elementos únicos da lista.
");
numeros.Distinct()
    .ToList()
    .ForEach(n => Console.WriteLine($"    {n}"));
Console.WriteLine();

Console.WriteLine(@"
2.  Dada uma lista de livros com título, autor e ano de publicação, 
    criar uma consulta LINQ para retornar uma lista com os títulos 
    dos livros publicados após o ano 2000, ordenados alfabeticamente.
");
var livros = new List<Livro>() {
    new Livro { 
        Titulo = "Aprendendo LINQ", 
        Autor = "João Silva", 
        AnoPublicacao = 2005 
    },
    new Livro { 
        Titulo = "Programação em C#", 
        Autor = "Ana Oliveira", 
        AnoPublicacao = 2010 
    },
    new Livro { 
        Titulo = "Algoritmos e Estruturas de Dados", 
        Autor = "Carlos Santos", 
        AnoPublicacao = 1998 
    },
    new Livro { 
        Titulo = "Introdução à Inteligência Artificial", 
        Autor = "Mariana Costa", 
        AnoPublicacao = 2021 
    },
    new Livro { 
        Titulo = "Design Patterns", 
        Autor = "Paulo Rocha", 
        AnoPublicacao = 2002
    }
};

livros
    .Where(l => l.AnoPublicacao > 2000)
    .OrderBy(l => l.Titulo)
    .ToList()
    .ForEach(l => Console.WriteLine($"    {l.AnoPublicacao} - {l.Titulo}"));
Console.WriteLine();

Console.WriteLine(@"
3.  Dada uma lista de produtos com nome e preço, criar uma consulta 
    LINQ para calcular o preço médio dos produtos.
");

var produtos = new List<Produto>() {
    new Produto { Nome = "Laptop", Preco = 1200 },
    new Produto { Nome = "Smartphone", Preco = 800 },
    new Produto { Nome = "Tablet", Preco = 500 },
    new Produto { Nome = "Câmera", Preco = 300 }
};

var media = produtos.Average(p => p.Preco);

Console.WriteLine($"    Média dos produtos: {media}");
Console.WriteLine();

Console.WriteLine(@"
4.  Dada uma lista de inteiros, criar uma consulta LINQ para retornar 
    apenas os números pares.
");
numeros
    .Where(n => n % 2 == 0)
    .ToList().ForEach(n => Console.WriteLine($"    {n}"));

```
