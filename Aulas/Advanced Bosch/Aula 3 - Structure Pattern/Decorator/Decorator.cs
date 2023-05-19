// Decora um objeto com uma implementação extra

public abstract class BaseClass
{
    public abstract string GetString();

    public override string ToString()
        => GetString();
}

public class ClassAA : BaseClass
{
    public override string GetString()
        => "Olá, Mundo!";
}

public class ClassBB : BaseClass
{
    public override string GetString()
        => "Olá, Mundo2!";
}

public class Decorator : BaseClass
{
    public BaseClass Wrapped { get; set; }
    public override string GetString()
        => Wrapped.GetString() + "-";
}
