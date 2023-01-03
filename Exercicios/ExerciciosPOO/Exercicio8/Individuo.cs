public class Individuo
{
    public string Cpf { get; set; }
    
    public List<DespesaMes> lista { get ; set;} 

    public Individuo(string cpf)
    {
        this.Cpf = cpf;
        this.lista = new List<DespesaMes>();
    }

    public string getCpf()
    {
        return Cpf;
    }
    public DespesaMes TaxaMes(int mes)
    {
        float Sum = 0f;
        foreach (DespesaMes x in this.lista)
            if (x.getMes() == mes)
                Sum+=x.getValor();
            
        Console.WriteLine(Sum);
        return new DespesaMes(mes,Sum);
    }

    public void AddInfo(DespesaMes info)
    {
        this.lista.Add(info);
    }
}
