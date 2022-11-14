public class Jogador
{
    private int Id { get; set; }
    private string Nome { get; set; }
    private string Posicao { get; set; }
    private string Apelido { get; set; }
    private string DataNascimento { get; set; }
    private int Numero { get; set; }
    private double Qual 
    { 
        get => Qualidade;

        set
        {
            if (Qual>100)
                this.Qualidade = 100;
            else if (Qual<0)
                this.Qualidade = 0;
            else
                this.Qualidade = this.Qualidade;
        } 
    }
    private double Qualidade { get; set; }
    private int CartaoAmarelo { get; set; }
  
    public Jogador(int ID, string NOME, string POSICAO, string APELIDO, string DATANASCIMENTO, int NUMERO, double QUALIDADE, int CARTAOAMARELO)
    {
        this.Id = ID;
        this.Nome = NOME;
        this.Posicao = POSICAO;
        this.Apelido = APELIDO;
        this.DataNascimento = DATANASCIMENTO;
        this.Numero = NUMERO;
        this.Qualidade = QUALIDADE;
        this.CartaoAmarelo = CARTAOAMARELO;
        this.Qual = QUALIDADE;
    }

    public bool Condicao()
    {
        if (this.CartaoAmarelo >=3)
            return false;
        else    
            return true;
    }

    public void Mostrar()
    {
        string cond = this.Condicao() ? "Tá pra jogo" : "Fora do jogo"; // <condicao> ? caso verdadeiro : caso falso
        Console.WriteLine($"{this.Posicao}: {this.Numero} - {this.Nome} ({this.Apelido}) - {this.DataNascimento} Condição: {cond} Qualidade: {this.Qualidade}\n");
    }

    public void MostrarTudo()
    {
        string cond = this.Condicao() ? "Tá pro Game" : "Fora do jogo"; // <condicao> ? caso verdadeiro : caso falso
        Console.WriteLine($"Id: {this.Id}\nPosição: {this.Posicao}\nNúmero: {this.Numero}\nNome: {this.Nome}\nApelido: {this.Apelido}\nData de Nascimetno: {this.          DataNascimento}\nCartões: {this.CartaoAmarelo}\nCondição: {cond}\nQualidade: {this.Qualidade}\n");
    }

    public void AplicarCartao(int numero)
    {
        this.CartaoAmarelo += numero;
    }

    public void AplicarCartaoVermelho()
    {
        this.CartaoAmarelo = 3;
    }

    public void CumprirSuspensao()
    {
        this.CartaoAmarelo = 0;
    }

    public void SofrerLesao()
    {
        Random randNum = new Random();
        int valor = randNum.Next(100);
        
        if (valor<=5)
            this.Qualidade -= (this.Qualidade * 0.15);

        else if(valor<=14 && valor>5)
            this.Qualidade -= (this.Qualidade * 0.10);

        else if(valor<=29 && valor>14)
            this.Qualidade -= (this.Qualidade * 0.05);

        else if(valor<=59 && valor>29)
            this.Qualidade -= 2;
        
        else
            this.Qualidade -= 1;
    }

        public void Treino()
    {
        Random randNum = new Random();
        int valor = randNum.Next(100);
        
        if (valor<=5)
            this.Qualidade += (this.Qualidade * 0.15);

        else if(valor<=14 && valor>5)
            this.Qualidade += (this.Qualidade * 0.10);

        else if(valor<=29 && valor>14)
            this.Qualidade += (this.Qualidade * 0.05);

        else if(valor<=59 && valor>29)
            this.Qualidade += 2;
        
        else
            this.Qualidade += 1;
    }
}
