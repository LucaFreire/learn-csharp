using System;

List<Pessoa> ListaPessoa = new List<Pessoa>();

for (int i = 0; i < 3; i++)
{
    Console.WriteLine($"Digite o Nome da {i + 1}° Pessoa: ");
    string Nome_Pessoa = (Console.ReadLine() ?? "Não Identificado");

    Console.WriteLine($"Digite a Idade da {i + 1}° Pessoa: ");
    int Idade_Pessoa = int.Parse(Console.ReadLine()?? "0");

    Pessoa Pessoa1 = new Pessoa(Nome_Pessoa,Idade_Pessoa);
    ListaPessoa.Add(Pessoa1);
    Console.Clear();
}

for (int j = 0; j<3; j++)
    ListaPessoa[j].ExibirDados();

int Maior = 0;
string NomeMaior = "";

for (int k = 0; k<3; k++)
    if(ListaPessoa[k].Idade > Maior)
    {
        Maior = ListaPessoa[k].Idade;
        NomeMaior = ListaPessoa[k].Nome;
    }
Console.WriteLine($"Nome da Pessoa Mais Velha: {NomeMaior}, com {Maior} Anos de Idade!");
