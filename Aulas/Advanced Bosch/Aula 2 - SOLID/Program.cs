// Examples with Singleton
Singleton.New("Before", 10);
var now = Singleton.Current;

Singleton.New("After", 100);
var after = Singleton.Current;

after.SomethingInt = 1000;
now.SomethingStr = "TROQUEI";

after.Show();
now.Show();
