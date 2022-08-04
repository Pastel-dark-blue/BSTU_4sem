using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba6_7.Goods
{
    public static class State
    {
        public static Stack<Good> undoActions = new Stack<Good>();
        public static Stack<Good> redoActions = new Stack<Good>();
    }
}
