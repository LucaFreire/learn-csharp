using static System.Console;
using System;

var pt = new Point(5, 5);
var circ = ConstrutorGeometrico.GetCirculo(pt, 5);
var squa = ConstrutorGeometrico.GetRetangulo(pt, 5, 5);
var tria = ConstrutorGeometrico.GetTriangulo(pt, 5, 5);

WriteLine(circ);
WriteLine(squa);
WriteLine(tria);

public class Point
{
    public int X { get; set; }
    public int Y { get; set; }
    public Point(int x, int y)
    {
        this.X = x;
        this.Y = y;
    }
}

public abstract class FiguraGeometrica
{
    public float Area { get; set; }
    public float Perimetro { get; set; }
}

public static class ConstrutorGeometrico
{
    public static FiguraGeometrica GetCirculo(Point centro, float raio)
    {
        Circulo CirculoObj = new Circulo(raio);
        return CirculoObj;
    }
    
    public static FiguraGeometrica GetRetangulo(Point cantoSuperiorEsquerdo, float altura, float largura)
    {
        Retangulo RetanguloObj = new Retangulo(altura, largura);
        return RetanguloObj;
    }
    
    public static FiguraGeometrica GetTriangulo(Point cantoEsquerdo, float baseTriangulo, float altura)
    {
        Triangulo TrianguloObj = new Triangulo(baseTriangulo, altura);
        return TrianguloObj;
    }
}
