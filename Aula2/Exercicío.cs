using System;

int[] bin = new int[]
{0, 0, 0, 0, 0, 0, 0, 0};
int v1 = 200;
int v2 = 150;
int soma = 0;

int BintoDec(int[] bin, int soma)
{
    for (int a = 7, elevado = 0; a > -1;a--, elevado++)
    {
        if (bin[a] == 1)
        {
            soma += (int)(Math.Pow(2, elevado));
        }
    }
    Console.WriteLine("\n"+soma);
    return soma;
}

void ConvertBin(int[] bin, int v1, int v2)
{
    
    v1 = v1/16;
    v2 = v2/16;

    for (int a = 3; a > -1; a--) 
    {
        bin[a] = v1 % 2;
        v1 = v1/2;
    }
    for (int a = 7; a > 3; a--) 
    {
        bin[a] = v2 % 2;
        v2 = v2/2;
    }
    foreach(var x in bin)
    {
        Console.Write(x);
    }
    soma = BintoDec(bin, soma);
    RevertBin(soma);
}

void RevertBin(int num)
{
    byte binr1 = (byte)(num >> 4 << 4);
    byte binr2 = (byte)(num << 4);
    Console.WriteLine(binr1);
    Console.WriteLine(binr2);
}

var s = DateTime.Now;
ConvertBin(bin, v1, v2);
var e = DateTime.Now;

Console.Write("Tempo" + (e - s).TotalMilliseconds);


//2.0

//  Random rnd = new Random();

//             byte[] arr = new byte[10];

//             rnd.NextBytes(arr);

//             byte[] compactado = compress(arr);    
//             byte[] descompactado = decompress(compactado);

//             printArr(arr);
//             printArr(compactado);
//             printArr(descompactado);
        

//         static void printArr(byte[] arr)
//         {
//             foreach(var i in arr) 
//             {
//                 Console.Write(i + " ");
//             }
//             Console.Write("\n\n");

//         }

//         static byte[] decompress(byte[] arr)
//         {
//             byte[] newArr = new byte[arr.Length * 2];
        
//             for(int i = 0, j = 0; i<arr.Length; i++, j+=2)
//             {
//                 newArr[j] = (byte) ((arr[i] >> 4 << 4)); //1010 1111 - 1010 0000
//                 newArr[j + 1] = (byte)(arr[i] << 4); //1010 1111 - 1111 0000
//             }

//             return newArr;
//         }

//         static byte[] compress(byte[] arr)
//         {
//             byte[] newArr = new byte[arr.Length/2];

//             for(int i = 0, j = 0; i < arr.Length; i+=2, j++)
//                 newArr[j] = (byte) ((arr[i] >> 4 <<4) | (arr[i+1] >> 4));

//             return newArr;
//         }