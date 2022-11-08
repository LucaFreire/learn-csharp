public class Pais
{
    public string codigo { get; set; }
    public string nome { get; set; }
    public int populacao { get; set; }
    public int dimensao { get; set; }
    List<Pais> lista = new List<Pais>();

    public Pais(string codigo, string nome, int populacao, int dimensao)
    {
        this.codigo = codigo;
        this.nome = nome;
        this.populacao = populacao;
        this.dimensao = dimensao;
    }

    public bool Verify(Pais pais1, Pais pais2)
    {
        if (pais1.codigo == pais2.codigo)
            return true;
        else
            return false;
    }

    public bool Vizinhos(Pais pais1)
    {
        foreach (var x in this.lista)
            if (x.nome == pais1.nome)
                return true;
        return false;
    } 


    public int Densidade(Pais pais1) => pais1.populacao / pais1.dimensao;
    public void AddFronteiras(Pais pais1) => this.lista.Add(pais1);


}





