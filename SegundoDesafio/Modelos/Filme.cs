namespace SegundoDesafio.Modelos;
using System.Text.Json.Serialization;

internal class Filme
{
    [JsonPropertyName("title")]
    public string? Titulo { get; set; }
    [JsonPropertyName("year")]
    public string? Ano { get; set; }
    [JsonPropertyName("crew")]
    public string? Elenco { get; set; }
    [JsonPropertyName("imDbRating")]
    public string? Nota { get; set; }

    public override string ToString() => 
        $"Titulo: {Titulo}; Ano: {Ano}; Elenco: {Elenco}; Nota: {Nota}";
}
