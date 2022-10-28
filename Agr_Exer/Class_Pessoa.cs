public class Pessoa
{
    public string Nome { get; set; }
    public int Idade { get; set; }

    public Pessoa(string Name, int Age)
    {
        this.Nome = Name;
        this.Idade = Age;
    }
    public Pessoa()
    {
        this.Nome = "Nome Desconhecido";
        this.Idade = 0;
    }
    public void ExibirDados()
    {
        Console.WriteLine($"Nome: {this.Nome}\nIdade: {this.Idade}");
    }
}


