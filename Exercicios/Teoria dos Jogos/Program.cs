Mundo mundo = new Mundo();

mundo.GeneratePlayers(5, 5, 0, 0);
bool isRunning = true;

while(isRunning)
    isRunning = mundo.Play();

Console.WriteLine(mundo);