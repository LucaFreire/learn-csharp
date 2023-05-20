/*
    juntar várias classes e subsistemas complexos em uma única 
    classe que encontra uma ou mais operações.

     - The famous "faz tudo" function -
 */

using static FlyWeight; // calling to don't call every time FlyWeight.Ca.Get() ...

public class FacadeClass
{
    public void Print()
    {   
        string res = Ca.Get() + Cb.Get() + Cc.Get();
        Console.WriteLine(res);
    }
}

// Implementing FlyWeight
public static class FlyWeight
{
    private static FacadeClass facade = null;
    public static FacadeClass Facade
    {
        get
        {
            if(facade == null)
                facade = new FacadeClass();
            return facade;
        }
    }

    private static ClassA ca = null;
    public static ClassA Ca
    {
        get
        {
            if(ca == null)
                ca = new ClassA();
            return ca;
        }
    }

    private static ClassB cb = null;
    public static ClassB Cb
    {
        get
        {
            if(cb == null)
                cb = new ClassB();
            return cb;
        }
    }

    private static ClassC cc = null;
    public static ClassC Cc
    {
        get
        {
            if(cc == null)
                cc = new ClassC();
            return cc;
        }
    }
}

// Classes 
public class ClassA
{
    public string Get()
        => "Olá";
} 
public class ClassB
{
    public string Get()
        => ", ";
} 
public class ClassC
{
    public string Get()
        => "Mundo!";
}