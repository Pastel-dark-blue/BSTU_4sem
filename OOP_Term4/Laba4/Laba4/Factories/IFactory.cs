using System;
using System.Collections.Generic;
using System.Text;
using Laba4.Abstract_Products;

namespace Laba4.Factories
{
    interface IFactory
    {
        ITrousers CreateTrousers(int size);
        IShirt CreateShirt(int size);
    }
}
