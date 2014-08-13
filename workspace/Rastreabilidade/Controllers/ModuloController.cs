using System.Web.Mvc;
using Rastreabilidade.Entidades;
using Rastreabilidade.Entidades.Persistence;
using Rastreabilidade.Infrastructure;
using Rastreabilidade.Models;
using Rastreabilidade.Util;
using Rastreabilidade.Resources;

namespace Rastreabilidade.Controllers {
    /// <summary>
    /// Controller que controla CRUD de Módulos
    /// </summary>
    public class ModuloController : LoggableController {

        private IRepository<Modulo> _moduloRepository;

        /// <summary>
        /// Construtor que instancia o repositório de acordo com o tipo
        /// </summary>
        public ModuloController(IRepository<Modulo> moduloRepository) {
            _moduloRepository = moduloRepository;
        }

        /// <summary>
        /// Método para buscar um Módulo existente ou levar para a página de criação de um Módulo novo
        /// </summary>
        public ViewResult Get(string id) {
            if (string.IsNullOrWhiteSpace(id)) {
                return View(new ModuloModelView());
            }

            ModuloModelView model = new ModuloModelView(_moduloRepository.Single(id.GenerateSlug()));
            log.DebugFormat(Log.DEBUG_GetModulo, id, model ?? null);
            return View(model);
        }

        /// <summary>
        /// Método para salvar algum novo Módulo ou alterar algum já existente no banco
        /// </summary>
        [HttpPost]
        public JsonResult Save(ModuloModelView model) {

            FeedbackMessageResponse response;
            
            try {
                Modulo updateModel = new Modulo();
                
                if (string.IsNullOrWhiteSpace(model.oldID)) {
                    updateModel.Nome = model.Nome;
                    updateModel.Tabelas = model.Tabelas;
                    _moduloRepository.Save(updateModel);

                    response = new FeedbackMessageResponse {
                        Status = Models.Status.SUCCESS,
                        Title = Messages.SUCCESS,
                        Message = string.Format(Messages.SUCCESS_ModuleSaved, model.Nome)
                    };
                    log.InfoFormat(Log.INFO_ModuleSaved, model.Slug);

                    return Json(response);
                }
                updateModel = _moduloRepository.Single(model.oldID.GenerateSlug());

                if (!updateModel.Nome.Equals(model.Nome)) {
                    _moduloRepository.Delete(model.oldID.GenerateSlug());
                    updateModel.Nome = model.Nome;
                }

                updateModel.Tabelas = model.Tabelas;
                _moduloRepository.Save(updateModel);

                response = new FeedbackMessageResponse {
                    Status = Models.Status.SUCCESS,
                    Title = Messages.SUCCESS,
                    Message = string.Format(Messages.SUCCESS_ModuleSaved, model.Nome)
                };
                log.InfoFormat(Log.INFO_ModuleSaved, model.Slug);
            } catch (EmptyKeyException) {
            
                response = new FeedbackMessageResponse {
                    Status = Models.Status.FAIL,
                    Title = Messages.FAIL,
                    Message = Messages.FAIL_EmptyModule
                };
                log.ErrorFormat(Log.ERROR_TryingToSaveEmptyModule);
            }

            return Json(response);
        }

        /// <summary>
        /// Método para deletar algum Módulo no banco
        /// </summary>

        [HttpPost]
        public JsonResult Delete(string id) {
            FeedbackMessageResponse response;
            
            _moduloRepository.Delete(id.GenerateSlug());

            response = new FeedbackMessageResponse {
                Status = Models.Status.SUCCESS,
                Title = Messages.SUCCESS,
                Message = string.Format(Messages.SUCCESS_ModuleDeleted, id)
            };
            log.InfoFormat(Log.INFO_ModuleDeleted, id);

            return Json(response);
        }
    }
}
