public class Colaborator
{
    string Name { get; set; }
    string EDV { get; set; }
    DateTime BirthDate { get; set; }
    bool isAdm { get; set; }

    public Colaborator(string name, string edv, DateTime birthDate, bool isAdm)
    {
        this.Name = name;
        this.EDV = edv;
        this.BirthDate = birthDate;
        this.isAdm = isAdm;
    }

    public override string ToString() =>
        $"Name: {this.Name} - EDV: {this.EDV} - BirthDate: {this.BirthDate}";
    public void AddColaborator(Colaborator colaborator)
    {
        if (!this.isAdm)
        {
            Console.WriteLine($"{this.Name}, You can't add an colaborator 'cause you're not an admin.\n");
            return;
        }
        Database.colaborators.Add(colaborator);
        Console.WriteLine($"{this.Name}, you added a new colaborator!\n");
    }
    public void ShowColaborators()
    {
        if (!this.isAdm)
        {
            Console.WriteLine($"{this.Name}, you can't view thw colaborators 'cause you're not an admin.\n");
            return;
        }
        Console.WriteLine("Colaborators: ");
        for (int i = 0; i < Database.colaborators.Count(); i++)
            Console.WriteLine($"{i+1} - {Database.colaborators[i]}");
    }
    public void PunchClock()
    {
        bool isFisrt = !Database.points.Any(z => z.EDV == this.EDV);

        if (isFisrt)
        {
            Database.points.Add(new Point(this.Name, this.EDV, new DateTime(), "In"));
            return;
        }

        var data = Database.points.Where(x => x.EDV == this.EDV).ToList();

        string Type = data.Last().Type == "In" ? "Out" : "In";

        Database.points.Add(new Point(this.Name, this.EDV, new DateTime(), Type));

        Console.WriteLine($"{this.Name}, you punched clock of {Type} at {new DateTime()}!\n");
    }
    public void ShowPoints()
    {
        if (!this.isAdm)
        {
            Console.WriteLine($"{this.Name}, you can't see the list of points 'cause you're not an admin.\n");
            return;
        }
        Console.WriteLine("List of Points: ");
        foreach (var item in Database.points)
            Console.WriteLine($"Name: {item.Name} - EDV: {item.EDV} - Horario: {item.Time} - Type: {item.Type}");
    }
}