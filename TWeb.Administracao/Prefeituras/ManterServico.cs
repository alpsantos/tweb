using System.Collections.Specialized;
using System.Linq;
using TWeb.Modelo;
using TWeb.Servico;

namespace TWeb.Administracao.Prefeituras
{
    public class ManterServico
    {
        public void BuscarPrefeitura(Manter manterView, int id)
        {
            PrefeituraServico prefeituraServico = new PrefeituraServico();
            var prefeitura = prefeituraServico.BuscarPrefeitura(id);

            manterView.Id = prefeitura.Id;
            manterView.Nome = prefeitura.Nome;
            manterView.Aderencia = prefeitura.Aderencia;
            manterView.Ordem = prefeitura.Ordem;
            manterView.Status = prefeitura.StatusId;
            manterView.DocumentosId = prefeitura.DocumentosId;
            manterView.Documentos = FormatarDocumentosParaCollection(prefeitura.Documentos);
        }

        public void AdicionarPrefeitura(Manter manterView)
        {
            Prefeitura prefeituraModelo = new Prefeitura();
            prefeituraModelo.Nome = manterView.Nome;
            prefeituraModelo.Aderencia = manterView.Aderencia;
            prefeituraModelo.Ordem = manterView.Ordem;
            prefeituraModelo.StatusId = manterView.Status;
            prefeituraModelo.Documentos = FormatarParaDocumentosModelo(manterView);

            prefeituraModelo.Validar();

            if (prefeituraModelo.BuscarRegrasDeNegocioInvalidas().Count() > 0)
            {
                foreach (var item in prefeituraModelo.BuscarRegrasDeNegocioInvalidas())
                {
                    manterView.MenssagensDeErro.Add(item.Regra);
                }
            }
            else
            {
                PrefeituraServico prefeituraServico = new PrefeituraServico();
                prefeituraServico.AdicionarPrefeitura(prefeituraModelo);
            }
        }

        public void AtualizarPrefeitura(Manter manterView)
        {
            Prefeitura prefeituraModelo = new Prefeitura();
            prefeituraModelo.Id = manterView.Id;
            prefeituraModelo.Nome = manterView.Nome;
            prefeituraModelo.Aderencia = manterView.Aderencia;
            prefeituraModelo.Ordem = manterView.Ordem;
            prefeituraModelo.StatusId = manterView.Status;
            prefeituraModelo.DocumentosId = manterView.DocumentosId;
            prefeituraModelo.Documentos = FormatarParaDocumentosModelo(manterView);

            prefeituraModelo.Validar();
            
            if (prefeituraModelo.BuscarRegrasDeNegocioInvalidas().Count() > 0)
            {
                foreach (var item in prefeituraModelo.BuscarRegrasDeNegocioInvalidas())
                {
                    manterView.MenssagensDeErro.Add(item.Regra);
                }
            }
            else
            {
                PrefeituraServico prefeituraServico = new PrefeituraServico();
                prefeituraServico.AtualizarPrefeitura(prefeituraModelo);
            }
        }

        private static Documentos FormatarParaDocumentosModelo(Manter manterView)
        {
            Documentos documentosModelo = new Documentos();
            
            if (manterView.DocumentosId != 0)
                documentosModelo.Id = manterView.DocumentosId;

            NameValueCollection documentosViewCollection = manterView.Documentos;

            foreach (var item in documentosViewCollection.AllKeys)
            {
                if (item.Contains("LDO"))
                    documentosModelo.LDO = true;
                if (item.Contains("BF"))
                    documentosModelo.BF = true;
                if (item.Contains("BP"))
                    documentosModelo.BP = true;
                if (item.Contains("RGF"))
                    documentosModelo.RGF = true;
                if (item.Contains("RREO"))
                    documentosModelo.RREO = true;
                if (item.Contains("PPA"))
                    documentosModelo.PPA = true;
                if (item.Contains("BO"))
                    documentosModelo.BO = true;
                if (item.Contains("LC"))
                    documentosModelo.LC = true;
                if (item.Contains("Painel Financeiro"))
                    documentosModelo.PainelFinanceiro = true;
                if (item.Contains("Parecer TCE"))
                    documentosModelo.ParecerTCE = true;
            }

            return documentosModelo;
        }

        private static NameValueCollection FormatarDocumentosParaCollection(Documentos documentosModelo)
        {
            NameValueCollection nameValueCollection = new NameValueCollection();

            nameValueCollection.Add("LDO", documentosModelo.LDO.ToString());
            nameValueCollection.Add("BF", documentosModelo.BF.ToString());
            nameValueCollection.Add("BP", documentosModelo.BP.ToString());
            nameValueCollection.Add("RGF", documentosModelo.RGF.ToString());
            nameValueCollection.Add("RREO", documentosModelo.RREO.ToString());
            nameValueCollection.Add("PPA", documentosModelo.PPA.ToString());
            nameValueCollection.Add("BO", documentosModelo.BO.ToString());
            nameValueCollection.Add("LC", documentosModelo.LC.ToString());
            nameValueCollection.Add("Painel Financeiro", documentosModelo.PainelFinanceiro.ToString());
            nameValueCollection.Add("Parecer TCE", documentosModelo.ParecerTCE.ToString());

            return nameValueCollection;
        }
    }
}