// 1 - Shuffle an array
// Write a query that shuffles sorted array.
// Expected input and output
// [1, 2, 3, 4, 5, 6, 7, 8, 9, 10] → [4, 9, 3, 5, 2, 10, 1, 6, 8, 7]
// [38, 24, 8, 0, -1, -17, -33, -100] → [0, -100, -17, 38, 8, -1, 24, -33,]

void Exer1(List<int> list)
{

    var rand = new Random();
    var query = list.OrderBy(x => rand.Next());

    foreach (var item in query)    
        Console.Write(item + " ");
}
List<int> ex1 = new List<int>(){1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
// Exer1(ex1);


// ----------------------------------------------------------------------------------
// 2 - Decrypt number
// Given a non-empty string consisting only of special chars (!, @, # etc.), return a number
// (as a string) where each digit corresponds to given special char on the keyboard ( 1→ !, 2 → @, 3 → # etc.).
// Expected input and output
// "())(" → "9009"
// "*$(#&" → "84937"
// "!!!!!!!!!!" → "1111111111"

void Exer2(string code)
{

    var chars = new char[] { ')', '!', '@', '#', '$', '%', '¨', '&', '*', '(' };

    var query = string.Join("", code.Select(c => Array.IndexOf(chars, c))); 
        // this way you don't need the replace method
    Console.WriteLine(query); 
}
// Exer2("())(");


// ----------------------------------------------------------------------------------
// 3 - Most frequent character
// Write a query that returns most frequent character in string. Assume that there is only one such character.
// Expected input and output
// "panda"  → 'a'
// "n093nfv034nie9"→ 'n'

void Exer3(string code)
{

    var query = string.Join("", code.GroupBy(x => x)
    .OrderByDescending( x => x.Count())
    .First().Key);
    
    Console.WriteLine(query); 
}
// Exer3("n093nfv034nie9");


// ----------------------------------------------------------------------------------
// 4 - Unique values
// Given a non-empty list of strings, return a list that contains only unique (non-duplicate) strings.
// Expected input and output
// ["abc", "xyz", "klm", "xyz", "abc", "abc", "rst"] → ["klm", "rst"]

void Exer4(List<string> list)
{

    var query = list.GroupBy(x => x)
    .Where(x => x.Count() == 1)
    .Select( x => x.Key);
    
    foreach (var item in query)
        Console.WriteLine(item + " "); 
}
List<string> ex4 = new List<string>(){"abc", "xyz", "klm", "xyz", "abc", "abc", "rst"};
// Exer4(ex4); 


// ----------------------------------------------------------------------------------
// 5 - Uppercase only
// Write a query that returns only uppercase words from string.
// Expected input and output
// "DDD example CQRS Event Sourcing" → DDD, CQRS

void Exer5(string word)
{

    var query = word.Split(" ").Where(x => x == x.ToUpper());
    // both do the same
    var query2 = word.Split(" ").Where(x => string.Equals(x, x.ToUpper()));

    foreach (var item in query)
        Console.Write(item+"");
}
// Exer5("DDD example CQRS Event Sourcing");


// ----------------------------------------------------------------------------------
// 6 - Arrays dot product
// Write a query that returns dot product of two arrays.
// Expected input and output
// [1, 2, 3], [4, 5, 6] → 32
// [7, -9, 3, -5], [9, 1, 0, -4] → 74

void Exer6(List<double> array1, List<double> array2)
{
    // Zip's method is like an uniun between 2 things
    var query = array1.Zip(array2, (x,y) => x * y).Sum();
        // x = array1's element  --  y = array2's element
    
    Console.WriteLine(query);
}
List<double> array1 = new List<double>(){1, 2, 3};
List<double> array2 = new List<double>(){4, 5, 6};
// Exer6(array1,array2);


// ----------------------------------------------------------------------------------
// 7 - Frequency of letters
// Write a query that returns letters and their frequencies in the string.
// Expected input and output
// "gamma" → "Letter g occurs 1 time(s), Letter a occurs 2 time(s), Letter m occurs 2 time(s)"

void Exer7(string word)
{
    var query = word.GroupBy(x => x)
    .Select(x => new {
        qtd = x.Count(),
        letter = x.Key
    });

    foreach (var item in query)
        Console.WriteLine($"letter: {item.letter} -- qtd {item.qtd}");
    
}
Exer7("gamma");
