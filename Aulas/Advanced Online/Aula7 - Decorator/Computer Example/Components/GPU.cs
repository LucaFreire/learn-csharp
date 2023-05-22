public class GPU : ComputerDecorator
{
    public GPU(IComputer pc) : base(pc) { }

    public override string GetSpecs()
        => base.GetSpecs() + $"\n- Added GPU R$ {GetValue() - base.GetValue()}";
    public override float GetValue()
        => base.GetValue() + 200;

    public override string ToString()
        => $"{GetSpecs()}\nFinal Value: R$ {GetValue()}";
}