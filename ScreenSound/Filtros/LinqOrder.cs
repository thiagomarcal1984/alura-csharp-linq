namespace ScreenSound.Filtros;
using ScreenSound.Modelos;


internal class LinqOrder
{
    public static void ExibirListaDeArtistasOrdenados(List<Musica> musicas)
    {
        var artistasOrdenados = musicas
            // .OrderBy(musica => musica.Artista)
            .OrderByDescending(musica => musica.Artista)
            .Select(musica => musica.Artista)
            .Distinct()
            .ToList();
        artistasOrdenados.ForEach(artista => Console.WriteLine($"- {artista}"));
    }
}
