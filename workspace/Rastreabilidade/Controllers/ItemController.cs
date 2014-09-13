using System.Web.Mvc;
using BIC.Entidades.Persistence;
using BIC.Entidades;
using BIC.Infrastructure;
using BIC.Models;
using System;
using System.Linq;
using System.Collections.Generic;

namespace BIC.Controllers
{
    public class ItemController : LoggableController {
        //
        // GET: /Item/

        private IRepository<Item> _itemRepository;
        private IRepository<Tema> _temaRepository;

        public ItemController(IRepository<Item> itemRepository, IRepository<Tema> temaRepository) {
            _itemRepository = itemRepository;
            _temaRepository = temaRepository;

        }


        [HttpGet]
        public ActionResult Get(ItemConhecimentoModelView model) {

            if (string.IsNullOrWhiteSpace(Request.QueryString["tema_id"]) && model.Tema == 0) {
                return View(new ItemConhecimentoModelView());
            }

            Sluggable i = model.MyBase();
            ItemConhecimentoModelView item = (ItemConhecimentoModelView)i;
            

            if(model.Tema != 0 && !string.IsNullOrWhiteSpace(model.Nome)){
                IEnumerable <Tema> temas =_temaRepository.All();

                Tema t = temas.First(tema => tema.ID == model.Tema);

                /*IEnumerable<Tema> results = (from tema in temas
                                            where tema.ID == model.Tema
                                            select tema);*/

                model.tema_id = model.Tema.ToString();
                model.tema_Nome = t.Nome;
                return View((ItemConhecimentoModelView)i);
            
            }

            item.tema_id = Request.QueryString["tema_id"];
            item.tema_Nome = Request.QueryString["tema_Nome"];
            return View(item);
            
         }


    }
}
