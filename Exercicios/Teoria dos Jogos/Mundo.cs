using System;

public static class Mundo{
    public static Player[] Players {get; private set;} = new Player[1000];
    private static int index { get;  set; } = 0;
    public static int Falidos { get; private set; } = 0;
    public static int TotalMoedas {get; private set;} = Mundo.Players.Length;
    public static int Rodada {get;private set;} = 0;
    public static void Jogada(){
        Random r = new Random();

        Player jogador1, jogador2;

        while (true){
            jogador1 = Mundo.Players[r.Next(Mundo.Players.Length)];
            jogador2 = Mundo.Players[r.Next(Mundo.Players.Length)];
            if ((jogador1.Moeda > 0 && jogador2.Moeda > 0) && jogador1 != jogador2)
                break;
        }
        int moedaIniciais = jogador1.Moeda + jogador2.Moeda; 
        if (jogador1.Decidir() && jogador2.Decidir()){
            jogador1.Recebe(1);
            jogador2.Recebe(1);
        }
        else if(jogador1.Decidir() && !jogador2.Decidir()){
            jogador1.Recebe(-1);
            jogador2.Recebe(4);
        }
        else if(!jogador1.Decidir() && jogador2.Decidir()){
            jogador1.Recebe(4);
            jogador2.Recebe(-1);
        }
        else{
            jogador1.Recebe(0);
            jogador2.Recebe(0);
        }

        if (jogador1.Moeda == 0)
            Mundo.Falidos++;
        if (jogador2.Moeda == 0)
            Mundo.Falidos++;

        int moedasFinais = jogador1.Moeda + jogador2.Moeda;
        int novasMoedas = moedasFinais + moedaIniciais;
        Mundo.TotalMoedas += novasMoedas;
        Mundo.Rodada +=1;
    }
    private static void addJogador(Player player){
        Mundo.Players[Mundo.index] = player;
        Mundo.index++;
    }
    public static void GerarJogadores(int cooperadores, int vingativos, int trapaceiros){
        if (cooperadores + trapaceiros + vingativos > Mundo.Players.Length)
            throw new Exception();
        for (int i = 0; i < cooperadores; i++)
            Mundo.addJogador(new Vingativo());
        for (int i = 0; i < vingativos; i++)
            Mundo.addJogador(new Cooperador());
        for (int i = 0; i < trapaceiros; i++)
            Mundo.addJogador(new Trapaceiro());
        }
}
