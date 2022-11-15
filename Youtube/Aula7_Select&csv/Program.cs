using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


var Anos = read()
    .Where(c => 2000 < c.Ano)
    .Select(x => new {
        Ano = x.Ano,
        Nome = x.Nome
    });

foreach (var item in Anos)
{
    Console.WriteLine($"{item.Nome} -- {item.Ano}");
}

IEnumerable<Jogos> read()
{
    StreamReader reader = new StreamReader("data/video_games.csv");

    var firstLine = reader.ReadLine();
    var header = firstLine.Split(";").ToList();

    int Name = header.IndexOf("Title");
    int ReleaseYear = header.IndexOf("Release.Year"); 

    while (!reader.EndOfStream)
    {
        var Games = new Jogos();

        
        yield return Games;
    }
}



public class Jogos
{
    public string Nome { get; set; }
    public string Dono { get; set; }
    public int Ano { get; set; }
    public string Nota { get; set; }
}



