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
    public class PrefeituraRepositorio : IPrefeituraRepositorio
    {
        private IConfiguracaoAplicacao _configuracaoDaAplicacao;
        private RepositorioContext _contexto;

        public PrefeituraRepositorio()
        {
            ConfiguracaoDaAplicacaoFactory.InicializarConfiguracaoAplicacaoFactory(new WebConfigConfiguracaoAplicacao());
            _configuracaoDaAplicacao = ConfiguracaoDaAplicacaoFactory.BuscarConfiguracaoAplicacao();
            _contexto = new RepositorioContext(_configuracaoDaAplicacao.ConnectionString);
        }

        public IEnumerable<Prefeitura> BuscarColecao(Expression<Func<Prefeitura, bool>> expressao)
        {
            IEnumerable<Prefeitura> prefeituras;

            if (expressao == null)
                prefeituras = _contexto.Prefeitura.ToList();
            else
                prefeituras = _contexto.Prefeitura.Where(expressao).ToList();

            return prefeituras;
        }

        public Prefeitura Buscar(Func<Prefeitura, bool> expressao)
        {
            Prefeitura prefeitura = _contexto.Prefeitura.Where(expressao).FirstOrDefault();

            return prefeitura;
        }
        
        public void Adicionar(Prefeitura entidade)
        {
            _contexto.Prefeitura.Add(entidade);
        }

        public void Atualizar(Prefeitura entidade)
        {
            _contexto.Prefeitura.Attach(entidade);
            _contexto.Entry(entidade).State = EntityState.Modified;
        }

        public void Deletar(Prefeitura entidade)
        {
            Prefeitura prefeitura = _contexto.Prefeitura.Find(entidade);
            prefeitura.StatusId = 3; // todo: tirar esse hard coded
        }

        public void Salvar()
        {
            _contexto.SaveChanges();
        }
    }
}
