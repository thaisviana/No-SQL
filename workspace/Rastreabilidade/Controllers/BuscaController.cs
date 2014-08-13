using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Rastreabilidade.Entidades;
using Rastreabilidade.Entidades.Persistence;
using Rastreabilidade.Infrastructure;
using Rastreabilidade.Resources;

namespace Rastreabilidade.Controllers {

    /// <summary>
    /// Controle que busca 
    /// </summary>
    //TODO: capturar dados de IP para colocar nas mensagens
    public class BuscaController : LoggableController {

        private IRepository<Busca> _searchRepository;

        public BuscaController(IRepository<Busca> searchRepository) {
            _searchRepository = searchRepository;
        } 

        /// <summary>
        /// Executa uma busca apenas pelo nome de módulos, tabelas ou casos de uso
        /// </summary>
        [HttpGet]
        public JsonResult Get(string q) {
            
            IEnumerable<Busca> searchResult = _searchRepository.All().Where(b => b.Nome.Contains(q));

            log.Debug(string.Format(Log.DEBUG_SearchPerformed, q, searchResult.Count()));

            return Json(searchResult, JsonRequestBehavior.AllowGet);
        }

    }
}
