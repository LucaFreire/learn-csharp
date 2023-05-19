/* 
    FlyWeigth evita que o objeto seja instanciado várias vezes,
    lembra o Singleton, porém pode existir muitas vezes no programa
*/

public static class FlyWeigth
{
    private static MyObjectA objA = null;
    public static MyObjectA ObjA
    {
        get
        {
            if(objA == null) // if the ibject isn't created, it creates
                objA = new MyObjectA();
            return objA; // else return the object
        }
    }

    private static MyObjectB objB = null;
    public static MyObjectB ObjB
    {
        get
        {
            if(objB == null) // if the ibject isn't created, it creates
                objB = new MyObjectB();
            return objB; // else return the object
        }
    }
}

public class MyObject
{
    public virtual void Show()
        => Console.WriteLine("Testes");
}

public class MyObjectA : MyObject
{
    public override void Show()
        => Console.WriteLine("Teste1");
}

public class MyObjectB : MyObject
{
    public override void Show()
        => Console.WriteLine("Teste2");
}
