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
        musicas[0].ExibirDetalhesDaMusica();

        // LinqFilter.FiltrarTodosOsGenerosMusicais(musicas);

        // LinqOrder.ExibirListaDeArtistasOrdenados(musicas);

        // LinqFilter.FiltrarArtistasPorGeneroMusical(musicas, "blues");
        // LinqFilter.FiltrarMusicasPorArtista(musicas, "U2");
        // LinqFilter.FiltrarMusicasPeloAno(musicas, 2008);

        // var musicasPreferidasEmilly = new MusicasPreferidas("Emilly");
        // musicasPreferidasEmilly.AdicionarMusicasFavoritas(musicas[500]);
        // musicasPreferidasEmilly.AdicionarMusicasFavoritas(musicas[637]);
        // musicasPreferidasEmilly.AdicionarMusicasFavoritas(musicas[428]);
        // musicasPreferidasEmilly.AdicionarMusicasFavoritas(musicas[13]);
        // musicasPreferidasEmilly.AdicionarMusicasFavoritas(musicas[71]);
        
        // musicasPreferidasEmilly.ExibirMusicasFavoritas();
        // musicasPreferidasEmilly.GerarArquivoJson();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Temos um problema: {ex.Message}");
    }
}
