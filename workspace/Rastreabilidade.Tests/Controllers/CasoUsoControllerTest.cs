using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rastreabilidade.Controllers;
using Rastreabilidade.Entidades;
using Rastreabilidade.Models;
using Rastreabilidade.Tests.Mock;
using log4net.Config;
using log4net.Core;
using Rastreabilidade.Resources;

namespace Rastreabilidade.Tests.Controllers {
    /// <summary>
    /// Testa as features referentes às açoes de busca
    /// </summary>
    [TestClass]
    public class CasoUsoControllerTest {



        /// <summary>
        /// Testa método Get
        /// </summary>
        [TestMethod]
        public void GetCasoUso() {
            CasoUsoController controller = new CasoUsoController(new CasoUsoRepositoryMock());

            ViewResult view = controller.Get("manter-produto");

            Assert.AreEqual(((CasoUso)view.Model).Nome, "Manter Produto", "O caso de uso retornado não possui os dados corretos...");
        }

        /// <summary>
        /// Salvar um caso de uso corretamente
        /// </summary>
        [TestMethod]
        public void SaveUseCase() {
            XmlConfigurator.Configure();

            CasoUsoController controller = new CasoUsoController(new CasoUsoRepositoryMock());
            //instanciando objeto correto de mock
            CasoUsoModelView ucmv = new CasoUsoModelView {
                Nome = "Caso de uso de Teste"
            };

            FeedbackMessageResponse response = controller.Save(ucmv).Data as FeedbackMessageResponse;

            //verficando se a operação retornou sucesso
            Assert.AreEqual(response.Status, Status.SUCCESS, "O caso uso não pode ser salvo, mesmo estando correto...");

            //verificando se a mensagem de resposta foi correta
            Assert.AreEqual(response.Message, 
                string.Format(Messages.SUCCESS_UseCaseSaved, ucmv.Nome), 
                "A mensagem de sucesso ao ter salvo o caso de uso está errada");

            //verificando se a mensagem de log foi salva
            string formatedLogMessage = string.Format(Log.INFO_UseCaseSaved, ucmv.Slug);
            Assert.IsTrue(Util.LogHasMessage(formatedLogMessage, Level.Info),
                "A mensagem de log não foi salva corretamente");
        }

        /// <summary>
        /// Se tentamos salvar um caso de uso com nome vazio deve retornar erro
        /// </summary>
        [TestMethod]
        public void SaveEmptyUseCase() {
            XmlConfigurator.Configure();

            CasoUsoController controller = new CasoUsoController(new CasoUsoRepositoryMock());

            CasoUsoModelView ucmv = new CasoUsoModelView();
            ucmv.oldID = null;

            FeedbackMessageResponse response = controller.Save(ucmv).Data as FeedbackMessageResponse;

            //verficando se a operação retornou sucesso
            Assert.AreEqual(response.Status, Status.FAIL, "O controller deveria ter acusado o erro na tentativa de salvar");

            //verificando se a mensagem de resposta foi correta
            Assert.AreEqual(response.Message,
                Messages.FAIL_EmptyUseCase,
                "A mensagem de falha tentar salvar um caso de uso vazio está errada");

            //verificando se a mensagem de log foi salva
            Assert.IsTrue(Util.LogHasMessage(Log.ERROR_TryingToSaveEmptyUseCase, Level.Error),
                "A mensagem de log não foi salva corretamente");
        }

        /// <summary>
        /// Teste do metodo Delete do CasoUsoController
        /// </summary>
        [TestMethod]
        public void DeleteTabela() {
            XmlConfigurator.Configure();

            CasoUsoController controller = new CasoUsoController(new CasoUsoRepositoryMock());

            CasoUso ucget = (CasoUso)controller.Get("manter-produto").Model;

            FeedbackMessageResponse response = controller.Delete(ucget.Slug).Data as FeedbackMessageResponse;

            //verficando se a operação retornou sucesso
            Assert.AreEqual(response.Status, Status.SUCCESS, "O Caso de Uso não pode ser deletado, mesmo estando correto...");

            //verificando se a mensagem de resposta foi correta
            Assert.AreEqual(response.Message,
                string.Format(Messages.SUCCESS_UseCaseDeleted, ucget.Slug),
                "A mensagem de sucesso ao ter deletado o caso de uso está errada");

            //verificando se a mensagem de log foi salva
            string formatedLogMessage = string.Format(Log.INFO_UseCaseDeleted, ucget.Slug);
            Assert.IsTrue(Util.LogHasMessage(formatedLogMessage, Level.Info),
                "A mensagem de log não foi salva corretamente");
        }

    }
}
