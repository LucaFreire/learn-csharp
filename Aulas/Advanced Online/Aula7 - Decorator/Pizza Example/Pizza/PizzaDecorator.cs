public class PizzaDecorator : IPizza
{
    IPizza _pizza;
    public PizzaDecorator(IPizza pizza)
        => this._pizza = pizza;
    public virtual float Price()
        => _pizza.Price();
    public virtual string Type()
        => _pizza.Type();
}