public class EUADismissalProcess : DismissalProcess
{
    public override string Title => "Demissão de Funcionário";
 
    public override void Apply(DismissalArgs args)
    {
        args.Company.Money -= 1 * args.Employe.Wage;
    }
}
 
public class EUAWagePaymentProcess : WagePaymentProcess
{
    public override string Title => "Pagamento de Salário";
 
    public override void Apply(WagePaymentArgs args)
    {
        args.Company.Money -= 1.50m * args.Employe.Wage + 500;
    }
}

public class EUAContractProcess : ContractProcess
{
    public override string Title => "Pagamento de Salário EUA";
 
    public override void Apply(ContractProcessArgs args)
    {
        args.Company.Money -= 1.50m * args.Employe.Wage + 900;
    }
}
 
public class EUAProcessFactory : IProcessFactory
{
    public DismissalProcess CreateDismissalProcess()
        => new EUADismissalProcess();
 
    public WagePaymentProcess CreateWagePaymentProcess()
        => new EUAWagePaymentProcess();

    public ContractProcess CreateProcess()
        => new EUAContractProcess();
}