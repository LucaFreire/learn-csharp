public class Pessoa
{
    public string Nome { get; set; }
    public int Idade { get; set; }

    public Pessoa(string name, int idade)
    {
        this.Nome = name;
        this.Idade = idade;
    }

    public override string ToString() => $"Nome: {Nome} e Idade: {Idade}"; 
    /*
    Nesse caso, ambos tem a mesma funcionalidade, porém com o ToString
    não é necessário chamar nenhuma função, apenas "printa-la" 
    */
    public string info() => $"Nome: {Nome} e Idade: {Idade}";
}
