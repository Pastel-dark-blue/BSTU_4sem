using System;
using System.Collections.Generic;
using System.Text;
using Laba4;

namespace Laba4.Abstract_Products
{
    interface ITrousers
    {
        public Materials Material { get; set; }
        public int Size { get; set; }
        public Colors Color { get; set; }
        public bool BackPockets { get; set; }
        public bool FrontPockets { get; set; }

        public string Style { get; }
        public string Type { get; } 
    }
}
