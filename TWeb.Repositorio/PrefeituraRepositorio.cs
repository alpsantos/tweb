using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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

        public IEnumerable<Prefeitura> BuscarColecao(Func<Prefeitura, bool> expressao)
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

        
        public void Adicionar(Prefeitura usuario)
        {
            _contexto.Prefeitura.Add(usuario);
        }

        public void Atualizar(Prefeitura prefeitura)
        {
            _contexto.Prefeitura.Attach(prefeitura);
            _contexto.Entry(prefeitura).State = EntityState.Modified;
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
