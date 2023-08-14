public class Mundo
{
    private int money { get; set; }
    private int rodada { get; set; }
    List<Player> list = new List<Player>();
    Random rand = new Random();

    public void GeneratePlayers(int cooperadores, int malvados, int repetidores, int vingativos)
    {
        for (int i = 0; i < cooperadores; i++)
            list.Add(new Cooperador());
        for (int i = 0; i < malvados; i++)
            list.Add(new Malvado());
        for (int i = 0; i < repetidores; i++)
            list.Add(new Repetidor());
        for (int i = 0; i < vingativos; i++)
            list.Add(new Vingativo());
    }

    public override string ToString()
        => $"Rodada: {this.rodada}\nDinheiro: {this.money}";

    public bool Play()
    {
        int randNum1 = rand.Next(list.Count);
        int randNum2 = rand.Next(list.Count);
        while (randNum1 == randNum2)
            randNum2 = rand.Next(list.Count);

        Player player1 = list[randNum1];
        Player player2 = list[randNum2];
        play(player1, player2);

        if (list.Count <= 1)
            return false;
        return true;
    }

    private void play(Player p1, Player p2)
    {
        if (p1.Choose() && p2.Choose())
        {
            p1.EarnMoney(1);
            p2.EarnMoney(1);
        }
        else if (p1.Choose() && !p2.Choose())
        {
            p1.LostMoney(1);
            p2.EarnMoney(3);
        }
        else if (!p1.Choose() && p2.Choose())
        {
            p1.EarnMoney(3);
            p2.LostMoney(1);
        }
        else
        {
            p1.LostMoney(1);
            p2.LostMoney(1);
        }

        if (p1.Money <= 0)
        {
            list.Remove(p1);
            return;
        }
        if (p2.Money <= 0)
        {
            list.Remove(p2);
            return;
        }
        rodada++;
    }


}