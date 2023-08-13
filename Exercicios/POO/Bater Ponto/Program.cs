Colaborator Admin = new Colaborator("Admin", "1234567", new DateTime(2000,01,04), true);
Colaborator Freire = new Colaborator("Freire", "2234567", new DateTime(2004,11,08), false);

Admin.AddColaborator(Freire);
Admin.AddColaborator(Admin);
Admin.ShowColaborators();

Freire.ShowColaborators();
Freire.AddColaborator(Admin);

Freire.PunchClock();
Freire.PunchClock();

Freire.ShowPoints();
Admin.ShowPoints();
