class PointClass
{
    public int no1, no2;

    public PointClass(int n1, int n2)
    {
        this.no1 = n1;
        this.no2 = n2;
    }
    public void ShowValues() => Console.WriteLine($"N1: {this.no1}\nN2: {this.no2}");
    
}
