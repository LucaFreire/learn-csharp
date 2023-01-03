// 3.	Crie um array 5x5 com números inteiros aleatórios. 
//Depois utilize uma condição para substituir os números ímpares
//desse array por 0. Printe os dois arrays.

Matriz Mat = new Matriz(5,5); // Criando array 5x5 com num aleatórios

Console.WriteLine(Mat); // Mostrando array com números aleatórios

Console.WriteLine(Mat.OnlyEven()); // Array alterada
