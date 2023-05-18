public interface IProcessFactory
{
  WagePaymentProcess CreateWagePaymentProcess();
  DismissalProcess CreateDismissalProcess();
  ContractProcess CreateProcess();
}