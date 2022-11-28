// 4.	Faça um programa para armazenar um livro de receitas (utilize struct) e:
// • Crie um vetor de 5 receitas, que deve ter nome (máximo 25 letras), 
//   quantidade de ingredientes e ingredientes.
// • Para cada receita, leia seu nome e a quantidade de ingredientes. 
//   Então crie e leia o vetor de ingredientes, sendo que cada ingrediente contem nome e quantidade. 
// • Procure receita por nome, mostrando seus ingredientes se encontrar.
//  Se não encontrar, informe ao usuário. Repita o processo até e digitar uma string vazia.

var receitas = new List<Receitas>()
{
    new Receitas("Receita",new Ingredientes("Ingredientex",1)),
    new Receitas("Receita2",new Ingredientes("Ingredientex",1)),
    new Receitas("Receita3",new Ingredientes("Ingredientex",4)),
    new Receitas("Receita4",new Ingredientes("Ingredientex",4)),
    new Receitas("Receita5",new Ingredientes("Ingredientex",1)),
};
Console.Clear();
bool run = true;
while (run)
{   
    Console.WriteLine($"=====Receitas=====\nDigite o Nome da Receita que você deseja: ");

    string user = Console.ReadLine().ToLower();
    bool find = false;

    if (user == "")
        run = false;

    else
    {
        foreach (var item in receitas)
            if(user == item.NomeReceita.ToLower())
            {
                Console.Clear();
                Console.WriteLine($"Receita Encontrada!\nNome da Receita: {item.NomeReceita}");

                Console.WriteLine($"Ingrediente: {item.Ingre.NomeIngre1} -- Quantidade: {item.Ingre.QtdIngre1}");
            
                find = true;
            }
        
    if (!find)
    {
        Console.Clear();
        Console.WriteLine("Receita Não Encontrada!");
    }
    find = false;
    }
}
Console.Write("Você Saiu!");