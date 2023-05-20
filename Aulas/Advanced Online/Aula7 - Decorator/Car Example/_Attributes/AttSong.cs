public class AttSong : CarDecorator
{
    public AttSong(ICar car) : base(car) { }

    public override float Price()
        => base.Price() + 50;
    public override string Attributes()
        => base.Attributes() + "\n- Added Song";
}