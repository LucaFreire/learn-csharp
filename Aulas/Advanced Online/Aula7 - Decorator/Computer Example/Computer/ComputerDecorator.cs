public class ComputerDecorator : IComputer
{
    IComputer _pc;
    public ComputerDecorator(IComputer pc)
        => this._pc = pc;

    public virtual float GetValue()
        => this._pc.GetValue();
    public virtual string GetSpecs()
        => this._pc.GetSpecs();
}