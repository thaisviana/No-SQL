using System.Configuration;
using System.Web.Mvc;
using BIC.Infrastructure;
using BIC.Models;
using BIC.Entidades;
using BIC.Entidades.Persistence;
using System.Collections.Generic;

namespace BIC.Controllers {
    public class HomeController : LoggableController {

        
        private IRepository<Item> _itemRepository;

        public HomeController(IRepository<Item> itemRepository) {
            _itemRepository = itemRepository;

        }

        public ActionResult Get(ItemConhecimentoModelView model) {
            Sluggable i = model.MyBase();
                        
            if (string.IsNullOrWhiteSpace(i.Nome)) {
                ViewBag.Message = "Trabalho No-SQL.";

                return View();
            }

            _itemRepository.Save((Item)i);

            ViewBag.Message = "Item inserido com sucesso.";

            return RedirectToAction("Get", "Item", model); ;
            
        }

        [HttpPost]
        public ActionResult Search() {
            ViewBag.Message = "Passou pelo search";
            Item i = new Item();
            i.Nome = "Oi";
            i.Fonte = "Vim de uma busca";
            i.PerguntaA = "Ninguém me perguntou nada";
            i = _itemRepository.Single("projeto-de-no-sql");
            return RedirectToAction("Get", "Item", new ItemConhecimentoModelView(i) );
        }

    }
}
