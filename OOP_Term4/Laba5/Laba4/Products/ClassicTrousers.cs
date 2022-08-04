using System;
using System.Collections.Generic;
using System.Text;
using Laba4.Abstract_Products;

namespace Laba4.Products
{
    class ClassicTrousers : Trousers, Prototype
    {
        public Prototype clone()
        {
            return this.MemberwiseClone() as Prototype;
        }

        new public Materials Material { get; set; }
        new public int Size { get; set; }
        new public Colors Color { get; set; }
        new public bool BackPockets { get; set; }
        new public bool FrontPockets { get; set; }

        private string _style = "классические";
        new public string Style { get { return _style; } }

        private int _cost = 125;
        public override int GetCost()
        {
            return _cost;
        }

        private string _type = "брюки";
        public override string GetClothesType()
        {
            return _type;
        }

        public override string ToString()
        {
            return "Тип товара : " + GetClothesType() + "\r\n" +
                "Стиль : " + Style + "\r\n" +
                "Материал : " + GetMaterial(Material) + "\r\n" +
                "Размер : " + Size + "\r\n" +
                "Цвет : " + GetColor(Color) + "\r\n" +
                "Имеют передние карманы : " + FrontPockets + "\r\n" +
                "Имеют задние карманы : " + BackPockets + "\r\n" +
                "Стоимость (руб.) : " + GetCost() + "\r\n";
        }
    }
}
