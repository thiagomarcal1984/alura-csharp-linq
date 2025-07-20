using ScreenSound.Modelos;

namespace ScreenSound.Filtros;

internal class LinqFilter
{
    public static void FiltrarTodosOsGenerosMusicais(List<Musica> musicas)
    {
        var generosMusicais = musicas
            .Select(generos => generos.Genero)
            .Distinct()
            .ToList();
        generosMusicais.ForEach(genero => Console.WriteLine($"- {genero}"));
    }

    public static void FiltrarArtistasPorGeneroMusical(
        List<Musica> musicas,
        string genero
    )
    {
        var artistasPorGeneroMusical = musicas
            .Where(musica => musica.Genero!.Contains(genero))
            .Select(musica => musica.Artista)
            .Distinct()
            .ToList();
        artistasPorGeneroMusical.ForEach(artista => Console.WriteLine($"- {artista}"));
    }

    public static void FiltrarMusicasPorArtista(
        List<Musica> musicas,
        string artista
    )
    {
        var musicasDoArtista = musicas
            .Where(musica => musica.Artista!.Equals(artista))
            .ToList();
        musicasDoArtista.ForEach(musica => Console.WriteLine($"- {musica.Nome}"));
    }

    public static void FiltrarMusicasPeloAno(
        List<Musica> musicas,
        int ano
    )
    {
        var musicasPorAno = musicas
            .Where(musica => musica.Ano == ano)
            .ToList();
        musicasPorAno.ForEach(musica => Console.WriteLine($"- {musica.Nome}"));
    }
}
