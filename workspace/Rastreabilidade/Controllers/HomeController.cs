using System.Configuration;
using System.Web.Mvc;
using BIC.Infrastructure;
using BIC.Models;

namespace BIC.Controllers {
    public class HomeController : LoggableController {

        public ActionResult Get(ItemConhecimentoModelView model) {
            if (string.IsNullOrWhiteSpace(model.Nome)) {
                ViewBag.Message = "Welcome to ASP.NET MVC!: " + ConfigurationManager.AppSettings["webpages:Version"];
                log.Info("É noiz manolão");
                return View();
            }
            return View("Item/Get", model);
            
        }

        [HttpPost]
        public ActionResult HandleForm(ItemConhecimentoModelView model) {

            string nome = model.Nome;

            return View("Get", model);
        }

    }
}
