public class RAM : ComputerDecorator
{
    public RAM(IComputer pc) : base(pc) { }

    public override string GetSpecs()
        => base.GetSpecs() + $"\n- Added RAM R$ {GetValue() - base.GetValue()}";
    public override float GetValue()
        => base.GetValue() + 100;

    public override string ToString()
        => $"{GetSpecs()}\nFinal Value: {GetValue()}";
}