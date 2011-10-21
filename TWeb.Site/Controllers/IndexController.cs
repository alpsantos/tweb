using System.Web.Mvc;
using System.Linq;
using TWeb.Portal.Models;
using TWeb.Portal.ViewModel;
using TWeb.Repositorio;
using TWeb.Site.Extensao;
using System;


namespace TWeb.Portal.Controllers
{
    public class IndexController : Controller
    {
        public ActionResult Index()
        {
            var homeViewModel = new HomeViewModel();

            PrefeituraRepositorio prefeituraRepositorio = new PrefeituraRepositorio();
            
            homeViewModel.TotalPrefeitura = prefeituraRepositorio.BuscarColecao(null).Count();

            homeViewModel.TotalPrefeiturasRegulamentados = prefeituraRepositorio.BuscarColecao(pref => pref.Aderencia >= 75).Count();

            homeViewModel.TotalPrefeiturasPendentes = prefeituraRepositorio.BuscarColecao(pref => pref.Aderencia < 75).Count();

            PrefeituraRepositorio r = new PrefeituraRepositorio();
       
            return View(homeViewModel);
        }

        [HttpPost]
        public JsonResult PaginacaoPrefeitura(int? paginacao)
        {
            try
            {
                System.Threading.Thread.Sleep(500);
                PrefeituraRepositorio prefeituraRepositorio = new PrefeituraRepositorio();

                int pagina = paginacao == null ? 1 : (int)paginacao;

                var prefeiturasPaginadas = prefeituraRepositorio.BuscarColecao(null).Paginacao(pagina, 5).ToList();

                return Json(prefeiturasPaginadas.Conveter());
            }
            catch (Exception ex)
            {
                return Json(new { msg = ex.Message });
            }
        }
    }
}
