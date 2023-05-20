public class BordaDecorator : PizzaDecorator
{
    public BordaDecorator(IPizza pizza) : base(pizza) { }

    public override string Type()
        => base.Type() + "\nCom borda recheada";
    public override float Price()
        => base.Price() + 5.00f;
}