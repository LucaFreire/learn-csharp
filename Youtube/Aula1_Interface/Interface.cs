
public interface Veiculo
{
    void ligar();
    void desligar();
    void info();
}

public interface Combate
{
    void disparar();
}

class Carro:Veiculo,Combate // herda os 2 e TEM QUE IMPPLEMENTAR TUDO
{ 
    public bool ligado;
    private int municao;
    public string nome;

    public void ligar() => this.ligado = true;
    public void desligar() => this.ligado=false; 
    public void info()
    {
        Console.WriteLine("Nome:...{0}",this.nome);
        Console.WriteLine("Carro:..{0}",this.ligado);
        Console.WriteLine("Municao:{0}",this.municao);
    }
    public void disparar() => municao -= 10; 
    public Carro(string nome)
    {
        this.nome=nome;
        ligado = true;
        setMunicao(100);
    }
    public void setMunicao(int qtde) => this.municao=qtde;

}
