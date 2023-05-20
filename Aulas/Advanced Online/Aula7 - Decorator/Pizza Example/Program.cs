
IPizza pizza = new Pizza();

IPizza bacon = new BaconDecorator(pizza); 

IPizza borda = new BordaDecorator(bacon);


Console.WriteLine(borda.Type());
Console.WriteLine(borda.Price());

