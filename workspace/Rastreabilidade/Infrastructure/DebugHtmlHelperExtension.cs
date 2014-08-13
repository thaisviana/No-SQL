
using System.Web.Mvc;

namespace Rastreabilidade.Infrastructure {
    /// <summary>
    /// Controller com capacidades de log
    /// </summary>
    public static class DebugHtmlHelperExtension {
        public static bool IsDebug(this HtmlHelper htmlHelper) {
            #if DEBUG
                return true;
            #else
                return false;
            #endif
        }
    }
}