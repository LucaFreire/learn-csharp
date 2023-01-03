List<Pessoa> lista = new List<Pessoa>
{
    new Pessoa("Jorgin", 23),
    new Pessoa("Teteus", 18),
    new Pessoa("Thigas", 22),
    new Pessoa("Dede", 12),
    new Pessoa("Didi", 15),
    new Pessoa("Dudu", 33),
    new Pessoa("Fabin", 12)
};

void MaiorDeIdade()
{
    var cond = lista
        .Where(x => x.Idade >= 18) // Selecionando os maiores de idade
        .OrderByDescending(x => x.Idade); // Ordenando por Idade (Decrescente)
    foreach (var i in cond)
        Console.WriteLine(i);
}

void MaisVelhos(int num)
{
    var cond = lista
        .OrderByDescending(x => x.Idade)
        .Take(num);
    foreach (var item in cond)
        Console.WriteLine(item);
}

void MaisNovos(int num)
{
    var cond = lista
        .OrderBy(x => x.Idade)
        .Take(num);
    foreach (var item in cond)
        Console.WriteLine(item);
}

void OrdemAlfabetica()
{
    var cond = lista
        .OrderBy(x => x.Nome);
    foreach (var item in cond)
        Console.WriteLine(item);
}

// // MaiorDeIdade();
// MaisVelhos(3);
// MaisNovos(4);
// OrdemAlfabetica();