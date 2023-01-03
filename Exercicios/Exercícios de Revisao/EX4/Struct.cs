public class Ingredientes
{
    public string NomeIngre1 { get; set; }
    public int QtdIngre1 { get; set; }
    public Ingredientes(string NomeIngre1, int QtdIngre1)
    {
        this.NomeIngre1 = NomeIngre1;
        this.QtdIngre1 = QtdIngre1;
    }

}

public struct Receitas
{
    public string NomeReceita { get; set; }
    public Ingredientes Ingre { get; set; }
    public Receitas(string Nome, Ingredientes Ingredientes)
    {
        this.NomeReceita = Nome;
        this.Ingre = Ingredientes;
    }
}
