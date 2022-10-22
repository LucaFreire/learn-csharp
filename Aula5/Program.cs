// //Lista encadeada

// using System.Collections;

// IntList list = new IntList();
// list.Add(4);
// list.Add(2);
// list.Add(1);

// foreach(int n in list)
// {
//     Console.WriteLine(n);
// }


// public class IntList : IEnumerable
// {
//     private int[] values = new int[10];
//     private int count = 0;


//     public int this[int index]
//     {
//         get
//         {
//             if (index < 0 || index >= count)
//                 throw new IndexOutOfRangeException();
//             return values[index];
//         }
//         set
//         {
//             if (index < 0 || index >= count)
//                 throw new IndexOutOfRangeException();
//             values[index] = value;            
//         }
//     }


//     public int Count => count;

//     public void Add(int num)
//     {
//         if (count == values.Length)
//         {
//         int[] newArr = new int[2 * values.Length];
//         for (int i = 0; i < values.Length; i++)
//             newArr[i] = values[i];
//         this.values = newArr;
//         }


//         values[count] = num;
//         count++;
//     }

//     public IEnumerator GetEnumerator()
//     {
//         IntListIterator list = new IntListIterator(this);
//         return list;
//     }
// }


// public class IntListIterator : IEnumerator
// {
//     private IntList list;
//     int index = -1;

//     public IntListIterator(IntList list)
//     {
//         this.list = list;
//     }


//     public object Current => list[index];

//     public bool MoveNext()
//     {
//         index++;
//         return index < list.Count;
//     }

//     public void Reset() => index = -1;
// }



namespace Aula
{


    public class Complex
    {
        double rValue;
        double iValue;

        public Complex(double r, double i)
        {
            this.rValue = r;
            this.iValue = i;    
        } 
        
        public static Complex operator + (Complex a, Complex b)
        {
            double somaReal = a.rValue + b.rValue;
            double somaImag = a.iValue + b.iValue;

            return new Complex(somaReal, somaImag);
        }

        public override string ToString() => rValue + " + i" + iValue;
        

    }

    class Program 
    {
        static void Main(string[] args)
        {
            Complex cpx1 = new Complex(18, 20);
            Complex cpx2 = new Complex(4, 3);

            Complex soma = cpx1 + cpx2;
            Console.WriteLine(soma);
        }
    }
}