/*
O Builder é um padrão de projeto que facilita criação de objetos complexos e de forma parcelada. Ao invés
de usarmos construtores gigantes e confusos podemos usar um Builder para fazer uma construção parcial,
e melhor, podemos passar o Builder para outras classes que podem fazer passos da construção para nós.
*/

public interface IBuilder
{
    IBuilder AddNumber(int num);
    IBuilder AddString(string text);
    Product Build();
}

public class ConcreteBuilderA : IBuilder
{
    private string message = "";
    public IBuilder AddNumber(int num)
    {
        message += num.ToString();
        return this;
    }
    public IBuilder AddString(string text)
    {
        message += text.ToString();
        return this;
    }
    public Product Build()
        => new Product(message);
}