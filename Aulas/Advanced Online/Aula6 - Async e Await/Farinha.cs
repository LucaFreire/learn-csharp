public class Farinha
{
    public Farinha JoaoPegarFarinha()
    {
        Console.WriteLine("João sai de casa");
        Thread.Sleep(3000);
        Console.WriteLine("João chega ao mercado");
        Thread.Sleep(2000);
        Console.WriteLine("João faz a compra");
        Thread.Sleep(3000);
        Console.WriteLine("João chega em casa");

        return new Farinha();
    }
    public async Task<Farinha> JoaoPegarFarinhaAsync()
    {
        Console.WriteLine("João sai de casa");
        await Task.Delay(3000);
        Console.WriteLine("João chega ao mercado");
        await Task.Delay(2000);
        Console.WriteLine("João faz a compra");
        await Task.Delay(3000);
        Console.WriteLine("João chega em casa");

        return new Farinha();
    }
}