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
    var chars = new char[] { ')', '!', '@', '#', '$', '%', '^', '&', '*', '(' };

    var query = string.Join("", code.Select(c => Array.IndexOf(chars, c))); 
        // this way don't need the replace method

    Console.WriteLine(query); 
}
Exer2("())(");


