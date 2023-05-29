Funcionario funcionario = new Funcionario()
{
    Id = 1,
    Nome = "Lucas",
    SalarioBase = 100,
    Incentivo = 50
};

// Gera um Arquivo Xml
CalculaSalario Calculadora = new CalculaSalario(new GeraXml());
Calculadora.ProcessoSalarioFuncionario(funcionario);

// Gera um arquivo Json
funcionario.Incentivo = 70;
Calculadora = new CalculaSalario(new GeraJson());
Calculadora.ProcessoSalarioFuncionario(funcionario);

// Gera um Arquivo Txt
funcionario.Incentivo = 100;
Calculadora = new CalculaSalario(new GeraTxt());
Calculadora.ProcessoSalarioFuncionario(funcionario);