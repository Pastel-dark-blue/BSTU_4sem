using System;
using System.Collections.Generic;
using System.Text;
using Laba4.Abstract_Products;
using Laba4.Products;

namespace Laba4.Builders
{
    interface ShirtBuilder
    {
        void SetColor(Colors color);
        void SetMaterial(Materials material);
        void SetSize(int size);
        void AddSleeves();

        Shirt GetResult(); // получить построенный объект
    }

    class ClassicShirtBuilder : ShirtBuilder
    {
        private ClassicShirt classicShirt = new ClassicShirt();

        public void AddSleeves()
        {
            classicShirt.Sleeves = true;
        }

        public void SetColor(Colors color)
        {
            classicShirt.Color = color;
        }

        public void SetMaterial(Materials material)
        {
            classicShirt.Material = material;
        }

        public void SetSize(int size)
        {
            classicShirt.Size = size;
        }

        public Shirt GetResult()
        {
            return classicShirt;
        }
    }

    class CasualShirtBuilder : ShirtBuilder
    {
        private CasualShirt casualShirt = new CasualShirt();

        public void AddSleeves()
        {
            casualShirt.Sleeves = true;
        }

        public void SetColor(Colors color)
        {
            casualShirt.Color = color;
        }

        public void SetMaterial(Materials material)
        {
            casualShirt.Material = material;
        }

        public void SetSize(int size)
        {
            casualShirt.Size = size;
        }

        public Shirt GetResult()
        {
            return casualShirt;
        }
    }
}
