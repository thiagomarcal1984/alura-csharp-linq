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
    new Livro { Titulo = "Aprendendo LINQ", Autor = "João Silva", AnoPublicacao = 2005 },
    new Livro { Titulo = "Programação em C#", Autor = "Ana Oliveira", AnoPublicacao = 2010 },
    new Livro { Titulo = "Algoritmos e Estruturas de Dados", Autor = "Carlos Santos", AnoPublicacao = 1998 },
    new Livro { Titulo = "Introdução à Inteligência Artificial", Autor = "Mariana Costa", AnoPublicacao = 2021 },
    new Livro { Titulo = "Design Patterns", Autor = "Paulo Rocha", AnoPublicacao = 2002 }
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
