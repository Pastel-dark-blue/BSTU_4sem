using System;
using System.Collections.Generic;
using System.Text;
using Laba4.Abstract_Products;

namespace Laba4.Products
{
    class ClassicTrousers : ITrousers, Prototype
    {
        public Prototype clone()
        {
            return this.MemberwiseClone() as Prototype;
        }

        public Materials Material { get; set; }
        public int Size { get; set; }
        public Colors Color { get; set; }
        public bool BackPockets { get; set; }
        public bool FrontPockets { get; set; }

        private string _style = "классические";
        public string Style { get { return _style; } }

        private string _type = "брюки";
        public string Type { get { return _type; } }

        public override string ToString()
        {
            return "Тип товара : "+ Type + "\n" +
                "Стиль : "+ Style + "\n" +
                "Материал : " + GetMaterial() + "\n" +
                "Размер : " + Size + "\n" +
                "Цвет : " + GetColor() + "\n" +
                "Имеют передние карманы : " + FrontPockets + "\n" +
                "Имеют задние карманы : " + BackPockets + "\n";
        }

        string GetColor()
        {
            string strColor = "";
            switch (Color)
            {
                case Colors.Белый:
                    strColor = "белый";
                    break;
                case Colors.Бордовый:
                    strColor = "бордовый";
                    break;
                case Colors.Зеленый:
                    strColor = "зеленый";
                    break;
                case Colors.Синий:
                    strColor = "синий";
                    break;
                case Colors.Черный:
                    strColor = "черный";
                    break;
                default:
                    strColor = "не указан";
                    break;
            }
            return strColor;
        }

        string GetMaterial()
        {
            string strMaterial = "";
            switch (Material)
            {
                case Materials.Джинса:
                    strMaterial = "джинса";
                    break;
                case Materials.Хлопок:
                    strMaterial = "хлопок";
                    break;
                case Materials.Эластан:
                    strMaterial = "эластан";
                    break;
                default:
                    strMaterial = "не указан";
                    break;
            }
            return strMaterial;
        }

        public ClassicTrousers Clone()
        {
            return this.MemberwiseClone() as ClassicTrousers;
        }
    }
}
