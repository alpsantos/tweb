namespace TOMWeb.Observatorio.Infra.Configuracao
{
    public interface IConfiguracaoAplicacao
    {
        string CaminhoDoArquivoDeLog { get; }
        string ConnectionString { get; }
    }
}
