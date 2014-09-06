using BIC.Entidades;

namespace BIC.Models {
    public class ItemConhecimentoModelView : Item {

        public ItemConhecimentoModelView() { }

        public ItemConhecimentoModelView(Item item) {
            this.Nome = item.Nome;
            this.Autores = item.Autores;
            this.Anexos = item.Anexos;
            this.Fonte = item.Fonte;
            this.PerguntaA = item.PerguntaA;
            this.PerguntaB = item.PerguntaB;
            this.PerguntaC = item.PerguntaC;
            this.PerguntaD = item.PerguntaD;

        }

        public string oldID { get; set; }

    }
}