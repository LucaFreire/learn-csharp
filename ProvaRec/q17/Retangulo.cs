public class Retangulo : FiguraGeometrica
{   
    public float Altura { get; set; }
    public float Largura { get; set; }

    public Retangulo(float Altura, float Largura)
    {
        this.Altura = (float) Altura;
        this.Largura = (float) Largura;
        this.Perimetro = (float) 2 * (Altura * Largura);
        this.Area = (float) (Altura * Largura);
    }
    public override string ToString()
    {
        return $"\nFigura: Retângulo\nAltura: {this.Altura}\nBase: {this.Largura}\nÁrea: {this.Area}\nPerímetro: {this.Perimetro}";
    }
}
