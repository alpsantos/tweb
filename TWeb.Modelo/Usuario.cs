using System;
using TWeb.Infra.Dominio;

namespace TWeb.Modelo
{
    public class Usuario : EntidadeBase<int>
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int StatusId { get; set; }
        public virtual Status Status { get; set; }

        public override void Validar()
        {
            throw new NotImplementedException();
        }
    }
}