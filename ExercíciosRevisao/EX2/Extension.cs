public static class Extension
{
    public static double Aritmetica(this IEnumerable<double> coll) => coll.Average();

    public static double Ponderada(this IEnumerable<double> coll, IEnumerable<double> ListaPond)
    {
        var itColl = coll.GetEnumerator();
        var itLista = ListaPond.GetEnumerator();
        double soma = 0; 

        while(itColl.MoveNext() && itLista.MoveNext())
            soma+= itColl.Current * itLista.Current;
        return soma;
    }

    public static double Harmonica(this IEnumerable<double> coll)
    {
        var it = coll.GetEnumerator();
        double soma = 0; 

        while(it.MoveNext())
            soma += 1 / it.Current;
        return coll.Count() / soma;
    }
}