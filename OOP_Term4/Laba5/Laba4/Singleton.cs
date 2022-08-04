using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;
using System.Drawing;

namespace Laba4
{
    public class Singleton
    {
        private static Singleton _intance;

        public static Singleton getInstance(Color color, Size size, Font font)
        {
            return _intance ?? new Singleton(color, size, font);
        }

        public Color WindowBackgroundColor { get; private set; }
        public Font WindowFont { get; private set; }
        public Size WindowSize { get; private set; }

        private Singleton(Color color, Size size, Font font) {
            this.WindowBackgroundColor = color;
            this.WindowSize = size;
            this.WindowFont = font;
        }

        public override string ToString()
        {
            return 
                "Цвет фона : " + this.WindowBackgroundColor.Name + 
                "\r\nШрифт : " + this.WindowFont.Name +
                "\r\nРазмер окна (ширина×высота) : " + this.WindowSize.Width + "×" + this.WindowSize.Height;
        }
    }
}
