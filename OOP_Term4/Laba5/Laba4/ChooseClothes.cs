using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Laba4
{
    public partial class ChooseClothes : Form
    {
        public ChooseClothes()
        {
            InitializeComponent();
        }

        private void buttonFurther_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();

            if (checkBoxTrousers.Checked || checkBoxShirt.Checked || 
                checkBoxPrintedShirt.Checked || checkBoxTrousersWithCuff.Checked)
            {
                if (checkBoxShirt.Checked) SetClothes.ChooseClothesDelHandler("shirt");
                if (checkBoxPrintedShirt.Checked) SetClothes.ChooseClothesDelHandler("printed shirt");
                if (checkBoxTrousers.Checked) SetClothes.ChooseClothesDelHandler("trousers");
                if (checkBoxTrousersWithCuff.Checked) SetClothes.ChooseClothesDelHandler("trousers with cuff");
            }
            else
            {
                errorProvider1.SetError(checkBoxTrousers, "Выберите один из предложенных стилей");
            }

            SetClothes.CreateClothesDelHandler();

            Close();
        }
    }
}
