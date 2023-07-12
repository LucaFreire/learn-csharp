Chefe ChefePrincipal = new Chefe();

Chefe ChefeSubordinado1 = new Chefe();
Chefe ChefeSubordinado2 = new Chefe();

Secretario Secretario = new Secretario();

Programador Programador1ChefeSubordinado1 = new Programador();
Programador Programador2ChefeSubordinado1 = new Programador();

Programador Programador1ChefeSubordinado2 = new Programador();
Programador Programador2ChefeSubordinado2 = new Programador();

Estagiario EstagiarioChefeSubordinado1 = new Estagiario();
Estagiario EstagiarioChefeSubordinado2 = new Estagiario();


ChefePrincipal.Add(Secretario);
Secretario.Add(ChefeSubordinado1);
ChefeSubordinado1.Add(Programador1ChefeSubordinado1);
ChefeSubordinado1.Add(Programador2ChefeSubordinado1);
ChefeSubordinado1.Add(EstagiarioChefeSubordinado1);

ChefePrincipal.Add(ChefeSubordinado2);
ChefeSubordinado2.Add(Programador1ChefeSubordinado2);
ChefeSubordinado2.Add(Programador2ChefeSubordinado2);
ChefeSubordinado2.Add(EstagiarioChefeSubordinado2);


// ChefePrincipal.Receber("Confidencial mensagem teste");
// ChefePrincipal.Receber("Memorando mensagem teste");
// ChefePrincipal.Receber("Importante mensagem teste");



public interface Empregado
{
    void Receber(string msg);
}
public class Chefe : Empregado
{
    List<Empregado> list = new List<Empregado>();
    IEnumerable<Empregado> Lista => list;

    public void Add(Empregado emp)
        => this.list.Add(emp);

    public void Receber(string msg)
    {
        if(msg.Contains("Confidencial"))
            return;
        
        foreach (var item in list)
            item.Receber(msg);
    }

}
public class Secretario : Empregado
{
    List<Empregado> list = new List<Empregado>();
    IEnumerable<Empregado> Lista => list;

    public void Add(Empregado emp)
        => this.list.Add(emp);

    public void Receber(string msg)
    {
        string newMsg;
        string msgToSend = msg;

        if(msg.Contains("Confidencial"))
        {
            msgToSend = msgToSend.Replace("Confidencial", "");
            newMsg = $"Confidencial: {msgToSend}";
        }

        else if(msg.Contains("Importante"))
        {
            msgToSend = msgToSend.Replace("Importante", "");
            newMsg = $"Importante: {msgToSend}";
        }

        else if(msg.Contains("Memorando"))
        {
            msgToSend = msgToSend.Replace("Memorando", "");
            newMsg = $"Memorando: {msgToSend}";
        }

        foreach (var item in list)
            item.Receber(msg);
    }
}
public class Estagiario : Empregado
{
    public void Receber(string msg)
    {
       if(!msg.Contains("Confidencial"))
            Console.WriteLine(msg);
    }
}
public class Programador : Empregado
{
    public void Receber(string msg)
        => Console.WriteLine("Mensagem Recebida");
}