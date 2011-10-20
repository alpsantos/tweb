using System.Web.Mvc;
using TWeb.Portal.Models;
using TWeb.Portal.ViewModel;
using TWeb.Repositorio;

namespace TWeb.Portal.Controllers
{
    public class IndexController : Controller
    {
        public ActionResult Index()
        {
            var homeViewModel = new HomeViewModel();

            homeViewModel.TotalMunicipios = 645;
            homeViewModel.TotalMunicipiosPendentes = 543;
            homeViewModel.TotalMunicipiosRegulamentados = 102;

            PrefeituraRepositorio prefeituraRepositorio = new PrefeituraRepositorio();
            var t =  prefeituraRepositorio.BuscarColecao(s => s.Nome.Contains("São"));
          
            homeViewModel.Rss = new RSS().LerPosts();
            return View(homeViewModel);
        }

    }
}
