using System.Web.Mvc;
using BIC.Entidades.Persistence;
using BIC.Entidades;
using BIC.Infrastructure;
using BIC.Models;
using BIC.Util;
using System;

namespace BIC.Controllers
{
    public class ItemController : LoggableController {
        //
        // GET: /Item/

        private IRepository<Item> _itemRepository;

        public ItemController(IRepository<Item> itemRepository) {
            _itemRepository = itemRepository;

        }

        [HttpGet]
        public ActionResult Get(ItemConhecimentoModelView model) {
            Sluggable i = model.MyBase();
            if (string.IsNullOrWhiteSpace(i.Nome)) {
                return View(new ItemConhecimentoModelView());
            }
            return View((ItemConhecimentoModelView) i);
        }

    }
}
