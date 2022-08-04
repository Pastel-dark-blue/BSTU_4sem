using System;
using System.Collections.Generic;
using System.Text;
using Laba4.Abstract_Products;

namespace Laba4.Products
{
    class CasualTrousers : Trousers, Prototype
    {
        new public Materials Material { get; set; }
        new public int Size { get; set; }
        new public Colors Color { get; set; }
        new public bool BackPockets { get; set; }
        new public bool FrontPockets { get; set; }
        public bool Torn { get; set; }

        private string _style = "повседневные";
        new public string Style { get { return _style; } }

        private string _type = "брюки";
        new public string Type { get { return _type; } }

        private int _cost = 86;
        public override int GetCost()
        {
            return _cost;
        }

        public override string ToString()
        {
            return "Тип товара : " + Type + "\r\n" +
                "Стиль : " + Style + "\r\n" +
                "Материал : " + GetMaterial(Material) + "\r\n" +
                "Размер : " + Size + "\r\n" +
                "Цвет : " + GetColor(Color) + "\r\n" +
                "Имеют передние карманы : " + FrontPockets + "\r\n" +
                "Имеют задние карманы : " + BackPockets + "\r\n" + 
                "Рваные : " + Torn + "\r\n" +
                "Стоимость (руб.) : " + GetCost() + "\r\n";
        }

        public Prototype clone()
        {
            return this.MemberwiseClone() as Prototype;
        }
    }
}
