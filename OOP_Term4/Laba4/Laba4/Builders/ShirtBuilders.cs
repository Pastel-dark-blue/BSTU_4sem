using System;
using System.Collections.Generic;
using System.Text;
using Laba4.Abstract_Products;
using Laba4.Products;

namespace Laba4.Builders
{
    interface IShirtBuilder
    {
        void SetMaterial();
        void SetSize(int size);
        void SetColor();
        void AddSleeves();

        IShirt GetResult(); // получить построенный объект
    }

    class ClassicShirtBuilder : IShirtBuilder
    {
        private ClassicShirt classicShirt = new ClassicShirt();

        public void AddSleeves()
        {
            classicShirt.Sleeves = true;
        }

        public void SetColor()
        {
            classicShirt.Color = Colors.Бордовый;
        }

        public void SetMaterial()
        {
            classicShirt.Material = Materials.Хлопок;
        }

        public void SetSize(int size)
        {
            classicShirt.Size = size;
        }

        public IShirt GetResult()
        {
            return classicShirt;
        }
    }

    class CasualShirtBuilder : IShirtBuilder
    {
        private CasualShirt casualShirt = new CasualShirt();

        public void AddSleeves()
        {
            casualShirt.Sleeves = true;
        }

        public void SetColor()
        {
            casualShirt.Color = Colors.Синий;
        }

        public void SetMaterial()
        {
            casualShirt.Material = Materials.Эластан;
        }

        public void SetSize(int size)
        {
            casualShirt.Size = size;
        }

        public IShirt GetResult()
        {
            return casualShirt;
        }
    }
}
