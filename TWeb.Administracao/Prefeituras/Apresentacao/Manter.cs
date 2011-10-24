using System.Collections.Specialized;
using TWeb.Modelo;
using TWeb.Servico;

namespace TWeb.Administracao.Prefeituras.Apresentacao
{
    public class Manter
    {
        public void BuscarPrefeitura(Prefeituras.Manter manter, int id)
        {
            PrefeituraServico prefeituraServico = new PrefeituraServico();
            var prefeitura = prefeituraServico.BuscarPrefeitura(id);

            manter.Id = prefeitura.Id;
            manter.Nome = prefeitura.Nome;
            manter.Aderencia = prefeitura.Aderencia;
            manter.Ordem = prefeitura.Ordem;
            manter.Status = prefeitura.StatusId;
            manter.DocumentosId = prefeitura.DocumentosId;
            manter.Documentos = FormatarDocumentos(prefeitura.Documentos);
        }

        public void AdicionarPrefeitura(Prefeituras.Manter manter)
        {
            Prefeitura prefeitura = new Prefeitura();
            prefeitura.Nome = manter.Nome;
            prefeitura.Aderencia = manter.Aderencia;
            prefeitura.Ordem = manter.Ordem;
            prefeitura.StatusId = manter.Status;
            prefeitura.Documentos = FormatarDocumentosX(manter);

            PrefeituraServico prefeituraServico = new PrefeituraServico();
            prefeituraServico.AdicionarPrefeitura(prefeitura);
        }

        public void AtualizarPrefeitura(Prefeituras.Manter manter)
        {
            Prefeitura prefeitura = new Prefeitura();
            prefeitura.Id = manter.Id;
            prefeitura.Nome = manter.Nome;
            prefeitura.Aderencia = manter.Aderencia;
            prefeitura.Ordem = manter.Ordem;
            prefeitura.StatusId = manter.Status;
            prefeitura.DocumentosId = manter.DocumentosId;
            prefeitura.Documentos = FormatarDocumentosX(manter);

            PrefeituraServico prefeituraServico = new PrefeituraServico();
            prefeituraServico.AtualizarPrefeitura(prefeitura);
        }

        private Documentos FormatarDocumentosX(Prefeituras.Manter manter)
        {
            Documentos documentos = new Documentos();
            
            if (manter.DocumentosId != 0)
                documentos.Id = manter.DocumentosId;

            NameValueCollection nameValueCollection = manter.Documentos;

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



        private static NameValueCollection FormatarDocumentos(Documentos documentos)
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
    }
}