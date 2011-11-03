using TWeb.Modelo;
using TWeb.Repositorio;

namespace TWeb.Servico
{
    public class GlossarioServico
    {
        private readonly IGlossarioRepositorio _glossarioRepositorio;

        public GlossarioServico()
        {
            _glossarioRepositorio = new GlossarioRepositorio();
        }

        public GlossarioServico(IGlossarioRepositorio glossarioRepositorio)
        {
            _glossarioRepositorio = glossarioRepositorio;
        }

        public Glossario BuscarGlossario()
        {
            Glossario usuario = _glossarioRepositorio.Buscar(x => x.Id == 1);

            return usuario;
        }

        public void AtualizarGlossario(Glossario glossario)
        {
            _glossarioRepositorio.Atualizar(glossario);
            _glossarioRepositorio.Salvar();
        }

    }
}
