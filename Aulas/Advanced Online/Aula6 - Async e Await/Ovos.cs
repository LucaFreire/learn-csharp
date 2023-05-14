public class Ovos
{
    public Ovos MariaPegarOvos()
    {
        Console.WriteLine("Maria vai ao galinheiro");
        Thread.Sleep(1000);
        Console.WriteLine("Maria coleta os ovos");
        Thread.Sleep(3500);
        Console.WriteLine("Maria retorna à casa");
        Thread.Sleep(3000);

        return new Ovos();
    }
    public async Task<Ovos> MariaPegarOvosAsync() // return a Task Ovos, not the object Ovos
    {
        Console.WriteLine("Maria vai ao galinheiro");
        await Task.Delay(1000); // delay of a Task
        Console.WriteLine("Maria coleta os ovos");
        await Task.Delay(3500);
        Console.WriteLine("Maria retorna à casa");
        await Task.Delay(3000);

        return new Ovos();
    }
}