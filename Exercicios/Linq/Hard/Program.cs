// 1 - Days names
// Write a query that returns names of days.
// Expected input and output
// daysNames → "Sunday Monday Tuesday Wednesday Thursday Friday Saturday"
void Exer1()
{
    var query = Enum.GetValues(typeof(DayOfWeek)).Cast<DayOfWeek>();

    foreach (var item in query)
        Console.WriteLine(item);
}
Exer1();


// ----------------------------------------------------------------------
// 2 - Write a query that returns double letters sequence in format: AA AB AC ... ZX ZY ZZ
// Expected input and output
// (no input) → "AA AB AC ... AZ BA BB ... ZX ZY ZZ"

void Exer2()
{
    


}
