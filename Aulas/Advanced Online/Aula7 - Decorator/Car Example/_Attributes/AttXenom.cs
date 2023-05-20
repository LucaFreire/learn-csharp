public class AttXenon : CarDecorator
{
    public AttXenon(ICar car) : base(car) { }

    public override float Price()
        => base.Price() + 100;
    public override string Attributes()
        => base.Attributes() + "\n- Added Xenom";
}