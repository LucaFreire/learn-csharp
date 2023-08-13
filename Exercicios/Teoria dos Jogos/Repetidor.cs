public class Repetidor : Player
{
    private bool cooperate { get; set; } = true;
    public override bool Choose()
        => cooperate;

    public override void EarnMoney(int Money)
    {
        base.EarnMoney(Money);
        cooperate = true;
    }
    public override void LostMoney(int Money)
    {
        base.LostMoney(Money);
        this.cooperate = false;
    }
}