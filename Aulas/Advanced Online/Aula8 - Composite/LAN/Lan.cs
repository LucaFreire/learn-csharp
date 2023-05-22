public class Lan : IOperationHours
{
    List<IOperationHours> lista = new List<IOperationHours>();
    public Lan(string name)
        => this.Name = name;
    public string Name { get; set; }
    public int Hours { get; set; }

    public int GetHours()
    {
        int hours = 0;
        foreach (var item in lista)
            hours += item.GetHours();
        
        Console.WriteLine($"Total Hours {Name}: {hours}\n");
        this.Hours = hours;
        return hours;
    }

    public void Add(IOperationHours op)
        => lista.Add(op);

}