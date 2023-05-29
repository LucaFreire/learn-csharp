public abstract class MassaBase
{
    public TipoMassa Type { get; set; }
    public string Nome { get; set; }
    public List<string> Ingredients = new List<string>();

    public MassaBase(string name, TipoMassa type)
    {
        this.Nome = name;
        this.Type = type;
    }
}