public class Quadrado
{
    public int Base { get; set; }
    public int Altura { get; set; }

    public Quadrado (int Base_Par, int Altura_par)
    {
        this.Base = Base_Par;
        this.Altura = Altura_par;
    }
    public void Area()
    {
        Console.WriteLine($"Área: {this.Base * this.Altura}\n");
    }
    public void MostarTudo()
    {
        Console.WriteLine($"Base: {this.Base}\nAltura: {this.Altura}\nÁrea: {this.Base * this.Altura}\n");
    }
}

