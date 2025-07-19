using System.Text.Json.Serialization;

namespace SegundoDesafio.Modelos;

internal class Livro
{
    [JsonPropertyName("titulo")]
    public string? Titulo { get; set; }
    [JsonPropertyName("autor")]
    public string? Autor { get; set; }
    [JsonPropertyName("ano_publicacao")]
    public int AnoPublicacao { get; set; }
    [JsonPropertyName("genero")]
    public string? Genero { get; set; }
    [JsonPropertyName("paginas")]
    public int Paginas { get; set; }
    [JsonPropertyName("editora")]
    public string? Editora { get; set; }

    public override string ToString() => 
        $"Titulo: {Titulo}; Autor: {Autor}; Ano de Publicação: {AnoPublicacao}; Gênero: {Genero}; Páginas: {Paginas}; Editora: {Editora}; ";
}
