public static class MyDelegate
{
    public static string CaixaAlta(string s) => s.ToUpper(); 


    public static List<string> formatString(List<string> strLista, Func<string, string> MyyDelegate)
    {
        var lista = new List<string>();

        foreach(var i in strLista)
            lista.Add(MyyDelegate(i));

        return lista;

    }

    public static List<int> formatNumber(List<int> strLista, Functions MyyDelegate)
    {
        var lista = new List<int>();

        foreach(var i in strLista)
            lista.Add(MyyDelegate(i));

        return lista;

    }

    public static int doublez(int num) => num * 2;

    public delegate int Functions(int num);

}

