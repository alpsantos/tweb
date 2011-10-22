using System;
using System.Collections.Specialized;
using TWeb.Modelo;
using TWeb.Servico;

namespace TWeb.Administracao.Prefeituras.Apresentacao
{
    public class Detalhes
    {
        public void BuscarPrefeitura(Prefeituras.Detalhes detalhes, int id)
        {
            PrefeituraServico prefeituraServico = new PrefeituraServico();
            var prefeitura = prefeituraServico.BuscarPrefeitura(id);

            detalhes.Id = prefeitura.Id;
            detalhes.Nome = prefeitura.Nome;
            detalhes.Aderencia = prefeitura.Aderencia;
            detalhes.Ordem = prefeitura.Ordem;
            detalhes.Status = prefeitura.StatusId;
            detalhes.Documentos = FormatarDocumentos(prefeitura.Documentos);
        }

        private NameValueCollection FormatarDocumentos(Documentos documentos)
        {
            NameValueCollection nameValueCollection = new NameValueCollection();

            nameValueCollection.Add("LDO", documentos.LDO.ToString());
            nameValueCollection.Add("BF", documentos.BF.ToString());
            nameValueCollection.Add("BP", documentos.BP.ToString());
            nameValueCollection.Add("RGF", documentos.RGF.ToString());
            nameValueCollection.Add("RREO", documentos.RREO.ToString());
            nameValueCollection.Add("PPA", documentos.PPA.ToString());
            nameValueCollection.Add("BO", documentos.BO.ToString());
            nameValueCollection.Add("LC", documentos.LC.ToString());
            nameValueCollection.Add("Painel Financeiro", documentos.PainelFinanceiro.ToString());
            nameValueCollection.Add("Parecer TCE", documentos.ParecerTCE.ToString());

            return nameValueCollection;
        }


        public void AtualizarPrefeitura(Prefeituras.Detalhes detalhes)
        {
            Prefeitura prefeitura = new Prefeitura();
            //detalhes.Id = detalhes.Id;
            prefeitura.Nome = detalhes.Nome;
            prefeitura.Aderencia = detalhes.Aderencia;
            prefeitura.Ordem = detalhes.Ordem;
            prefeitura.StatusId = detalhes.Status;
            prefeitura.Documentos = FormatarDocumentosX(detalhes.Documentos);

            PrefeituraServico prefeituraServico = new PrefeituraServico();
            //prefeituraServico.AtualizarPrefeitura(prefeitura);
        }

        private Documentos FormatarDocumentosX(NameValueCollection nameValueCollection)
        {
            Documentos documentos = new Documentos();

            foreach (var item in nameValueCollection.AllKeys)
            {
                if (item.Contains("LDO"))
                    documentos.LDO = true;
                if (item.Contains("BF"))
                    documentos.BF = true;
                if (item.Contains("BP"))
                    documentos.BP = true;
                if (item.Contains("RGF"))
                    documentos.RGF = true;
                if (item.Contains("RREO"))
                    documentos.RREO = true;
                if (item.Contains("PPA"))
                    documentos.PPA = true;
                if (item.Contains("BO"))
                    documentos.BO = true;
                if (item.Contains("LC"))
                    documentos.LC = true;
                if (item.Contains("Painel Financeiro"))
                    documentos.PainelFinanceiro = true;
                if (item.Contains("Parecer TCE"))
                    documentos.ParecerTCE = true;
            }


            return documentos;
        }
    }
}