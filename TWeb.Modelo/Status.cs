using System.Collections.Generic;
using TWeb.Infra.Dominio;

namespace TWeb.Modelo
{
    public class Status : ObjetoDeValorBase<int> // todo : Resolver se vai mapear no banco ou usar enum com foi em perfil
    {
        public string Descricao { get; set; }

        public ICollection<Prefeitura> Prefeituras { get; set; }

        protected override void Validar()
        {

        }
    }
}