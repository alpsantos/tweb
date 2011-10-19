using System.Collections.Generic;
using TWeb.Infra.Dominio;

namespace TWeb.Modelo
{
    public class Status : ObjetoDeValorBase<int>
    {
        public string Descricao { get; set; }

        public ICollection<Prefeitura> Prefeituras { get; set; }

        protected override void Validar()
        {

        }
    }
}