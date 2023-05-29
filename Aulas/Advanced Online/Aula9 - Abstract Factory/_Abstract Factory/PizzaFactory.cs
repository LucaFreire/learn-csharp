public class PizzaFactory : MassasAbstractFactory
{
    public override MassaBase CriaMassa(TipoMassa type)
    {
        var typePizza = (TipoPizza) type;
        switch (typePizza)
        {
            case TipoPizza.Frango:
                return new PizzaFrango();
            case TipoPizza.Calabresa:
                return new PizzaCalabresa();
            default:
                throw new Exception();
        }
    }
}