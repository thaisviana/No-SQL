using System.Configuration;
using System.Web.Mvc;
using Rastreabilidade.Infrastructure;

namespace Rastreabilidade.Controllers {
    public class HomeController : LoggableController {
        
        public ActionResult Get() {
            ViewBag.Message = "Welcome to ASP.NET MVC!: " + ConfigurationManager.AppSettings["webpages:Version"];
            log.Info("É noiz manolão");
            return View();
        }

    }
}
