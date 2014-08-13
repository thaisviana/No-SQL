using System.Text.RegularExpressions;

namespace Rastreabilidade.Util {
    /// <summary>
    /// Injeta o método GenerateSlug no tipo string
    /// </summary>
    public static class SlugStringExtension {

        /// <summary>
        /// Retorna uma string pronta para URL 
        /// removendo os acentos, caracteres especiais e substituindo espaços por '-'
        /// </summary>
        public static string GenerateSlug(this string phrase, int maxSize = 45) {
            string str = phrase.RemoveAccent().ToLower();

            str = Regex.Replace(str, @"[^a-z0-9\s-]", ""); // invalid chars          
            str = Regex.Replace(str, @"\s+", " ").Trim(); // convert multiple spaces into one space  
            str = str.Substring(0, str.Length <= maxSize ? str.Length : maxSize).Trim(); // cut and trim it  
            str = Regex.Replace(str, @"\s", "-"); // hyphens  

            return str;
        }

        /// <summary>
        /// Apenas substitui caracteres acentuados por não acentuados
        /// </summary>
        public static string RemoveAccent(this string txt) {
            byte[] bytes = System.Text.Encoding.GetEncoding("Cyrillic").GetBytes(txt);
            return System.Text.Encoding.ASCII.GetString(bytes);
        }
    }
}
