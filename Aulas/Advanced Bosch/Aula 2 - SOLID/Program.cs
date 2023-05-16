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

