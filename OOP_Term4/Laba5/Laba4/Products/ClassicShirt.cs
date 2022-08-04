using System;
using System.Collections.Generic;
using System.Text;
using Laba4.Abstract_Products;

namespace Laba4.Products
{
    class ClassicShirt : Shirt, Prototype
    {
        new public Materials Material { get; set; }
        new public int Size { get; set; }
        new public Colors Color { get; set; }
        new public bool Sleeves { get; set; }

        private string _style = "классическая";
        new public string Style { get { return _style; } }

        private string _type = "футболка";
        public override string GetClothesType()
        {
            return _type;
        }

        private int _cost = 60;
        public override int GetCost()
        {
            return _cost;
        }

        public override string ToString()
        {
            return "Тип товара : " + GetClothesType() + "\r\n" +
                "Стиль : " + Style + "\r\n" +
                "Материал : " + GetMaterial(Material) + "\r\n" +
                "Размер : " + Size + "\r\n" +
                "Цвет : " + GetColor(Color) + "\r\n" +
                "Имеет рукава : " + Sleeves + "\r\n" +
                "Стоимость (руб.) : " + GetCost() + "\r\n";
        }

        public Prototype clone()
        {
            return this.MemberwiseClone() as Prototype;
        }
    }
}
