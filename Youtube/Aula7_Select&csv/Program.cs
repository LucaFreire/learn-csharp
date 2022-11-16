using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

// ============================== FUNÇÕES =================================

void Anos(int num) // Mostra todos os Jogos acima do ano <num>
{
    var Anos = read()
            .Where(j => j.Ano > num);

    foreach (var item in Anos)
        Console.WriteLine($"{item.Nome} -- {item.Ano}");
}


void Notas(int num, int qtd) // Pega os <qtd> primeiros jogos com notas acima do <num>
{
    var Notas = read()
        .Where(x => x.Nota > num)
        .OrderByDescending(x => x.Nota)
        .Take(qtd);

    foreach (var item in Notas)
        Console.WriteLine($"{item.Nome} -- {item.Nota}");
}


void InfoGame(string Nomegame) // Mostra todas as infos sobre o <Nomegame>
{
    var df = read();
    
    bool Existe = false;
    foreach (var x in df)
    { 
        if (x.Nome == Nomegame)
        {
            Console.WriteLine($"Jogo: {x.Nome}\nGênero: {x.Genero}\nNota: {x.Nota}\nPreço: US$ {x.Preco}\nAno de Lançamento: {x.Ano}\nEmpresa: {x.Dono}\nConsole: {x.Console}");
            Existe = true;
            break;
        }
    }
    if (!Existe)
        Console.WriteLine("Jogo não encontrado!");
}


void InfoConsole(string NomeConsole) // Mostra todos os jogos do <NomeConsole> 
{
    var df = read();
    bool Existe = false;
    foreach (var x in df)
    {
        if (x.Console == NomeConsole)
        {
            Console.WriteLine($"Jogo: {x.Nome}");
            Existe = true;
        }
    }
    if (!Existe)
        Console.WriteLine("Console não encontrado!");
}


void PorEmpresa(string NomeEmpresa) // Mostra todos os jogos da <NomeEmpresa>
{
    var df = read();
    bool Existe = false;

    foreach(var x in df)
    {
        if(x.Dono == NomeEmpresa)
        {
            Existe = true;
            Console.WriteLine($"Jogo: {x.Nome}");
        }
    }
    if (!Existe)
        Console.WriteLine("Empresa não encontrada!");
}

void Preco()
{
    var df = read()
            .OrderByDescending(x => x.Preco);
        
    foreach (var item in df)
        Console.WriteLine($"Jogo: {item.Nome} -- US$ {item.Preco}");

}

void AnoPreco(int ano, float price)
{
    var df = read();
    var test = df.Where(j => j.Ano > ano && (double.Parse(j.Preco)/100 > 25));

    foreach(var line in test)
        Console.WriteLine(line.Nome + " - " + line.Preco);
                
}

// ===================== CHAMAR FUNÇÕES ========================

// Anos(1990); // Todos os jogos que foram lançados após os anos 1990

// Notas(90,5); // Os 5 primeiros jogos com notas acima de 90

// InfoGame("Super Mario 64 DS"); // Jogo encontrado
// InfoGame("Super Mario"); // Jogo não encontrado

// InfoConsole("Nintendo DS"); // Console encontrado
// InfoConsole("Play"); // Console não encontrado

// PorEmpresa("Nintendo"); // Empresa encontrada
// PorEmpresa("Pray"); // Empresa não encontrada

// Preco();

// =========================== MANIPULAÇÃO DO ARQUIVO ===========================

IEnumerable<Jogos> read()
{
    StreamReader reader = new StreamReader("data/video_games.csv");

    var header = reader.ReadLine().Replace("\"", "").Split(",").ToList(); // Separa os headers

    int NomeJogo = header.IndexOf("Title");
    int NomeEmpresa = header.IndexOf("Metadata.Publishers");
    int AnoJogo = header.IndexOf("Release.Year");
    int NotaJogo = header.IndexOf("Metrics.Review Score");
    int ConsoleJogo = header.IndexOf("Release.Console");
    int GeneroJogo = header.IndexOf("Metadata.Genres");
    int PrecoJogo = header.IndexOf("Metrics.Used Price");

    while (!reader.EndOfStream)
    {
        string[] jogo = reader.ReadLine().Replace("\"", "").Split(",");
        Jogos games = new Jogos();

        games.Nome = jogo[NomeJogo];
        games.Dono = jogo[NomeEmpresa];
        games.Console = jogo[ConsoleJogo];
        games.Genero = jogo[GeneroJogo];
        

        if (int.TryParse(jogo[NotaJogo], out int n)) // Se o dado for int, é necessário fazer essa conversão
            games.Nota = n;
        
        if (int.TryParse(jogo[AnoJogo], out n))
            games.Ano = n;

        games.Preco = jogo[PrecoJogo];

        yield return games;
    }
}
