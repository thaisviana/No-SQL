using BIC.Entidades;

namespace BIC.Models
{
    public class TemaModelView : Tema{

        public TemaModelView() { }
        public TemaModelView(Tema tema) {
            this.Nome = tema.Nome;
            this.nivel = tema.nivel;
            this.Children = tema.Children;
            this.ID = tema.ID;
        }


        public Sluggable MyBase() {
            return (Sluggable)this;
        }

    }
}
