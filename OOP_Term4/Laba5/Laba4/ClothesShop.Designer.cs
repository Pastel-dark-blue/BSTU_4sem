
namespace Laba4
{
    partial class ClothesShop
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonMakeAnOrder = new System.Windows.Forms.Button();
            this.buttonShowOrders = new System.Windows.Forms.Button();
            this.buttonSingleton = new System.Windows.Forms.Button();
            this.buttonClone = new System.Windows.Forms.Button();
            this.labelMakeAnOrder = new System.Windows.Forms.Label();
            this.labelOrdersList = new System.Windows.Forms.Label();
            this.labelSingleton = new System.Windows.Forms.Label();
            this.labelPrototype = new System.Windows.Forms.Label();
            this.buttonSaveOrdersState = new System.Windows.Forms.Button();
            this.buttonRestoreOrdersState = new System.Windows.Forms.Button();
            this.textBoxShowOrders = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonMakeAnOrder
            // 
            this.buttonMakeAnOrder.BackColor = System.Drawing.Color.Lavender;
            this.buttonMakeAnOrder.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonMakeAnOrder.Location = new System.Drawing.Point(23, 34);
            this.buttonMakeAnOrder.Name = "buttonMakeAnOrder";
            this.buttonMakeAnOrder.Size = new System.Drawing.Size(166, 54);
            this.buttonMakeAnOrder.TabIndex = 0;
            this.buttonMakeAnOrder.Text = "Сделать заказ";
            this.buttonMakeAnOrder.UseVisualStyleBackColor = false;
            this.buttonMakeAnOrder.Click += new System.EventHandler(this.buttonMakeAnOrder_Click);
            // 
            // buttonShowOrders
            // 
            this.buttonShowOrders.BackColor = System.Drawing.Color.Lavender;
            this.buttonShowOrders.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonShowOrders.Location = new System.Drawing.Point(23, 113);
            this.buttonShowOrders.Name = "buttonShowOrders";
            this.buttonShowOrders.Size = new System.Drawing.Size(166, 54);
            this.buttonShowOrders.TabIndex = 1;
            this.buttonShowOrders.Text = "Просмотреть заказы";
            this.buttonShowOrders.UseVisualStyleBackColor = false;
            this.buttonShowOrders.Click += new System.EventHandler(this.buttonShowOrders_Click);
            // 
            // buttonSingleton
            // 
            this.buttonSingleton.BackColor = System.Drawing.Color.Lavender;
            this.buttonSingleton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonSingleton.Location = new System.Drawing.Point(23, 191);
            this.buttonSingleton.Name = "buttonSingleton";
            this.buttonSingleton.Size = new System.Drawing.Size(166, 54);
            this.buttonSingleton.TabIndex = 2;
            this.buttonSingleton.Text = "Singleton";
            this.buttonSingleton.UseVisualStyleBackColor = false;
            this.buttonSingleton.Click += new System.EventHandler(this.buttonSingleton_Click);
            // 
            // buttonClone
            // 
            this.buttonClone.BackColor = System.Drawing.Color.Lavender;
            this.buttonClone.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonClone.Location = new System.Drawing.Point(23, 268);
            this.buttonClone.Name = "buttonClone";
            this.buttonClone.Size = new System.Drawing.Size(166, 54);
            this.buttonClone.TabIndex = 3;
            this.buttonClone.Text = "Prototype";
            this.buttonClone.UseVisualStyleBackColor = false;
            this.buttonClone.Click += new System.EventHandler(this.buttonClone_Click);
            // 
            // labelMakeAnOrder
            // 
            this.labelMakeAnOrder.Location = new System.Drawing.Point(230, 34);
            this.labelMakeAnOrder.Name = "labelMakeAnOrder";
            this.labelMakeAnOrder.Size = new System.Drawing.Size(280, 50);
            this.labelMakeAnOrder.TabIndex = 4;
            this.labelMakeAnOrder.Text = "Выбрать стиль и тип одежды и поместить заказ в список";
            // 
            // labelOrdersList
            // 
            this.labelOrdersList.Location = new System.Drawing.Point(230, 113);
            this.labelOrdersList.Name = "labelOrdersList";
            this.labelOrdersList.Size = new System.Drawing.Size(248, 54);
            this.labelOrdersList.TabIndex = 5;
            this.labelOrdersList.Text = "Просмотреть список заказов";
            // 
            // labelSingleton
            // 
            this.labelSingleton.Location = new System.Drawing.Point(230, 191);
            this.labelSingleton.Name = "labelSingleton";
            this.labelSingleton.Size = new System.Drawing.Size(280, 54);
            this.labelSingleton.TabIndex = 6;
            this.labelSingleton.Text = "Просмотреть информацию о текущей форме (размер, цвет фона, шрифт)";
            // 
            // labelPrototype
            // 
            this.labelPrototype.Location = new System.Drawing.Point(230, 268);
            this.labelPrototype.Name = "labelPrototype";
            this.labelPrototype.Size = new System.Drawing.Size(661, 54);
            this.labelPrototype.TabIndex = 7;
            this.labelPrototype.Text = "Сделать клон последнего заказа из списка заказов и поменять значение размера в об" +
    "ъекте клона. Вывести оригинал, не затронутый изменениями клона, и клон.";
            // 
            // buttonSaveOrdersState
            // 
            this.buttonSaveOrdersState.BackColor = System.Drawing.Color.Lavender;
            this.buttonSaveOrdersState.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSaveOrdersState.Location = new System.Drawing.Point(23, 345);
            this.buttonSaveOrdersState.Name = "buttonSaveOrdersState";
            this.buttonSaveOrdersState.Size = new System.Drawing.Size(166, 71);
            this.buttonSaveOrdersState.TabIndex = 8;
            this.buttonSaveOrdersState.Text = "Сохранить состояние списка заказов";
            this.buttonSaveOrdersState.UseVisualStyleBackColor = false;
            this.buttonSaveOrdersState.Click += new System.EventHandler(this.buttonSaveOrdersState_Click);
            // 
            // buttonRestoreOrdersState
            // 
            this.buttonRestoreOrdersState.BackColor = System.Drawing.Color.Lavender;
            this.buttonRestoreOrdersState.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRestoreOrdersState.Location = new System.Drawing.Point(23, 437);
            this.buttonRestoreOrdersState.Name = "buttonRestoreOrdersState";
            this.buttonRestoreOrdersState.Size = new System.Drawing.Size(166, 71);
            this.buttonRestoreOrdersState.TabIndex = 9;
            this.buttonRestoreOrdersState.Text = "Вернуть сохраненное состояние";
            this.buttonRestoreOrdersState.UseVisualStyleBackColor = false;
            this.buttonRestoreOrdersState.Click += new System.EventHandler(this.buttonRestoreOrdersState_Click);
            // 
            // textBoxShowOrders
            // 
            this.textBoxShowOrders.Location = new System.Drawing.Point(23, 538);
            this.textBoxShowOrders.Multiline = true;
            this.textBoxShowOrders.Name = "textBoxShowOrders";
            this.textBoxShowOrders.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxShowOrders.Size = new System.Drawing.Size(854, 168);
            this.textBoxShowOrders.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(230, 345);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(647, 54);
            this.label1.TabIndex = 11;
            this.label1.Text = "Сохранить текущее состояние списка заказов в памяти";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(230, 437);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(647, 54);
            this.label2.TabIndex = 12;
            this.label2.Text = "Вернуть список заказов в последнее сохраненное состояние";
            // 
            // ClothesShop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(906, 734);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxShowOrders);
            this.Controls.Add(this.buttonRestoreOrdersState);
            this.Controls.Add(this.buttonSaveOrdersState);
            this.Controls.Add(this.labelPrototype);
            this.Controls.Add(this.labelSingleton);
            this.Controls.Add(this.labelOrdersList);
            this.Controls.Add(this.labelMakeAnOrder);
            this.Controls.Add(this.buttonClone);
            this.Controls.Add(this.buttonSingleton);
            this.Controls.Add(this.buttonShowOrders);
            this.Controls.Add(this.buttonMakeAnOrder);
            this.Name = "ClothesShop";
            this.Text = "Мебельный магазин";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonMakeAnOrder;
        private System.Windows.Forms.Button buttonShowOrders;
        private System.Windows.Forms.Button buttonSingleton;
        private System.Windows.Forms.Button buttonClone;
        private System.Windows.Forms.Label labelMakeAnOrder;
        private System.Windows.Forms.Label labelOrdersList;
        private System.Windows.Forms.Label labelSingleton;
        private System.Windows.Forms.Label labelPrototype;
        private System.Windows.Forms.Button buttonSaveOrdersState;
        private System.Windows.Forms.Button buttonRestoreOrdersState;
        private System.Windows.Forms.TextBox textBoxShowOrders;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

