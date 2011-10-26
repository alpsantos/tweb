using System.Collections.Generic;
using TWeb.Site.Models;

namespace TWeb.Site.Extensao
{
    public static class Conversao
    {
        public static List<TWeb.Site.Models.Prefeitura> Conveter(this List<TWeb.Modelo.Prefeitura> prefeiturasDominio)
        {
            List<TWeb.Site.Models.Prefeitura> prefeiturasModel = new List<Models.Prefeitura>();

            foreach (var prefeituraDominio in prefeiturasDominio)
            {
                TWeb.Site.Models.Prefeitura prefeituraModel = new Models.Prefeitura();

                prefeituraModel.Nome = prefeituraDominio.Nome;
                prefeituraModel.Aderencia = prefeituraDominio.Aderencia;
                prefeituraModel.Ordem = prefeituraDominio.Ordem;
                prefeituraModel.StatusId = prefeituraDominio.StatusId;
                prefeituraModel.Longitude = prefeituraDominio.Longitude;
                prefeituraModel.Latitude = prefeituraDominio.Latitude;
                prefeituraModel.Brasao = prefeituraDominio.Brasao;

                prefeituraModel.Documentos = new List<Models.Documento>();

                var pd = prefeituraDominio;

                prefeituraModel.Documentos.Add(new Documento(TipoDocumento.BF, pd.Documentos.BF));
                prefeituraModel.Documentos.Add(new Documento(TipoDocumento.BO, pd.Documentos.BO));
                prefeituraModel.Documentos.Add(new Documento(TipoDocumento.BP, pd.Documentos.BP));
                prefeituraModel.Documentos.Add(new Documento(TipoDocumento.LC, pd.Documentos.LC));
                prefeituraModel.Documentos.Add(new Documento(TipoDocumento.LDO, pd.Documentos.LDO));
                prefeituraModel.Documentos.Add(new Documento(TipoDocumento.PPA, pd.Documentos.PPA));
                prefeituraModel.Documentos.Add(new Documento(TipoDocumento.RGF, pd.Documentos.RGF));
                prefeituraModel.Documentos.Add(new Documento(TipoDocumento.RREO, pd.Documentos.RREO));
                prefeituraModel.Documentos.Add(new Documento(TipoDocumento.PainelFinanceiro, pd.Documentos.PainelFinanceiro));
                prefeituraModel.Documentos.Add(new Documento(TipoDocumento.ParecerTCE, pd.Documentos.ParecerTCE));

                prefeiturasModel.Add(prefeituraModel);
            }

            return prefeiturasModel;
        }
    }
}