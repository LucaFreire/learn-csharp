/* 
Talvez o padrão mais simples de todos e um dos primeiros a se aprender é o Singleton. Este padrão
consiste em criar uma classe que só pode ter uma instância no sistema inteiro. Singletons em geral são
mais flexíveis que classes puramente estáticas embora sejam baseadas nelas. 
*/

public class Singleton
{
    // Proprieties
    public string SomethingStr { get; set; }
    public int SomethingInt { get; set; }
    
    // OverLoad of constructors
    private Singleton() { }
    private Singleton(string text) => this.SomethingStr = text;
    private Singleton(string text, int num)
    {
        this.SomethingStr = text;
        this.SomethingInt = num;
    }
    
    // Current Values
    private static Singleton current = new Singleton();
    public static Singleton Current => current; // => 'Current' GET the current's values

    // Methods
    public void Show()
        => Console.WriteLine($"Str {SomethingStr} - Int {SomethingInt}");    
    
    // Methods of Creation
    public static void New()
        => current = new Singleton();
    public static void New(string txt)
        => current = new Singleton(txt);
    public static void New(string txt, int num)
        => current = new Singleton(txt, num);
}