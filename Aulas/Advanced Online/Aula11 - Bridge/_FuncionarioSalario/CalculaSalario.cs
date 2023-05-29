public class CalculaSalario : AbstractionGeraArquivo
{
    public CalculaSalario(IGerarArquivo gera) : base(gera)
    { }

    public void ProcessoSalarioFuncionario(Funcionario func)
    {
        func.SalarioTotal = func.SalarioBase + func.Incentivo;
        Console.WriteLine($"{func.Nome} - Salario total: {func.SalarioTotal}");
        geraArquivo.GravaArquivo(func);
    }
}