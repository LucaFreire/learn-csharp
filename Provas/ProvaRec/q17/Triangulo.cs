public class Triangulo : FiguraGeometrica
{   
    public float Altura { get; set; }
    public float Largura { get; set; }

    public Triangulo(float Altura, float Largura)
    {
        this.Altura = (float) Altura;
        this.Largura = (float) Largura;
        this.Perimetro = (float) (Altura + Largura + Math.Sqrt(Math.Pow(Altura,2)+Math.Pow(Largura,2)));
        this.Area = (float) (Altura * Largura / 2);
    }
    public override string ToString()
    {
        return $"\nFigura: Triângulo\nAltura: {this.Altura}\nBase: {this.Largura}\nÁrea: {this.Area}\nPerímetro: {this.Perimetro}";
    }
}
