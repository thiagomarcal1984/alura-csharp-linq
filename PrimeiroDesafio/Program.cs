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
