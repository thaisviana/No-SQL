
namespace BIC.Models {

    /// <summary>
    /// Respostas básicas as ações de CRUD
    /// Será tipicamente serializado em JSON para alertas
    /// </summary>
    public class FeedbackMessageResponse {

        /// <summary>
        /// Indica se a operação desejada foi executada com sucesso ou não
        /// </summary>
        public Status Status { get; set; }

        /// <summary>
        /// Mensagem de feedback para usuário
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Título da mensagem de feedback
        /// </summary>
        public string Title { get; set; }

    }

    /// <summary>
    /// Estados possíveis de uma resposta
    /// </summary>
    public enum Status { SUCCESS, INFO, ALERT, FAIL }
}
