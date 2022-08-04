using System;
using System.Collections.Generic;
using System.Text;

namespace Laba4.Abstract_Products
{
    interface IShirt
    {
        public Materials Material { get; set; }
        public int Size { get; set; }
        public Colors Color { get; set; }
        public bool Sleeves { get; set; }

        public string Style { get; }
        public string Type { get; }
    }
}
