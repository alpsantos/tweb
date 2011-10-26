using System.Collections.Generic;

namespace TWeb.Site.ViewModel
{
    public class Paginacao
    {
        public string Action { get; set; }

        public string Controller { get; set; }

        public int IndiceAtual { get; set; }

        public int QuantidadePaginacaoExibicao { get; set; }

        public int QuantidadeRegistroExibicao { get; set; }

        public int TotalRegistro { get; set; }

        public Dictionary<string,string> Parametros {get;set;}

        public int IndiceMedio
        {
            get
            {
                var resto = QuantidadeRegistroExibicao % 2 != 0 ? 0 : 1;
                var totalExibicao = QuantidadePaginacaoExibicao / 2;

                return totalExibicao + resto;
            }
        }

        public int TotalPaginacao
        {
            get
            {
                var resto = TotalRegistro % QuantidadeRegistroExibicao == 0 ? 0 : 1;
                var totalPaginacao = TotalRegistro / QuantidadeRegistroExibicao;

                return totalPaginacao + resto;
            }
        }
    }
}