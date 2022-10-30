
var ListaAnimais = new List<Animais>();

for (int i = 0; i < 5; i++)
{   
    Console.WriteLine($"Digite o Tipo do Animal: ");
    string TipoUser = Console.ReadLine() ?? "Peixe";

    Console.WriteLine($"Digite o Nome do {i+1}° Animal: ");
    string NomeUser = Console.ReadLine() ?? "Desconhecido";

    Console.WriteLine($"Deseja inserir Dados Opcionais? [S/N]");
    string escolhaUser = Console.ReadLine() ?? "N";

    if (escolhaUser == "S")
    {
        Console.WriteLine($"Digite a Cor do Animal: ");
        string corUser = Console.ReadLine() ?? "Desconhecido";
        Console.WriteLine($"Digite a Idade do Animal: ");
        int idadeUser = int.Parse(Console.ReadLine() ?? "0");
        Animais Animal = new Animais(NomeUser, TipoUser, corUser, idadeUser);
        ListaAnimais.Add(Animal);
    }
    else
    {
        Animais Animal1 = new Animais(NomeUser, TipoUser);
        ListaAnimais.Add(Animal1);
    }
    Console.Clear();
}

for (int j = 0; j < 5; j++)
    ListaAnimais[j].MostrarTudo();

// for (int j = 0; j < 5; j++)
//     ListaAnimais[j].Mostrar();