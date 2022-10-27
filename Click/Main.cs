Player Jogador = new Player();
Maquina1 Maq1 = new Maquina1();
Maquina2 Maq2 = new Maquina2();
Maquina3 Maq3 = new Maquina3();
Maquina4 Maq4 = new Maquina4();
Maquina5 Maq5 = new Maquina5();

var ListaMaquinas = new List<Maquinas>();



while (true)
{
    Console.Clear();
    Console.WriteLine($"Seu Dinheiro: {Jogador.Dinheiro}");
    Console.WriteLine("Digite 0 P/ Lucrar!\n1P/ Loja");

    var Tecla  = Console.ReadKey().Key;

    

    if (Tecla == ConsoleKey.D0)
    {
        Jogador.Dinheiro+=Jogador.ClicksJogador;
    }

    else if (Tecla == ConsoleKey.D1)
        {   
            Console.Clear();

            Console.WriteLine($"1 - Máquina Fraca R${Maq1.Preco}\n2 - Máquina Melhorada R${Maq2.Preco}\n3 - Máquina Forte R${Maq3.Preco}\n4 - Máquina Forte Plus R${Maq4.Preco}\n5 - Máquina Poggers R${Maq5.Preco}");
            var Compra  = Console.ReadKey().Key;
            
            //Máquina 1
            if (Compra == ConsoleKey.D1)
            { 
                if (Jogador.Dinheiro >= Maq1.Preco)
                    {
                        Jogador.ClicksJogador += Maq1.Incremento;
                        Jogador.Dinheiro -= Maq1.Preco;
                    }
                else
                    Console.WriteLine("Dinheiro Inválido!");
            }
            
            //Máquina 2
            else if (Compra == ConsoleKey.D2)
            { 
                if (Jogador.Dinheiro >= Maq2.Preco)
                    {
                        Jogador.ClicksJogador += Maq2.Incremento;
                        Jogador.Dinheiro -= Maq2.Preco;
                    }
                else
                    Console.WriteLine("Dinheiro Inválido!");
            }

            //Máquina 3
            else if (Compra == ConsoleKey.D3)
            { 
                if (Jogador.Dinheiro >= Maq3.Preco)
                    {
                        Jogador.ClicksJogador += Maq3.Incremento;
                        Jogador.Dinheiro -= Maq3.Preco;
                    }
                else
                    Console.WriteLine("Dinheiro Inválido!");
            }

            //Máquina 4
            else if (Compra == ConsoleKey.D4)
            { 
                if (Jogador.Dinheiro >= Maq4.Preco)
                    {
                        Jogador.ClicksJogador += Maq4.Incremento;
                        Jogador.Dinheiro -= Maq4.Preco;
                    }
                else
                    Console.WriteLine("Dinheiro Inválido!");
            }

            //Máquina 5
            else if (Compra == ConsoleKey.D5)
            { 
                if (Jogador.Dinheiro >= Maq4.Preco)
                    {
                        Jogador.ClicksJogador += Maq5.Incremento;
                        Jogador.Dinheiro -= Maq5.Preco;
                    }
                else
                    Console.Clear();
                    Console.WriteLine("Dinheiro Inválido!");
            }

        }
}
