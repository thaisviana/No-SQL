
using System.Collections.Generic;

namespace BIC.Entidades {
    public class Item : Sluggable {
         
        /*public char Tipo;
        public string PerguntaA;
        public string PerguntaB;
        public string PerguntaC;
        public string PerguntaD;
        public List<Usuario> Autores;
        public string Fonte;
        public List<Anexo> Anexos;*/


        public string oldID;

        public Sluggable MyBase () {
                return (Sluggable)this;
        }
    }
}
