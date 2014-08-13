using System.Collections.Generic;
using System.Linq;
using log4net;
using log4net.Appender;
using log4net.Core;
using log4net.Repository.Hierarchy;

namespace Rastreabilidade.Tests {

    /// <summary>
    /// Métodos comuns a vários testes
    /// </summary>
    internal abstract class Util {
        /// <summary>
        /// Busca a mensagem dentro do logger e retorna true se encontrar
        /// </summary>
        internal static bool LogHasMessage(string Message, Level LoggingLevel) {
            List<string> messages = new List<string>();
            Hierarchy hierarchy = (Hierarchy)LogManager.GetRepository();

            //isso só vai funcionar se a configuração do log4net estiver correta 
            //(o appender do log principal precisa ser MemoryAppender)
            MemoryAppender appender = (MemoryAppender)hierarchy.Root.GetAppender("MemoryAppender");

            return appender.GetEvents().Any(e => e.Level.Equals(LoggingLevel) && e.MessageObject.ToString().Equals(Message));
        }
    }
}
