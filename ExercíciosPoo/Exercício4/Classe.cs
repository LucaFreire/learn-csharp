public class Jogador
{
    private int Id { get; set; }
    private string Nome { get; set; }
    private string Posicao { get; set; }
    private string Apelido { get; set; }
    private string DataNascimento { get; set; }
    private int Numero { get; set; }
    private int Qualidade { get; set; }
    private int CartaoAmarelo { get; set; }
  
    public Jogador(int ID, string NOME, string POSICAO, string APELIDO, string DATANASCIMENTO, int NUMERO, int QUALIDADE, int CARTAOAMARELO)
    {
        this.Id = ID;
        this.Nome = NOME;
        this.Posicao = POSICAO;
        this.Apelido = APELIDO;
        this.DataNascimento = DATANASCIMENTO;
        this.Numero = NUMERO;
        this.Qualidade = QUALIDADE;
        this.CartaoAmarelo = CARTAOAMARELO;
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
        string cond = this.Condicao() ? "Ta pra jogo" : "Fora do jogo"; // <condicao> ? caso verdadeiro : caso falso
        Console.WriteLine($"{this.Posicao}: {this.Numero} - {this.Nome} ({this.Apelido}) - {this.DataNascimento} Condição: {cond}\n");
    }

    public void AplicarCartao(int numero)
    {
        this.CartaoAmarelo += numero;
    }

    public void CumprirSuspensao()
    {
        this.CartaoAmarelo = 0;
    }


}
