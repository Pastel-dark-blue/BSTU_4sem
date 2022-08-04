using System;

namespace Laba1_calc
{
    public interface ICalc
    {
        void delClick(object sender, EventArgs e);
        void signClick(object sender, EventArgs e);
        void rowClick(object sender, EventArgs e);
        void operClick(object sender, EventArgs e);
        void commaClick(object sender, EventArgs e);
        void numClick(object sender, EventArgs e);
    }
}
