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
