public class Computer : IComputer
{
    public Computer() { }

    public string GetSpecs()
        => $"Pattern Computer R$ {GetValue()}";
    public float GetValue()
        => 1000;    
}