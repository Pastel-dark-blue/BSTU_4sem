
namespace Laba4
{
    partial class ChooseClothes
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
            this.buttonFurther = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panelStyles = new System.Windows.Forms.Panel();
            this.checkBoxTrousersWithCuff = new System.Windows.Forms.CheckBox();
            this.checkBoxPrintedShirt = new System.Windows.Forms.CheckBox();
            this.checkBoxShirt = new System.Windows.Forms.CheckBox();
            this.checkBoxTrousers = new System.Windows.Forms.CheckBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panelStyles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonFurther
            // 
            this.buttonFurther.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.buttonFurther.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.buttonFurther.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFurther.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonFurther.Location = new System.Drawing.Point(0, 221);
            this.buttonFurther.Name = "buttonFurther";
            this.buttonFurther.Size = new System.Drawing.Size(303, 50);
            this.buttonFurther.TabIndex = 7;
            this.buttonFurther.Text = "Далее";
            this.buttonFurther.UseVisualStyleBackColor = false;
            this.buttonFurther.Click += new System.EventHandler(this.buttonFurther_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Lavender;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(303, 39);
            this.label1.TabIndex = 6;
            this.label1.Text = "Отметьте элемент(ы) одежды";
            // 
            // panelStyles
            // 
            this.panelStyles.Controls.Add(this.checkBoxTrousersWithCuff);
            this.panelStyles.Controls.Add(this.checkBoxPrintedShirt);
            this.panelStyles.Controls.Add(this.checkBoxShirt);
            this.panelStyles.Controls.Add(this.checkBoxTrousers);
            this.panelStyles.Location = new System.Drawing.Point(0, 42);
            this.panelStyles.Name = "panelStyles";
            this.panelStyles.Size = new System.Drawing.Size(303, 180);
            this.panelStyles.TabIndex = 5;
            // 
            // checkBoxTrousersWithCuff
            // 
            this.checkBoxTrousersWithCuff.AutoSize = true;
            this.checkBoxTrousersWithCuff.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxTrousersWithCuff.Location = new System.Drawing.Point(23, 52);
            this.checkBoxTrousersWithCuff.Name = "checkBoxTrousersWithCuff";
            this.checkBoxTrousersWithCuff.Size = new System.Drawing.Size(200, 29);
            this.checkBoxTrousersWithCuff.TabIndex = 3;
            this.checkBoxTrousersWithCuff.Text = "Брюки с манжетами";
            this.checkBoxTrousersWithCuff.UseVisualStyleBackColor = true;
            // 
            // checkBoxPrintedShirt
            // 
            this.checkBoxPrintedShirt.AutoSize = true;
            this.checkBoxPrintedShirt.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxPrintedShirt.Location = new System.Drawing.Point(23, 127);
            this.checkBoxPrintedShirt.Name = "checkBoxPrintedShirt";
            this.checkBoxPrintedShirt.Size = new System.Drawing.Size(201, 29);
            this.checkBoxPrintedShirt.TabIndex = 2;
            this.checkBoxPrintedShirt.Text = "Футболка с принтом";
            this.checkBoxPrintedShirt.UseVisualStyleBackColor = true;
            // 
            // checkBoxShirt
            // 
            this.checkBoxShirt.AutoSize = true;
            this.checkBoxShirt.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxShirt.Location = new System.Drawing.Point(23, 89);
            this.checkBoxShirt.Name = "checkBoxShirt";
            this.checkBoxShirt.Size = new System.Drawing.Size(111, 29);
            this.checkBoxShirt.TabIndex = 1;
            this.checkBoxShirt.Text = "Футболка";
            this.checkBoxShirt.UseVisualStyleBackColor = true;
            // 
            // checkBoxTrousers
            // 
            this.checkBoxTrousers.AutoSize = true;
            this.checkBoxTrousers.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxTrousers.Location = new System.Drawing.Point(23, 17);
            this.checkBoxTrousers.Name = "checkBoxTrousers";
            this.checkBoxTrousers.Size = new System.Drawing.Size(89, 29);
            this.checkBoxTrousers.TabIndex = 0;
            this.checkBoxTrousers.Text = "Брюки";
            this.checkBoxTrousers.UseVisualStyleBackColor = true;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ChooseClothes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(302, 271);
            this.Controls.Add(this.buttonFurther);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelStyles);
            this.Name = "ChooseClothes";
            this.Text = "ChooseClothes";
            this.panelStyles.ResumeLayout(false);
            this.panelStyles.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonFurther;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelStyles;
        private System.Windows.Forms.CheckBox checkBoxShirt;
        private System.Windows.Forms.CheckBox checkBoxTrousers;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.CheckBox checkBoxPrintedShirt;
        private System.Windows.Forms.CheckBox checkBoxTrousersWithCuff;
    }
}