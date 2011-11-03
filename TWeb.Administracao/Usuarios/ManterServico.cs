using System.Linq;
using TWeb.Modelo;
using TWeb.Servico;

namespace TWeb.Administracao.Usuarios
{
    public class ManterServico
    {
        private UsuarioServico _usuarioServico;

        public ManterServico()
        {
            _usuarioServico = new UsuarioServico();
        }

        public void BuscarUsuario(Manter manterView, int id)
        {
            
            Usuario usuarioModelo = _usuarioServico.BuscarUsuario(id);

            manterView.Id = usuarioModelo.Id;
            manterView.Nome = usuarioModelo.Nome;
            manterView.Login = usuarioModelo.Login;
            manterView.Email = usuarioModelo.Email;
            manterView.Senha = usuarioModelo.Senha;
            manterView.Status = usuarioModelo.StatusId;
        }

        public void AdicionarUsuario(Manter manterView)
        {
            Usuario usuarioModelo = new Usuario();

            manterView.Id = usuarioModelo.Id;
            manterView.Nome = usuarioModelo.Nome;
            manterView.Login = usuarioModelo.Login;
            manterView.Email = usuarioModelo.Email;
            manterView.Senha = usuarioModelo.Senha;
            manterView.Status = usuarioModelo.StatusId;

            usuarioModelo.Validar();

            if (usuarioModelo.BuscarRegrasDeNegocioInvalidas().Count() > 0)
            {
                foreach (var item in usuarioModelo.BuscarRegrasDeNegocioInvalidas())
                {
                    manterView.MenssagensDeErro.Add(item.Regra);
                }
            }
            else
            {
                _usuarioServico = new UsuarioServico();
                _usuarioServico.AdicionarUsuario(usuarioModelo);
            }
        }

        public void AtualizarUsuario(Manter manterView)
        {
            Usuario usuarioModelo = new Usuario();

            usuarioModelo.Id = manterView.Id;
            usuarioModelo.Nome = manterView.Nome;
            usuarioModelo.Login = manterView.Login;
            usuarioModelo.Email = manterView.Email;
            usuarioModelo.Senha = manterView.Senha;
            usuarioModelo.StatusId = manterView.Status;
            usuarioModelo.PerfilId = 1;

            usuarioModelo.Validar();

            if (usuarioModelo.BuscarRegrasDeNegocioInvalidas().Count() > 0)
            {
                foreach (var item in usuarioModelo.BuscarRegrasDeNegocioInvalidas())
                {
                    manterView.MenssagensDeErro.Add(item.Regra);
                }
            }
            else
            {
                _usuarioServico = new UsuarioServico();
                _usuarioServico.AtualizarUsuario(usuarioModelo);
            }
        }
    }
}