using System.Threading;
using System.Threading.Tasks;

// Tasks ContinueWith Como Executar Ação sobre Task


// Série de processos

// passo1: pegar num aleatório 
// passo2: pegar o num do passo1 e multiplicar p/ 2 
// passo3: pegar o num do passo2 e multiplicar p/ 3


Task<double> passo1 = Task.Factory.StartNew(() => {
    Random r = new Random();
    return (double) r.Next(100);
});

Task<double> passo2 = passo1.ContinueWith((numeroP1) => numeroP1.Result * 2); 

Task<double> passo3 = passo2.ContinueWith((numeroP2) => numeroP2.Result * 3);

Console.WriteLine(passo3.Result);

// Ao invés de utilizar vários awaits e pegar o valor depois, 
// usamos o ContinueWith p/ pegar o valor e usar a função await  
