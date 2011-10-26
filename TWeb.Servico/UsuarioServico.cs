using System.Collections.Generic;
using TWeb.Modelo;
using TWeb.Repositorio;

namespace TWeb.Servico
{
    public class UsuarioServico
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioServico()
        {
            _usuarioRepositorio = new UsuarioRepositorio();
        }

        public UsuarioServico(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public void AdicionarUsuario(Usuario usuario)
        {
            _usuarioRepositorio.Adicionar(usuario);
            _usuarioRepositorio.Salvar();
        }

        public IEnumerable<Usuario> BuscarPrefeiturasPaginaInicial()
        {
            IEnumerable<Usuario> usuarios = _usuarioRepositorio.BuscarColecao(null); // todo : trazer todo eh assim mesmo

            return usuarios;
        }

        public Usuario BuscarUsuario(int id)
        {
            Usuario usuario = _usuarioRepositorio.Buscar(x => x.Id == id);

            return usuario;
        }

        public IEnumerable<Usuario> BuscarUsuarioPorNome(string nome)
        {
            IEnumerable<Usuario> usuarios = _usuarioRepositorio.BuscarColecao(x => x.Nome.Contains(nome)); 

            return usuarios;
        }

        public void AtualizarUsuario(Usuario usuario)
        {
            _usuarioRepositorio.Atualizar(usuario);
            _usuarioRepositorio.Salvar();
        }
    }
}
