using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcesamientoImagenes1.Logica.Entities
{
    public class YIQPixel
    {
        public int Xpos { get; set; }
        public int Ypos { get; set; }
        public float Y { get; set;  }
        public float I { get; set; }
        public float Q { get; set; }

        public YIQPixel()
        {
            Y = 0;
            I = 0;
            Q = 0;
        }
    }
}
