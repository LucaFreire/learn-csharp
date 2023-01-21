// 1 - Escreva um programa que produza a seguinte resultado no Console:
// *
// **
// ***
// ****
// ***
// **
// *
static void Exer1()
{ 
    for (int i = 0; i < 5; i++)
    {
        for (int j = 0; j < i; j++)  
            Console.Write("*");
        Console.WriteLine();
    }

    for (int k = 3; k > 0; k--)
    {
        for (int l = 0; l < k; l++)   
            Console.Write("*");
        Console.WriteLine();
    }
};
// Exer1();


// 2 - Escreva um programa que imprime no Console uma matriz identidade n por n usando um laço for.
static void Exer2()
{   
    Console.Write("Número da sua Matriz identidade: ");
    int N = int.Parse(Console.ReadLine() ?? "0");

    for (int i = 0; i < N; i++)
    {
        for (int j = 0; j < N; j++)
            Console.Write((j == i) ? "1" : "0"); 
        Console.WriteLine();
    }
}
// Exer2();


// 3 - Escreva um programa de conversão que usando switch
// P -> Polegadas para Centímetros
// G -> Galão para Litros
// M -> Milhas para Kilometros
static void Exer3()
{
    Console.Write("Escolha sua conversão:\nP -> Polegadas para Centímetros\nG -> Galão para Litros\nM -> Milhas para Kilometros\nSua Letra: ");

    string user = Console.ReadLine();

    switch (user.ToUpper())
    {

        case "P":
            Console.Write("Insira o número para converter de polegadas p/ centímetros: ");
            float pol = float.Parse(Console.ReadLine() ?? "0");
            Console.WriteLine($"{pol} Polegada(s) é igual a {pol * 2.54} cm, ou {pol * 2.54 / 100} metros ou {pol * 2.54 * 10} milímetros");
            break;

        case "G":
            Console.Write("Insira o número para converter de galão p/ litros: ");
            float gal = float.Parse(Console.ReadLine() ?? "0");
            Console.WriteLine($"{gal} Galão(s) é igual a {gal * 3.74} Litros");
            break;

        case "M":
            Console.Write("Insira o número para converter de Milhas p/ Kilometros: ");
            float mil = float.Parse(Console.ReadLine() ?? "0");
            Console.WriteLine($"{mil} Milha(s) é igual a {mil * 1.609} Km ou {mil * 1.609 * 1000} metros ou {mil * 1.609 * 100000} ");
            break;

        default:
            Console.WriteLine("Opção Inválida!");
            break;
    }

}
// Exer3();
