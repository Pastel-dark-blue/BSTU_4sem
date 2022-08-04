using System;
using System.Collections.Generic;
using System.Text;
using Laba4.Builders;
using Laba4.Products;
using Laba4.Abstract_Products;

namespace Laba4.Factories
{
    class CasualClothesFactory : IFactory
    {
        public IShirt CreateShirt(int size)
        {
            CasualShirtBuilder builder = new CasualShirtBuilder();

            // собираем повседневную футболку
            builder.SetMaterial();
            builder.SetColor();
            builder.SetSize(size);

            return (CasualShirt)builder.GetResult();
        }

        public ITrousers CreateTrousers(int size)
        {
            CasualTrousersBuilder builder = new CasualTrousersBuilder();

            // собираем повседневные брюки
            builder.SetMaterial(Materials.Джинса);
            builder.SetColor(Colors.Синий);
            builder.AddBackPockets();
            builder.AddFrontPockets();
            builder.SetSize(size);
            builder.SetTorn();

            return (CasualTrousers)builder.GetResult();
        }
    }
}
