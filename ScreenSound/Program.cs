using (HttpClient client = new())
{
    string resposta = await client.GetStringAsync(
        "https://guilhermeonrails.github.io/api-csharp-songs/songs.json"
    );
    Console.WriteLine(resposta);
}
