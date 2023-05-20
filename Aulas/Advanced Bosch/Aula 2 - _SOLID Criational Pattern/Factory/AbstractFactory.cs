// Abstract
public abstract class AbstractProductA
{
    public float PropertyA { get; set; }
    public abstract float MethodA();
}
public abstract class AbstractProductB
{
    public float PropertyB { get; set; }
    public abstract float MethodB();
}

// Cada produto abstrato pode ter muitos produtos concretos
    // que funcionam de formas diferentes


// Concrete Product A
public class ConcreteProductA1 : AbstractProductA
{
    public override float MethodA()
        => 2 * PropertyA;
}
public class ConcreteProductA2 : AbstractProductA
{
    public override float MethodA()
        => PropertyA * PropertyA;
}

// Concrete Product B
public class ConcreteProductB1 : AbstractProductB
{
    public override float MethodB()
        => 2 * PropertyB; 
}
public class ConcreteProductB2 : AbstractProductB
{
    public override float MethodB()
        => PropertyB * PropertyB; 
}

// Uma Fábrica pode criar qualquer produto, mas voce não sabe qual
public interface IAbstractFactory
{
    AbstractProductA CreateProductA();
    AbstractProductB CreateProductB();
}

// As implementações das fábricas decidem qual os produtos concretos que voce receberá
public class ConcreteFactory1 : IAbstractFactory
{
    public AbstractProductA CreateProductA()
        => new ConcreteProductA1();
    public AbstractProductB CreateProductB()
        => new ConcreteProductB1();
}
public class ConcreteFactory2 : IAbstractFactory
{
    public AbstractProductA CreateProductA()
        => new ConcreteProductA2();
    public AbstractProductB CreateProductB()
        => new ConcreteProductB2();
}
