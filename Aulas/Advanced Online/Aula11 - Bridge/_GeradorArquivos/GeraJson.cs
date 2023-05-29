using System.IO;
using System.Text.Json;

public class GeraJson : IGerarArquivo
{
    string nomeArquivo = "SalarioFuncionario.json";
    public void GravaArquivo(Funcionario func)
    {
        var funcionario = JsonSerializer.Serialize(func);
        File.WriteAllText($"_Arquivos//{nomeArquivo}", funcionario);
        Console.WriteLine($"{func.Nome} - gerado com sucesso: {nomeArquivo}");
    }
}