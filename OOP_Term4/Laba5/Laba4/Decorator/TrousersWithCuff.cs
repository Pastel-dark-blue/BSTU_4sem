using System;
using System.Collections.Generic;
using System.Text;
using Laba4.Abstract_Products;

namespace Laba4.Decorator
{
    class TrousersWithCuff : TrousersDecorator
    {
        public TrousersWithCuff(Trousers _trousers)
            : base(_trousers)
        {   }

        public override int GetCost()
        {
            return trousers.GetCost() + 2;
        }

        public override string GetClothesType()
        {
            return trousers.GetClothesType() + " с манжетами";
        }
    }
}
