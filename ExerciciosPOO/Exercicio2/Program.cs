//Base do Usuário
Console.Write("Digite a Base de seu Quadrado/Retângulo: ");
int BaseUser = int.Parse(Console.ReadLine() ?? "0");

//Altura do Usuário
Console.Write("\nDigite a Altura de seu Quadrado/Retângulo: ");
int AlturaUser = int.Parse(Console.ReadLine() ?? "0");

Quadrado Obj = new Quadrado(BaseUser, AlturaUser);

// Obj.Area();
// Obj.MostarTudo();
