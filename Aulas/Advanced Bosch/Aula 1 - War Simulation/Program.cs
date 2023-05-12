using System.Threading;
using System.Threading.Tasks;
using System.Collections.Concurrent;

Random Rand = new Random();

Army Attackers = new Army(857);
Army Defensors = new Army(450);

double Count = 0;
double N = 10000;

for (int i = 0; i < N; i++)
    Count += Battle(Defensors, Attackers);

Console.WriteLine($"N: {N}\nWin Rate Attackersers: {Count / N * 100:F2} %");
Console.WriteLine($"Win Rate Defensorss: {(N - Count) / N * 100:F2} %");


int Battle(Army Defensors, Army Attackers)
{
    bool isFighting;
    int[] QtdSoldiers = new int[]{ Defensors.Soldiers, Attackers.Soldiers };

    do
    {
        Defensors.getDataDice(Rand);
        Attackers.getDataDice(Rand);

        for (int i = 0; i < 3; i++)
        {
            Attackers.Soldiers -= Attackers.DataDice[i] > Defensors.DataDice[i] ? 0 : 1;
            Defensors.Soldiers -= Defensors.DataDice[i] >= Attackers.DataDice[i] ? 0 : 1; 
        }
        
        isFighting = Defensors.Soldiers <= 0 || Attackers.Soldiers <= 1 ? false : true;
    
    } while(isFighting);

    string win = Defensors.Soldiers > Attackers.Soldiers ? "D" : "A";

    Defensors.Soldiers = QtdSoldiers[0];
    Attackers.Soldiers = QtdSoldiers[1];

    return win == "A" ? 1 : 0;
}