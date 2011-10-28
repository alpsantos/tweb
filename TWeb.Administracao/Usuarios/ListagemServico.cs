using System;
using System.Collections.Generic;
using TWeb.Modelo;
using TWeb.Servico;

namespace TWeb.Administracao.Usuarios
{
    public class ListagemServico
    {
        private UsuarioServico _usuarioServico;

        public ListagemServico()
        {
            _usuarioServico = new UsuarioServico();
        }

        public List<Listagem> BuscarUsuarios()
        {
            _usuarioServico = new UsuarioServico();
            IEnumerable<Usuario> listaUsuarioModelo = _usuarioServico.BuscarUsuarios();

            List<Listagem> listagemView = new List<Listagem>();

            foreach (var item in listaUsuarioModelo)
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

        public IEnumerable<Usuario> BuscarUsuarios(string nome)
        {
            _usuarioServico = new UsuarioServico();
            IEnumerable<Usuario> listaUsuarioModelo = _usuarioServico.BuscarUsuariosPorNome(nome);

            return listaUsuarioModelo;
        }
    }
}