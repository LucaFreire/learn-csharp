// Exemplo do try catch
while(true)
{
    Console.Write("\nDigite um número: ");
    var user = Console.ReadLine();

    try
    {
        var tryy = int.Parse(user);
        Console.WriteLine($"> Caso não for número, ele pula esse print ({tryy} é um número)\n");
    }

    catch(Exception) // Podemos especificar a exce
    {
        Console.WriteLine($"> {user} não é um número\n");
    }
}
// A ideia é bem parecida com python
