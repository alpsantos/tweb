using System.Linq;
using TWeb.Servico;

namespace TWeb.Administracao.Glossario
{
    public class ManterServico
    {
        private GlossarioServico _glossarioServico;

        public ManterServico()
        {
            _glossarioServico = new GlossarioServico();
        }

        public void AtualizarGlossario(Manter manterView)
        {
            Modelo.Glossario glossarioModelo = new Modelo.Glossario();

            glossarioModelo.Id = manterView.Id;
            glossarioModelo.Conteudo = manterView.Conteudo;

            glossarioModelo.Validar();

            if (glossarioModelo.BuscarRegrasDeNegocioInvalidas().Count() > 0)
            {
                foreach (var item in glossarioModelo.BuscarRegrasDeNegocioInvalidas())
                {
                    manterView.MenssagensDeErro.Add(item.Regra);
                }
            }
            else
            {
                _glossarioServico = new GlossarioServico();
                _glossarioServico.AtualizarGlossario(glossarioModelo);
            }
        }

        public void BuscarGlossario(Manter manterView)
        {
            Modelo.Glossario glossarioModelo = _glossarioServico.BuscarGlossario();
            manterView.Id = glossarioModelo.Id;
            manterView.Conteudo = glossarioModelo.Conteudo;
        }
    }
}