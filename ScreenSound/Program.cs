using System.Text.Json;
using ScreenSound.Filtros;
using ScreenSound.Modelos;

using (HttpClient client = new())
{
    try
    {
        string resposta = await client.GetStringAsync(
            "https://guilhermeonrails.github.io/api-csharp-songs/songs.json"
        );
        var musicas = JsonSerializer.Deserialize<List<Musica>>(resposta)!;
        // musicas[0].ExibirDetalhesDaMusica();

        // LinqFilter.FiltrarTodosOsGenerosMusicais(musicas);

        // LinqOrder.ExibirListaDeArtistasOrdenados(musicas);

        // LinqFilter.FiltrarArtistasPorGeneroMusical(musicas, "blues");
        LinqFilter.FiltrarMusicasPorArtista(musicas, "U2");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Temos um problema: {ex.Message}");
    }
}
