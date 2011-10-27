using System;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using TWeb.Portal.ViewModel;
using TWeb.Repositorio;
using TWeb.Site.Atributos;
using TWeb.Site.Extensao;
using TWeb.Site.Models;
using System.Collections.Generic;

namespace TWeb.Portal.Controllers
{
    public class PrefeituraController : Controller
    {
        private int _quantidadePaginacaoExibir = 7;
        private int _quantidadePaginaExibir = 5;

        [HttpPost]
        [ActionName("Pagina")]
        [AceitarParametros(Nome = "button", Valor = "Buscar")]
        public ActionResult BuscarPrefeituras(string busca)
        {
            return Pagina(1, busca);
        }

        public ActionResult Pagina(int? id, string busca)
        {
            var homeViewModel = new HomeViewModel();

            var indicePagina = id == null ? 1 : (int)id;

            Dictionary<string, string> parametros = new Dictionary<string, string>();

            parametros.Add("busca", busca);

            MontarView(homeViewModel, indicePagina, parametros);

            return View(homeViewModel);
        }

        public ActionResult Paginacao(TWeb.Site.ViewModel.Paginacao paginacao)
        {
            return PartialView("PaginacaoView", paginacao);
        }

        public ActionResult Prefeituras(Prefeitura prefeitura)
        {
            return PartialView("Prefeitura", prefeitura);
        }

        private void MontarView(HomeViewModel homeViewModel, int indicePagina, Dictionary<string, string> parametros)
        {
            if (string.IsNullOrEmpty(parametros["busca"]))
            {
                MontarView(homeViewModel, indicePagina, null, parametros);
            }
            else
            {
                MontarView(homeViewModel, indicePagina, pref => pref.Nome.StartsWith(parametros["busca"]), parametros);
            }
        }

        private void MontarView(HomeViewModel homeViewModel, int indicePagina, Expression<Func<Modelo.Prefeitura, bool>> expressao, Dictionary<string,string> parametros)
        {
            PrefeituraRepositorio prefeituraRepositorio = new PrefeituraRepositorio();

            homeViewModel.TotalPrefeitura = prefeituraRepositorio.BuscarColecao(null).Count();

            homeViewModel.TotalPrefeiturasRegulamentados = prefeituraRepositorio.BuscarColecao(pref => pref.Aderencia >= 75).Count();

            homeViewModel.TotalPrefeiturasPendentes = prefeituraRepositorio.BuscarColecao(pref => pref.Aderencia < 75).Count();

            homeViewModel.Prefeituras = prefeituraRepositorio.BuscarColecao(expressao).Paginacao(indicePagina, _quantidadePaginaExibir).ToList().Conveter();

            ///////////// configuração da paginação /////////////
            homeViewModel.Paginacao = new Site.ViewModel.Paginacao();

            homeViewModel.Paginacao.Controller = "Prefeitura";

            homeViewModel.Paginacao.Action = "Pagina";

            homeViewModel.Paginacao.Parametros = parametros;

            homeViewModel.Paginacao.IndiceAtual = indicePagina;

            homeViewModel.Paginacao.TotalRegistro = prefeituraRepositorio.BuscarColecao(expressao).Count();

            homeViewModel.Paginacao.QuantidadeRegistroExibicao = _quantidadePaginaExibir;

            homeViewModel.Paginacao.QuantidadePaginacaoExibicao = _quantidadePaginacaoExibir;
        }

        #region Ajax

        [HttpPost]
        public JsonResult PaginacaoPrefeitura(int? paginacao)
        {
            try
            {
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

        #endregion
    }
}
