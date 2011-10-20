using System.Collections.Generic;
using TWeb.Portal.Models;
using TWeb.Site.Models;

namespace TWeb.Portal.ViewModel
{
    public class HomeViewModel
    {
        public List<Post> Rss { get; set; }

        public List<Prefeitura> Municipios { get; set; }

        public int TotalMunicipios { get; set; }

        public int TotalMunicipiosRegulamentados { get; set; }

        public int TotalMunicipiosPendentes { get; set; }
    }
}