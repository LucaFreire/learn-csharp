// var coll = exemplo("Teste");

// foreach (var x in coll)
//     Console.WriteLine(x);


// var it = coll.GetEnumerator();
// while(it.MoveNext());
// {
//     var x = it.Current;
//     Console.WriteLine(x);
// }
// it.Reset();

// IEnumerable<string> exemplo(string parametroLegal)
// {
//     yield return parametroLegal;
//     yield return "Passo1";
//     yield return "Passo2";
//     yield return "Passo3";
//     yield return "Passo4";
// }

// IEnumerable<string> exemplo(string parametroLegal)
// {
//     while (true)
//         yield return parametroLegal;
// }

// IEnumerable<long> Infinity() 
// {
//     for (long i =0; true; i++)
//         yield return i;
// }

// var lines = File.ReadLines("Arquivo.csv"); (Muito pesado p/ rodar)

// var stream = new StreamReader("Arquivo.csv"); //(Esse método é mais eficiente)

// while (!stream.EndOfStream)
// {
//     var line = stream.ReadLine();
//     Console.WriteLine(line);
// }
// stream.Close();


var file = "Arquivo.csv".Open().Skip(1).Take(1000);

foreach (var x in file)
    Console.WriteLine(x);

public static class MyExetenionsMethods
{
    public static IEnumerable<T> Skip<T>(this IEnumerable<T> coll, int N) // Skip funciona <T> (Qualquer tipo)
    {
        var it = coll.GetEnumerator();
        for (int i = 0; i < N && it.MoveNext(); i++);
        
        while (it.MoveNext())
            yield return it.Current;
    }

    public static IEnumerable<T> Append<T>(this IEnumerable<T> coll, T item)
    {
        var it = coll.GetEnumerator();

        while (it.MoveNext())
            yield return it.Current;

        yield return item;
    }

    public static IEnumerable<T> Prepend<T>(this IEnumerable<T> coll, T item)
    {
        var it = coll.GetEnumerator();

        yield return item;

        while (it.MoveNext())
            yield return it.Current;

    }

    public static T FirstOrDefault<T>(this IEnumerable<T> coll)
    {
        var it = coll.GetEnumerator();
        // int tam = coll.Count();
        // if (tam != 0)
        // {
        //     it.MoveNext();
        //     return it.Current;
        // }
        // else
        //     return default(T);
        return it.MoveNext() ? it.Current : default(T);
    }

    public static T[] ToArray<T>(this IEnumerable<T> coll)
    {
        T[] Array = new T[coll.Count()]; // P/ Criar um array, é necessário falar o tamanho
        var it = coll.GetEnumerator();
        int index = 0;

        while (it.MoveNext())
        {
            Array[index] = it.Current;
            index++;
        }
        return Array;
    }

    public static IEnumerable<T> LastOrDefault<T>(this IEnumerable<T> coll)
    {
        int count = 0;
        var it = coll.GetEnumerator();

        while (it.MoveNext())
            count++;        

        if (count == 0)
            yield return default(T);

        else
            yield return it.Current;
    }

    public static int Count<T>(this IEnumerable<T> coll)
    {
        int count = 0;
        var it = coll.GetEnumerator();

        while (it.MoveNext())
            count++;

        return count;
    }

    public static List<T> ToList<T>(this IEnumerable<T> coll)
    {
        List<T> list = new List<T>();

        var it = coll.GetEnumerator();

        while (it.MoveNext())
            list.Add(it.Current);

        return list;
    }

    public static IEnumerable<T> Take<T>(this IEnumerable<T> coll, int N) // Skip funciona <T> (Qualquer tipo)
    {
        var it = coll.GetEnumerator();

        for (int i = 0; i < N && it.MoveNext(); i++);
            yield return it.Current; 
    }
    
    public static IEnumerable<string[]> Split(this IEnumerable<string> coll)
    {
        foreach (var x in coll)
            yield return x.Split(";");
    }

    public static IEnumerable<string> Open(this string coll)
    {
        var stream = new StreamReader(coll);
        while (!stream.EndOfStream)
        {
            var line = stream.ReadLine() ?? "Null";
            yield return line;
        }
        stream.Close();
    }
}
