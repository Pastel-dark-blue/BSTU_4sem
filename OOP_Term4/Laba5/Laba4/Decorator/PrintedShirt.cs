using System;
using System.Collections.Generic;
using System.Text;
using Laba4.Abstract_Products;
using System.Windows.Forms;
using Laba4.Products;

namespace Laba4.Decorator
{
    class PrintedShirt : ShirtsDecorator
    {
        public PrintedShirt(Shirt _shirt)
            : base(_shirt)
        { }

        public override int GetCost()
        {
            return shirt.GetCost() + 5;
        }

        public override string GetClothesType()
        {
            return shirt.GetClothesType() + " с принтом";
        }
    }
}
