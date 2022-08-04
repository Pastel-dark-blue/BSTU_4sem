using System;
using System.Collections.Generic;
using System.Text;

namespace Laba4.Memento
{
    class OrdersHistory
    {
        public Stack<OrdersMemento> History;

        public OrdersHistory()
        {
            History = new Stack<OrdersMemento>();
        }
    }
}
