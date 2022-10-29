// using System;
// public class Pessoa{
//     public Pessoa(){}
//     public Pessoa(string nome, string senha){
//         this.Nome = nome;
//         this.Senha = senha;
//     }
//     public string Nome {get; set;}
//     public DateTime DataNascimento{get;set;}
//     public decimal saldo{get;set;}
//     public string Senha{get;set;} //propriedade
//     private long cpf; //campo 
//     private string CPF{  //Criar um campo: get set
//         get{
//             return cpf.ToString("000.000.000-00");
//         }
//         set{
//             cpf = long.Parse(value.Replace(".","").Replace("-",""));
//         }
//     }
// }


 Random rnd = new Random();

            byte[] arr = new byte[10];

            rnd.NextBytes(arr);

            byte[] compactado = compress(arr);    
            byte[] descompactado = decompress(compactado);

            printArr(arr);
            printArr(compactado);
            printArr(descompactado);
        

        static void printArr(byte[] arr)
        {
            foreach(var i in arr) 
            {
                Console.Write(i + " ");
            }
            Console.Write("\n\n");

        }

        static byte[] decompress(byte[] arr)
        {
            byte[] newArr = new byte[arr.Length * 2];
        
            for(int i = 0, j = 0; i<arr.Length; i++, j+=2)
            {
                newArr[j] = (byte) ((arr[i] >> 4 << 4)); //1010 1111 - 1010 0000
                newArr[j + 1] = (byte)(arr[i] << 4); //1010 1111 - 1111 0000
            }

            return newArr;
        }

        static byte[] compress(byte[] arr)
        {
            byte[] newArr = new byte[arr.Length/2];

            for(int i = 0, j = 0; i < arr.Length; i+=2, j++)
                newArr[j] = (byte) ((arr[i] >> 4 <<4) | (arr[i+1] >> 4));

            return newArr;
        }
