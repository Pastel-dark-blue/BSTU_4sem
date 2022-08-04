using System;
using System.Collections.Generic;
using System.Text;

namespace Laba4
{
    // этот интерфейс будет реализован всеми продуктами
    interface Prototype
    {
        public Prototype clone();
    }
}
