using System.Threading;
using System.Threading.Tasks;


static void DoJob()
{
    for (int i = 0; i < 6; i++)
        Console.WriteLine(i);
}

// Tasks alike Threads 

// --Task  COM FUNÇÕES VOID-- \\

// Maneira 1
Task t = new Task(DoJob); // Cria um objeto do tipo Task
t.Start();
await t; // Mesma função do join

// Maneira 2
Task t2 = Task.Run(() => DoJob()); // Dessa maneira não é necessário usar o t2.Start()
await t2;

// Maneira 3
await Task.Run(() => DoJob()); // Dessa maneira não é necessário criar um objeto e nem uma variável
// Caso não queira o await, apenas exclua-o
 
// Maneira 4
await Task.Factory.StartNew(DoJob);
// Caso não queira o await, apenas exclua-o

// É possívle usar Lambda em todos os métodos acima


// -- Task COM FUNÇÃO DE RETORNO -- \\

static double Dobro(double x) => x * 2;

Task<double> DobroObject = new Task<double>(() => Dobro(25));
DobroObject.Start();
await DobroObject;
Console.WriteLine(DobroObject.Result); // Obtendo o valor do return da função
