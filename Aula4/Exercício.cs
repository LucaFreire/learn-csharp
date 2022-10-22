// E, OU, NÃO, entradas

Input a = new Input();
Input b = new Input();
Input c = new Input();
AndGate and = new AndGate();
OrGate or = new OrGate();
NotGate not = new NotGate();

a.Input1 = true;
b.Input1 = false;
c.Input1 = true;

a.Connect(and);
b.Connect(and);
c.Connect(or);
and.Connect(or);
or.Connect(not);

Console.WriteLine(not.Output);

public abstract class Gates
{
    public bool Input1 {get;set;}
    public bool Input2 {get;set;}
    public bool Output {get;set;}
    public bool IsConnected {get;set;}
    public abstract void Receive (bool valor);
    public abstract void Connect(Gates target);
    public abstract void Next(Gates target);
    public abstract void Update(Gates target);
}

public class Input : Gates
{
    public Input()
    {
        this.Output = this.Input1;
    }
    public override void Connect(Gates target)
    {
        target.Receive(this.Input1);
    }
    public override void Receive(bool valor)
    {
        this.Input1 = valor;
    }
}

public class AndGate : Gates
{
    public AndGate()
    {
        this.Input1 = false;
        this.Input2 = false;
        this.Output = this.Input1 && this.Input2;
        this.IsConnected = false;
    }
    public override void Connect(Gates target)
    {
        this.Output = this.Input1 && this.Input2;
        target.Receive(this.Output);
    }
    public override void Receive(bool valor)
    {
         if (this.IsConnected == false)
        {
            this.Input1 = valor;
            this.IsConnected = true;
        }
        else
        {
            this.Input2 = valor;
            this.IsConnected = false;
        }
    }
}

public class OrGate : Gates
{
    public OrGate()
    {
        this.Input1 = false;
        this.Input2 = false;
        this.Output = this.Input1 || this.Input2;
        this.IsConnected = false;
    }
    public override void Connect(Gates target)
    {
        this.Output = this.Input1 || this.Input2;
        target.Receive(this.Output);
    }
    public override void Receive(bool valor)
    {
         if (this.IsConnected == false)
        {
            this.Input1 = valor;
            this.IsConnected = true;
        }
        else
        {
            this.Input2 = valor;
            this.IsConnected = false;
        }
    }
}

public class NotGate : Gates
{
    public NotGate()
    {
        this.Input1 = false;
        this.Input2 = false;
        this.IsConnected = false;
        this.Output = !this.Input1;
    }
    public override void Connect(Gates target)
    {
        this.Output = !this.Input1;
        target.Receive(this.Output);
    }
    public override void Receive(bool valor)
    {
        this.Input1 = valor;
        this.Output = !this.Input1;
    }
}
