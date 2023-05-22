using static System.Console;
using System.Collections.Generic;
using System.Text;

public abstract class BaseClass1
{
    public abstract string GetString();

    public override string ToString()
        => GetString();
}

public class ClassAAA : BaseClass1
{
    public override string GetString()
        => "Olá, Mundo";
}

public class ClassBBB : BaseClass1
{
    public override string GetString()
        => "Xispita";
}

public class Composite : BaseClass1
{
    private List<BaseClass1> list = new List<BaseClass1>();
    public IEnumerable<BaseClass1> Classes => list;
    public void Add(BaseClass1 obj)
        => list.Add(obj);

    public override string GetString()
    {
        StringBuilder sb = new StringBuilder();
        foreach (var obj in list)
            sb.Append(obj);
        return sb.ToString();
    }
}