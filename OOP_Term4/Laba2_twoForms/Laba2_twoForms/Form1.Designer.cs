
namespace Laba2_twoForms
{
    partial class Form1
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.manufacturer = new System.Windows.Forms.Button();
            this.priceBox = new System.Windows.Forms.TextBox();
            this.amountLabel = new System.Windows.Forms.Label();
            this.amountTrackBar = new System.Windows.Forms.TrackBar();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.sizePan = new System.Windows.Forms.Panel();
            this.lengthBox = new System.Windows.Forms.TextBox();
            this.heightBox = new System.Windows.Forms.TextBox();
            this.widthBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.typeRadioButton2 = new System.Windows.Forms.RadioButton();
            this.typeRadioButton1 = new System.Windows.Forms.RadioButton();
            this.weightNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.numBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.addButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.readXml = new System.Windows.Forms.Button();
            this.saveXml = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.amountTrackBar)).BeginInit();
            this.sizePan.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.weightNumericUpDown)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(-4, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1140, 640);
            this.tabControl1.TabIndex = 12;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.manufacturer);
            this.tabPage1.Controls.Add(this.priceBox);
            this.tabPage1.Controls.Add(this.amountLabel);
            this.tabPage1.Controls.Add(this.amountTrackBar);
            this.tabPage1.Controls.Add(this.monthCalendar1);
            this.tabPage1.Controls.Add(this.sizePan);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.weightNumericUpDown);
            this.tabPage1.Controls.Add(this.numBox);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Controls.Add(this.nameBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1132, 607);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Описание";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // manufacturer
            // 
            this.manufacturer.BackColor = System.Drawing.Color.AliceBlue;
            this.manufacturer.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.manufacturer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.manufacturer.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.manufacturer.Location = new System.Drawing.Point(652, 480);
            this.manufacturer.Name = "manufacturer";
            this.manufacturer.Size = new System.Drawing.Size(218, 68);
            this.manufacturer.TabIndex = 27;
            this.manufacturer.Text = "Производитель";
            this.manufacturer.UseVisualStyleBackColor = false;
            this.manufacturer.Click += new System.EventHandler(this.manufacturer_Click);
            // 
            // priceBox
            // 
            this.priceBox.BackColor = System.Drawing.Color.White;
            this.priceBox.Location = new System.Drawing.Point(795, 414);
            this.priceBox.Name = "priceBox";
            this.priceBox.Size = new System.Drawing.Size(125, 27);
            this.priceBox.TabIndex = 26;
            // 
            // amountLabel
            // 
            this.amountLabel.AutoSize = true;
            this.amountLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.amountLabel.Location = new System.Drawing.Point(1008, 329);
            this.amountLabel.Name = "amountLabel";
            this.amountLabel.Size = new System.Drawing.Size(28, 28);
            this.amountLabel.TabIndex = 25;
            this.amountLabel.Text = " 1";
            // 
            // amountTrackBar
            // 
            this.amountTrackBar.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.amountTrackBar.Location = new System.Drawing.Point(805, 319);
            this.amountTrackBar.Maximum = 1000;
            this.amountTrackBar.Minimum = 1;
            this.amountTrackBar.Name = "amountTrackBar";
            this.amountTrackBar.Size = new System.Drawing.Size(197, 56);
            this.amountTrackBar.TabIndex = 24;
            this.amountTrackBar.Value = 1;
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(652, 76);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 23;
            // 
            // sizePan
            // 
            this.sizePan.Controls.Add(this.lengthBox);
            this.sizePan.Controls.Add(this.heightBox);
            this.sizePan.Controls.Add(this.widthBox);
            this.sizePan.Controls.Add(this.label5);
            this.sizePan.Controls.Add(this.label6);
            this.sizePan.Controls.Add(this.label7);
            this.sizePan.Controls.Add(this.label8);
            this.sizePan.Location = new System.Drawing.Point(34, 167);
            this.sizePan.Name = "sizePan";
            this.sizePan.Size = new System.Drawing.Size(340, 167);
            this.sizePan.TabIndex = 22;
            // 
            // lengthBox
            // 
            this.lengthBox.Location = new System.Drawing.Point(197, 128);
            this.lengthBox.Name = "lengthBox";
            this.lengthBox.Size = new System.Drawing.Size(125, 27);
            this.lengthBox.TabIndex = 6;
            // 
            // heightBox
            // 
            this.heightBox.Location = new System.Drawing.Point(119, 89);
            this.heightBox.Name = "heightBox";
            this.heightBox.Size = new System.Drawing.Size(125, 27);
            this.heightBox.TabIndex = 5;
            // 
            // widthBox
            // 
            this.widthBox.Location = new System.Drawing.Point(134, 46);
            this.widthBox.Name = "widthBox";
            this.widthBox.Size = new System.Drawing.Size(125, 27);
            this.widthBox.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(18, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(163, 28);
            this.label5.TabIndex = 3;
            this.label5.Text = "Длина/глубина :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(18, 85);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 28);
            this.label6.TabIndex = 2;
            this.label6.Text = "Высота :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(18, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 28);
            this.label7.TabIndex = 1;
            this.label7.Text = "Ширина :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(119, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 28);
            this.label8.TabIndex = 0;
            this.label8.Text = "Размер, м";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.typeRadioButton2);
            this.groupBox1.Controls.Add(this.typeRadioButton1);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(34, 440);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(250, 135);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Тип";
            // 
            // typeRadioButton2
            // 
            this.typeRadioButton2.AutoSize = true;
            this.typeRadioButton2.Location = new System.Drawing.Point(9, 80);
            this.typeRadioButton2.Name = "typeRadioButton2";
            this.typeRadioButton2.Size = new System.Drawing.Size(189, 32);
            this.typeRadioButton2.TabIndex = 12;
            this.typeRadioButton2.TabStop = true;
            this.typeRadioButton2.Text = "промышленный";
            this.typeRadioButton2.UseVisualStyleBackColor = true;
            // 
            // typeRadioButton1
            // 
            this.typeRadioButton1.AutoSize = true;
            this.typeRadioButton1.Checked = true;
            this.typeRadioButton1.Location = new System.Drawing.Point(9, 42);
            this.typeRadioButton1.Name = "typeRadioButton1";
            this.typeRadioButton1.Size = new System.Drawing.Size(199, 32);
            this.typeRadioButton1.TabIndex = 11;
            this.typeRadioButton1.TabStop = true;
            this.typeRadioButton1.Text = "потребительский";
            this.typeRadioButton1.UseVisualStyleBackColor = true;
            // 
            // weightNumericUpDown
            // 
            this.weightNumericUpDown.DecimalPlaces = 4;
            this.weightNumericUpDown.Location = new System.Drawing.Point(147, 377);
            this.weightNumericUpDown.Name = "weightNumericUpDown";
            this.weightNumericUpDown.Size = new System.Drawing.Size(131, 27);
            this.weightNumericUpDown.TabIndex = 20;
            // 
            // numBox
            // 
            this.numBox.Location = new System.Drawing.Point(281, 98);
            this.numBox.Name = "numBox";
            this.numBox.Size = new System.Drawing.Size(163, 27);
            this.numBox.TabIndex = 19;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(652, 410);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(121, 28);
            this.label9.TabIndex = 18;
            this.label9.Text = "Цена, BYN :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(652, 329);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(134, 28);
            this.label10.TabIndex = 17;
            this.label10.Text = "Количество :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(652, 32);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(194, 28);
            this.label11.TabIndex = 16;
            this.label11.Text = "Дата поступления :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label12.Location = new System.Drawing.Point(34, 372);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(85, 28);
            this.label12.TabIndex = 15;
            this.label12.Text = "Вес, кг :";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label13.Location = new System.Drawing.Point(34, 94);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(222, 28);
            this.label13.TabIndex = 14;
            this.label13.Text = "Инвентарный номер :";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label14.Location = new System.Drawing.Point(34, 32);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(113, 28);
            this.label14.TabIndex = 13;
            this.label14.Text = "Название :";
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(168, 36);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(337, 27);
            this.nameBox.TabIndex = 12;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.addButton);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.dataGridView2);
            this.tabPage2.Controls.Add(this.dataGridView1);
            this.tabPage2.Controls.Add(this.readXml);
            this.tabPage2.Controls.Add(this.saveXml);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1132, 607);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Сохранение формы";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // addButton
            // 
            this.addButton.BackColor = System.Drawing.Color.Lavender;
            this.addButton.FlatAppearance.BorderColor = System.Drawing.Color.CornflowerBlue;
            this.addButton.FlatAppearance.BorderSize = 2;
            this.addButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addButton.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.addButton.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.addButton.Location = new System.Drawing.Point(893, 24);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(196, 57);
            this.addButton.TabIndex = 6;
            this.addButton.Text = "Добавить";
            this.addButton.UseVisualStyleBackColor = false;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(38, 359);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(185, 28);
            this.label2.TabIndex = 5;
            this.label2.Text = "ПРОИЗВОДИТЕЛЬ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(38, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 28);
            this.label1.TabIndex = 4;
            this.label1.Text = "ТОВАР";
            // 
            // dataGridView2
            // 
            this.dataGridView2.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column9,
            this.Column10,
            this.Column11,
            this.Column12});
            this.dataGridView2.Location = new System.Drawing.Point(38, 390);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 29;
            this.dataGridView2.Size = new System.Drawing.Size(556, 171);
            this.dataGridView2.TabIndex = 3;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Организация";
            this.Column9.MinimumWidth = 6;
            this.Column9.Name = "Column9";
            this.Column9.Width = 125;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "Страна";
            this.Column10.MinimumWidth = 6;
            this.Column10.Name = "Column10";
            this.Column10.Width = 125;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "Адрес";
            this.Column11.MinimumWidth = 6;
            this.Column11.Name = "Column11";
            this.Column11.Width = 125;
            // 
            // Column12
            // 
            this.Column12.HeaderText = "Телефон";
            this.Column12.MinimumWidth = 6;
            this.Column12.Name = "Column12";
            this.Column12.Width = 125;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8});
            this.dataGridView1.Location = new System.Drawing.Point(38, 144);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(1051, 188);
            this.dataGridView1.TabIndex = 2;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Название";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 125;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Инвентарный номер";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 125;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Размер (высота×ширина×длина), м";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Width = 125;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Вес, кг";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.Width = 125;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Тип";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.Width = 125;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Дата поступления";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.Width = 125;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Количество";
            this.Column7.MinimumWidth = 6;
            this.Column7.Name = "Column7";
            this.Column7.Width = 125;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Цена, BYN";
            this.Column8.MinimumWidth = 6;
            this.Column8.Name = "Column8";
            this.Column8.Width = 125;
            // 
            // readXml
            // 
            this.readXml.BackColor = System.Drawing.Color.White;
            this.readXml.Cursor = System.Windows.Forms.Cursors.Hand;
            this.readXml.FlatAppearance.BorderColor = System.Drawing.Color.CornflowerBlue;
            this.readXml.FlatAppearance.BorderSize = 2;
            this.readXml.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.readXml.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.readXml.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.readXml.Location = new System.Drawing.Point(472, 24);
            this.readXml.Name = "readXml";
            this.readXml.Size = new System.Drawing.Size(397, 57);
            this.readXml.TabIndex = 1;
            this.readXml.Text = "Прочитать данные из json-файла";
            this.readXml.UseVisualStyleBackColor = false;
            this.readXml.Click += new System.EventHandler(this.readXml_Click);
            // 
            // saveXml
            // 
            this.saveXml.BackColor = System.Drawing.Color.White;
            this.saveXml.Cursor = System.Windows.Forms.Cursors.Hand;
            this.saveXml.FlatAppearance.BorderColor = System.Drawing.Color.CornflowerBlue;
            this.saveXml.FlatAppearance.BorderSize = 2;
            this.saveXml.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveXml.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.saveXml.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.saveXml.Location = new System.Drawing.Point(38, 24);
            this.saveXml.Name = "saveXml";
            this.saveXml.Size = new System.Drawing.Size(397, 57);
            this.saveXml.TabIndex = 0;
            this.saveXml.Text = "Сохранить данные в json-файл";
            this.saveXml.UseVisualStyleBackColor = false;
            this.saveXml.Click += new System.EventHandler(this.saveXml_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1133, 636);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Товар";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.amountTrackBar)).EndInit();
            this.sizePan.ResumeLayout(false);
            this.sizePan.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.weightNumericUpDown)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel sizePan;
        private System.Windows.Forms.TextBox lengthBox;
        private System.Windows.Forms.TextBox heightBox;
        private System.Windows.Forms.TextBox widthBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton typeRadioButton2;
        private System.Windows.Forms.RadioButton typeRadioButton1;
        private System.Windows.Forms.NumericUpDown weightNumericUpDown;
        private System.Windows.Forms.TextBox numBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Button manufacturer;
        private System.Windows.Forms.TextBox priceBox;
        private System.Windows.Forms.Label amountLabel;
        private System.Windows.Forms.TrackBar amountTrackBar;
        private System.Windows.Forms.Button readXml;
        private System.Windows.Forms.Button saveXml;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.Button addButton;
    }
}

