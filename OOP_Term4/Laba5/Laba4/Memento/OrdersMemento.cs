using System;
using System.Collections.Generic;
using System.Text;

namespace Laba4.Memento
{
    class OrdersMemento
    {
        public List<Prototype> ordersList;

        public OrdersMemento(List<Prototype> _list)
        {
            ordersList = new List<Prototype>(_list);
        }
    }
}
