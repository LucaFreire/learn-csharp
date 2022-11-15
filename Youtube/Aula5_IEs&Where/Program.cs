using System;

// Percorrendo lista com Enumerator

var lista = new int[] {1,2,3,4,5,6,7,8,9,10};

var item = lista.GetEnumerator();

while (item.MoveNext())
    Console.WriteLine(item.Current);


