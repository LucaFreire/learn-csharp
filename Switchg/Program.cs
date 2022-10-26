int i = -2;

switch (i)
{
    case < 0:
        Console.WriteLine("isso é um nan");
        goto default;
    case 1:
        Console.WriteLine("isso é um 1");
        goto default;
    case 2:
        Console.WriteLine("isso é um 2");
        goto case 1;
    case 3:
        Console.WriteLine("isso é um 3");
        break;
    
    default:
        Console.WriteLine("ai nao");
        break;
}