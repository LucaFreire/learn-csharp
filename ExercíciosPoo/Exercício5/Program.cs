List<Jogador> TimeLista = new List<Jogador>();

for (int i = 0; i<2; i++)
    Console.WriteLine($"Cadastrar {i+1}° Time");
    
    Console.Write("Nome: ");
    string NomeTime = Console.ReadLine();

    Console.Write($"Apelido do {NomeTime}: ");
    string ApelidoTime = Console.ReadLine();

    Console.Write($"Ano de Fundação do {NomeTime}: ");
    int AnoTime = int.Parse(Console.ReadLine());


    for (int j = 0; j < 11; j++)
    {
        Console.Clear();

        Console.Write($"\nDigite o ID do {j+1}° Jogador: ");
        int IDUser = int.Parse(Console.ReadLine() ?? "0");

        Console.Write($"Digite o Nome do Jogador: ");
        string NomeUser = Console.ReadLine() ?? "Desconhecido";

        Console.Write($"Digite a Posição do {NomeUser}: ");
        string PosicaoUser = Console.ReadLine() ?? "Desconhecido";

        Console.Write($"Digite o Apelido do {NomeUser}: ");
        string ApelidoUser = Console.ReadLine() ?? "Desconhecido";

        Console.Write($"Digite a Data de Nascimento do {NomeUser}: ");
        string DataUser = Console.ReadLine() ?? "Desconhecido";

        Console.Write($"Digite o Número do {NomeUser}: ");
        int NumUser = int.Parse(Console.ReadLine() ?? "0");

        Console.Write($"Digite a qualidade do {NomeUser}: ");
        double QualidadeUser = int.Parse(Console.ReadLine() ?? "0");

        Console.Write($"Digite a Quantidade de Cartões Amarelos o {NomeUser} recebeu: ");
        int AmareloUser = int.Parse(Console.ReadLine() ?? "0");

        Jogador Player = new Jogador(IDUser, NomeUser, PosicaoUser, ApelidoUser, DataUser, NumUser, QualidadeUser, AmareloUser);
        TimeLista.Add(Player);
    }

List<Jogador> Time1Ordem = TimeLista.OrderByDescending(x => x.Qualidade).ToList();

List<Time> TimesLista = new List<Time>();

Time Time1 = new Time(NomeTime,ApelidoTime,AnoTime,TimeLista,Time1Ordem);

Time1.MostrarTime(TimesLista);
Time1.RelacionarJogadores(Time1Ordem);
