using System.Collections.Generic;
using TWeb.Modelo;
using TWeb.Servico;

namespace TWeb.Administracao.Prefeituras
{
    public class ListagemServico
    {
        public List<Listagem> BuscarPrefeituras()
        {
            PrefeituraServico prefeituraServico = new PrefeituraServico();
            IEnumerable<Prefeitura> listaPrefeituraModelo = prefeituraServico.BuscarPrefeiturasPaginaInicial();

            List<Listagem> listagemView = new List<Listagem>();

            foreach (var item in listaPrefeituraModelo)
            {
                Listagem view = new Listagem();
                view.Id = item.Id;
                view.Nome = item.Nome;
                view.Aderencia = item.Aderencia;
                view.StatusId = item.StatusId;

                listagemView.Add(view);
            }

            return listagemView;
        }
    }
}