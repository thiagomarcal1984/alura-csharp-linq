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
    [JsonPropertyName("year")]
    public string? AnoString { get; set; }
    [JsonPropertyName("key")]
    public int Key { get; set; }

    public string Tonalidade 
    { 
        get
        {
            string[] tonalidade = {
                "C", "C#", "D", "Eb", "E", "F", 
                "F#", "G", "Ab", "A", "Bb", "B"
            };
            return tonalidade[Key];
        }
    }

    public int Ano { 
        get {
            return int.Parse(AnoString!);
        }
    }

    public void ExibirDetalhesDaMusica()
    {
        Console.WriteLine($"Artista: {Artista}");
        Console.WriteLine($"Música: {Nome}");
        Console.WriteLine($"Duração em segundos: {Duracao / 1000}");
        Console.WriteLine($"Gênero musical: {Genero}");
        Console.WriteLine($"Key: {Key}");
        Console.WriteLine($"Tonalidade: {Tonalidade}");
    }
}
