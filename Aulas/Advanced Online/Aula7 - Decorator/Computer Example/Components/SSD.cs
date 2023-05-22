public class SSD : ComputerDecorator
{
    public SSD(IComputer pc) : base(pc) { }

    public override string GetSpecs()
        => base.GetSpecs() + $"\n- Added SSD R$ {GetValue() - base.GetValue()}";
    public override float GetValue()
        => base.GetValue() + 150;

    public override string ToString()
        => $"{GetSpecs()}\nFinal Value: R${GetValue()}";

}