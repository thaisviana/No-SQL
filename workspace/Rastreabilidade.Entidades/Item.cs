
using System.Collections.Generic;

namespace BIC.Entidades {
    public class Item : Sluggable {
        public char Tipo;
        public string Nome;
        public string PerguntaA;
        public string PerguntaB;
        public string PerguntaC;
        public string PerguntaD;
        public List<Usuario> Autores;
        public string Fonte;
        public List<Anexo> Anexos;
    }
}
