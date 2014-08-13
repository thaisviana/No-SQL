using System.Web.Mvc;
using Rastreabilidade.Entidades;
using Rastreabilidade.Entidades.Persistence;
using Rastreabilidade.Infrastructure;
using Rastreabilidade.Util;
using Rastreabilidade.Resources;
using Rastreabilidade.Models;

namespace Rastreabilidade.Controllers {
    /// <summary>
    /// Controller que controla CRUD de Casos de Uso
    /// </summary>
    public class CasoUsoController : LoggableController {

        private IRepository<CasoUso> _casoUsoRepository;

        /// <summary>
        /// Construtor que instancia o repositório de acordo com o tipo
        /// </summary>
        public CasoUsoController(IRepository<CasoUso> casoUsoRepository) {
            _casoUsoRepository = casoUsoRepository;
        }

        /// <summary>
        /// Método para buscar um Caso de Uso existente ou levar para a página de criação de um Caso de Uso novo
        /// </summary>
        public ViewResult Get(string id) {
            if (string.IsNullOrWhiteSpace(id)) {
                return View(new CasoUsoModelView());
            }

            CasoUsoModelView model = new CasoUsoModelView(_casoUsoRepository.Single(id.GenerateSlug()));
            log.DebugFormat(Log.DEBUG_GetCasoUso, id, model ?? null);
            return View(model);
        }

        /// <summary>
        /// Método para salvar algum novo Caso de Uso ou alterar algum já existente no banco
        /// </summary>
        [HttpPost]
        public JsonResult Save(CasoUsoModelView model) {
            FeedbackMessageResponse response;
            try {
                CasoUso updateModel = new CasoUso();

                if (string.IsNullOrWhiteSpace(model.oldID)) {
                    updateModel.Nome = model.Nome;
                    updateModel.Menu = model.Menu;
                    updateModel.Referencias = model.Referencias;
                    _casoUsoRepository.Save(updateModel);

                    response = new FeedbackMessageResponse {
                        Status = Models.Status.SUCCESS,
                        Title = Messages.SUCCESS,
                        Message = string.Format(Messages.SUCCESS_UseCaseSaved, model.Nome)
                    };
                    log.InfoFormat(Log.INFO_UseCaseSaved, model.Slug);

                    return Json(response);
                }

                updateModel = _casoUsoRepository.Single(model.oldID.GenerateSlug());

                if (!updateModel.Nome.Equals(model.Nome)) {
                    _casoUsoRepository.Delete(model.oldID.GenerateSlug());
                    updateModel.Nome = model.Nome;
                }

                _casoUsoRepository.Save(updateModel);

                response = new FeedbackMessageResponse {
                    Status = Models.Status.SUCCESS,
                    Title = Messages.SUCCESS,
                    Message = string.Format(Messages.SUCCESS_UseCaseSaved, model.Nome)
                };
                log.InfoFormat(Log.INFO_UseCaseSaved, model.Slug);
            } catch (EmptyKeyException) {

                response = new FeedbackMessageResponse {
                    Status = Models.Status.FAIL,
                    Title = Messages.FAIL,
                    Message = Messages.FAIL_EmptyUseCase
                };
                log.ErrorFormat(Log.ERROR_TryingToSaveEmptyUseCase);
            }
            return Json(response);
        }

        /// <summary>
        /// Método para deletar algum Caso de Uso no banco
        /// </summary>
        [HttpPost]
        public JsonResult Delete(string id) {

            FeedbackMessageResponse response;

            _casoUsoRepository.Delete(id.GenerateSlug());

            response = new FeedbackMessageResponse {
                Status = Models.Status.SUCCESS,
                Title = Messages.SUCCESS,
                Message = string.Format(Messages.SUCCESS_UseCaseDeleted, id)
            };
            log.InfoFormat(Log.INFO_UseCaseDeleted, id);

            return Json(response);
        }
    }
}
