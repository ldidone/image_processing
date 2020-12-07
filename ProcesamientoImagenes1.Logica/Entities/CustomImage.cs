using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcesamientoImagenes1.Logica.Entities
{
    public class CustomImage<T> where T : class
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public List<T> Pixels { get; set; }

        public CustomImage()
        {
            Width = 0;
            Height = 0;
            Pixels = new List<T>();
        }
    }
}
