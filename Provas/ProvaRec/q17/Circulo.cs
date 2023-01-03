public class Circulo : FiguraGeometrica
{   
    public float Raio { get; set; }
    
    public Circulo(float raio)
    {
        this.Raio = (float) raio;
        this.Area = (float) (raio * 3.14);
        this.Perimetro = (float) (2 * 3.14 * raio);
    }
    public override string ToString()
    {
        return $"\nFigura: Círculo\nRaio: {this.Raio}\nÁrea: {this.Area}\nPerímetro: {this.Perimetro}";
    }
}
