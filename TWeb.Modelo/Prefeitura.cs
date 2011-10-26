using System;
using TWeb.Infra.Dominio;

namespace TWeb.Modelo
{
    public class Prefeitura : EntidadeBase<int>
    {
        public string Nome { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        public int Aderencia { get; set; }
        public int Ordem { get; set; }
        public byte[] Brasao { get; set; }
        //public string Prefeito { get; set; }

        //public DateTime DataCriacao { get; set; }
        //public DateTime DataAtualizacao { get; set; }

        public int StatusId { get; set; }
        public Status Status { get; set; }

        public int DocumentosId { get; set; }
        public virtual Documentos Documentos { get; set; }

        public override void Validar()
        {
            if (String.IsNullOrEmpty(this.Nome))
                base.AdicionarRegraDeNegocioInvalida(new RegraDeNegocio("Nome", "Nome da Prefeitura inválido."));

            if (this.Aderencia <= 0)
                base.AdicionarRegraDeNegocioInvalida(new RegraDeNegocio("Aderencia", "Porcentagem de aderência invalida."));

            //Todo : Terminar validações
        }
    }
}
