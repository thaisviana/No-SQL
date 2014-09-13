
using System.Collections.Generic;
namespace BIC.Entidades {
    public class Tema : Sluggable {

       
        public double nivel;

        public List<double> Children;

        public double ID;

        public string oldID;

        public Sluggable MyBase() {
            return (Sluggable)this;
        }
    }
}
