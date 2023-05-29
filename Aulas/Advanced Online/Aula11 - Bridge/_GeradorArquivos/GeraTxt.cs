using System.IO;
using System.Reflection;
public class GeraTxt : IGerarArquivo
{
    string nomeArquivo = "SalarioFuncionario.txt";

    public void GravaArquivo(Funcionario func)
    {

        StreamWriter st = new StreamWriter($"_Arquivos\\{this.nomeArquivo}");
        st.Write(func);
        st.Close();
        Console.WriteLine($"{func.Nome} - gerado com sucesso: {nomeArquivo}");
    }
}



