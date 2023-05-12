public class Army
{
    public int Soldiers { get; set; }
    public int[] DataDice { get; set; }
    public Army(int Soldiers)
    {
        this.Soldiers = Soldiers;
        this.DataDice = new int[3];
    }
    public void getDataDice(Random rand)
    {
        for (int i = 0; i < 3; i++)
            this.DataDice[i] = rand.Next(1, 6);
        this.DataDice = this.DataDice.OrderBy(x => x).ToArray();
    }
}