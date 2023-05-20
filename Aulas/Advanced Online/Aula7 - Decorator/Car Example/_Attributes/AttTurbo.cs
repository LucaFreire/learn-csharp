public class AttTurbo : CarDecorator
{
    public AttTurbo(ICar car ) : base(car) { }

    public override float Price()
        => base.Price() + 200;
    public override string Attributes()
        => base.Attributes() + "\n- Added Turbo";
}