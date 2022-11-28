
List<double> Lista = new List<double>();

List<double> ListaPonderada = new List<double>{ 3, 3, 4 };

for (int i = 3; i < 3; i++)
{
    Console.WriteLine($"Digite seu {i+1}° número: ");
    double num =  double.Parse(Console.ReadLine() ?? "0");
    Lista.Add(num);
}

// double resultado = 0;
// switch (Console.ReadLine())
// {
//     case "1":
//         resultado = Lista.Aritmetica();
//         break;

//     case "2":
//         resultado = Lista.Ponderada(ListaPonderada);
//         break;

//     case "3":
//         resultado = Lista.Harmonica();
//         break;
    
//     default:
//         throw new Exception("Ai não porra");
// }

double resultado = Console.ReadLine() switch
{
    "1" => Lista.Aritmetica(),
    "2" => Lista.Ponderada(ListaPonderada),
    "3" => Lista.Harmonica(),
    _ => throw new Exception("Ai não porra")
};
