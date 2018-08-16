using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Class
{
    public class Layer
    {
        public Layer()
        {
            this.Layers = new List<Layer>();
        }

        public int ID { get; set; }
        public string Description { get; set; }
        public string Abreviation { get; set; }
        public List<Layer> Layers { get; set; }

    }
}
