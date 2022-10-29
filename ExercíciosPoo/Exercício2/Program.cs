//Base do Usuário
Console.Write("Digite a Base de seu Quadrado/Retângulo: ");
int BaseUser = int.Parse(Console.ReadLine());

//Altura do Usuário
Console.Write("\nDigite a Altura de seu Quadrado/Retângulo: ");
int AlturaUser = int.Parse(Console.ReadLine());

Quadrado Obj = new Quadrado(BaseUser, AlturaUser);

// Obj.Area();
// Obj.MostarTudo();
