using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using TOMWeb.Observatorio.Infra.Configuracao;
using TWeb.Infra.Configuracao;
using TWeb.Modelo;

namespace TWeb.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private IConfiguracaoAplicacao _configuracaoDaAplicacao;
        private RepositorioContext _contexto;

        public UsuarioRepositorio()
        {
            ConfiguracaoDaAplicacaoFactory.InicializarConfiguracaoAplicacaoFactory(new WebConfigConfiguracaoAplicacao());
            _configuracaoDaAplicacao = ConfiguracaoDaAplicacaoFactory.BuscarConfiguracaoAplicacao();
            _contexto = new RepositorioContext(_configuracaoDaAplicacao.ConnectionString);
        }

        public IEnumerable<Usuario> BuscarColecao(Expression<Func<Usuario, bool>> expressao)
        {
            IEnumerable<Usuario> usuarios;

            if (expressao == null)
                usuarios = _contexto.Usuario.ToList();
            else
                usuarios = _contexto.Usuario.Where(expressao).ToList();

            return usuarios;
        }

        public Usuario Buscar(Func<Usuario, bool> expressao)
        {
            Usuario usuario = _contexto.Usuario.Where(expressao).FirstOrDefault();

            return usuario;
        }

        public void Adicionar(Usuario entidade)
        {
            _contexto.Usuario.Add(entidade);
        }

        public void Atualizar(Usuario entidade)
        {
            _contexto.Usuario.Attach(entidade);
            _contexto.Entry(entidade).State = EntityState.Modified;
        }

        public void Deletar(Usuario entidade)
        {
            Usuario usuario = _contexto.Usuario.Find(entidade);
            usuario.StatusId = 3; // todo: tirar esse hard coded
        }

        public void Salvar()
        {
            _contexto.SaveChanges();
        }
    }
}
