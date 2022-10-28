// // Programa da Árvore
// // Implementar estrutura de árvore binária


// // Classe chamado Arvore com variaveis "Esquerda" e "Direita"
// // Filho da Esquerda <= Mãe
// // Filho da Direita >= Mãe
// // Conter .Add(int i), bool .Contains(int i)

// BinaryTree<string> bt = new BinaryTree<string>();
// bt.Add("20f");
// bt.Add("30f");
// bt.Add("19f");
// bt.Add("25f");

// Console.WriteLine(bt.Contains("20f"));

// public class BinaryTree<T>
//     where T : IComparable<T>
// {
//     public T? Value { get; set; }
//     public BinaryTree<T>? Left { get; set; }  = null;
//     public BinaryTree<T>? Right { get; set; } = null;

//     public void Add(T i)
//     {
//         Console.WriteLine("Teste");
//         if ((this.Value.CompareTo(default(T)) == 0) || (this.Value == null))
//         {
//             this.Value = i;
//         }
//         else if (i.CompareTo(this.Value) < 0)
//         {
//             if (Left == null)
//                 Left = new BinaryTree<T>();
//             Left.Add(i);
//         }
//         else
//         {  
//             if (Right == null)
//                 Right = new BinaryTree<T>();
//             Right.Add(i);
//         }
//     }

//     public bool Contains(T value)
//     {
//         if (value.CompareTo(this.Value) == 0)
//             return true;
//         if (value.CompareTo(this.Value) > 0)
//             return Right?.Contains(value) ?? false;
//         return Left?.Contains(value) ?? false;
//     }
// }


ArvoreBinaria bt = new ArvoreBinaria();

bt.Add(20);
bt.Add(13);
bt.Add(31);
bt.Add(44);
bt.Add(23);
bt.Add(2);
bt.Add(22);
Console.WriteLine(bt.Contains(10));

public class ArvoreBinaria
{
    public int? Value { get; set; }=null;
    public ArvoreBinaria? Esquerda { get; set; } = null;
    public ArvoreBinaria? Direita { get; set; } = null;

    public void Add(int value)
    {
        if (this.Value == null){
            this.Value = value;
            this.Esquerda = new ArvoreBinaria();
            this.Direita = new ArvoreBinaria();
        }

        else if (this.Value <= value)
            this.Esquerda.Add(value);

        else
            this.Direita.Add(value);
    }

    public bool Contains(int value)
    {   
        // Entra um valor e verifica se ele existe na árvore e retorna o resultado ( True / False)
        if (value == this.Value)
            return true;
        
        else if (value < this.Value)
            return this.Esquerda.Contains(value);
        
        else 
            return this.Direita.Contains(value);

    }
}
