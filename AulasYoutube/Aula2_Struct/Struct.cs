// struct é quase a mesma coisa que a class, é utilizada quando contemos poucas variáveis,
//utilizando-a, obtemos uma melhor performace


struct Carro
{
    public string Marca { get; set; }
    public string Cor { get; set; }
    public int Ano { get; set; }

    public Carro(string marca, string cor, int ano)
    {
        this.Marca = marca;
        this.Cor = cor;
        this.Ano = ano;
    }
    public void Info() => Console.WriteLine($"Marca: {this.Marca}\nCor: {this.Cor}\nAno: {this.Ano}");

}
