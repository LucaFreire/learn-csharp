// https://csharpexercises.com/linq/exercise/numbers-from-range

// 1 - Numbers from range
// Given an array of integers, write a query that returns list of numbers greater than 30 and less than 100.
// Expected input and output
// [67, 92, 153, 15] → 67, 92

void Exer1(List<int> list)
{
    var query = list.Where(x => x > 30 && x < 100);

    foreach (var item in query)
        Console.WriteLine(item);
}

List<int> ex1 = new List<int>(){67, 92, 153, 15};
// Exer1(ex1);

// ------------------------------------------------------------------------------------------------------------

// 2 - Minimum length
// Write a query that returns words at least 5 characters long and make them uppercase.
// Expected input and output
// "computer", "usb" → "COMPUTER"

void Exer2(List<string> list)
{
    var query = list.Where(x => x.Length > 5)
    .Select(x => x.ToUpper());

    foreach (var item in query)
        Console.WriteLine(item);
}

List<string> ex2 = new List<string>(){"computer","usb"};
// Exer2(ex2);

// ------------------------------------------------------------------------------------------------------------

// 3 - Select words
// Write a query that returns words starting with letter 'a' and ending with letter 'm'.
// Expected input and output
// "mum", "amsterdam", "bloom" → "amsterdam"

void Exer3(List<string> list)
{
    var query = list.Where(x => x[0] == 'a' && x[x.Length-1] == 'm');
    // both do the same
    var query2 = list.Where(x => x.StartsWith('a') && x.EndsWith('m'));

    foreach (var item in query)
        Console.WriteLine(item);
}

List<string> ex3 = new List<string>(){"mum", "amsterdam", "bloom"};
// Exer3(ex3);

// ------------------------------------------------------------------------------------------------------------

// 4 - Top 5 numbers
// Write a query that returns top 5 numbers from the list of integers in descending order.
// Expected input and output
// [78, -9, 0, 23, 54,  21, 7, 86]  → 86 78 54 23 21

void Exer4(List<int> list)
{
    var query = list
    .OrderByDescending(x => x)
    .Take(5);

    foreach (var item in query)
        Console.Write(item + " ");
}

List<int> ex4 = new List<int>(){78, -9, 0, 23, 54,  21, 7, 86};
Exer4(ex4);

// ------------------------------------------------------------------------------------------------------------

// 5 - Square greater than 20
// Write a query that returns list of numbers and their squares only if square is greater than 20
// Expected input and output
// [7, 2, 30] → 7 - 49, 30 - 900

void Exer5(List<int> list)
{
    var query = list.Where(x => x * x > 20);

    foreach (var item in query)
        Console.WriteLine($"{item} - {item*item}");
}

List<int> ex5 = new List<int>(){7, 2, 30};
// Exer5(ex5);

// ------------------------------------------------------------------------------------------------------------

// 6 - Replace substring
// Write a query that replaces 'ea' substring with astersik (*) in given list of words.
// Expected input and output
// "learn", "current", "deal" →  "l*rn", "current", "d*l"

void Exer6(List<string> list)
{
    var query = list.Select(x => x.Replace("ea","*"));

    foreach (var item in query)
        Console.WriteLine(item);
}

List<string> ex6 = new List<string>(){"learn", "current", "deal"};
// Exer6(ex6);

// ------------------------------------------------------------------------------------------------------------

// 7 - Last word containing letter
// Given a non-empty list of words, sort it alphabetically and return a word that contains letter 'e'.
// Expected input and output
// ["plane", "ferry", "car", "bike"]→ "plane"

void Exer7(List<string> list)
{
    var query = list.OrderBy(x => x)
    .LastOrDefault(x => x.Contains("e"));

    Console.WriteLine(query);
}

List<string> ex7 = new List<string>(){"plane", "ferry", "car", "bike"};
// Exer7(ex7);

