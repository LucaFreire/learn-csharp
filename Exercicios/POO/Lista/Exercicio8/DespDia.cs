public class DespesaDia : DespesaMes
{
    private int dia { get; set; }

    public DespesaDia(int dia, int mes, float valor) : base(mes,valor)
    {
        this.dia = dia;
    }
    public int getDia()
    {
        return dia;
    }
}
