public class Livro
{
    private string titulo { get; set; }
    private int qtdPaginas { get; set; } 
    private int paginasLidas { get; set; }

    public Livro(string TITULO, int QTDPAGINAS, int PAGINASLIDAS)
    {
        this.titulo = TITULO;
        this.qtdPaginas = QTDPAGINAS;
        this.paginasLidas = PAGINASLIDAS;
    }
    public string VereficarProgresso()
    {
        return $"Progresso: {this.paginasLidas * 100 / this.qtdPaginas}%";
    }
    public void setTitulo(string nomeNovo)
    {
        this.titulo = nomeNovo;
    }
    public void  setQtdPaginas(int PaginasNovas)
    {
        this.qtdPaginas = PaginasNovas;
    }
    public string getTitulo()
    {
        return this.titulo;
    }
    public int getQtdPaginas()
    {
        return this.qtdPaginas;
    }

    public string Mostrar()
    {
        return $"O Livro {getTitulo()} possui {getQtdPaginas()} páginas.";
    }
    public int setPaginasLidas(int paginas)
    {
        return this.paginasLidas = paginas;
    }


}

