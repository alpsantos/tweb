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
    public class GlossarioRepositorio : IGlossarioRepositorio
    {
        private IConfiguracaoAplicacao _configuracaoDaAplicacao;
        private RepositorioContext _contexto;

        public GlossarioRepositorio()
        {
            ConfiguracaoDaAplicacaoFactory.InicializarConfiguracaoAplicacaoFactory(new WebConfigConfiguracaoAplicacao());
            _configuracaoDaAplicacao = ConfiguracaoDaAplicacaoFactory.BuscarConfiguracaoAplicacao();
            _contexto = new RepositorioContext(_configuracaoDaAplicacao.ConnectionString);
        }

        public IEnumerable<Glossario> BuscarColecao(Expression<Func<Glossario, bool>> expressao)
        {
            throw new NotImplementedException();
        }

        public Glossario Buscar(Func<Glossario, bool> expressao)
        {
            Glossario glossario = _contexto.Glossario.Where(expressao).FirstOrDefault();

            return glossario;
        }

        public void Adicionar(Glossario entidade)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(Glossario entidade)
        {
            _contexto.Glossario.Add(entidade);
            _contexto.Entry(entidade).State = EntityState.Modified;
        }

        public void Deletar(Glossario entidade)
        {
            throw new NotImplementedException();
        }

        public void Salvar()
        {
            _contexto.SaveChanges();
        }
    }
}
