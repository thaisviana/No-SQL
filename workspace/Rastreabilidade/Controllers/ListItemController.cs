using System.Web.Mvc;
using BIC.Infrastructure;
using BIC.Entidades.Persistence;
using BIC.Entidades;
using System.Collections.Generic;

namespace BIC.Controllers
{
    public class ListItemController : LoggableController {


        private IRepository<Item> _itemRepository;
        private IRepository<Tema> _temaRepository;

        public ListItemController(IRepository<Item> itemRepository, IRepository<Tema> temaRepository) {
            _itemRepository = itemRepository;
            _temaRepository = temaRepository;
        }


        public ActionResult Get(){
            ViewBag.Tema = Request.Params["tema"];
            ViewBag.NomeTema = Request.Params["nomeTema"];
            return View(_itemRepository.All());
        }

    }
}
