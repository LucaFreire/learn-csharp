using System;
using System.Linq.Expressions;
using System.Reflection;
using static System.Linq.Expressions.Expression;

Andre a = new Andre();
Joao j = new Joao();

// Function.Print(a);
// Function.Print(j);
// var x = j.Copyy();

Expression<Func<int, int, int>> menos = (val1, val2) => val1 - val2;

menos.Compile();

public static class Function
{
    public static void Print<T>(T f)
    {
        var type = typeof(T);
        var att = type.GetMethods();

        foreach (var item in att)
        {
            var exist = item.GetCustomAttribute<ImportantAttribute>();
            if (exist != null)
            {
                var data = type.GetProperties();
                foreach (var i in data)
                    Console.WriteLine(i);
                break;
            }
        }
    }
    public static T Copyy<T>(this T t)
        where T : new()
    {

        var type = typeof(T);
        var campos = type.GetRuntimeFields();

        T newt = new T();

        foreach (var d in campos)
            d.SetValue(newt, d.GetValue(t));

        return newt;
    }
}

public class Joao
{
    public int Age { get; set; }
    public string Name { get; set; }

    public void Method() { }
}

public class Andre
{
    public int Age { get; set; }
    public string Name { get; set; }

    [ImportantAttribute]
    public void Method() { }
}

public class ImportantAttribute : Attribute
{ }