internal class TestarLivros
{
    private static void Main(string[] args)
    {
        Livro livrofavorito = new Livro("O Pequeno Príncipe", 98, 0);

        Console.WriteLine(livrofavorito.Mostrar());
        livrofavorito.setPaginasLidas(20);

        Console.WriteLine(livrofavorito.Mostrar());
        Console.WriteLine(livrofavorito.VereficarProgresso());

        livrofavorito.setPaginasLidas(50);
        Console.WriteLine(livrofavorito.VereficarProgresso());

        List<Livro> ListaLivros = new List<Livro>(); 
        for (int i =0; i<10; i++)
        {
            Console.WriteLine($"Título do {i+1}° Livro: ");
            string NomeUser = Console.ReadLine() ?? "Desconhecido";

            Console.WriteLine($"Páginas de {NomeUser}: ");
            int PaginasUser = int.Parse(Console.ReadLine() ?? "0");

            Console.WriteLine($"Páginas Lidas: ");
            int LidasUser = int.Parse(Console.ReadLine() ?? "0");

            Livro livro = new Livro(NomeUser, PaginasUser, LidasUser);
            ListaLivros.Add(livro);
        }

        for (int k = 0; k<ListaLivros.Count();k++)
            Console.WriteLine($"{ListaLivros[k].Mostrar()}");
    }
}
