public class Matriz
{
    public int Linhas{get;set;}
    public int Colunas{get;set;}
    public int[,] Valores {get;set;}


    public Matriz(int altura, int largura)
    {
        this.Linhas = altura;
        this.Colunas = largura;
        this.Valores = new int[altura ,largura];
    }

    public void Add(int altura, int largura, int valor)
    {
        this.Valores[altura,largura] = valor;
    }

    
    public override string? ToString()
    {
        string matrix = "";
        for (int i = 0; i < this.Linhas; i++)
        {
            for (int j = 0; j < this.Colunas; j++)
            {
                matrix+=$"{this.Valores[i,j]} ";
            }
            matrix += "\n";
        }
        return matrix;
    }

    public Matriz Transposta()
    {
        Matriz Aux = new Matriz(this.Colunas,this.Linhas);

        for( int i =0; i<Linhas; i++)
            for( int j=0; j<Colunas; j++)
                Aux.Valores[j,i] = Valores[i,j];
        return Aux;
    }

    public Matriz Oposta()
    {
        Matriz Aux = new Matriz(this.Linhas,this.Colunas);

        for( int i =0; i<Linhas; i++)
            for( int j=0; j<Colunas; j++)
                Aux.Valores[j,i] = Valores[(j*-1),(i*-1)];

        return Aux;
    }
    
    public Matriz Nula()
    {
        Matriz Aux = new Matriz(this.Linhas,this.Colunas);

        for( int i =0; i<Linhas; i++)
            for( int j=0; j<Colunas; j++)
                Aux.Valores[j,i] = 0;

        return Aux;
    }

    public bool Identidade()
    {
        if(this.Linhas != this.Colunas)
            return false;
        for ( int i=0; i<this.Linhas; i++)
        {
            for(int j=0; j<this.Colunas; j++)
            {
                if(i==j)
                {
                    if(this.Valores[i,j] != 1)
                        return false;
                }
                else if(this.Valores[i,j] != 0)
                    return false;
            }
        }
        return true;
    }

    
    public bool Diagonal()
    {
        if(this.Linhas != this.Colunas)
            return false;
        for ( int i=0; i<this.Linhas; i++)
        {
            for(int j=0; j<this.Colunas; j++)
            {
                if(i==j)
                    continue;
                else if(this.Valores[i,j] != 0)
                    return false;
            }
        }
        return true;
    }

    public bool Singular()
    {
        if(!this.Diagonal())
            return false;
        for ( int i=0; i<this.Linhas; i++)
        {
            for(int j=0; j<this.Colunas; j++)
            {
                if(i==j)
                {
                    if(this.Valores[i,j]!=this.Valores[0,0])
                        return false;
                }
            }
        }
        return true;
    }


    public bool Simetrica()                                               
    {
        for ( int i=0; i<this.Linhas; i++)
        {
            for(int j=0; j<this.Colunas; j++)
            {
                if(this.Valores[i,j] != this.Transposta().Valores[i,j])
                    return false;
            }
        }
        return true;
    }

    public bool AntiSimetrica()                                        
    {
        for ( int i=0; i<this.Linhas; i++)
        {
            for(int j=0; j<this.Colunas; j++)
            {
                if(this.Oposta().Valores[i,j] != this.Transposta().Valores[i,j])
                    return false;
            }
        }
        return true;
    }


    // public Matriz Soma(Matriz primeira, Matriz segunda)
    // {
    //     if(primeira.Altura != segunda.Altura && primeira.Largura != segunda.Largura)
    //         throw new Exception();
    //     for ( int i=0; i<this.Altura; i++)
    //     {
    //         for(int j=0; j<this.Largura; j++)
    //         {
    //             primeira.Valores[i,j] += segunda.Valores[i,j];
    //         }
    //     }
    //     return primeira;
    // }


    public static Matriz operator + (Matriz primeira, Matriz segunda)
    {
        if(primeira.Linhas != segunda.Linhas && primeira.Colunas != segunda.Colunas)
            throw new Exception();
        for ( int i=0; i<primeira.Linhas; i++)
        {
            for(int j=0; j<primeira.Colunas; j++)
            {
                primeira.Valores[i,j] += segunda.Valores[i,j];
            }
        }
        return primeira;
    }


    public static Matriz operator - (Matriz primeira, Matriz segunda)
    {
        if(primeira.Linhas != segunda.Linhas && primeira.Colunas != segunda.Colunas)
            throw new Exception();
        for ( int i=0; i<primeira.Linhas; i++)
        {
            for(int j=0; j<primeira.Colunas; j++)
            {
                primeira.Valores[i,j] -= segunda.Valores[i,j];
            }
        }
        return primeira;
    }


    public static Matriz operator * (Matriz mat1, Matriz mat2)
    {
        if(mat1.Colunas != mat2.Linhas)
            throw new Exception();
        
        Matriz Result = new Matriz(mat1.Colunas,mat2.Linhas);

        for ( int i=0; i<Result.Linhas; i++)
        {
            for(int j=0; j<Result.Colunas; j++)
            {
                int sum=0;
                for (int k = 0; k < Result.Colunas; k++)
                {
                    sum += mat1.Valores[i,k] * mat2.Valores[k,j];
                }
                Result.Valores[i,j] = sum;
            }
        }
        return Result;
    }

}
