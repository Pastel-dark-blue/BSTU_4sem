
namespace Laba4
{
    partial class ChooseStyle
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
            this.panelStyles = new System.Windows.Forms.Panel();
            this.radioButtonClassic = new System.Windows.Forms.RadioButton();
            this.radioButtonCasual = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonFurther = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panelStyles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelStyles
            // 
            this.panelStyles.Controls.Add(this.radioButtonClassic);
            this.panelStyles.Controls.Add(this.radioButtonCasual);
            this.panelStyles.Location = new System.Drawing.Point(0, 42);
            this.panelStyles.Name = "panelStyles";
            this.panelStyles.Size = new System.Drawing.Size(246, 113);
            this.panelStyles.TabIndex = 0;
            // 
            // radioButtonClassic
            // 
            this.radioButtonClassic.AutoSize = true;
            this.radioButtonClassic.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radioButtonClassic.Location = new System.Drawing.Point(32, 63);
            this.radioButtonClassic.Name = "radioButtonClassic";
            this.radioButtonClassic.Size = new System.Drawing.Size(143, 29);
            this.radioButtonClassic.TabIndex = 3;
            this.radioButtonClassic.Text = "Классический";
            this.radioButtonClassic.UseVisualStyleBackColor = true;
            // 
            // radioButtonCasual
            // 
            this.radioButtonCasual.AutoSize = true;
            this.radioButtonCasual.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radioButtonCasual.Location = new System.Drawing.Point(32, 18);
            this.radioButtonCasual.Name = "radioButtonCasual";
            this.radioButtonCasual.Size = new System.Drawing.Size(156, 29);
            this.radioButtonCasual.TabIndex = 2;
            this.radioButtonCasual.Text = "Повседневный";
            this.radioButtonCasual.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Lavender;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(246, 39);
            this.label1.TabIndex = 1;
            this.label1.Text = "Отметьте стиль одежды";
            // 
            // buttonFurther
            // 
            this.buttonFurther.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.buttonFurther.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.buttonFurther.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFurther.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonFurther.Location = new System.Drawing.Point(0, 160);
            this.buttonFurther.Name = "buttonFurther";
            this.buttonFurther.Size = new System.Drawing.Size(246, 50);
            this.buttonFurther.TabIndex = 4;
            this.buttonFurther.Text = "Далее";
            this.buttonFurther.UseVisualStyleBackColor = false;
            this.buttonFurther.Click += new System.EventHandler(this.buttonFurther_Click);
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
            this.ClientSize = new System.Drawing.Size(245, 210);
            this.Controls.Add(this.buttonFurther);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelStyles);
            this.MaximumSize = new System.Drawing.Size(263, 257);
            this.MinimumSize = new System.Drawing.Size(263, 257);
            this.Name = "ChooseClothes";
            this.Text = "ChooseClothes";
            this.panelStyles.ResumeLayout(false);
            this.panelStyles.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelStyles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonFurther;
        private System.Windows.Forms.RadioButton radioButtonClassic;
        private System.Windows.Forms.RadioButton radioButtonCasual;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}