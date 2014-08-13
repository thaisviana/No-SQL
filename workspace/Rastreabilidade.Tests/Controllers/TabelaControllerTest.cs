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
    public class TabelaControllerTest {
        
        /// <summary>
        /// Teste do metodo Get do TabelaController
        /// </summary>
        [TestMethod]
        public void GetTabela() {
            TabelaController controller = new TabelaController(new TabelaRepositoryMock());

            ViewResult view = controller.Get("tabelateste");

            Assert.AreEqual(((Tabela)view.Model).Nome, "TabelaTeste", "A tabela retornada não possui os dados corretos...");
        }

        /// <summary>
        /// Teste do metodo Save do TabelaController, criando uma nova tabela
        /// </summary>
        [TestMethod]
        public void NewSaveTabela() {
            XmlConfigurator.Configure();
            
            TabelaController controller = new TabelaController(new TabelaRepositoryMock());

            //instanciando objeto correto de mock
            TabelaModelView tmv = new TabelaModelView() {
                Nome = "TesteTabelas",
                oldID = null
            };
            
            FeedbackMessageResponse response = controller.Save(tmv).Data as FeedbackMessageResponse;

            //verficando se a operação retornou sucesso
            Assert.AreEqual(response.Status, Status.SUCCESS, "A tabela não pode ser salva, mesmo estando correto...");

            //verificando se a mensagem de resposta foi correta
            Assert.AreEqual(response.Message,
                string.Format(Messages.SUCCESS_TableSaved, tmv.Nome),
                "A mensagem de sucesso ao ter salvo a tabela está errada");

            //verificando se a mensagem de log foi salva
            string formatedLogMessage = string.Format(Log.INFO_TableSaved, tmv.Slug);
            Assert.IsTrue(Util.LogHasMessage(formatedLogMessage, Level.Info),
                "A mensagem de log não foi salva corretamente");
        }

        /// <summary>
        /// Teste do metodo Save do TabelaController, editando uma tabela já existente
        /// </summary>
        [TestMethod]
        public void EditSaveTabela() {
            XmlConfigurator.Configure();

            TabelaController controller = new TabelaController(new TabelaRepositoryMock());

            TabelaModelView tget = (TabelaModelView)controller.Get("nome").Model;
            tget.Nome = "NovoNome";
            tget.oldID = "nome";

            FeedbackMessageResponse response = controller.Save(tget).Data as FeedbackMessageResponse;

            //verficando se a operação retornou sucesso
            Assert.AreEqual(response.Status, Status.SUCCESS, "A tabela não pode ser salva, mesmo estando correto...");

            //verificando se a mensagem de resposta foi correta
            Assert.AreEqual(response.Message,
                string.Format(Messages.SUCCESS_TableSaved, tget.Nome),
                "A mensagem de sucesso ao ter salvo a tabela está errada");

            //verificando se a mensagem de log foi salva
            string formatedLogMessage = string.Format(Log.INFO_TableSaved, tget.Slug);
            Assert.IsTrue(Util.LogHasMessage(formatedLogMessage, Level.Info),
                "A mensagem de log não foi salva corretamente");
        }

        /// <summary>
        /// Teste do metodo Save do TabelaController, inserindo um nome vazio. Deve retornar erro.
        /// </summary>
        [TestMethod]
        public void SaveEmptyTabela() {
            XmlConfigurator.Configure();

            TabelaController controller = new TabelaController(new TabelaRepositoryMock());

            TabelaModelView tmv = new TabelaModelView();
            tmv.oldID = null;

            FeedbackMessageResponse response = controller.Save(tmv).Data as FeedbackMessageResponse;

            //verficando se a operação retornou fail
            Assert.AreEqual(response.Status, Status.FAIL, "O controller deveria ter acusado o erro na tentativa de salvar");

            //verificando se a mensagem de resposta foi correta
            Assert.AreEqual(response.Message,
                Messages.FAIL_EmptyTable,
                "A mensagem de falha ao tentar salvar uma tabela vazia está errada");

            //verificando se a mensagem de log foi salva
            Assert.IsTrue(Util.LogHasMessage(Log.ERROR_TryingToSaveEmptyTable, Level.Error),
                "A mensagem de log não foi salva corretamente");
        }

        /// <summary>
        /// Teste do metodo Delete do TabelaController
        /// </summary>
        [TestMethod]
        public void DeleteTabela() {
            XmlConfigurator.Configure();

            TabelaController controller = new TabelaController(new TabelaRepositoryMock());

            Tabela tget = (Tabela)controller.Get("teste").Model;

            FeedbackMessageResponse response = controller.Delete(tget.Slug).Data as FeedbackMessageResponse;

            //verficando se a operação retornou sucesso
            Assert.AreEqual(response.Status, Status.SUCCESS, "A tabela não pode ser deletada, mesmo estando correto...");

            //verificando se a mensagem de resposta foi correta
            Assert.AreEqual(response.Message,
                string.Format(Messages.SUCCESS_TableDeleted, tget.Slug),
                "A mensagem de sucesso ao ter deletado a tabela está errada");

            //verificando se a mensagem de log foi salva
            string formatedLogMessage = string.Format(Log.INFO_TableDeleted, tget.Slug);
            Assert.IsTrue(Util.LogHasMessage(formatedLogMessage, Level.Info),
                "A mensagem de log não foi salva corretamente");
        }
    }
}
