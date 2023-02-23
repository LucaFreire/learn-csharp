// A classe é do tipo genérico
public class Stack<T>
{
    int Top = -1; // Index
    T[] lista = new T[12]; // Index
    // public Stack(int size) => this.lista = new T[size];

    // O método é do tipo genérico, aceita todos os tipos de valores(int, float, etc)
    public void Push(T item)
    {
        Top++;
        lista[Top] = item;
    }
    public void Pop() // Não apaga o valor, apenas volta um Top(index) (o que o computador realmente faz)
    {
        if(Top < 0)
            return;
        Top--;
    }
    public void RealPop() // Apaga o último valor (substitui por um valor genérico: se int = 0, se string = "" , etc.)
    {
        if(Top < 0)
            return;
        lista[Top] = default(T);
        Top--;
    }
    public bool isEmpty() => Top > 0 ? false : true;
    public int Size() => Top + 1;
    public void Clear() => Top = 0; // Mesma ideia do Pop, porém volta tudo
    public void RealClear() // Mesma ideia do RealPop (com a lista inteira ao invés de apenas o último valor)
    {
        for (int i = 0; i < lista.Length; i++)
            lista[i] =  default(T);
        Top = -1;
    }

    public override string ToString()
    {
        string s = "";
        for (int i = Top; i >= 0; i--)
            s += $"{i} - [{lista[i]}]\n";
        return s;
    }
}