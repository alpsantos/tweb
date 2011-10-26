using System.Reflection;
using System.Web.Mvc;

namespace TWeb.Site.Atributos
{
    public class AceitarParametrosAttribute : ActionMethodSelectorAttribute
    {
        public string Nome { get; set; }
        public string Valor { get; set; }

        public override bool IsValidForRequest(ControllerContext controllerContext, MethodInfo methodInfo)
        {
            var req = controllerContext.RequestContext.HttpContext.Request;
            return req.Form[this.Nome] == this.Valor;
        }
    }
}