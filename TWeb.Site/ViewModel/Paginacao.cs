using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TWeb.Site.ViewModel
{
    public class Paginacao
    {
        public string Controller { get; set; }

        public string Action { get; set; }

        public int QuantidadeRegistroExibicao { get; set; }

        public int QuantidadePaginacaoExibicao { get; set; }

        public int IndiceAtual { get; set; }

        public int TotalRegistro { get; set; }

        public int TotalPaginacao
        {
            get
            {
                var resto = TotalRegistro % QuantidadeRegistroExibicao == 0 ? 0 : 1;
                var totalPaginacao = TotalRegistro / QuantidadeRegistroExibicao;

                return totalPaginacao + resto;
            }
        }

        public int IndiceMedio
        {
            get
            {
                var resto = QuantidadeRegistroExibicao % 2 != 0 ? 0 : 1;
                var totalExibicao = QuantidadePaginacaoExibicao / 2;

                return totalExibicao + resto;
            }
        }
    }
}