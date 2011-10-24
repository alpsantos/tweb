using System.Web.Mvc;
using System.Linq;
using TWeb.Portal.Models;
using TWeb.Portal.ViewModel;
using TWeb.Repositorio;
using TWeb.Site.Extensao;
using System;
using TWeb.Site.Models;
using TWeb.Site.Controllers;

namespace TWeb.Portal.Controllers
{
    public class PrefeituraController : Controller
    {
        public ActionResult Pagina(int? id)
        {
            var homeViewModel = new HomeViewModel();

            int quantidadePaginaExibir = 5;

            int quantidadePaginacaoExibir = 7;

            var indicePagina = id == null ? 1: (int)id;

            PrefeituraRepositorio prefeituraRepositorio = new PrefeituraRepositorio();

            homeViewModel.TotalPrefeitura = prefeituraRepositorio.BuscarColecao(null).Count();

            homeViewModel.TotalPrefeiturasRegulamentados = prefeituraRepositorio.BuscarColecao(pref => pref.Aderencia >= 75).Count();

            homeViewModel.TotalPrefeiturasPendentes = prefeituraRepositorio.BuscarColecao(pref => pref.Aderencia < 75).Count();

            homeViewModel.Prefeituras = prefeituraRepositorio.BuscarColecao(null).Paginacao(indicePagina, quantidadePaginaExibir).ToList().Conveter();

            ///////////// configuração da paginação /////////////
            homeViewModel.Paginacao = new Site.ViewModel.Paginacao();

            homeViewModel.Paginacao.Controller = "Prefeitura";

            homeViewModel.Paginacao.Action = "Pagina";

            homeViewModel.Paginacao.IndiceAtual = indicePagina;

            homeViewModel.Paginacao.TotalRegistro = homeViewModel.TotalPrefeitura;

            homeViewModel.Paginacao.QuantidadeRegistroExibicao = quantidadePaginaExibir;

            homeViewModel.Paginacao.QuantidadePaginacaoExibicao = quantidadePaginacaoExibir;
       
            return View(homeViewModel);
        }

        public ActionResult Prefeituras(Prefeitura prefeitura)
        {
            return PartialView("Prefeitura", prefeitura);
        }

        public ActionResult Paginacao(TWeb.Site.ViewModel.Paginacao paginacao)
        {
            return PartialView("PaginacaoView", paginacao);
        }



        //////////////////////////////////////// AJAX //////////////////////////////////////////
        [HttpPost]
        public JsonResult PaginacaoPrefeitura(int? paginacao)
        {
            try
            {
                System.Threading.Thread.Sleep(1000);
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

        [HttpPost]
        public JsonResult ConsultarPrefeituraPorNome(string nomePrefeitura)
        {
            PrefeituraRepositorio prefeituraRepositorio = new PrefeituraRepositorio();

            var prefeiturasEncontradas = prefeituraRepositorio.BuscarColecao(pref => 
                pref.Nome.StartsWith(nomePrefeitura) ||
                pref.Nome.Contains(nomePrefeitura) ||
                pref.Nome.EndsWith(nomePrefeitura));

            var r = prefeiturasEncontradas.ToList().Conveter();
            return Json(prefeiturasEncontradas.ToList().Conveter());
        }
    }
}
