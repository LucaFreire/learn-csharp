public class PC : IOperationHours
{
    public int Hours { get; set; }
    public string Name { get; set; }
 
    public PC(int hours, string name)
    {
        this.Hours = hours;
        this.Name = name;
    }
    public int GetHours()
    {
        Console.WriteLine($"{this.Name} - {this.Hours}");
        return this.Hours;
    }
}