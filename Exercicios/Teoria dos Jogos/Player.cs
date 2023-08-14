public abstract class Player
{
    public virtual int Money { get; protected set; } = 3;
    public abstract bool Choose();
    public virtual void EarnMoney(int Money)
        => this.Money += Money;
    public virtual void LostMoney(int Money)
        => this.Money -= Money;
}