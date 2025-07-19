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
