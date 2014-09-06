using System.Web.Mvc;
using log4net;

namespace BIC.Infrastructure {
    /// <summary>
    /// Controller com capacidades de log
    /// </summary>
    public abstract class LoggableController : Controller {

        /// <summary>
        /// Expõe a implementação de ILog do log4Net
        /// Exmeplo de uso: log.Info("Essa é uma mensagem de log")
        /// </summary>
        protected ILog log { get; set; }

        /// <summary>
        /// Construtor que instancia o logger de acordo com o nome do objeto
        /// </summary>
        public LoggableController () {
            this.log = LogManager.GetLogger(this.GetType());
        }
    }
}

