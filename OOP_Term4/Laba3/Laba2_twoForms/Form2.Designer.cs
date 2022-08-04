
namespace Laba2_twoForms
{
    partial class Form2
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
            this.components = new System.ComponentModel.Container();
            this.countryComboBox = new System.Windows.Forms.ComboBox();
            this.orgTextBox = new System.Windows.Forms.TextBox();
            this.phoneMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.houseTextBox = new System.Windows.Forms.TextBox();
            this.streetTextBox = new System.Windows.Forms.TextBox();
            this.cityTextBox = new System.Windows.Forms.TextBox();
            this.districtTextBox = new System.Windows.Forms.TextBox();
            this.regionTextBox = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.orgError = new System.Windows.Forms.ErrorProvider(this.components);
            this.countryError = new System.Windows.Forms.ErrorProvider(this.components);
            this.phoneError = new System.Windows.Forms.ErrorProvider(this.components);
            this.regionError = new System.Windows.Forms.ErrorProvider(this.components);
            this.districtError = new System.Windows.Forms.ErrorProvider(this.components);
            this.cityError = new System.Windows.Forms.ErrorProvider(this.components);
            this.streetError = new System.Windows.Forms.ErrorProvider(this.components);
            this.houseError = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.orgError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.countryError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.phoneError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.regionError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.districtError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cityError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.streetError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.houseError)).BeginInit();
            this.SuspendLayout();
            // 
            // countryComboBox
            // 
            this.countryComboBox.AutoCompleteCustomSource.AddRange(new string[] {
            "Россия",
            "Польша",
            "Литва"});
            this.countryComboBox.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.countryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.countryComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.countryComboBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.countryComboBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.countryComboBox.FormattingEnabled = true;
            this.countryComboBox.Items.AddRange(new object[] {
            "Россия",
            "Литва",
            "Латвия",
            "Польша",
            "Украина"});
            this.countryComboBox.Location = new System.Drawing.Point(224, 109);
            this.countryComboBox.Name = "countryComboBox";
            this.countryComboBox.Size = new System.Drawing.Size(328, 36);
            this.countryComboBox.TabIndex = 0;
            // 
            // orgTextBox
            // 
            this.orgTextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.orgTextBox.Location = new System.Drawing.Point(224, 38);
            this.orgTextBox.Name = "orgTextBox";
            this.orgTextBox.Size = new System.Drawing.Size(328, 34);
            this.orgTextBox.TabIndex = 1;
            // 
            // phoneMaskedTextBox
            // 
            this.phoneMaskedTextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.phoneMaskedTextBox.Location = new System.Drawing.Point(224, 179);
            this.phoneMaskedTextBox.Mask = "(00)000-00-00";
            this.phoneMaskedTextBox.Name = "phoneMaskedTextBox";
            this.phoneMaskedTextBox.Size = new System.Drawing.Size(177, 34);
            this.phoneMaskedTextBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(36, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 28);
            this.label1.TabIndex = 3;
            this.label1.Text = "Организация :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(18, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 28);
            this.label2.TabIndex = 4;
            this.label2.Text = "Район";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(19, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 28);
            this.label3.TabIndex = 5;
            this.label3.Text = "Город";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(22, 224);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 28);
            this.label4.TabIndex = 6;
            this.label4.Text = "Улица";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(22, 278);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 28);
            this.label5.TabIndex = 7;
            this.label5.Text = "Дом";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(18, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 28);
            this.label6.TabIndex = 8;
            this.label6.Text = "Область";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(36, 112);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 28);
            this.label7.TabIndex = 9;
            this.label7.Text = "Страна :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(36, 182);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 28);
            this.label8.TabIndex = 10;
            this.label8.Text = "Телефон :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.houseTextBox);
            this.groupBox1.Controls.Add(this.streetTextBox);
            this.groupBox1.Controls.Add(this.cityTextBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.districtTextBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.regionTextBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(36, 243);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(421, 357);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Адрес";
            // 
            // houseTextBox
            // 
            this.houseTextBox.Location = new System.Drawing.Point(148, 275);
            this.houseTextBox.Name = "houseTextBox";
            this.houseTextBox.Size = new System.Drawing.Size(217, 34);
            this.houseTextBox.TabIndex = 13;
            // 
            // streetTextBox
            // 
            this.streetTextBox.Location = new System.Drawing.Point(148, 221);
            this.streetTextBox.Name = "streetTextBox";
            this.streetTextBox.Size = new System.Drawing.Size(217, 34);
            this.streetTextBox.TabIndex = 12;
            // 
            // cityTextBox
            // 
            this.cityTextBox.Location = new System.Drawing.Point(148, 161);
            this.cityTextBox.Name = "cityTextBox";
            this.cityTextBox.Size = new System.Drawing.Size(217, 34);
            this.cityTextBox.TabIndex = 11;
            // 
            // districtTextBox
            // 
            this.districtTextBox.Location = new System.Drawing.Point(148, 104);
            this.districtTextBox.Name = "districtTextBox";
            this.districtTextBox.Size = new System.Drawing.Size(217, 34);
            this.districtTextBox.TabIndex = 10;
            // 
            // regionTextBox
            // 
            this.regionTextBox.Location = new System.Drawing.Point(147, 45);
            this.regionTextBox.Name = "regionTextBox";
            this.regionTextBox.Size = new System.Drawing.Size(218, 34);
            this.regionTextBox.TabIndex = 9;
            // 
            // saveButton
            // 
            this.saveButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.saveButton.Location = new System.Drawing.Point(593, 548);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(171, 52);
            this.saveButton.TabIndex = 12;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = false;
            // 
            // orgError
            // 
            this.orgError.ContainerControl = this;
            // 
            // countryError
            // 
            this.countryError.ContainerControl = this;
            // 
            // phoneError
            // 
            this.phoneError.ContainerControl = this;
            // 
            // regionError
            // 
            this.regionError.ContainerControl = this;
            // 
            // districtError
            // 
            this.districtError.ContainerControl = this;
            // 
            // cityError
            // 
            this.cityError.ContainerControl = this;
            // 
            // streetError
            // 
            this.streetError.ContainerControl = this;
            // 
            // houseError
            // 
            this.houseError.ContainerControl = this;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 631);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.phoneMaskedTextBox);
            this.Controls.Add(this.orgTextBox);
            this.Controls.Add(this.countryComboBox);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(818, 678);
            this.MinimumSize = new System.Drawing.Size(818, 678);
            this.Name = "Form2";
            this.Text = "Производитель";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.orgError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.countryError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.phoneError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.regionError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.districtError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cityError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.streetError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.houseError)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox countryComboBox;
        private System.Windows.Forms.TextBox orgTextBox;
        private System.Windows.Forms.MaskedTextBox phoneMaskedTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox houseTextBox;
        private System.Windows.Forms.TextBox streetTextBox;
        private System.Windows.Forms.TextBox cityTextBox;
        private System.Windows.Forms.TextBox districtTextBox;
        private System.Windows.Forms.TextBox regionTextBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.ErrorProvider orgError;
        private System.Windows.Forms.ErrorProvider countryError;
        private System.Windows.Forms.ErrorProvider phoneError;
        private System.Windows.Forms.ErrorProvider regionError;
        private System.Windows.Forms.ErrorProvider districtError;
        private System.Windows.Forms.ErrorProvider cityError;
        private System.Windows.Forms.ErrorProvider streetError;
        private System.Windows.Forms.ErrorProvider houseError;
    }
}