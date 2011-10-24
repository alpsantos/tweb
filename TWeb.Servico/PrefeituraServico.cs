using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TWeb.Modelo;
using TWeb.Repositorio;

namespace TWeb.Servico
{
    public class PrefeituraServico
    {
        private readonly IPrefeituraRepositorio _prefeituraRepositorio;

        public PrefeituraServico()
        {
            _prefeituraRepositorio = new PrefeituraRepositorio();
        }

        public PrefeituraServico(IPrefeituraRepositorio prefeituraRepositorio)
        {
            _prefeituraRepositorio = prefeituraRepositorio;
        }

        public void AdicionarPrefeitura(Prefeitura prefeitura)
        {
            ExceptionSePrefeituraForInvalida(prefeitura);

            _prefeituraRepositorio.Adicionar(prefeitura);
            _prefeituraRepositorio.Salvar();
        }

        public IEnumerable<Prefeitura> BuscarPrefeiturasPaginaInicial()
        {
            IEnumerable<Prefeitura> prefeituras = _prefeituraRepositorio.BuscarColecao(null); // todo : trazer todo eh assim mesmo

            return prefeituras;
        }

        public Prefeitura BuscarPrefeitura(int id)
        {
            Prefeitura prefeitura = _prefeituraRepositorio.Buscar(x => x.Id == id);

            return prefeitura;
        }

        public IEnumerable<Prefeitura> BuscarPrefeiturasPorNome(string nome)
        {
            IEnumerable<Prefeitura> prefeituras = _prefeituraRepositorio.BuscarColecao(x => x.Nome.Contains(nome)); 

            return prefeituras;
        }

        public void AtualizarPrefeitura(Prefeitura prefeitura)
        {
            _prefeituraRepositorio.Atualizar(prefeitura);
            _prefeituraRepositorio.Salvar();
        }

        public void ExceptionSePrefeituraForInvalida(Prefeitura prefeitura)
        {
            if (prefeitura.BuscarRegrasDeNegocioInvalidas().Count() > 0)
            {
                StringBuilder regrasInvalidas = new StringBuilder();
                foreach (var item in prefeitura.BuscarRegrasDeNegocioInvalidas())
                {
                    regrasInvalidas.Append(item);
                }

                throw new Exception(regrasInvalidas.ToString());
            }
        }
    }
}
