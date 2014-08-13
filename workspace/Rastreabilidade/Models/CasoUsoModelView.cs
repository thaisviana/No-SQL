using Rastreabilidade.Entidades;

namespace Rastreabilidade.Models {
    public class CasoUsoModelView : CasoUso {
        public CasoUsoModelView() { }

        public CasoUsoModelView(CasoUso cs) {
            this.Nome = cs.Nome;
            this.Menu = cs.Menu;
            this.Referencias = cs.Referencias;
        }

        public string oldID { get; set; }
    }
}