public abstract class Bolo : MassaBase
{
    public Bolo(string name, TipoMassa type) : base(name, type)
    { }
}
public class BoloChocolate : Bolo
{
    public BoloChocolate() : base("Bolo chocolate", TipoMassa.Bolo)
    {
        Ingredients.Add("Com cobertura");
    }
}
public class BoloLaranja : Bolo
{
    public BoloLaranja() : base("Bolo laranja", TipoMassa.Bolo)
    {
        Ingredients.Add("Com laranja");
    }
}