using System;

Random rand = new Random(DateTime.Now.Millisecond);


Retangulo retan = new Retangulo();
int count = 0;
for (int i = 0; i < 10000; i++)
    if (retan.EstaDentro(sortearPonto()))
        count+=1;
Console.WriteLine(count/10000 * 100+"%");


Triangulo tri = new Triangulo();
count = 0;
for (int j = 0; j < 10000; j++)
    if (tri.EstaDentro(sortearPonto()))
        count+=1;
Console.WriteLine(count/1000 * 100+"%");


Ponto sortearPonto()
{
    Ponto point = new Ponto();

    point.X = rand.Next(0,101);
    point.Y = rand.Next(0,101);

    return point;    
}

public struct Ponto
{
    public int X { get; set; }
    public int Y { get; set; }
}

public abstract class Figura
{
    public int Altura { get; set; }
    public int Base { get; set; }
    public abstract bool EstaDentro(Ponto p);
}

public class Retangulo : Figura
{
    public Retangulo()
    {
        this.Altura = 50;
        this.Base = 50;
    }
    public override bool EstaDentro(Ponto p)
    {
        if (p.X <this.Altura && p.Y < this.Altura)
            return true;
        else
            return false;
    }
}


public class Triangulo : Figura
{
    public Triangulo()
    {
        this.Altura = 100;
        this.Base = 100;
    }
    public override bool EstaDentro(Ponto p)
    {
        if (p.X + p.Y < 100)
            return true;
        else
            return false;
    }
}

// public class Circulo : Figura
// {
//     
//     
// }
