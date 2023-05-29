public abstract class Pizza : MassaBase
{
    public Pizza(string name, TipoMassa type) : base(name, type)
    { }
}
public class PizzaCalabresa : Pizza
{
    public PizzaCalabresa() : base("Pizza calabresa", TipoMassa.Pizza)
    { 
        Ingredients.Add("Special calabresa");
    }
}
public class PizzaFrango : Pizza
{
    public PizzaFrango() : base("Pizza frango", TipoMassa.Pizza)
    { 
        Ingredients.Add("Special frango");
    }
}