using System.Collections.Generic;
using TWeb.Servico;

namespace TWeb.Administracao.Prefeituras
{
    public class ListagemServico
    {
        public List<Listagem> BuscarPrefeituras()
        {
            PrefeituraServico prefeituraServico = new PrefeituraServico();
            var prefeituras = prefeituraServico.BuscarPrefeiturasPaginaInicial();

            List<Listagem> listagemServicoses = new List<Listagem>();

            foreach (var prefeitura in prefeituras)
            {
                Listagem listagem = new Listagem();
                listagem.Id = prefeitura.Id;
                listagem.Nome = prefeitura.Nome;
                listagem.Aderencia = prefeitura.Aderencia;
                listagem.StatusId = prefeitura.StatusId;

                listagemServicoses.Add(listagem);
            }

            return listagemServicoses;
        }
    }
}