using BIC.Entidades;
using System.Collections.Generic;

namespace BIC.Models {
    public class ItemConhecimentoModelView : Item {

        public ItemConhecimentoModelView() { }

        public ItemConhecimentoModelView(Item item) {
            this.Nome = item.Nome;
            this.Fonte = item.Fonte;
            this.PerguntaA = item.PerguntaA;
            this.PerguntaB = item.PerguntaB;
            this.PerguntaC = item.PerguntaC;
            this.PerguntaD = item.PerguntaD;

        }

        public Sluggable MyBase() {
            return (Sluggable)this;
        }


    }
}