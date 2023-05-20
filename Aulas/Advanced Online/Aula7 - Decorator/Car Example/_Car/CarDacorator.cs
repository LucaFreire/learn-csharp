public class CarDecorator : ICar
{
    ICar _car;
    public CarDecorator(ICar car)
        => this._car = car;

    public virtual string Attributes()
        => this._car.Attributes();
    public virtual float Price()
        => this._car.Price();
}