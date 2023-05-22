// representa o component
public abstract class HoraTrabalhada
{
    public HoraTrabalhada() { }

    public string Nome { get; set; }
    public abstract int GetHoraTrabalhada();
    public virtual void Add(HoraTrabalhada component) { }
}