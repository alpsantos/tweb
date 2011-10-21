using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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

                prefeituraModel.Documento = new Models.Documento();

                prefeituraDominio.Documentos.BF = prefeituraDominio.Documentos.BF;
                prefeituraDominio.Documentos.BO = prefeituraDominio.Documentos.BO;
                prefeituraDominio.Documentos.BP = prefeituraDominio.Documentos.BP;
                prefeituraDominio.Documentos.LC = prefeituraDominio.Documentos.LC;
                prefeituraDominio.Documentos.LDO = prefeituraDominio.Documentos.LDO;
                prefeituraDominio.Documentos.PPA = prefeituraDominio.Documentos.PPA;
                prefeituraDominio.Documentos.RGF = prefeituraDominio.Documentos.RGF;
                prefeituraDominio.Documentos.RREO = prefeituraDominio.Documentos.RREO;
                prefeituraDominio.Documentos.PainelFinanceiro = prefeituraDominio.Documentos.PainelFinanceiro;
                prefeituraDominio.Documentos.ParecerTCE = prefeituraDominio.Documentos.ParecerTCE;

                prefeiturasModel.Add(prefeituraModel);
            }

            return prefeiturasModel;
        }
    }
}