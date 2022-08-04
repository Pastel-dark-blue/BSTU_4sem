using System;
using System.Collections.Generic;
using System.Text;
using Laba4.Abstract_Products;
using Laba4.Memento;

namespace Laba4
{
    class Goods
    {
        public static List<Prototype> ordersList = new List<Prototype>();

        static public OrdersMemento SaveState()
        {
            return new OrdersMemento(ordersList);
        }

        static public void RestoreState(OrdersMemento memento)
        {
            ordersList.Clear();
            ordersList.AddRange(memento.ordersList);
        }
    }
}
