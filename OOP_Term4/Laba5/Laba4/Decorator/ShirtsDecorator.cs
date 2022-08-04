using System;
using System.Collections.Generic;
using System.Text;
using Laba4.Abstract_Products;
using System.Windows.Forms;
using Laba4.Products;

namespace Laba4.Decorator
{
    abstract class ShirtsDecorator : Shirt, Prototype
    {
        public Shirt shirt { get; set; }

        public ShirtsDecorator(Shirt _shirt)
        {
            shirt = _shirt;
        }

        public override int GetCost()
        {
            return shirt.GetCost();
        }

        public override string GetClothesType()
        {
            return shirt.GetClothesType();
        }

        public override string ToString()
        {
            if ((shirt as ClassicShirt) != null)
            return "Тип товара : " + GetClothesType() + "\r\n" +
                "Стиль : " + (shirt as ClassicShirt).Style + "\r\n" +
                "Материал : " + (shirt as ClassicShirt).GetMaterial((shirt as ClassicShirt).Material) + "\r\n" +
                "Размер : " + (shirt as ClassicShirt).Size + "\r\n" +
                "Цвет : " + (shirt as ClassicShirt).GetColor((shirt as ClassicShirt).Color) + "\r\n" +
                "Имеет рукава : " + (shirt as ClassicShirt).Sleeves + "\r\n" +
                "Стоимость (руб.) : " + GetCost() + "\r\n";

            if ((shirt as CasualShirt) != null)
                return "Тип товара : " + GetClothesType() + "\r\n" +
                    "Стиль : " + (shirt as CasualShirt).Style + "\r\n" +
                    "Материал : " + (shirt as CasualShirt).GetMaterial((shirt as CasualShirt).Material) + "\r\n" +
                    "Размер : " + (shirt as CasualShirt).Size + "\r\n" +
                    "Цвет : " + (shirt as CasualShirt).GetColor((shirt as CasualShirt).Color) + "\r\n" +
                    "Имеет рукава : " + (shirt as CasualShirt).Sleeves + "\r\n" +
                    "Стоимость (руб.) : " + GetCost() + "\r\n";

            else return "";
        }

        public Prototype clone()
        {
            return this.MemberwiseClone() as ShirtsDecorator;
        }
    }
}
