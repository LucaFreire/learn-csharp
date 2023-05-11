using System.Threading;
using System.Threading.Tasks;
using System.Collections.Concurrent;

Random rand = new Random();

Army attack = new Army(857, new int[3]);
Army defensor = new Army(500, new int[3]);

int Battle(Army defensor, Army attack)
{
    
    bool isFighting;

    do
    {
        defensor.getDataDice(rand);
        attack.getDataDice(rand);

        for (int i = 0; i < 3; i++)
        {
            attack.Soldiers -= attack.DataDice[i] > defensor.DataDice[i] ? 0 : 1;
            defensor.Soldiers -= defensor.DataDice[i] >= attack.DataDice[i] ? 0 : 1; 
        }
        
        isFighting = defensor.Soldiers <= 0 || attack.Soldiers <= 1 ? false : true;
    
    } while(isFighting);

    string win = defensor.Soldiers > attack.Soldiers ? "D" : "A";

    return win == "A" ? 1 : 0;

    // ShowStatistics(defensor, attack);'

}

void ShowStatistics(Army defensor, Army attack) 
{
    Console.WriteLine($"Qtd Defensors remain: {defensor.Soldiers}\nQtd Attack remain: {attack.Soldiers}");
    Console.WriteLine(defensor.Soldiers > attack.Soldiers ? "Defensors Win!" : "Attackers Win!");
}


double count = 0;
double N = 1000;

for (int i = 0; i < 2; i++)
{
    Battle(defensor, attack);
    ShowStatistics(defensor, attack);
}


Console.WriteLine($"Win Rate Attackers: {count / N} %");
Console.WriteLine($"Win Rate Defensors: {(N - count) / N} %");
