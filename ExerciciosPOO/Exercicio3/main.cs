
var ListaAnimais = new List<Animais>();

for (int i = 0; i < 5; i++)
{   
    Console.WriteLine($"Digite o Tipo do Animal: ");
    string TipoUser = Console.ReadLine() ?? "Peixe";

    Console.WriteLine($"Digite o Nome do {i+1}° Animal: ");
    string NomeUser = Console.ReadLine() ?? "Desconhecido";

    Console.WriteLine($"Deseja inserir Dados Opcionais? [S/N]");
    string escolhaUser = Console.ReadLine() ?? "N".ToLower();

    if (escolhaUser == "s")
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

int Dog = 0;
int Cat = 0;
int Fish = 0;

for (int j = 0; j < 5; j++)
{
    if (ListaAnimais[j].Tipo == "Cachorro")
        Dog+=1;
    else if(ListaAnimais[j].Tipo == "Gato")
        Cat+=1;
    else
        Fish+=1;
        
    ListaAnimais[j].MostrarTudo();
    //ListaAnimais[j].Mostrar();
}
Console.WriteLine($"\nCachorro(s): {Dog}\nGato(s): {Cat}\nPeixe(s): {Fish}");
