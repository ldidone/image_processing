using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcesamientoImagenes1.Logica.Entities
{
    public class RGBPixel
    {
        public int Xpos { get; set; }
        public int Ypos { get; set; }
        public int R { get; set; }
        public int G { get; set; }
        public int B { get; set; }

        public RGBPixel()
        {
            R = 0;
            G = 0;
            B = 0;
        }
    }
}
