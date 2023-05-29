
var BoloFactory = MassasAbstractFactory.CriaFabricaMassas(TipoMassa.Bolo);

var x = BoloFactory.CriaMassa((TipoMassa) TipoPizza.Calabresa);

System.Console.WriteLine(x.Nome);
