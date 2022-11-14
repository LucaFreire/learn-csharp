public class Matriz
{
    public int Altura{get;set;}
    public int Largura{get;set;}
    public int[,] Valores {get;set;}


    public Matriz(int altura, int largura)
    {
        this.Altura = altura;
        this.Largura = largura;
        this.Valores = new int[altura ,largura];
    }

    public void Add(int altura, int largura, int valor)
    {
        this.Valores[altura,largura] = valor;
    }

    
    public override string? ToString()
    {
        string matrix = "";
        for (int i = 0; i < this.Altura; i++)
        {
            for (int j = 0; j < this.Largura; j++)
            {
                matrix+=$"{this.Valores[i,j]} ";
            }
            matrix += "\n";
        }
        return matrix;
    }

    public Matriz Transposta()
    {
        Matriz Aux = new Matriz(this.Largura,this.Altura);

        for( int i =0; i<Altura; i++)
            for( int j=0; j<Largura; j++)
                Aux.Valores[j,i] = Valores[i,j];
        return Aux;
    }

    public Matriz Oposta()
    {
        Matriz Aux = new Matriz(this.Altura,this.Largura);

        for( int i =0; i<Altura; i++)
            for( int j=0; j<Largura; j++)
                Aux.Valores[j,i] = Valores[(j*-1),(i*-1)];

        return Aux;
    }
    public Matriz Nula()
    {
        Matriz Aux = new Matriz(this.Altura,this.Largura);

        for( int i =0; i<Altura; i++)
            for( int j=0; j<Largura; j++)
                Aux.Valores[j,i] = 0;

        return Aux;
    }

    public bool Identidade()
    {
        if(this.Altura != this.Largura)
            return false;
        for ( int i=0; i<this.Altura; i++)
        {
            for(int j=0; j<this.Largura; j++)
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
        if(this.Altura != this.Largura)
            return false;
        for ( int i=0; i<this.Altura; i++)
        {
            for(int j=0; j<this.Largura; j++)
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
        for ( int i=0; i<this.Altura; i++)
        {
            for(int j=0; j<this.Largura; j++)
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
        for ( int i=0; i<this.Altura; i++)
        {
            for(int j=0; j<this.Largura; j++)
            {
                if(this.Valores[i,j] != this.Transposta().Valores[i,j])
                    return false;
            }
        }
        return true;
    }

    public bool AntiSimetrica()                                                // conferir altura +1
    {
        for ( int i=0; i<this.Altura; i++)
        {
            for(int j=0; j<this.Largura; j++)
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
        if(primeira.Altura != segunda.Altura && primeira.Largura != segunda.Largura)
            throw new Exception();
        for ( int i=0; i<primeira.Altura; i++)
        {
            for(int j=0; j<primeira.Largura; j++)
            {
                primeira.Valores[i,j] += segunda.Valores[i,j];
            }
        }
        return primeira;
    }


    public static Matriz operator - (Matriz primeira, Matriz segunda)
    {
        if(primeira.Altura != segunda.Altura && primeira.Largura != segunda.Largura)
            throw new Exception();
        for ( int i=0; i<primeira.Altura; i++)
        {
            for(int j=0; j<primeira.Largura; j++)
            {
                primeira.Valores[i,j] -= segunda.Valores[i,j];
            }
        }
        return primeira;
    }


    public static Matriz operator * (Matriz primeira, Matriz segunda)
    {
        if(primeira.Largura != segunda.Altura)
            throw new Exception();
        Matriz Aux = new Matriz(primeira.Largura,primeira.Altura);
        for ( int i=0; i<primeira.Altura-1; i++)
        {
            for(int j=0; j<primeira.Largura-1; j++)
            {
                Aux.Valores[i,j] = primeira.Valores[i,j] * segunda.Valores[i,j] + primeira.Valores[i,j+1] * segunda.Valores[i,j+1];
            }
        }
        return Aux;
    }

}