public abstract class MassasAbstractFactory
{
    public abstract MassaBase CriaMassa(TipoMassa type);
    public static MassasAbstractFactory CriaFabricaMassas(TipoMassa type)
    {
        switch (type)
        {
            case TipoMassa.Pizza:
                return new PizzaFactory();
            case TipoMassa.Bolo:
                return new BoloFactory();                
            default:
                throw new Exception();
        }
    }
}