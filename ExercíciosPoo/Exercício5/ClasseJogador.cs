public class Jogador
{
    public int Id { get; set; }
    public string Nome { get; set; }
    private string Posicao { get; set; }
    private string Apelido { get; set; }
    private string DataNascimento { get; set; }
    private int Numero { get; set; }
    public double Qualidade { get; set; }
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

        if (QUALIDADE > 100)
            this.Qualidade = 100;

        else if (Qualidade < 0) 
            this.Qualidade = 0;
        
        else
            this.Qualidade = QUALIDADE;

    }
}
