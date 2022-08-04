using System;
using System.Collections.Generic;
using System.Text;
using Laba4.Factories;
using Laba4.Abstract_Products;
using Laba4.Products;

namespace Laba4.Builders
{
    // интерфес строения брюк
    interface TrousersBuilder
    {
        void SetMaterial(Materials material);
        void SetSize(int size);
        void SetColor(Colors color);
        void AddBackPockets();
        void AddFrontPockets();

        Trousers GetResult(); // получить построенный объект
    }

    // конкретные реализации интерфейса строения брюк

    // --------------   брюки в классическом стиле
    class ClassicTrousersBuilder : TrousersBuilder
    {
        // создаем новый экземпляр брюк в классическом стиле
        private ClassicTrousers classicTrousers = new ClassicTrousers();

        // добавляем задние карманы
        public void AddBackPockets()
        {
            classicTrousers.BackPockets = true;
        }

        // добавляем передние карманы
        public void AddFrontPockets()
        {
            classicTrousers.FrontPockets = true;
        }

        // устанавливаем цвет
        public void SetColor(Colors color)
        {
            classicTrousers.Color = color;
        }

        // устанавливаем материал
        public void SetMaterial(Materials material)
        {
            classicTrousers.Material = material;
        }

        // устанавливаем размер
        public void SetSize(int size)
        {
            classicTrousers.Size = size;
        }

        // возвращаем готовые брюки
        public Trousers GetResult()
        {
            return classicTrousers;
        }
    }

    // --------------   брюки в повседневном стиле
    class CasualTrousersBuilder : TrousersBuilder
    {
        private CasualTrousers casualTrousers = new CasualTrousers();

        public void AddBackPockets()
        {
            casualTrousers.BackPockets = true;
        }

        public void AddFrontPockets()
        {
            casualTrousers.FrontPockets = true;
        }

        public void SetColor(Colors color)
        {
            casualTrousers.Color = color;
        }

        public void SetMaterial(Materials material)
        {
            casualTrousers.Material = material;
        }

        public void SetSize(int size)
        {
            casualTrousers.Size = size;
        }

        public void SetTorn()
        {
            casualTrousers.Torn = true;
        }

        public Trousers GetResult()
        {
            return casualTrousers;
        }
    }
}
