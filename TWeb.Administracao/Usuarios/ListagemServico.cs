using System.Collections.Generic;
using TWeb.Modelo;
using TWeb.Servico;

namespace TWeb.Administracao.Usuarios
{
    public class ListagemServico
    {
        public List<Listagem> BuscarUsuarios()
        {
            UsuarioServico usuarioServico = new UsuarioServico();
            IEnumerable<Usuario> listaPrefeituraModelo = usuarioServico.BuscarPrefeiturasPaginaInicial();

            List<Listagem> listagemView = new List<Listagem>();

            foreach (var item in listaPrefeituraModelo)
            {
                Listagem view = new Listagem();
                view.Id = item.Id;
                view.Nome = item.Nome;
                view.Login = item.Login;
                view.Email = item.Email;
                view.StatusId = item.StatusId;

                listagemView.Add(view);
            }

            return listagemView;
        }
    }
}