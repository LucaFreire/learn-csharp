public class Soldier : IClonable
{
    string name { get; set; }
    public int age { get; set; }

    public Soldier(string name, int age)
    {
        this.name = name;
        this.age = age;
    }
    public IClonable Clone()
        => new Soldier(this.name, this.age);

    public override string ToString()
        => $"{this.name} - {this.age}";
}