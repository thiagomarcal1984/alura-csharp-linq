namespace SegundoDesafio.Modelos;
using System.Text.Json.Serialization;

internal class Pais
{
    [JsonPropertyName("nome")]
    public string? Nome { get; set; }
    [JsonPropertyName("capital")]
    public string? Capital { get; set; }
    [JsonPropertyName("populacao")]
    public int Populacao { get; set; }
    [JsonPropertyName("continente")]
    public string? Continente { get; set; }
    [JsonPropertyName("idioma")]
    public string? Idioma { get; set; }

    public override string ToString() =>
        $"Nome: {Nome}; Capital: {Capital}, População: {Populacao}; Continente: {Continente}; Idioma: {Idioma}";
}
