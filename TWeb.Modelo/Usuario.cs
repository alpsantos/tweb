using System;
using TWeb.Infra.Dominio;
using TWeb.Modelo.Util;

namespace TWeb.Modelo
{
    public class Usuario : EntidadeBase<int>
    {
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int StatusId { get; set; }
        public int PerfilId { get; set; } // todo ; vai ficar assim mesmo?
        public virtual Status Status { get; set; }


        public override void Validar()
        {
            if (String.IsNullOrEmpty(this.Nome))
                base.AdicionarRegraDeNegocioInvalida(new RegraDeNegocio("Nome", "Nome de usuário inválido."));

            if (!LoginValidador.LoginValido(this.Login))
                base.AdicionarRegraDeNegocioInvalida(new RegraDeNegocio("Login", "Login de usuário inválido."));
            
            if (!EmailValidator.EmailValido(this.Email))
                base.AdicionarRegraDeNegocioInvalida(new RegraDeNegocio("Email", "Email inválido."));

            if (!SenhaValidador.SenhaValida(this.Senha))
                base.AdicionarRegraDeNegocioInvalida(new RegraDeNegocio("Senha", "Senha inválida."));
            
            if (this.StatusId <= 0)
                base.AdicionarRegraDeNegocioInvalida(new RegraDeNegocio("Status", "Status inválido."));
            
            if (this.PerfilId <= 0)
                base.AdicionarRegraDeNegocioInvalida(new RegraDeNegocio("Perfil", "Perfil inválido."));
        }
    }
}