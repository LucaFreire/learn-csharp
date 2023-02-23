using System;
using System.Collections.Generic;
using System.Linq;

// Linq

var estoque = new List<Produto>()
{
    new Produto("Arroz", 10.0, new DateTime(2023, 12, 31)),
    new Produto("Feijão", 8.0, new DateTime(2023, 6, 30)),
    new Produto("Azeite", 20.0, new DateTime(2025, 2, 28)),
    new Produto("Sal", 2.0, new DateTime(2024, 10, 31)),
    new Produto("Açúcar", 5.0, new DateTime(2023, 8, 31)),
    new Produto("Café", 7.5, new DateTime(2022, 12, 31)),
    new Produto("Leite", 3.5, new DateTime(2023, 4, 30)),
    new Produto("Pão", 4.0, new DateTime(2022, 11, 30)),
    new Produto("Queijo", 15.0, new DateTime(2022, 10, 31)),
    new Produto("Presunto", 12.0, new DateTime(2022, 11, 30)),
    new Produto("Manteiga", 8.5, new DateTime(2023, 1, 31)),
    new Produto("Achocolatado", 6.0, new DateTime(2024, 5, 31)),
    new Produto("Refrigerante", 4.5, new DateTime(2023, 7, 31)),
    new Produto("Suco", 3.5, new DateTime(2023, 3, 31)),
    new Produto("Água", 2.0, new DateTime(2024, 2, 29)),
    new Produto("Carne", 25.0, new DateTime(2023, 2, 28)),
    new Produto("Frango", 15.0, new DateTime(2023, 1, 31)),
    new Produto("Peixe", 20.0, new DateTime(2022, 12, 31)),
    new Produto("Batata", 2.5, new DateTime(2022, 10, 31)),
    new Produto("Cebola", 3.0, new DateTime(2023, 3, 31)),
    new Produto("Alho", 2.0, new DateTime(2022, 11, 30)),
    new Produto("Tomate", 3.5, new DateTime(2023, 1, 28)),
    new Produto("Cenoura", 2.5, new DateTime(2023, 1, 31)),
    new Produto("Abóbora", 4.0, new DateTime(2024, 4, 30)),
    new Produto("Beterraba", 2.5, new DateTime(2010, 2, 19))
};



// Produtos que contém a letra "a" e valor maior ou igual a 10
void Exemplo()
{
    var selectedProducts = estoque.Where(x => x.Valor >= 10)
                .Select(x => {
                    if(x.Nome.Any(x => char.ToLower(x) == 'a'))
                        return new { Name = x.Nome, Data = x.DataValidade };
                    return new { Name = "Falso", Data = new DateTime() };
                });

    foreach (var item in selectedProducts)
        Console.WriteLine(item);

}

// Exemplo();


// 1 - Liste todos os produtos do estoque, do mais barato ao mais caro.
void Exer1()
{
    // var prod = estoque.Select(x => new {
    //     nome = x.Nome,
    //     price = x.Valor
    // }).OrderByDescending(x => x.price);

    // foreach (var item in prod)
    // {
    //     Console.Write(item.nome + " ");
    //     Console.WriteLine("R$ " + item.price);
    // }

    var exer1 = estoque.OrderBy(x => x.Valor);

    Console.WriteLine("1 - Liste todos os produtos do estoque, do mais barato ao mais caro.");
    foreach (var item in exer1)
        Console.WriteLine(item);
}

// Exer1();


// 2 - Liste os produtos por ordem alfabética.
void Exer2()
{
    var exer2 = estoque.OrderBy(x => x.Nome);

    Console.WriteLine("2 - Liste os produtos por ordem alfabética.");
    foreach (var item in exer2)
        Console.WriteLine(item);
}

// Exer2();


// 3 - Encontre a média de preço dos produtos, mostre a média, e todos os produtos com o preço acima dela
void Exer3()
{
    var exer3 = estoque.Where(x => x.Valor > estoque.Average(x => x.Valor));
    Console.WriteLine("3 - Encontre a média de preço dos produtos, mostre a média, e todos os produtos com o preço acima dela");
    Console.WriteLine("Média: " + estoque.Average(x => x.Valor));

    foreach (var item in exer3)
        Console.WriteLine(item);
}

// Exer3();


// 4 - Liste os produtos vencidos
void Exer4()
{
    var exer4 = estoque.Where(x => x.DataValidade <  DateTime.Today).OrderBy(x => x.Nome);

    Console.WriteLine("4 - Liste os produtos vencidos");
    foreach (var item in exer4)
        Console.WriteLine(item);
}

// Exer4();


// 5 - Implemente uma função que receba a lista de estoque e uma data utilizando o tipo DateTime, 
// esta função deve retornar uma lista que contendo todos os produtos que irão expirar até esta data
// Ex: WillExpirate(List<estoque> estoque, DateTime dataDesejada)
List<Produto> WillExpirate(List<Produto> lista, DateTime date) // yy/mm/dd
{
    return lista.Where(x => DateTime.Today < x.DataValidade && x.DataValidade < date).ToList();
}

List<Produto> exer5 = WillExpirate(estoque, new DateTime(2023,10,30)); // yy/mm/dd

Console.WriteLine("5 - Produtos que irão expirar até esta data");
foreach (var item in exer5)
    Console.WriteLine(item);


// 6 - Implemente uma função chamada valorMínimo, que tenha como parâmetro a lista de estoque e o valor mínimo
// que a lista deve filtrar, utilize o LINQ para retornar todos os valores acima do valorMínimo
// Ex: getByMinValue(List<estoque> estoque, double minValue)

List<Produto> getByMinValue(List<Produto> lista, double minValue) => lista.Where(x => x.Valor > minValue).ToList(); 


// 7 - Assim como no exercício 6, implemente agora uma função que pegue todos os valores menores que o valor máximo
// Ex: getByMaxValue(List<estoque> estoque, double maxValue)

List<Produto> getByMaxValue(List<Produto> lista, double maxValue) => lista.Where(x => x.Valor < maxValue).ToList(); 



public class Produto
{
    public string Nome { get; set; }
    public double Valor { get; set; }

    public DateTime DataValidade { get; set; }

    public Produto(string nome, double valor, DateTime validade)
    {
        this.Nome = nome;
        this.Valor = valor;
        this.DataValidade = validade;
    }

    public override string ToString()
    {
        return this.Nome + " - R$ " + this.Valor + " - Data Validade " + this.DataValidade;
    }
}
