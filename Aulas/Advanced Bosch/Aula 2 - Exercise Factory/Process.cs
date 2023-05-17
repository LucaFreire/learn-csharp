public abstract class Process
{
    public abstract string Title { get; }
}

public abstract class DismissalProcess : Process
{
    public abstract void Apply(DismissalArgs args);
}

public abstract class WagePaymentProcess : Process
{
    public abstract void Apply(WagePaymentArgs args);
}