Car myCar = new Car();

AttXenon attXenom = new AttXenon(myCar);

AttTurbo attTurbo = new AttTurbo(attXenom);

AttSong attSong = new AttSong(attTurbo);

Console.WriteLine(attSong.Attributes());
Console.WriteLine(attSong.Price());
