using System.Threading;
using System.Threading.Tasks;

static void TimeSleepCsharp()
{
    Console.WriteLine("Iniciou função");
    Thread.Sleep(5000); // "Time.Sleep do C#" 1000 milésimos =  1 segundo
    Console.WriteLine("Terminou a função");
}


// criando thread rodar o TimeSleepCsharp
Thread t = new Thread(new ThreadStart(TimeSleepCsharp));
t.Start();
Thread.Sleep(3000);
Console.WriteLine("Timesleep da main 3 secs");

// Se somado os tempos, o programa seria terminado de executar em 8 secs,
// mas quando utilizado o sistema de threads, o tempo diminui drásticamente
// pelo fato de estar executando ambas as tarefas ao mesmo tempo