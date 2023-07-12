using System.Reflection;

Console.WriteLine("Mensagem antes do clear");

Clear clear = new Clear();
Console.Write("Digite Algo: ");
string user = Console.ReadLine() ?? "";

var assembly = Assembly.GetExecutingAssembly();

foreach (var item in assembly.GetTypes())
{
    var att = item.GetCustomAttribute<Command>();

    if(att is not null)
    {
        if(user.ToLower() != item.Name.ToLower())
            break;

        var method = item.GetMethod("Run");
        method.Invoke(clear, new object[] { });   
    }
}

[Command]
public class Clear
{
    public void Run()
        => Console.Clear();
}

public class Command : Attribute { }