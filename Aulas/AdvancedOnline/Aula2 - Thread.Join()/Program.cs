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
t.Join(); // O join serve para finalizar por completo todas as tarefas da thread
Thread.Sleep(3000);
Console.WriteLine("Timesleep da main 3 secs");

// Ex de join: um programa que descompacta um arquivo e envia-o logo em seguida,
// é preciso tomar muito cuidado para não enviar o arquivo incompleto, 
// o join serve justamente p/ isso, a próxima tarefa vai ser apenas executada,
// quando a thread completar seu 'current work'