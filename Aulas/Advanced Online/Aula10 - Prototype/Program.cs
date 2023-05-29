Soldier MainSoldier = new Soldier("Lucas", 18);

var MyClone = MainSoldier.Clone();
Console.WriteLine($"Soldier: {MainSoldier}");
Console.WriteLine($"Clone: {MyClone}");
MainSoldier.age = 20;
Console.WriteLine($"\nSoldier after update: {MainSoldier}");
Console.WriteLine($"Clone after soldier's update: {MyClone}");