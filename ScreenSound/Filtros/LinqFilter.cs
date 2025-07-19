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
}
