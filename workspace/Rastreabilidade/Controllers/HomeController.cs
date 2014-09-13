using System.Web.Mvc;
using BIC.Infrastructure;
using BIC.Models;
using BIC.Entidades;
using BIC.Entidades.Persistence;
using BIC.Util;
using System;

namespace BIC.Controllers {
    public class HomeController : LoggableController {

        
        private IRepository<Item> _itemRepository;
        private IRepository<Tema> _temaRepository;

        public HomeController(IRepository<Item> itemRepository, IRepository<Tema> temaRepository) {
            _itemRepository = itemRepository;
            _temaRepository = temaRepository;

        }

        public ActionResult Get(ItemConhecimentoModelView model) {
            Sluggable i = model.MyBase();
                        
            if (string.IsNullOrWhiteSpace(i.Nome)) {
                ViewBag.Message = "Trabalho No-SQL.";
                return View(_temaRepository.All());
            }
            var a = Request.Form;
            string value = Request.Form.GetValues("tema_id")[0];
            i.Tema = Convert.ToDouble(value);
            i.Data = DateTime.Now.ToString();
            _itemRepository.Save((Item)i);

            ViewBag.Message = "Item inserido com sucesso.";
            model.tema_id = Request.Form.GetValues("tema_id")[0];
            model.tema_Nome = Request.Form.GetValues("tema_Nome")[0];
            return RedirectToAction("Get", "Item", model); ;
            
        }


        [HttpPost]
        public ActionResult Search() {
            if (string.IsNullOrWhiteSpace(Request.Form.GetValues("srch-term")[0])) {
                    ViewBag.Message = "Nenhum resultado encontrado";
                    return View(_temaRepository.All());
                
            }
            return RedirectToAction("Get", "Item", new ItemConhecimentoModelView(_itemRepository.Single(Request.Form.GetValues("srch-term")[0].GenerateSlug())));
        }

    }
}
