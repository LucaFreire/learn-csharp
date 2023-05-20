
// Example using Facade and FlyWeight
void ExampleFacade()
    => FlyWeight.Facade.Print();

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

ExampleDecorator();
