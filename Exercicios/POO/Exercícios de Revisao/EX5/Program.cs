// 5.	Crie um programa que tenha uma função (comando def) para criptografar senhas. Deve funcionar da seguinte forma: 
// •	Cada letra deve ser transformada para seu número correspondente. Ex: A=0, B=1, etc.
// •	Cada número deve ser transformado para a letra correspondente (Números de 0 a 9). Ex: 4=E, 5=F. 
// •	Caracteres diferentes de números e letras devem ser mantidos. 
// •	Cada caractere deve ser separado por um “_”.
using System;

Console.WriteLine(Criptografar("tHIGAS123"));

string Criptografar(string msg)
{
    List<char> Str = new List<char>(){'a','b','c','d','e','f','g','h',
    'i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'};
    string txt = "";
    List<char> Num = new List<char>(){'0','1','2','3','4','5','6','7','8','9'};
    for (int i = 0; i < msg.Length; i++)
    {
        string StrL = msg[i].ToString().ToLower();
        char Strletter = char.Parse(StrL);

        if (Str.Contains(Strletter)) // Caso o caracter seja letra
        {
            int ind = Str.IndexOf(msg.ToLower()[i]);

            if(ind >= 10)
            {
                string index = ind.ToString();
                char first = index[0];
                char second = index[1];            
                txt+=first;
                txt+=second;
            }
            else
                txt+=ind;
        }

        else if (Num.Contains(Strletter)) // Caso o caracter seja número
            txt+=Str[int.Parse(Strletter.ToString())];

        else 
            txt+= Strletter; // Caso seja um caracter especial
        
        txt+='_';
    }
    return txt.Remove(txt.Length - 1);
}
