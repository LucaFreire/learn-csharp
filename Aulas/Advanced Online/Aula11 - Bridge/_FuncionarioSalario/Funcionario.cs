public class Funcionario
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public decimal SalarioBase { get; set; }
    public decimal Incentivo { get; set; }
    public decimal SalarioTotal { get; set; }

    public override string ToString()
        => $"Id: {this.Id}\nNome: {this.Nome}\nSalario Base: {this.SalarioBase}\nIncentivo: {this.Incentivo}\nSalario total: {this.SalarioTotal}";

}