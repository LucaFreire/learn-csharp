Player Jogador = new Player();

var ListaMaquinas = new List<Maquinas>();

Maquina1 Maq1 = new Maquina1(); 
Maquina2 Maq2 = new Maquina2(); 
Maquina3 Maq3 = new Maquina3(); 
Maquina4 Maq4 = new Maquina4(); 
Maquina5 Maq5 = new Maquina5(); 

ListaMaquinas.Add(Maq1);
ListaMaquinas.Add(Maq2);
ListaMaquinas.Add(Maq3);
ListaMaquinas.Add(Maq4);
ListaMaquinas.Add(Maq5);



while (true)
{
    Console.Clear();
    Console.WriteLine($"Seu Dinheiro: {Jogador.Dinheiro}");
    Console.WriteLine("Digite 0 P/ Lucrar!\n1P/ Loja");

    ConsoleKeyInfo Tecla;
    Tecla = Console.ReadKey();


    if (Tecla.Key.ToString() == "0")
        Jogador.Dinheiro+=Jogador.ClicksJogador;
    
    else if (Tecla.ToString() == "1D1")
        { 
            Console.Clear();

            // Mostra a Loja
            for (int i = 0; i<ListaMaquinas.Count;i++)   
                Console.WriteLine($"{ListaMaquinas[i].Nome} - Preço: R${ListaMaquinas[i].Preco}");

            // Compra
            var Compra  = Console.ReadKey();
            for (int j = 0; j<ListaMaquinas.Count;j++)
            {
                if (Compra.ToString() == ListaMaquinas[j].Codigo)

                    if (Jogador.Dinheiro >= ListaMaquinas[j].Preco)
                    {
                        Jogador.ClicksJogador += ListaMaquinas[j].Incremento;
                        Jogador.Dinheiro -= ListaMaquinas[j].Preco;
                    }
                    else
                    {
                        Thread.Sleep(5);
                        Console.WriteLine("Dinheiro Inválido");
                    }
            }
           
        }
}
