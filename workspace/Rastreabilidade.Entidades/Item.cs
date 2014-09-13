

namespace BIC.Entidades {
    public class Item : Sluggable {


        public string tema_id;
        public string tema_Nome;

        public double Autor;

        public double ID;

         
        public string oldID;

        public Sluggable MyBase () {
                return (Sluggable)this;
        }
    }
}
