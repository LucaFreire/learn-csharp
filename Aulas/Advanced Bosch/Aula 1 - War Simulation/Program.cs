using System.Threading;
using System.Threading.Tasks;
using System.Collections.Concurrent;

Random Rand = new Random();
int N = 10000;

Army Attackers = new Army(1000);
Army Defensors = new Army(582);

WithoutThred(N);
WithThread(N);
WithThread2(N);


void WithThread(int N)
{
    Console.WriteLine("\n-- WithThread --");
    List<int> count = new List<int>();
    var start = DateTime.Now;

    Parallel.For(0, N, i =>
    {    
        count.Add(Battle(Defensors, Attackers));
    });

    var end = DateTime.Now;
    Console.WriteLine($"N: {N}\nTime executed: {end - start}");
    Console.WriteLine($"Win Rate Attackersers: {(double) (count.Where(x => x == 1).Count()) / N * 100:F2} %");
    Console.WriteLine($"Win Rate Defensorss: {(double) (count.Where(x => x == 0).Count()) / N * 100:F2} %");
}

void WithThread2(int N)
{
    Console.WriteLine("\n-- WithThread2 --");
    List<int> count = new List<int>();
    var start = DateTime.Now;

    for (int i = 0; i < N; i++)
        count.Add(Battle2(Defensors, Attackers));

    var end = DateTime.Now;
    Console.WriteLine($"N: {N}\nTime executed: {end - start}");
    Console.WriteLine($"Win Rate Attackersers: {(double) (count.Where(x => x == 1).Count()) / N * 100:F2} %");
    Console.WriteLine($"Win Rate Defensorss: {(double) (count.Where(x => x == 0).Count()) / N * 100:F2} %");
}

void WithoutThred(int N)
{
    Console.WriteLine("\n-- WithoutThread --");
    List<int> count = new List<int>();
    var start = DateTime.Now;

    for (int i = 0; i < N; i++)
        count.Add(Battle(Defensors, Attackers));

    var end = DateTime.Now;
    Console.WriteLine($"N: {N}\nTime executed: {end - start}");
    Console.WriteLine($"Win Rate Attackersers: {(double) (count.Where(x => x == 1).Count()) / N * 100:F2} %");
    Console.WriteLine($"Win Rate Defensorss: {(double) (count.Where(x => x == 0).Count()) / N * 100:F2} %");
}



int Battle(Army Defensors, Army Attackers)
{
    bool isFighting;
    int[] QtdSoldiers = new int[]{ Defensors.Soldiers, Attackers.Soldiers, Defensors.Soldiers, Attackers.Soldiers };

    do
    {
        // Defensors.getDataDice(Rand);
        // Attackers.getDataDice(Rand);

        int[] vetDef = new int[3];
        int[] vetAtt = new int[3];

        for (int i = 0; i < 3; i++)
        {
            vetDef[i] = Roll();
            vetAtt[i] = Roll();
        }

        vetAtt = vetAtt.OrderBy(x => x).ToArray();
        vetDef = vetDef.OrderBy(x => x).ToArray();

        for (int i = 0; i < 3; i++)
        {
            QtdSoldiers[3] -= vetAtt[i] > vetDef[i] ? 0 : 1;
            QtdSoldiers[2] -= vetDef[i] >= vetAtt[i] ? 0 : 1; 
        }
        
        isFighting = QtdSoldiers[2] <= 0 || QtdSoldiers[3] <= 1 ? false : true;
    
    } while(isFighting);

    string win = QtdSoldiers[2] > QtdSoldiers[3] ? "D" : "A";

    // Defensors.Soldiers = QtdSoldiers[0];
    // Attackers.Soldiers = QtdSoldiers[1];

    return win == "A" ? 1 : 0;
}

int Battle2(Army Defensors, Army Attackers)
{
    bool isFighting;
    int[] QtdSoldiers = new int[]{ Defensors.Soldiers, Attackers.Soldiers, Defensors.Soldiers, Attackers.Soldiers };

    do
    {

        int[] vetDef = new int[3];
        int[] vetAtt = new int[3];

        for (int i = 0; i < 3; i++)
        {
            vetDef[i] = Roll();
            vetAtt[i] = Roll();
        }

        vetAtt = vetAtt.OrderBy(x => x).ToArray();
        vetDef = vetDef.OrderBy(x => x).ToArray();

        Parallel.For(0, 3, i => {
            QtdSoldiers[3] -= vetAtt[i] > vetDef[i] ? 0 : 1;
            QtdSoldiers[2] -= vetDef[i] >= vetAtt[i] ? 0 : 1; 
        });
        
        isFighting = QtdSoldiers[2] <= 0 || QtdSoldiers[3] <= 1 ? false : true;
    
    } while(isFighting);

    string win = QtdSoldiers[2] > QtdSoldiers[3] ? "D" : "A";

    return win == "A" ? 1 : 0;
}

int Roll() => Rand.Next(1,7);