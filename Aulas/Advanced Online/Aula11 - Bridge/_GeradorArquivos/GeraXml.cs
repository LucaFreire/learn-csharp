using System.IO;
using System.Xml.Serialization;

public class GeraXml : IGerarArquivo
{
    string nomeArquivo = "SalarioFuncionario.xml";
    XmlSerializer xmlSerializer = new XmlSerializer(typeof(Funcionario));
    FileStream fileStream; 
    public void GravaArquivo(Funcionario func)
    {
        fileStream = new FileStream($"_Arquivos\\{nomeArquivo}", FileMode.OpenOrCreate);
        xmlSerializer.Serialize(fileStream, func);
        Console.WriteLine($"{func.Nome} - gerado com sucesso: {nomeArquivo}");
    }
}