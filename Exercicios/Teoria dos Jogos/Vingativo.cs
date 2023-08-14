public class Vingativo : Player
{
    private bool cooperate { get; set; } = true;

    public override bool Choose()
        => cooperate;

    public override void LostMoney(int Money)
    {
        base.LostMoney(Money);
        cooperate = false;
    }

}