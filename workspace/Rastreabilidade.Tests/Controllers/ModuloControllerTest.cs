using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rastreabilidade.Controllers;
using Rastreabilidade.Entidades;
using Rastreabilidade.Models;
using Rastreabilidade.Tests.Mock;
using log4net.Config;
using Rastreabilidade.Resources;
using log4net.Core;

namespace Rastreabilidade.Tests.Controllers {
    [TestClass]
    public class ModuloControllerTest {

        /// <summary>
        /// Teste do metodo Get do ModuloController
        /// </summary>
        [TestMethod]
        public void GetModulo() {
            ModuloController mc = new ModuloController(new ModuloRepositoryMock());

            ViewResult view = mc.Get("moduloteste");

            Assert.AreEqual(((ModuloModelView)view.Model).Nome, "MóduloTeste", "O módulo retornado não possui os dados corretos...");
        }

        /// <summary>
        /// Teste do metodo Save do ModuloController, criando um novo módulo
        /// </summary>
        [TestMethod]
        public void NewSaveModulo() {
            XmlConfigurator.Configure();
            
            ModuloController controller = new ModuloController(new ModuloRepositoryMock());
            //instanciando objeto correto de mock
            ModuloModelView mmv = new ModuloModelView() {
                Nome = "TesteIrmão",
                Tabelas = new List<Tabela>() {
                    new Tabela {
                        Nome = "Caraca"
                    }
                },
                oldID = null
            };

            FeedbackMessageResponse response = controller.Save(mmv).Data as FeedbackMessageResponse;
            
            //verficando se a operação retornou sucesso
            Assert.AreEqual(response.Status, Status.SUCCESS, "O modulo não pode ser salvo, mesmo estando correto...");

            //verificando se a mensagem de resposta foi correta
            Assert.AreEqual(response.Message,
                string.Format(Messages.SUCCESS_ModuleSaved, mmv.Nome),
                "A mensagem de sucesso ao ter salvo o modulo está errada");

            //verificando se a mensagem de log foi salva
            string formatedLogMessage = string.Format(Log.INFO_ModuleSaved, mmv.Slug);
            Assert.IsTrue(Util.LogHasMessage(formatedLogMessage, Level.Info),
                "A mensagem de log não foi salva corretamente");
        }

        /// <summary>
        /// Teste do metodo Save do ModuloController, editando um módulo já existente
        /// </summary>
        [TestMethod]
        public void EditSaveModulo() {
            XmlConfigurator.Configure();

            ModuloController controller = new ModuloController(new ModuloRepositoryMock());

            ModuloModelView mmvget = (ModuloModelView)controller.Get("nome").Model;
            mmvget.Nome = "NovoNome";
            mmvget.oldID = "nome";

            FeedbackMessageResponse response = controller.Save(mmvget).Data as FeedbackMessageResponse;
            
            //verficando se a operação retornou sucesso
            Assert.AreEqual(response.Status, Status.SUCCESS, "O modulo não pode ser salvo, mesmo estando correto...");

            //verificando se a mensagem de resposta foi correta
            Assert.AreEqual(response.Message,
                string.Format(Messages.SUCCESS_ModuleSaved, mmvget.Nome),
                "A mensagem de sucesso ao ter salvo o modulo está errada");

            //verificando se a mensagem de log foi salva
            string formatedLogMessage = string.Format(Log.INFO_ModuleSaved, mmvget.Slug);
            Assert.IsTrue(Util.LogHasMessage(formatedLogMessage, Level.Info),
                "A mensagem de log não foi salva corretamente");
        }

        /// <summary>
        /// Teste do metodo Save do TabelaController, inserindo um nome vazio. Deve retornar erro.
        /// </summary>
        [TestMethod]
        public void SaveEmptyModulo() {
            XmlConfigurator.Configure();

            ModuloController controller = new ModuloController(new ModuloRepositoryMock());

            ModuloModelView mmv = new ModuloModelView();
            mmv.oldID = null;

            FeedbackMessageResponse response = controller.Save(mmv).Data as FeedbackMessageResponse;

            //verficando se a operação retornou fail
            Assert.AreEqual(response.Status, Status.FAIL, "O controller deveria ter acusado o erro na tentativa de salvar");

            //verificando se a mensagem de resposta foi correta
            Assert.AreEqual(response.Message,
                Messages.FAIL_EmptyModule,
                "A mensagem de falha ao tentar salvar um modulo vazio está errada");

            //verificando se a mensagem de log foi salva
            Assert.IsTrue(Util.LogHasMessage(Log.ERROR_TryingToSaveEmptyModule, Level.Error),
                "A mensagem de log não foi salva corretamente");
        }

        /// <summary>
        /// Teste do metodo Delete do ModuloController
        /// </summary>
        [TestMethod]
        public void DeleteModulo() {
            XmlConfigurator.Configure();

            ModuloController controller = new ModuloController(new ModuloRepositoryMock());

            ModuloModelView mmvget = (ModuloModelView)controller.Get("teste").Model;

            FeedbackMessageResponse response = controller.Delete(mmvget.Slug).Data as FeedbackMessageResponse;

            //verficando se a operação retornou sucesso
            Assert.AreEqual(response.Status, Status.SUCCESS, "O modulo não pode ser deletado, mesmo estando correto...");

            //verificando se a mensagem de resposta foi correta
            Assert.AreEqual(response.Message,
                string.Format(Messages.SUCCESS_ModuleDeleted, mmvget.Slug),
                "A mensagem de sucesso ao ter deletado o modulo está errada");

            //verificando se a mensagem de log foi salva
            string formatedLogMessage = string.Format(Log.INFO_ModuleDeleted, mmvget.Slug);
            Assert.IsTrue(Util.LogHasMessage(formatedLogMessage, Level.Info),
                "A mensagem de log não foi salva corretamente");
        }
    }    
}
