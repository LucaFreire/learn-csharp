public class ArgentinaDismissalProcess : DismissalProcess
{
    public override string Title => "Despido de Empleados";
 
    public override void Apply(DismissalArgs args)
    {
        args.Company.Money -= 3 * args.Employe.Wage;
    }
}

public class ArgentinaWagePaymentProcess : WagePaymentProcess
{
    public override string Title => "Pago de salario";
 
    public override void Apply(WagePaymentArgs args)
    {
        args.Company.Money -= 1.65m * args.Employe.Wage + 700;
    }
}

public class ArgentinaContractProcess : ContractProcess
{
    public override string Title => "Funcionario Contratado em espanhol";
 
    public override void Apply(ContractProcessArgs args)
    {
        args.Company.Money -= 1.5m * args.Employe.Wage + 500;
    }
}

public class ArgentinaProcessFactory : IProcessFactory
{
    public DismissalProcess CreateDismissalProcess()
        => new ArgentinaDismissalProcess();

    public WagePaymentProcess CreateWagePaymentProcess()
        => new ArgentinaWagePaymentProcess();
        
    public ContractProcess CreateProcess()
        => new ArgentinaContractProcess();
}