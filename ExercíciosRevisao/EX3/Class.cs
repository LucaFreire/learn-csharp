using System;
public class Matriz
{
    public int Linhas { get; set; }
    public int Colunas { get; set; }
    public int[,] Valores { get; set; }

    public Matriz(int Linhas, int Colunas)
    {
        this.Linhas = Linhas;
        this.Colunas = Colunas;
        this.Valores = new int [Linhas,Colunas];
        
        Random rand = new Random();
        for (int i = 0; i < this.Linhas; i++)
            for (int j = 0; j < this.Colunas; j++)
                Valores[i,j] = rand.Next(10);
    }

    public Matriz OnlyEven() // Função p/ substituir números ímpares
    {
        Matriz aux = new Matriz(this.Linhas, this.Colunas); 
        for (int i = 0; i < this.Linhas; i++)
            for (int j = 0; j < this.Colunas; j++)
                if(this.Valores[i,j] % 2 != 0)
                    aux.Valores[i,j] = 0;
        return aux;
    }

    public override string? ToString()
    {
        string matrix = "";
        for (int i = 0; i < this.Linhas; i++)
        {
            for (int j = 0; j < this.Colunas; j++)
                matrix+=$"{this.Valores[i,j]} ";   
            matrix += "\n";
        }
        return matrix;
    }
}
