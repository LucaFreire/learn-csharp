
using System.Diagnostics;

// // ================== Método de Lista Comum ===============
// int[] numbers = new int[] {1,2,3}; 
// foreach(var num in numbers)
//     Console.WriteLine($"Número Método lista {num}");
// // ========================================================

// // ======================= Método Enumerator ============================
// var enumerator = numbers.GetEnumerator();
// while (enumerator.MoveNext())
//     Console.WriteLine($"Número Método Enumerator: {enumerator.Current}");
// // ======================================================================

// =============================== TIPO LISTA ================================
// List<Person> getPerson() Dessa Maneira, o código executou 652 miliseconds
// {
//     List<Person> pessoa = new List<Person>();
//     for (int i = 0; i < 100; i++)
//         pessoa.Add(new Person() {ID = i, Name = $"Pessoa {i}"});
//     return pessoa;
// }
// ===========================================================================

// ============================ TIPO IEnumerable =====================================
IEnumerable<Person> getPerson() // Dessa maneira, o código executou em 62 miliseconds
{
    List<Person> pessoa = new List<Person>();
    for (int i = 0; i < 100; i++)
        yield return new Person() {ID = i, Name = $"Pessoa {i}"};
}
// ====================================================================================

var tempo = new Stopwatch();
tempo.Start();
info(41);
tempo.Stop();
Console.WriteLine(tempo.ElapsedMilliseconds);

void info(int count)
{
    var pessoa = getPerson();
    foreach (var pessoaLoop in pessoa)
        if (pessoaLoop.ID < count)
            Console.WriteLine($"Nome: {pessoaLoop.Name} e ID {pessoaLoop.ID}");
}

class Person
{   
    public int ID { get; set; }
    public string Name { get; set; }
}
