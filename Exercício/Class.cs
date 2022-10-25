public class Curso
{
    public int Codigo{ get; private set; }
    public string Nome  { get; private set; }
    public int Horas { get; private set; }
}  

public class Aluno{
    public int CodigoCurso{ get; private set; }
    public string NomeAluno{ get; private set; }
    public int Matricula{ get; private set; }
    public float Nota{ get; private set; }
}


