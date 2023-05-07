public struct Point
{
    public string Name { get; private set; }
    public string EDV { get; private set; }
    public DateTime Time { get; private set; } 
    public string Type { get; private set; }

    public Point(string name, string edv, DateTime time, string type)
    {
        this.Name = name;
        this.EDV = edv;
        this.Time = time;
        this.Type = type;
    }
}