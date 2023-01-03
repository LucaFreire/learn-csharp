public class CalculadoraMaior : Calculadora
{
    public double potencia(double num1, double num2)
    {
        return Math.Pow(num1, num2);
    }
    public double raiz(double num1)
    {
        return Math.Pow(num1, 0.5);
    }
}
