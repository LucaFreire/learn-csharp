// Examples with Singleton
void SingletonExample()
{
    Singleton.New("Before", 10);
    var now = Singleton.Current;

    Singleton.New("After", 100);
    var after = Singleton.Current;

    after.SomethingInt = 1000;
    now.SomethingStr = "TROQUEI";

    after.Show();
    now.Show();
}

// Example 2 - Builder
void ExampleBuilder()
{
    ConcreteBuilderA builder = new ConcreteBuilderA();

    Product myProduct = 
        builder.AddString("Teste")
        .AddNumber(123)
        .AddString("Final")
        .Build();

    Console.WriteLine(myProduct);
}

// Example 3 - Abstract Factory
void ExampleFactory()
{
    int user = int.Parse(Console.ReadLine() ?? "0");

    IAbstractFactory factory = 
        user % 2 == 0 ? new ConcreteFactory1() : new ConcreteFactory2();

    AbstractProductA ProductA = factory.CreateProductA();
    AbstractProductB ProductB = factory.CreateProductB();
    // Dependendo do input, um objeto é criado de uma maneira totalmente diferente 
}

// Example 4 - FlyWeight
void ExampleFlyWeight()
{
    List<MyObject> lista = new List<MyObject>();

    lista.Add(FlyWeight.ObjA);
    lista.Add(FlyWeight.ObjA);
    lista.Add(FlyWeight.ObjB);
    lista.Add(FlyWeight.ObjB);

    foreach (var item in lista)
        item.Show();
}

ExampleFlyWeight();
