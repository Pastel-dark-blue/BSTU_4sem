using System;
using System.Collections.Generic;
using System.Text;
using Laba4.Abstract_Products;
using System.Windows.Forms;
using Laba4.Products;

namespace Laba4.Decorator
{
    class TrousersDecorator : Trousers, Prototype
    {
        public Trousers trousers { get; set; }

        public TrousersDecorator(Trousers _trousers)
        {
            trousers = _trousers;
        }

        public override int GetCost()
        {
            return trousers.GetCost();
        }

        public override string GetClothesType()
        {
            return trousers.GetClothesType();
        }

        public override string ToString()
        {
            if ((trousers as ClassicTrousers) != null)
                return "Тип товара : " + GetClothesType() + "\r\n" +
                    "Стиль : " + (trousers as ClassicTrousers).Style + "\r\n" +
                    "Материал : " + (trousers as ClassicTrousers).GetMaterial((trousers as ClassicTrousers).Material) + "\r\n" +
                    "Размер : " + (trousers as ClassicTrousers).Size + "\r\n" +
                    "Цвет : " + (trousers as ClassicTrousers).GetColor((trousers as ClassicTrousers).Color) + "\r\n" +
                    "Имеют передние карманы : " + (trousers as ClassicTrousers).FrontPockets + "\r\n" +
                    "Имеют задние карманы : " + (trousers as ClassicTrousers).BackPockets + "\r\n" +
                    "Стоимость (руб.) : " + GetCost() + "\r\n";

            if ((trousers as CasualTrousers) != null)
                return "Тип товара : " + GetClothesType() + "\r\n" +
                    "Стиль : " + (trousers as CasualTrousers).Style + "\r\n" +
                    "Материал : " + (trousers as CasualTrousers).GetMaterial((trousers as CasualTrousers).Material) + "\r\n" +
                    "Размер : " + (trousers as CasualTrousers).Size + "\r\n" +
                    "Цвет : " + (trousers as CasualTrousers).GetColor((trousers as CasualTrousers).Color) + "\r\n" +
                    "Имеют передние карманы : " + (trousers as CasualTrousers).FrontPockets + "\r\n" +
                    "Имеют задние карманы : " + (trousers as CasualTrousers).BackPockets + "\r\n" +
                    "Рваные : " + (trousers as CasualTrousers).Torn + "\r\n" +
                    "Стоимость (руб.) : " + GetCost() + "\r\n";

            else return "";
        }

        public Prototype clone()
        {
            return this.MemberwiseClone() as Prototype;
        }
    }
}
