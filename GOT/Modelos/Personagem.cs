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
