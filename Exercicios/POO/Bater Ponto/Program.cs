Colaborator Queila = new Colaborator("Queila", "1234567", new DateTime(2000,01,04), true);
Colaborator Freire = new Colaborator("Freire", "2234567", new DateTime(2004,11,08), false);

Queila.AddColaborator(Freire);
Queila.AddColaborator(Queila);
Queila.ShowColaborators();

Freire.ShowColaborators();
Freire.AddColaborator(Queila);

Freire.PunchClock();
Freire.PunchClock();

Freire.ShowPoints();
Queila.ShowPoints();
