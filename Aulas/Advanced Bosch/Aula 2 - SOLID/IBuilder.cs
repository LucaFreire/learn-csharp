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