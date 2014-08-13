using System.Web.Mvc;
using Rastreabilidade.Infrastructure;
using Rastreabilidade.Entidades.Persistence;
using Rastreabilidade.Entidades;
using Rastreabilidade.Util;
using Rastreabilidade.Models;
using Rastreabilidade.Resources;

namespace Rastreabilidade.Controllers {
    /// <summary>
    /// Controller que controla CRUD de Tabelas
    /// </summary>
    public class TabelaController : LoggableController {

        private IRepository<Tabela> _tabelaRepository;

        /// <summary>
        /// Construtor que instancia o repositório de acordo com o tipo
        /// </summary>
        public TabelaController(IRepository<Tabela> tabelaRepository) {
            _tabelaRepository = tabelaRepository;
        }

        /// <summary>
        /// Método para buscar uma Tabela existente ou levar para a página de criação de uma Tabela nova
        /// </summary>
        public ViewResult Get(string id) {
            if (string.IsNullOrWhiteSpace(id)) {
                return View(new TabelaModelView());
            }

            TabelaModelView model = new TabelaModelView(_tabelaRepository.Single(id.GenerateSlug()));
            log.DebugFormat(Log.DEBUG_GetTabela, id, model ?? null);
            return View(model);
        }

        /// <summary>
        ///  Método para salvar alguma nova Tabela ou alterar alguma já existente no banco
        /// </summary>
        [HttpPost]
        public JsonResult Save(TabelaModelView model) {
            FeedbackMessageResponse response;

            try {
                Tabela updateModel = new Tabela();

                if (string.IsNullOrWhiteSpace(model.oldID)) {
                    updateModel.Nome = model.Nome;
                    _tabelaRepository.Save(updateModel);

                    response = new FeedbackMessageResponse {
                        Status = Models.Status.SUCCESS,
                        Title = Messages.SUCCESS,
                        Message = string.Format(Messages.SUCCESS_TableSaved, model.Nome)
                    };
                    log.InfoFormat(Log.INFO_TableSaved, model.Slug);

                    return Json(response);
                }
                updateModel = _tabelaRepository.Single(model.oldID.GenerateSlug());

                if (!updateModel.Nome.Equals(model.Nome)) {
                    _tabelaRepository.Delete(model.oldID.GenerateSlug());
                    updateModel.Nome = model.Nome;
                }
                
                _tabelaRepository.Save(updateModel);

                response = new FeedbackMessageResponse {
                    Status = Models.Status.SUCCESS,
                    Title = Messages.SUCCESS,
                    Message = string.Format(Messages.SUCCESS_TableSaved, model.Nome)
                };
                log.InfoFormat(Log.INFO_TableSaved, model.Slug);
            } catch (EmptyKeyException) {

                response = new FeedbackMessageResponse {
                    Status = Models.Status.FAIL,
                    Title = Messages.FAIL,
                    Message = Messages.FAIL_EmptyTable
                };
                log.ErrorFormat(Log.ERROR_TryingToSaveEmptyTable);
            }

            return Json(response);
        }

        /// <summary>
        /// Método para deletar alguma Tabela no banco
        /// </summary>
        [HttpPost]
        public JsonResult Delete(string id) {

            FeedbackMessageResponse response;

            _tabelaRepository.Delete(id.GenerateSlug());

            response = new FeedbackMessageResponse {
                Status = Models.Status.SUCCESS,
                Title = Messages.SUCCESS,
                Message = string.Format(Messages.SUCCESS_TableDeleted, id)
            };
            log.InfoFormat(Log.INFO_TableDeleted, id);

            return Json(response);
        }
    }

}
