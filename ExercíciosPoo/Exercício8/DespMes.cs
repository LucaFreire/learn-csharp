public class DespesaMes
{
    public int mes { get; set; } // Mês da Despesa
    private float valor { get; set; } // Valor da Despesa

    public DespesaMes(int mes, float valor)
    {
        this.mes = mes;
        this.valor = valor;
    }
    public int getMes()
    {
        return mes;
    }
    public float getValor()
    {
        return valor;
    }
}
