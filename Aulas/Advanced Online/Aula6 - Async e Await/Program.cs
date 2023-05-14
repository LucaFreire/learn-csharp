var ovos = new Ovos();
var farinha = new Farinha(); 

// ExemploPao();
ExemplopaoAsync();

void ExemploPao() // Normal way to do functions, the code is executed sequentially
{
    Console.WriteLine("Mãe mandou Maria buscar os ovos\n");
    Ovos ovoss = ovos.MariaPegarOvos();

    Console.WriteLine("\nMãe manda João comprar farinha");
    Farinha farinhaa = farinha.JoaoPegarFarinha();

    FazerPao(farinhaa, ovoss); 
}

async void ExemplopaoAsync() // Async method
{
    Console.WriteLine("Mãe mandou Maria buscar os ovos\n");
    Task<Ovos> tarefaOvos = ovos.MariaPegarOvosAsync();

    Console.WriteLine("\nMãe manda João comprar farinha");
    Task<Farinha> tarefaFarinha = farinha.JoaoPegarFarinhaAsync();

    Ovos ovoss = await tarefaOvos; // await the task to finalize, the code doesn't start if the task isn't finished
    Farinha farinhaa = await tarefaFarinha;

    FazerPao(farinhaa, ovoss); 
}

void FazerPao(Farinha farinha, Ovos ovos)
{
    Console.WriteLine("\nPreparando pão"); 
    Thread.Sleep(2000);
    Console.WriteLine("Pão feito");
}