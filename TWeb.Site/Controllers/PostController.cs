using System.Web.Mvc;
using TWeb.Portal.Models;

namespace TWeb.Site.Controllers
{
    public class PostController : Controller
    {
        public ActionResult Recente()
        {
            return PartialView("PostsRecentes", new RSS().LerPosts());
        }
    }
}
