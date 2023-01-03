// 1.Crie um programa que recebe listas de caracteres e retorna essa 
// mesma lista de forma ordenada até que o usuário deseje parar,
// e depois imprime no console todas as listas. 

List<String> lista = new List<string>();


while (true)
{
    Console.Write("Digite (0 p/ Sair): ");
    string user = Console.ReadLine();
    
    if (user == "0")
        break;
    
    lista.Add(Ordena(user));
}

for (int i = 0; i < lista.Count; i++)
    Console.WriteLine($"{i+1}° Lista: {lista[i]}");

string Ordena(string palavras) => String.Concat(palavras.OrderBy(p => p));
