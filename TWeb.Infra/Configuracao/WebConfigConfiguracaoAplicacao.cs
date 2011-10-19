using System.Configuration;
using TOMWeb.Observatorio.Infra.Configuracao;

namespace TWeb.Infra.Configuracao
{
    public class WebConfigConfiguracaoAplicacao : IConfiguracaoAplicacao
    {
        public string CaminhoDoArquivoDeLog
        {
            get { return ConfigurationManager.AppSettings["caminho-arquivo-log"]; }
        }

        public string ConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString; }
        }
    }
}


//<appSettings>
//      <add key="LoggerName" value="Nome.log"/> 
//</appSettings >
