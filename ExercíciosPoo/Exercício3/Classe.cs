public class Animais
{
    private string Nome { get; set; }
    public string Tipo { get; set; } 
    private string Cor { get; set; } = "Desconhecido";
    private int Idade { get; set;} = 0;

//  Constutores
    public Animais(string nome, string tipo, string cor, int idade)
    {
        this.Nome = nome;
        this.Cor = cor;
        this.Idade = idade;

        if ((tipo != "Peixe") && (tipo != "Cachorro") && (tipo != "Gato"))
            this.Tipo = "Peixe";
        else
            this.Tipo = tipo;
    }
    public Animais(string nome, string tipo)
    {
        this.Nome = nome;
        if ((tipo != "Peixe") && (tipo != "Cachorro") && (tipo != "Gato"))
            this.Tipo = "Peixe";
        else
            this.Tipo = tipo;
    }

//  Métodos
    public void MostrarTudo()
    {
        Console.WriteLine($"\nTipo: {this.Tipo}\nNome: {this.Nome}\nCor: {this.Cor}\nIdade: {this.Idade}");
    }
    public void Mostrar()
    {
        Console.WriteLine($"\nTipo: {this.Tipo}\nNome: {this.Nome}");
    }
}
