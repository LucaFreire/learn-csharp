public class Time 
{
    public string NomeTime { get; set; }
    public string ApelidoTime { get; set; }
    public int Fundacao { get; set; }
    public List<Jogador> Plantel { get; set; }
    public List<Jogador> Relacionados { get; set; }


    public Time(string NOMETM, string APELIDOTM, int FUNDATION, List<Jogador> Lista, List<Jogador> Lista2)
    {
        this.NomeTime = NOMETM;
        this.ApelidoTime = APELIDOTM;
        this.Fundacao = FUNDATION;
        this.Plantel = Lista;
        this.Relacionados = Lista2;
    }

    // public void RelacionarJogadores(List<Jogador> Ordem)
    // {
    //     for (int i = 0; i<11; i++)
    //         Console.WriteLine($"Nome: {Ordem[i].Nome}, Qualidade: {Ordem[i].Qualidade}");
    // }

    public void RelacionarJogadores(List<Jogador> Ordem)
    {
        for (int i = 0; i<18; i++)
            if (i<=11)
                Console.WriteLine($"Nome: {Ordem[i].Nome}, Qualidade: {Ordem[i].Qualidade}, Titular");
            else
                Console.WriteLine($"Nome: {Ordem[i].Nome}, Qualidade: {Ordem[i].Qualidade}, Reserva");
    }

    public void MostrarTime (List<Time> Time)
    {
        for(int j = 0;j<2;j++)
            Console.WriteLine($"Time: {Time[j].NomeTime}\nApelido: {Time[j].ApelidoTime}\nAno De Fundação: {Time[j].Fundacao}");

    }

}

