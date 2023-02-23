void Exemplo1()
{
    List<string> lista = new List<string>() { "abc", "cde", "fgh" };

    var x = MyDelegate.formatString(lista, MyDelegate.CaixaAlta);

    foreach (var i in x)
        Console.WriteLine(i);
}

void Exemplo2()
{
    List<int> lista = new List<int>() { 1, 2, 3, 4 };

    var x = MyDelegate.formatNumber(lista, quadrado);

    // Posso chamar função por fora também, apenas tenho que certificasse dos requisítos(int se for int etc.)
    // var y = MyDelegate.formatNumber(lista, MyDelegate.doublez);  

    foreach (var item in x)
        Console.WriteLine(item);

    int quadrado(int num) => num * num;

}
Exemplo2();