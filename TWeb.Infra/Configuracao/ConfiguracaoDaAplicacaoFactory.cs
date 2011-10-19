using TOMWeb.Observatorio.Infra.Configuracao;

namespace TWeb.Infra.Configuracao
{
    public class ConfiguracaoDaAplicacaoFactory
    {
        private static IConfiguracaoAplicacao _configuracaoAplicacao;

        public static void InicializarConfiguracaoAplicacaoFactory(IConfiguracaoAplicacao configuracaoAplicacao)
        {
            _configuracaoAplicacao = configuracaoAplicacao;
        }

        public static IConfiguracaoAplicacao BuscarConfiguracaoAplicacao()
        {
            return _configuracaoAplicacao;
        }
    }
}
