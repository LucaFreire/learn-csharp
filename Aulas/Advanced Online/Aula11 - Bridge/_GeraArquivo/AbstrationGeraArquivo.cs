public abstract class AbstractionGeraArquivo
{
    protected IGerarArquivo geraArquivo;
    protected AbstractionGeraArquivo(IGerarArquivo gera)
        => this.geraArquivo = gera;
    protected virtual void GravaArquivo(Funcionario fun)
        => geraArquivo.GravaArquivo(fun);
}