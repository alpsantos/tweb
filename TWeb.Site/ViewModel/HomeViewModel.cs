using System.Collections.Generic;
using TWeb.Portal.Models;
using TWeb.Site.ViewModel;

namespace TWeb.Portal.ViewModel
{
    public class HomeViewModel
    {
        public int TotalPrefeitura {get;set;}

        public int TotalPrefeiturasPendentes { get; set; }

        public int TotalPrefeiturasRegulamentados { get; set; }

        public List<TWeb.Site.Models.Prefeitura> Prefeituras { get; set; }

        public int IndicePaginaAtual { get; set; }

        public int TotalPaginacao { get; set; }

        public Paginacao Paginacao
        {
            get;

            set;
        }
    }
}