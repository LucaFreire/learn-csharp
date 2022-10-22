
// Pessoa pessoa = new Pessoa("Edjalma", "senha");
// Pessoa pessoa2 = pessoa;
// pessoa2.Saldo = 80;
// Console.WriteLine(pessoa.Saldo);
// DateTime date = new DateTime(2004, 2, 23);
// DateTime date2 = date;
// date2 = date2.AddDays(1);
// Console.WriteLine(date);
// public class Pessoa
// {
//     public Pessoa(string nome, string senha)
//     {
//         this.Nome = nome;
//         this.Senha = senha;
//         //class faz com que seja usado como ponteiro, com o struct ele salva o valor na variável (mas deve declarar tudo na Pessoa)
//     }
//     public string Nome { get; set; }
//     public decimal Saldo { get; set; }
//     private DateTime dataNascimento { get; set; }
//     // public DateTime getDataNascimento()
//     // {
//     //     return dataNascimento;
//     // }
//     // public void setDataNascimento(DateTime value)
//     // {
//     //     dataNascimento = value;
//     // }
//     public string Senha {get;set;}

//     // public string senha;
//     // private string criptografar (String s)
//     // {
//     //     return s + "oi kkk";
//     // }
//     // public string getSenha()
//     // {
//     //     return senha;
//     // }
//     // public void setSenha(string value)
//     // {
//     //     senha = criptografar(value);
//     // }
//     private long cpf;
//     public string CPF{
//         get
//         {
//             return cpf.ToString("000.000.000-00");
//         }
//         set
//         {
//             cpf = long.Parse(
//             value.Replace(".","")
//                 .Replace("-",""));
//         }
//     }
//     // private long cpf;
//     // public string getCPF()
//     // {
//     //     return cpf.ToString("000.000.000-00");
//     // }
//     // public void setCPF(string value)
//     // {
//     //     cpf = long.Parse(
//     //         value.Replace(".","")
//     //             .Replace("-","")
//     //     );
//     // }
// }
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
Set empty = new EmptySet();
Set empty2 = new EmptySet();
Set empty3 = new EmptySet();
Set empty4 = new EmptySet();

PairSet pair = new PairSet();
pair.A = empty;
pair.B = empty2;

PairSet pair2 = new PairSet();
pair2.A = empty3;
pair2.B = empty4;

Set set = pair.Union(pair2);
Console.WriteLine(set.IsIn(empty));
Console.WriteLine(pair.Equals(pair2));

public abstract class Set
{
    public abstract bool IsIn(Set set);
    public virtual Set Union(Set set)
    {
        UnionSet unionSet = new UnionSet();
        unionSet.A = this;
        unionSet.B = set;
        return unionSet;
    }
    public virtual Set Intersect(Set set)
    {
        IntersectionSet unionSet = new IntersectionSet();
        unionSet.A = this;
        unionSet.B = set;
        return unionSet;
    }
}

public class EmptySet : Set
{
    public override bool IsIn(Set set)
    {
        return false;
    }
    public override bool Equals(object obj)
    {
        return obj is EmptySet;
    }

    public override Set Union(Set set)
    {
        throw new NotImplementedException();
    }
}

public class PairSet : Set
{
    public Set A { get; set; }
    public Set B { get; set; }

    public override bool IsIn(Set set)
    {
        return A.Equals(set) || B.Equals(set);
    }

    public override bool Equals(object obj)
    {
        if (obj is PairSet pair)
        {
            return (pair.A.Equals(this.A) && pair.B.Equals(this.B))
                || (pair.A.Equals(this.B) && pair.B.Equals(this.A))
                || (pair.A.Equals(pair.B) && (pair.A.Equals(this.A) || pair.A.Equals(this.B)));
        }
        return false;
    }

    public override Set Union(Set set)
    {
        return set;
    }

    public override Set Intersect(Set set)
    {
        return this;
    }
}

public class UnionSet : Set
{
    public Set A { get; set; }
    public Set B { get; set; }

    public override bool IsIn(Set set)
    {
        return A.IsIn(set) || B.IsIn(set);
    }

    public override Set Union(Set set)
    {
        throw new NotImplementedException();
    }
}

public class IntersectionSet : Set
{
    public Set A { get; set; }
    public Set B { get; set; }

    public override bool IsIn(Set set)
    {
        return A.IsIn(set) && B.IsIn(set);
    }

    public override Set Union(Set set)
    {
        throw new NotImplementedException();
    }
}
