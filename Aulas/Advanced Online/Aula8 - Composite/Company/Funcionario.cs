// representa o leaf
public class Funcionario : HoraTrabalhada
{
    public int Id { get; set; }
    public int Horas { get; set; }

    public override int GetHoraTrabalhada()
    {
        Console.WriteLine($"Funcionario {Id} -- {Nome} registrou {Horas} trabalhadas");
        return Horas;
    }
}