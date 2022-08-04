
namespace Laba2_twoForms
{
    partial class SearchForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelName = new System.Windows.Forms.Label();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.groupBoxPrice = new System.Windows.Forms.GroupBox();
            this.textBoxPriceTop = new System.Windows.Forms.TextBox();
            this.textBoxPriceLow = new System.Windows.Forms.TextBox();
            this.labelPriceTop = new System.Windows.Forms.Label();
            this.labelPriceLow = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBoxType = new System.Windows.Forms.GroupBox();
            this.typeCheckBox1 = new System.Windows.Forms.CheckBox();
            this.typeCheckBox2 = new System.Windows.Forms.CheckBox();
            this.groupBoxPrice.SuspendLayout();
            this.groupBoxType.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelName.Location = new System.Drawing.Point(66, 108);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(99, 25);
            this.labelName.TabIndex = 1;
            this.labelName.Text = "Название :";
            // 
            // buttonSearch
            // 
            this.buttonSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.buttonSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSearch.FlatAppearance.BorderColor = System.Drawing.Color.Olive;
            this.buttonSearch.FlatAppearance.BorderSize = 0;
            this.buttonSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearch.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonSearch.Location = new System.Drawing.Point(174, 489);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(97, 39);
            this.buttonSearch.TabIndex = 4;
            this.buttonSearch.Text = "Поиск";
            this.buttonSearch.UseVisualStyleBackColor = false;
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(253, 109);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(125, 27);
            this.textBoxName.TabIndex = 5;
            // 
            // groupBoxPrice
            // 
            this.groupBoxPrice.Controls.Add(this.textBoxPriceTop);
            this.groupBoxPrice.Controls.Add(this.textBoxPriceLow);
            this.groupBoxPrice.Controls.Add(this.labelPriceTop);
            this.groupBoxPrice.Controls.Add(this.labelPriceLow);
            this.groupBoxPrice.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBoxPrice.Location = new System.Drawing.Point(67, 327);
            this.groupBoxPrice.Name = "groupBoxPrice";
            this.groupBoxPrice.Size = new System.Drawing.Size(312, 140);
            this.groupBoxPrice.TabIndex = 7;
            this.groupBoxPrice.TabStop = false;
            this.groupBoxPrice.Text = "Диапазон цены";
            // 
            // textBoxPriceTop
            // 
            this.textBoxPriceTop.Location = new System.Drawing.Point(94, 91);
            this.textBoxPriceTop.Name = "textBoxPriceTop";
            this.textBoxPriceTop.Size = new System.Drawing.Size(125, 31);
            this.textBoxPriceTop.TabIndex = 3;
            // 
            // textBoxPriceLow
            // 
            this.textBoxPriceLow.Location = new System.Drawing.Point(94, 39);
            this.textBoxPriceLow.Name = "textBoxPriceLow";
            this.textBoxPriceLow.Size = new System.Drawing.Size(125, 31);
            this.textBoxPriceLow.TabIndex = 2;
            // 
            // labelPriceTop
            // 
            this.labelPriceTop.AutoSize = true;
            this.labelPriceTop.Location = new System.Drawing.Point(7, 94);
            this.labelPriceTop.Name = "labelPriceTop";
            this.labelPriceTop.Size = new System.Drawing.Size(44, 25);
            this.labelPriceTop.TabIndex = 1;
            this.labelPriceTop.Text = "До :";
            // 
            // labelPriceLow
            // 
            this.labelPriceLow.AutoSize = true;
            this.labelPriceLow.Location = new System.Drawing.Point(7, 42);
            this.labelPriceLow.Name = "labelPriceLow";
            this.labelPriceLow.Size = new System.Drawing.Size(42, 25);
            this.labelPriceLow.TabIndex = 0;
            this.labelPriceLow.Text = "От :";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.Lavender;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Location = new System.Drawing.Point(13, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBox1.Size = new System.Drawing.Size(428, 65);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.TabStop = false;
            this.richTextBox1.Text = "Заполните поля ниже в соответствии с критериями поиска. В случае, если поиск по з" +
    "начению какого-либо поля вас не интересует, оставьте это поле пустым.";
            // 
            // groupBoxType
            // 
            this.groupBoxType.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxType.Controls.Add(this.typeCheckBox2);
            this.groupBoxType.Controls.Add(this.typeCheckBox1);
            this.groupBoxType.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBoxType.Location = new System.Drawing.Point(73, 167);
            this.groupBoxType.Name = "groupBoxType";
            this.groupBoxType.Size = new System.Drawing.Size(250, 135);
            this.groupBoxType.TabIndex = 36;
            this.groupBoxType.TabStop = false;
            this.groupBoxType.Text = "Тип";
            // 
            // typeCheckBox1
            // 
            this.typeCheckBox1.AutoSize = true;
            this.typeCheckBox1.Location = new System.Drawing.Point(13, 45);
            this.typeCheckBox1.Name = "typeCheckBox1";
            this.typeCheckBox1.Size = new System.Drawing.Size(200, 32);
            this.typeCheckBox1.TabIndex = 37;
            this.typeCheckBox1.Text = "потребительский";
            this.typeCheckBox1.UseVisualStyleBackColor = true;
            // 
            // typeCheckBox2
            // 
            this.typeCheckBox2.AutoSize = true;
            this.typeCheckBox2.Location = new System.Drawing.Point(17, 83);
            this.typeCheckBox2.Name = "typeCheckBox2";
            this.typeCheckBox2.Size = new System.Drawing.Size(190, 32);
            this.typeCheckBox2.TabIndex = 38;
            this.typeCheckBox2.Text = "промышленный";
            this.typeCheckBox2.UseVisualStyleBackColor = true;
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(452, 553);
            this.Controls.Add(this.groupBoxType);
            this.Controls.Add(this.groupBoxPrice);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.richTextBox1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(470, 600);
            this.Name = "SearchForm";
            this.Text = "SearchForm";
            this.groupBoxPrice.ResumeLayout(false);
            this.groupBoxPrice.PerformLayout();
            this.groupBoxType.ResumeLayout(false);
            this.groupBoxType.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.GroupBox groupBoxPrice;
        private System.Windows.Forms.Label labelPriceTop;
        private System.Windows.Forms.Label labelPriceLow;
        private System.Windows.Forms.TextBox textBoxPriceTop;
        private System.Windows.Forms.TextBox textBoxPriceLow;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.GroupBox groupBoxType;
        private System.Windows.Forms.CheckBox typeCheckBox2;
        private System.Windows.Forms.CheckBox typeCheckBox1;
    }
}