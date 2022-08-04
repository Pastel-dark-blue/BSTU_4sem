using System;
using System.Collections.Generic;
using System.Text;
using Laba4.Abstract_Products;

namespace Laba4.Factories
{
    interface IFactory
    {
        Trousers CreateTrousers(int size);
        Shirt CreateShirt(int size);
    }
}
