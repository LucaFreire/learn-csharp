public class BoloFactory : MassasAbstractFactory
{
    public override MassaBase CriaMassa(TipoMassa type)
    {
        var typeBolo = (TipoBolo) type;
        switch (typeBolo)
        {
            case TipoBolo.Chocolate:
                return new BoloChocolate();
            case TipoBolo.Laranja:
                return new BoloLaranja();
            default:
                throw new Exception();
        }
    }
}