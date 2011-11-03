using System;
using TWeb.Infra.Dominio;

namespace TWeb.Modelo
{
    public class Glossario : EntidadeBase<int>
    {
        public string Conteudo { get; set; }

        public override void Validar() //todo : mudar esse nome para ValidarRegrasDeNegocio
        {
            if (String.IsNullOrEmpty(this.Conteudo))
                base.AdicionarRegraDeNegocioInvalida(new RegraDeNegocio("Conteudo", "Conteúdo do glossário é inválido."));
        }
    }
}