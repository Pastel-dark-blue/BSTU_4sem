using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Laba4
{
    public partial class ChooseStyle : Form
    {
        public ChooseStyle()
        {
            InitializeComponent();
        }

        private void buttonFurther_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();

            if (radioButtonClassic.Checked || radioButtonCasual.Checked)
            {
                if (radioButtonClassic.Checked) SetClothes.ChooseStyleDelHandler("classic");
                if (radioButtonCasual.Checked) SetClothes.ChooseStyleDelHandler("casual");

                ChooseClothes newClothes = new ChooseClothes();
                newClothes.ShowDialog();
            }
            else
            {
                errorProvider1.SetError(radioButtonCasual, "Выберите один из предложенных стилей");
                return;
            }

            Close();
        }
    }
}
