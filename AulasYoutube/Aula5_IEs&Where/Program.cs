using System;

// ======== Percorrendo lista com Enumerator ==========

var lista = new int[] {1,2,3,4,5,6,7,8,9,10};

var item = lista.GetEnumerator();

while (item.MoveNext())
    Console.WriteLine(item.Current);

// =======================================================


// =========== Percorrendo lista com uma condição, utilizando Where ===========

var variavel = lista.Where(i => i > 5); // armazena na variavel todos os números
// que atendem a condição(se i (como se fosse o i do for) for maior que 5)

foreach (var itemLoop in variavel)
    Console.WriteLine(itemLoop);

// ============================================================================

