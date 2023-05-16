public class Product
{
    string Message { get; set; }
    public Product(string text)
        => this.Message = text;

    public override string ToString()
        => $"Message: {this.Message}";
}