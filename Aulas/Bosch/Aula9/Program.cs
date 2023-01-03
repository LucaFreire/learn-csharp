// int[] sla = trasforme(array1,delegate(int i) 
// {
//  return i * i; 
// } ); Função Anônima



// int Dobro(int i) => i * 2;

// int Quadrado(int i) => i * i;


// int[] array1 = new int[5] { 1, 3, 7, 12, 8 };

// int[] sla = trasforme(array1, Quadrado);


// foreach (var item in sla)
//     Console.WriteLine(item);


// int[] trasforme(int[] entradaArray, Transformador <int> trans)
// {
//     for(int j = 0; j < entradaArray.Count(); j++)
//         entradaArray[j] = trans(entradaArray[j]);
    
//     return entradaArray;
// }

// public delegate T Transformador<T>(T n);


using System;
using System.Collections.Generic;
using System.IO;

void ChameNVezesExemplo()
{
    ChameNVezes(Console.WriteLine, 10);

    ChameNVezes(meuPrint, 2);

    MeuDelegate func = delegate(string s)
    {
        Console.WriteLine("Função Anonima diz:" + s);
    };

    ChameNVezes(func, 5);

    MeuDelegate func2 = s => Console.WriteLine("Lambda diz:" + s);
    ChameNVezes(func2, 3);

    ChameNVezes(s => Console.WriteLine("Lambda direto diz:" + s), 3);

    void meuPrint(string s)
    {
        Console.WriteLine("Mensagem: " + s);
    }
    void ChameNVezes(MeuDelegate f, int n)
    {
        for (int i = 0; i < n; i++)
            f("Olá Mundo");
    }  
}

var array = new int[] { 1, 4, 9, 16, 25 };
var list = new List<int>() { 1, 4, 9, 16, 25 };

var arr1 = array.Select(n => 2 * n + 1);
var arr2 = list.Select(n => n * n);
var arr3 = array.Select(n => (int)Math.Sqrt(n));

var pessoas = new List<Pessoa>()
{
    new Pessoa()
    {
        Nome = "Edjalma",
        Idade = 830,
        Sexo = "Masculino"
        
    },
    new Pessoa()
    {
        Nome = "Eu",
        Idade = 23,
        Sexo = "Masculino"
    },
    new Pessoa()
    {
        Nome = "Voces",
        Idade = 16,
        Sexo = "Feminino"
    }
};

var idades = pessoas
    .Max(p => p.Idade);



var idadesMedia = pessoas.Sum(p => p.Idade);

int[] Transforme(int[] entrada, Transformador<int> t)
{
    int[] saida = new int[entrada.Length];
    for (int i = 0; i < saida.Length; i++)
        saida[i] = t(entrada[i]);
    return saida;
}

bool condicaoAge(Pessoa p) => p.Idade < 18;

bool condicaoSexMas(Pessoa p) => p.Sexo == "Masculino";

bool condicaoSexMFem(Pessoa p) => p.Sexo == "Feminino";
 

var sla = pessoas.Max();

Console.Write(sla.Idade);


public delegate void MeuDelegate(string x);
public delegate T Transformador<T>(T n);
public delegate R Transformador2<T, R>(T n);

public class Pessoa
{
    public string Nome { get; set; }
    public int Idade { get; set; }
    public string Sexo { get; set; } 
}


public static class MyExtensionMethods
{

    public static IEnumerable<R> Select<T, R>(
        this IEnumerable<T> coll, 
        Func<T, R> func)
    {
        var it = coll.GetEnumerator();
        while (it.MoveNext())
            yield return func(it.Current);
    }


    public static IEnumerable<T> Where<T>(
        this IEnumerable<T> coll,
        Func<T, bool> condition
    )
    {
        var it = coll.GetEnumerator();
        while (it.MoveNext())
            if (condition(it.Current))
                yield return it.Current;
    }

    public static int Max<T>(this IEnumerable<T> coll, Func<T, int> func)
    {   
        int Maior = int.MinValue;
        var it = coll.GetEnumerator();

        while (it.MoveNext())
            if(func(it.Current) > Maior)
                Maior = func(it.Current);
        return Maior;
    }

    public static double Average<T>(this IEnumerable<T> coll, Func<T, double> func)
    {
        var it = coll.GetEnumerator();
        double Soma = 0;

        while (it.MoveNext())
            Soma += func(it.Current);

        return Soma/coll.Count();
    }


    public static IEnumerable<T> Skip<T>(this IEnumerable<T> coll, int N)
    {
        var it = coll.GetEnumerator();
        for (int i = 0; i < N && it.MoveNext(); i++) ;
        
        while (it.MoveNext())
            yield return it.Current;
    }

    public static IEnumerable<T> Take<T>(this IEnumerable<T> coll, int N)
    {
        var it = coll.GetEnumerator();
        for (int i = 0; i < N && it.MoveNext(); i++)
            yield return it.Current;
    }

    public static List<T> ToList<T>(this IEnumerable<T> coll)
    {
        List<T> list = new List<T>();
        
        var it = coll.GetEnumerator();
        while (it.MoveNext())
            list.Add(it.Current);
        
        return list;
    }

    public static int Count<T>(this IEnumerable<T> coll)
    {
        int count = 0;
        var it = coll.GetEnumerator();

        while (it.MoveNext())
            count++;
        
        return count;
    }

    public static T LastOrDefault<T>(this IEnumerable<T> coll)
    {
        int count = 0;
        var it = coll.GetEnumerator();
        while (it.MoveNext())
            count++;

        return count == 0 ? default(T) : it.Current;
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
        yield return item;

        foreach (var x in coll)
            yield return x;
    }

    public static T FirstOrDefault<T>(this IEnumerable<T> coll)
    {
        var it = coll.GetEnumerator();
        return it.MoveNext() ? it.Current : default(T);
    }

    public static T[] ToArray<T>(this IEnumerable<T> coll)
    {
        T[] arr = new T[coll.Count()];

        var it = coll.GetEnumerator();
        for (int i = 0; it.MoveNext(); i++)
            arr[i] = it.Current;

        return arr;
    }

    public static IEnumerable<string> Open(this string file)
    {
        var stream = new StreamReader(file);

        while (!stream.EndOfStream)
        {
            var line = stream.ReadLine();
            yield return line;
        }

        stream.Close();
    }

    public static IEnumerable<string[]> Split(this IEnumerable<string> coll)
    {
        foreach (var el in coll)
            yield return el.Split(';');
        
    }
}
