using System.Text.Json;
using System.Text.Json.Nodes;

class Pessoa
{
    public string? Nome { get; set; }
    public int Idade { get; set; }
    public string? Email { get; set; }
}

class Program
{
    static void ex1(){
        Console.WriteLine(@"
        1.  Criar um programa que permite ao usuário inserir informações de uma 
            pessoa (nome, idade, e e-mail), serializa essas informações em formato 
            JSON e salva em um arquivo.
        ");
        Console.Write("    Digite seu nome: ");
        string nome = Console.ReadLine()!;

        int idade = -1;
        while (idade < 0) 
        {
            Console.Write("    Digite sua idade: ");
            try
            {
                idade = int.Parse(Console.ReadLine()!);
            }
            catch (Exception e)
            {
                Console.WriteLine($"    Erro: {e.Message}");
            }
        }

        Console.Write("    Digite seu email: ");
        string email = Console.ReadLine()!;

        string json = JsonSerializer.Serialize(new Pessoa {
            Nome = nome,
            Idade = idade, 
            Email = email
        });
        // Json resultante: {"campo_nome":"Thiago","campo_idade":40,"campo_email":"tma@cdtn.br"}

        File.WriteAllText("exercicio1.json", json);
        Console.WriteLine();
    }

    static void ex2(){
        Console.WriteLine(@"
        2.  Criar um programa que lê um arquivo JSON contendo informações de uma 
            pessoa, desserializa essas informações e exibe na tela.
        ");
        string leitura = File.ReadAllText("exercicio1.json");
        Pessoa pessoa = JsonSerializer.Deserialize<Pessoa>(leitura)!;
        Console.WriteLine($"    Nome: {pessoa.Nome}");
        Console.WriteLine($"    Idade: {pessoa.Idade}");
        Console.WriteLine($"    Email: {pessoa.Email}");
        Console.WriteLine();
    }

    static void ex3(){
        Console.WriteLine(@"
        3.  Criar um programa que permite ao usuário inserir informações de várias 
            pessoas, armazena essas informações em uma lista, serializa a lista em 
            formato JSON e salva em um arquivo.
        ");

        string nome;
        int idade;
        var lista = new List<object>();
        for (int i = 0; i < 3; i++)
        {
            Console.Write("    Digite seu nome: ");
            nome = Console.ReadLine()!;
            Console.Write("    Digite sua idade: ");
            idade = int.Parse(Console.ReadLine()!);
            lista.Add(new Pessoa { Nome = nome, Idade = idade});
        }

        var json = JsonSerializer.Serialize(lista);
        File.WriteAllText("exercicio3.json", json);
        Console.WriteLine();
    }

    static void ex4(){
        Console.WriteLine(@"
        4.  Criar um programa que lê um arquivo JSON contendo informações de várias 
            pessoas, desserializa essas informações em uma lista e exibe na tela.
        ");
        string leitura = File.ReadAllText("exercicio3.json");
        List<Pessoa> lista = JsonSerializer.Deserialize<List<Pessoa>>(leitura)!;
        lista.ForEach(pessoa => {
            Console.WriteLine($"    Nome: {pessoa.Nome}; Idade: {pessoa.Idade}");
        });
        Console.WriteLine();
    }

    static void ex5(){
        Console.WriteLine(@"
        5.  Criar um programa que lê um arquivo JSON contendo informações de 
            várias pessoas, permite ao usuário inserir uma idade e exibe as 
            pessoas com aquela idade.
        ");
        string leitura = File.ReadAllText("exercicio3.json");
        int idade; 
        var listaJson = JsonSerializer.Deserialize<List<Pessoa>>(leitura)!;

        Console.Write("    Digite a idade procurada: ");
        idade = int.Parse(Console.ReadLine()!);

        listaJson
            .Where(obj => obj.Idade == idade)
            .ToList().ForEach(obj => Console.WriteLine($"    Nome: {obj.Nome}"));
        Console.WriteLine();
    }

    public static void Main()
    {
        ex1();
        ex2();
        ex3();
        ex4();
        ex5();
    }
}
