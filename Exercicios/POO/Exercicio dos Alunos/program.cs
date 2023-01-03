using System;

// Curso
var cursos = new List<Curso>();

// Aluno
var Alunos = new List<Aluno>();

// Estatística
var Estati = new List<Estatistica>();

while (true){
    Console.Write("1 - Cadastrar Curso\n2 - Listar Cursos\n3 - Cadastrar Alunos\n4 - Dar Notas\n5 - Estatística\n6 - Sair\nSeu Número: ");
    int Num = Convert.ToInt32(Console.ReadLine());


    if (Num == 1)
    {
        Curso curso = new Curso();

        Console.Write("\nDigite o Nome do Curso: ");
        curso.Nome =  Console.ReadLine();

        Console.Write("\nDigite o Código do Curso: ");
        curso.Codigo = int.Parse(Console.ReadLine());

        Console.Write("\nDigite a Carga Horária: ");
        curso.Horas = int.Parse(Console.ReadLine());

        cursos.Add(curso);
        Console.WriteLine("\nCurso Cadastrado!\n");
    }


    else if (Num == 2)
        for (int i = 0; i<cursos.Count; i++)
            Console.WriteLine($"\nCurso: {cursos[i].Nome}\nCódigo do Curso: {cursos[i].Codigo}\nCarga Horária: {cursos[i].Horas}\n\n");


    else if (Num == 3)
    {
        Aluno aluno = new Aluno();

        Console.Write($"\nNome do Aluno: ");
        aluno.NomeAluno = Console.ReadLine();

        Console.Write($"\nCódigo de Curso: ");
        aluno.CodigoCurso = int.Parse(Console.ReadLine());

        Console.Write($"\nNúmero de Matrícula: ");
        aluno.Matricula = int.Parse(Console.ReadLine());

        Alunos.Add(aluno);
        Console.Write($"\nAluno Cadastrado!\n");
    }


    else if (Num == 4)
    {
        for (int j = 0; j<cursos.Count; j++)
            Console.WriteLine($"Nome do Curso: {cursos[j].Nome}, Código: {cursos[j].Codigo}");

        Console.Write("Digite o Código do Curso: ");
        int CodigoInserido = int.Parse(Console.ReadLine());

        for (int k = 0; k<cursos.Count; k++)
        {   
            if (CodigoInserido == cursos[k].Codigo)
            {
                Estatistica EstaCurso = new Estatistica();
                // Media
                var Med = new List<float>();

                for (int l = 0; l<Alunos.Count; l++)
                {
                    if (CodigoInserido == Alunos[l].CodigoCurso)
                    {
                        Console.Write($"\nDigite a Nota do {Alunos[l].NomeAluno}: ");
                        float nota = float.Parse(Console.ReadLine());

                        Med.Add(nota);

                        if (nota>=7)
                            EstaCurso.Aprovados++;
                        else
                            EstaCurso.Reprovados++;
                    }

                float media = (Med.Sum()) / (Med.Count);
                EstaCurso.Media = media;
                Estati.Add(EstaCurso);

                }
            }
        }
    }


    else if (Num == 5)
    {
        Console.WriteLine("Estatística do Curso\n");
        for (int i = 0; i<Estati.Count; i++)
            Console.WriteLine($"Curso: {cursos[i].Nome}\nMédia{Estati[i].Media}\nAprovados: {Estati[i].Aprovados}\nReprovados: {Estati[i].Reprovados}\n\n");
    }

    else if (Num == 6)
    {
        Console.WriteLine("Você Saiu!");
        break;
    }

    else
        Console.WriteLine("Número Inváido, Digite Novamente!");
}