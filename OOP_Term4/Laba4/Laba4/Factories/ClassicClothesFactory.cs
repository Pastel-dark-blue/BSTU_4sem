using System;
using System.Collections.Generic;
using System.Text;
using Laba4.Builders;
using Laba4.Products;
using Laba4.Abstract_Products;

namespace Laba4.Factories
{
    class ClassicClothesFactory : IFactory
    {
        public IShirt CreateShirt(int size)
        {
            ClassicShirtBuilder builder = new ClassicShirtBuilder();

            // собираем классические брюки
            builder.SetMaterial();
            builder.SetColor();
            builder.SetSize(size);
            builder.AddSleeves();

            return (ClassicShirt)builder.GetResult();
        }

        public ITrousers CreateTrousers(int size)
        {
            ClassicTrousersBuilder builder = new ClassicTrousersBuilder();

            // собираем классические брюки
            builder.SetMaterial(Materials.Хлопок);
            builder.SetColor(Colors.Черный);
            builder.AddBackPockets();
            builder.AddFrontPockets();
            builder.SetSize(size);

            return (ClassicTrousers)builder.GetResult();
        }
    }
}
