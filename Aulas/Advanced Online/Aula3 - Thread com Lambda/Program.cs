using System.Threading;
using System.Threading.Tasks;

bool flag = false;
int sum = 0;

Thread t = new Thread(new ThreadStart(() => { // É possível criar função anônimas (lambda)
    
    while (!flag)
        sum++;

}));

t.Start();
// t.Join(); // Caso utilizado, o código ficaria em loop infinito
Console.WriteLine("Início Sleep: " + sum);
Thread.Sleep(5000);
Console.WriteLine("Fim Sleep: " + sum);
flag = true;
Console.Write("Fim Programa: " + sum);
