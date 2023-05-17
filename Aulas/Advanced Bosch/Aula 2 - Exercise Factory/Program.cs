// Modifique a Abstração anterior para possibilitar que Empresa tenha a operação de
// contratação personalizável a cada país, bem como pagamento de salários e demissão.
// Modifique a Abstração anterior para possibilitar que Empresa opere nos Estados Unidos da
// América.



var builder = Company.GetBuilder();

Company n = builder
    .InBrazil()
    .SetInitialCapital(1000)
    .SetName("Teste")
    .Build();

