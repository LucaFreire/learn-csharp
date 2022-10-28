using System;

Console.WriteLine("Teste");
var Tecla  = Console.ReadKey().Key;


Console.WriteLine(Tecla.GetType().ToString() == "0System.ConsoleKey");