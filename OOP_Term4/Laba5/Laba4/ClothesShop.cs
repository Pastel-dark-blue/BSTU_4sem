using System;
using System.Collections.Generic;
using Laba4.Factories;
using System.Linq;
using Laba4.Decorator;
using System.Threading.Tasks;
using System.Windows.Forms;
using Laba4.Memento;
using Laba4.Abstract_Products;
using Laba4.Products;

namespace Laba4
{
    public partial class ClothesShop : Form
    {
        void ClothesStyleWasChosen(string styleType)
        {
            this.style = styleType;
        }

        void ClothesTypeWasChosen(string type)
        {
            this.clothes.Add(type);
        }

        string style;
        List<string> clothes = new List<string>();

        public ClothesShop()
        {
            InitializeComponent();
        }

        private void buttonMakeAnOrder_Click(object sender, EventArgs e)
        {
            SetClothes.ChooseStyleDelHandler = new SetClothes.ChooseStyleDel(ClothesStyleWasChosen);
            SetClothes.ChooseClothesDelHandler = new SetClothes.ChooseClothesDel(ClothesTypeWasChosen);
            SetClothes.CreateClothesDelHandler = new SetClothes.CreateClothesDel(CreateClothes);

            ChooseStyle newStyle = new ChooseStyle();
            newStyle.Owner = this;
            newStyle.ShowDialog();
        }

        private void CreateClothes()
        {
            switch (style)
            {
                case "classic":
                    ClassicClothesFactory newClassic = new ClassicClothesFactory();
                        foreach(var type in clothes)
                        {
                            switch (type)
                            {
                                case "trousers":
                                    Goods.ordersList.Add(newClassic.CreateTrousers(29) as Prototype);
                                    break;
                                case "shirt":
                                    Goods.ordersList.Add(newClassic.CreateShirt(29) as Prototype);
                                    break;
                                case "printed shirt":
                                    Goods.ordersList.Add(
                                        new PrintedShirt(newClassic.CreateShirt(666))
                                    );
                                break;
                                case "trousers with cuff":
                                Goods.ordersList.Add(
                                    new TrousersWithCuff(newClassic.CreateTrousers(606))
                                );
                                break;
                            }
                        }
                    break;
                case "casual":
                    CasualClothesFactory newCasual = new CasualClothesFactory();
                    foreach (var type in clothes)
                    {
                        switch (type)
                        {
                            case "trousers":
                                Goods.ordersList.Add(newCasual.CreateTrousers(30) as Prototype);
                                break;
                            case "shirt":
                                Goods.ordersList.Add(newCasual.CreateShirt(30) as Prototype); 
                                break;
                            case "printed shirt":
                                Goods.ordersList.Add(
                                    new PrintedShirt(newCasual.CreateShirt(666))
                                );
                            break;
                            case "trousers with cuff":
                                Goods.ordersList.Add(
                                    new TrousersWithCuff(newCasual.CreateTrousers(44))
                                );
                                break;
                        }
                    }
                    break;
            }

            style = "";
            clothes.Clear();
        }

        private void buttonShowOrders_Click(object sender, EventArgs e)
        {
            string orders = "=============================\r\n";

            foreach(var ord in Goods.ordersList)
            {
                orders += ord.ToString() + "=============================\r\n";
            }

            textBoxShowOrders.Text = orders;
        }

        private void buttonSingleton_Click(object sender, EventArgs e)
        {
            Singleton appInf = Singleton.getInstance(this.BackColor, this.Size, this.Font);

            MessageBox.Show(
                    appInf.ToString(),
                    "Информация о форме",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
        }

        private void buttonClone_Click(object sender, EventArgs e)
        {
            if (Goods.ordersList.Count != 0)
            {
                int lastInd = Goods.ordersList.Count - 1;
                Prototype prot = Goods.ordersList[lastInd].clone();
                
                // меняем значение размера в клоне
                if(prot is Shirt)      // проверяем, являлся ли скопированный объект футболкой
                {
                    (prot as Shirt).Size = 667;
                }
                else if(prot is Trousers)      // или брюками
                {
                    (prot as Trousers).Size = 667;
                }

                // выводим оригинал и клон, при этом видим, что изменения, внесенные в клон, не затронули оригинал
                MessageBox.Show(
                    "ОРИГИНАЛ\r\n" + Goods.ordersList[lastInd].ToString() + "\r\n=============================\r\n" +
                    "КЛОН С ИЗМЕНЕННЫМ ЗНАЧЕНИЕМ РАЗМЕРА \r\n" + prot.ToString());
            }
        }

        OrdersHistory orders = null;
        private void buttonSaveOrdersState_Click(object sender, EventArgs e)
        {
            if (Goods.ordersList != null)
            {
                orders = new OrdersHistory();

                orders.History.Push(Goods.SaveState());
            }
            else
            {
                MessageBox.Show("Вы не сделали ни одного заказа!");
            }
        }

        private void buttonRestoreOrdersState_Click(object sender, EventArgs e)
        {
            if (orders != null && orders.History.Count > 0) 

                Goods.RestoreState(orders.History.Pop());
        }
    }

    public static class SetClothes
    {
        public delegate void ChooseStyleDel(string styleType);
        public static ChooseStyleDel ChooseStyleDelHandler;

        public delegate void ChooseClothesDel(string styleType);
        public static ChooseClothesDel ChooseClothesDelHandler;

        public delegate void CreateClothesDel();
        public static CreateClothesDel CreateClothesDelHandler;
    }
}
