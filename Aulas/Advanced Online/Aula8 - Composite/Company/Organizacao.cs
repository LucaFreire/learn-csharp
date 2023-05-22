// representa o composite
public class Organizacao : HoraTrabalhada
{
    List<HoraTrabalhada> dep = new List<HoraTrabalhada>();

    public override void Add(HoraTrabalhada component)
        => dep.Add(component);
    public override int GetHoraTrabalhada()
    {
        Console.WriteLine(Nome);

        int HorasTT = 0;
        foreach (var item in dep)
            HorasTT += item.GetHoraTrabalhada();
        
        Console.WriteLine($"Total de {Nome}: {HorasTT} horas\n");
        return HorasTT;
    }
}