﻿using System;
using System.Collections.Generic;
using System.Text;
using Laba4;

namespace Laba4.Abstract_Products
{
    abstract class Trousers
    {
        public Materials Material { get; set; }
        public int Size { get; set; }
        public Colors Color { get; set; }
        public bool BackPockets { get; set; }
        public bool FrontPockets { get; set; }

        public string Style { get; }
        public string Type { get; }

        public virtual int GetCost()
        {
            return 0;
        }

        public virtual string GetClothesType()
        {
            return "брюки";
        }

        public string GetColor(Colors _color)
        {
            string strColor = "";
            switch (_color)
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

        public string GetMaterial(Materials _material)
        {
            string strMaterial = "";
            switch (_material)
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
    }
}
