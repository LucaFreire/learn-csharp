using System;
using System.IO;
using System.Collections.Generic;

string nome = string.Empty;
bool premiun = false;
int dia = -1;
int mes = -1;
int ano = -1;
bool run = true;
var listaToFind = new List<Produto>();

// TODO

//Vou completar esta bela obra semana que vem,
//se não for demitido né vai que kkkk
//caracteres úteis: ─│┌┐└┘├┤┬┴┼
Console.WriteLine("┌───┐ ┌───┐");
Console.WriteLine("│┌─┐│ │┌─┐│");
Console.WriteLine("│└─┘│ ││ ││");
Console.WriteLine("│ ┌─┘ ││ ││");
Console.WriteLine("│ └─┐ ││ ││");
Console.WriteLine("│┌─┐│ ││ ││");
Console.WriteLine("│└─┘│ │└─┘│");
Console.WriteLine("└───┘ └───┘");
Console.WriteLine("\t\tTecnologia para a vida");
Console.WriteLine("");
Console.WriteLine("Pressione qualquer tecla para começar...");
Console.ReadKey(true);

while (run)
{

    Console.WriteLine("O que você quer fazer?");
    Console.WriteLine("1 - Cadastrar Novo cliente");
    Console.WriteLine("2 - Ler dados do cliente");
    Console.WriteLine("3 - Cadastrar Novo produto");
    Console.WriteLine("4 - Ler dados do produto");
    Console.WriteLine("5 - Sair");
    int id = int.Parse(Console.ReadLine());
    switch(id)
    {
        case 1:
            Console.Clear();
            Console.Write("Digite o nome do Cliente: ");
            nome = Console.ReadLine() ?? "Desconhecido";

            Console.Write($"\nO {nome} já obteve um 'premiun'? ");
            string x = Console.ReadLine().ToLower();

            if (x == "sim" || x == "true" )
                premiun = true;

            else premiun = false;

            Console.Write($"\nDia: ");
            dia = int.Parse(Console.ReadLine() ?? "-1");

            Console.Write($"\nMês: ");
            mes = int.Parse(Console.ReadLine() ?? "-1");

            Console.Write($"\nAno: ");
            ano = int.Parse(Console.ReadLine() ?? "-1");

            Console.WriteLine("Cliente Cadastrado!");

            Cliente cliente = new Cliente(nome, premiun, dia, mes, ano);
            cliente.Save();
            break;
        
        // TODO

        case 2:
            Console.Clear();
            Console.Write("Digite o nome do Cliente: ");
            string NomeUser = Console.ReadLine();

            var dados = Cliente.Load(NomeUser);
            Console.WriteLine($"Nome: {dados.Nome}\nPremiun: {dados.Premium}\nData de Nascimento: {dados.DiaNascimento}/{dados.MesNascimento}/{dados.AnoNascimento}\n");
            break;
        

        case 3:
            Console.Clear();
            Console.WriteLine("Cadastro de Produtos");
            
            Console.WriteLine("\nNome do Produto: ");
            string ProdutoUser = Console.ReadLine();

            Console.WriteLine($"Nacionalidade do {ProdutoUser}: ");
            string NacioUser = Console.ReadLine();

            Console.WriteLine($"Preço do {ProdutoUser}: ");
            double PrecoUser = double.Parse(Console.ReadLine() ?? "0");

            Console.WriteLine("Produto Cadastrado!");
            Produto prod = new Produto(ProdutoUser, NacioUser, PrecoUser);
            listaToFind.Add(prod);
            prod.Save();
            break;
        
        case 4:
            Console.Clear();
            Console.WriteLine("Visualizar Produto");

            Console.Write("Digite o Nome do Produto: ");
            string maq = Console.ReadLine();

            bool exis = false;

            foreach (var item in listaToFind)
                if (item.NomePro.ToLower() == maq.ToLower())
                {
                    Console.WriteLine($"Nome do Produto: {item.NomePro}\nNacionalidade: {item.Nacionalidade}\nPreço: {item.Preco}\n");
                    exis = true;
                }
        
            if (!exis)
                Console.WriteLine("Produto Não Encontrado!");
            break;

        case 5:
            Console.WriteLine("Você Saiu!");
            run = false;
            break;
        
        default:
            Console.WriteLine("Opção Inválida, Digite Novamente!");
            break;
    }
}

public class Cliente
{
    public Cliente(string nome, bool premium, int dia, int mes, int ano)
    {
        this.Nome = nome;
        this.Premium = premium;
        this.DiaNascimento = dia;
        this.MesNascimento = mes;
        this.AnoNascimento = ano;
    }

    public string Nome { get; set; }
    public bool Premium { get; set; }
    public int DiaNascimento { get; set; }
    public int MesNascimento { get; set; }
    public int AnoNascimento { get; set; }

    public void Save()
    {
        StreamWriter writer = new StreamWriter(this.Nome + ".txt");

        writer.WriteLine(this.Nome);
        writer.WriteLine(this.Premium);
        writer.WriteLine(this.DiaNascimento);
        writer.WriteLine(this.MesNascimento);
        writer.WriteLine(this.AnoNascimento);

        writer.Close();
    }

    public static Cliente Load(string nome)
    {
        StreamReader reader = new StreamReader(nome + ".txt");

        nome = reader.ReadLine();

        bool premiun = bool.Parse(reader.ReadLine());

        int dia = int.Parse(reader.ReadLine());

        int mes = int.Parse(reader.ReadLine());

        int ano = int.Parse(reader.ReadLine());
        // TODO
        
        Cliente cliente = new Cliente(nome, premiun, dia, mes, ano);
        return cliente;
    }
}

public class Produto
{
    public string NomePro { get; set; }
    public string Nacionalidade { get; set; }
    public double Preco { get; set; }
    
    public Produto(string name, string place, double value)
    {
        this.NomePro = name;
        this.Nacionalidade = place;
        this.Preco = value;
    }
    
    public void Save()
    {
        StreamWriter writer = new StreamWriter(this.NomePro + ".txt");

        writer.WriteLine(this.NomePro);
        writer.WriteLine(this.Nacionalidade);
        writer.WriteLine(this.Preco);

        writer.Close();
    }
    public static Produto Load(string nome)
    {
        StreamReader reader = new StreamReader(nome + ".txt");

        nome = reader.ReadLine();

        string place = reader.ReadLine();

        double value = int.Parse(reader.ReadLine());

        Produto produto = new Produto(nome, place, value);
        return produto;
    }

}
