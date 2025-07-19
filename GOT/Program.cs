using GOT.Modelos;
using System.Text.Json;

using (HttpClient client = new())
{
    string resposta = await client.GetStringAsync("https://anapioficeandfire.com/api/characters");
    var lista = JsonSerializer.Deserialize<List<Personagem>>(resposta)!;

    lista.ForEach(obj => obj.Descrever());

    int numPersonagem = 16;
    resposta = await client.GetStringAsync($"https://anapioficeandfire.com/api/characters/{numPersonagem}");
    var personagem = JsonSerializer.Deserialize<Personagem>(resposta)!;
    Console.WriteLine($"Personagem {numPersonagem}: {personagem.Nome}");
    personagem.Descrever();
}