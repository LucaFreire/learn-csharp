List<Pais> lista1 = new List<Pais>();
Pais Pais1 = new Pais("1234","Brasil", 150, 3);

Pais Pais2 = new Pais("1234","Boludos", 150, 3);

Pais1.AddFronteiras(new Pais("4321","Peru",100,2));
Pais1.AddFronteiras(new Pais("4321","Boludos",100,2));

Console.WriteLine(Pais1.Vizinhos(Pais2));



