public interface IOperationHours
{
    public string Name { get; set; }
    public int Hours { get; set; }
    public int GetHours();
}