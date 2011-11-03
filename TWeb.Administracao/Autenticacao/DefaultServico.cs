using TWeb.Modelo;
using TWeb.Servico;

namespace TWeb.Administracao.Autenticacao
{
    public class DefaultServico
    {
        private readonly UsuarioServico usuarioServico;

        public DefaultServico()
        {
            usuarioServico = new UsuarioServico();
        }

        public bool Autenticar(Default defaultView)
        {
            return UsuarioSenhaValido(defaultView.Usuario, defaultView.Senha);
        }

        private bool UsuarioSenhaValido(string usuario, string senha)
        {
            Usuario usuarioModelo = usuarioServico.BuscarUsuarioPorUsuario(usuario);

            if (usuarioModelo == null)
                return false;

            if (usuarioModelo.Login == usuario && usuarioModelo.Senha == senha)
                return true;

            return false;
        }
    }
}