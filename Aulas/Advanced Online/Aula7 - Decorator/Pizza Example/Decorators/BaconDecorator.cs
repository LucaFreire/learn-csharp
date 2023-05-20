public class BaconDecorator : PizzaDecorator
{
    public BaconDecorator(IPizza pizza) : base(pizza) { }
    
    public override string Type()
        => base.Type() + "\nCom Porção extra de Bacon";
    public override float Price()
        => base.Price() + 3.50f;
}