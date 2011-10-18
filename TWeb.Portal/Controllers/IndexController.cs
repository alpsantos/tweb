using System.Web.Mvc;
using TWeb.Portal.Models;
using TWeb.Portal.ViewModel;

namespace TWeb.Portal.Controllers
{
    public class IndexController : Controller
    {
        public ActionResult Index()
        {
            var homeViewModel = new HomeViewModel();
            homeViewModel.Rss = new RSS().LerPosts();
            return View(homeViewModel);
        }

    }
}
