// Example using Facade and FlyWeight
void ExampleFacade()
    => FlyWeight.Facade.Print();

// Example Decorator
void ExampleDecorator()
{
    var classA = new ClassAA();
    var classB = new ClassBB();

    var d1 = new Decorator();
    var d2 = new Decorator();
    var d3 = new Decorator();
    var d4 = new Decorator();

    d1.Wrapped = classA;
    d2.Wrapped = classB;
    d3.Wrapped = d2;
    d4.Wrapped = d3;

    Console.WriteLine(d1);
    Console.WriteLine(d2);
    Console.WriteLine(d3);
    Console.WriteLine(d4);
}

void ExampleComposite()
{

    var a = new ClassAAA();
    var b = new ClassBBB();

    var c1 = new Composite();
    var c2 = new Composite();

    c1.Add(a);
    c1.Add(c2);

    c2.Add(a);
    c2.Add(b);
    Console.WriteLine(c1); //Olá, MundoOlá, MundoXispita

    /*
      c1
     / \
    a   c2
        / \
        a  b
    */
}