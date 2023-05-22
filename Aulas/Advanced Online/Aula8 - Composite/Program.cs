Organizacao org = new Organizacao { Nome = "Freire's Org" };

Organizacao setorTI = new Organizacao { Nome = "TI" }; 
setorTI.Add( new Funcionario { Id = 1001, Nome = "Fun1", Horas = 8});
setorTI.Add( new Funcionario { Id = 1002, Nome = "Fun2", Horas = 9});
setorTI.Add( new Funcionario { Id = 1003, Nome = "Fun3", Horas = 10});

Organizacao setorConta = new Organizacao { Nome = "Contabilidade" };
setorConta.Add( new Funcionario { Id = 1004, Nome = "Fun4", Horas = 8});
setorConta.Add( new Funcionario { Id = 1005, Nome = "Fun5", Horas = 9});
setorConta.Add( new Funcionario { Id = 1006, Nome = "Fun6", Horas = 10});

org.Add(setorTI);
org.Add(setorConta);

org.GetHoraTrabalhada();