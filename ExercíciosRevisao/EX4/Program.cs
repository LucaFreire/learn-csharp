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