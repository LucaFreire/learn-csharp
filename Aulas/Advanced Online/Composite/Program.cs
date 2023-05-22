Lan lanzinha1 = new Lan("LANZINHA 1");
lanzinha1.Add(new PC(5, "PC1"));
lanzinha1.Add(new PC(5, "PC2"));
lanzinha1.Add(new PC(5, "PC3"));

Lan lanzinha2 = new Lan("LANZINHA 2");
lanzinha2.Add(new PC(5, "PC4"));
lanzinha2.Add(new PC(10, "PC5"));
lanzinha2.Add(new PC(5, "PC6"));

Lan Lanzona = new Lan("LANZONA");
Lanzona.Add(lanzinha1);
Lanzona.Add(lanzinha2);

Lanzona.GetHours();
