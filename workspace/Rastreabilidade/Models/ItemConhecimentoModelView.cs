using BIC.Entidades;

namespace BIC.Models {
    public class ItemConhecimentoModelView : Item {

        public ItemConhecimentoModelView() { }

        public ItemConhecimentoModelView(Item item) {
            this.Nome = item.Nome;
            this.Fonte = item.Fonte;
            this.Tipo = item.Tipo;
            this.Tema = item.Tema;
            this.ID = this.ID;
            this.Autor = item.Autor;

            //perguntas PA

            this.Oque = item.Oque;
            this.Porque = item.Porque;

            //perguntas BP

            this.Razao = item.Razao;
            this.Detalhes = item.Detalhes;

            //perguntas LA

            this.Diferencas = item.Diferencas;
            this.Esperado = item.Esperado;
            this.Aconteceu = item.Aconteceu;
            this.Aprendizado = item.Aprendizado;
            
            this.Complemento = item.Complemento;

            this.Data = item.Data;

        }

        public Sluggable MyBase() {
            return (Sluggable)this;
        }


    }
}