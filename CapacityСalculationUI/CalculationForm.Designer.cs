namespace CapacityСalculationUI
{
    partial class CalculationForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CalculationForm));
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.типыШкафовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.профилиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.подборШкафаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.печатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьВExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.экспортВExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RS485PLK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RS485SHL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label8 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dgType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgAI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgDI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgAO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgDO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgRS485PLK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgRS485SHL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label12 = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(161, 36);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(224, 27);
            this.comboBox1.TabIndex = 6;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(462, 35);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(72, 29);
            this.comboBox2.TabIndex = 7;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(594, 464);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(202, 33);
            this.button2.TabIndex = 8;
            this.button2.Text = "Подобрать шкаф";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.типыШкафовToolStripMenuItem,
            this.профилиToolStripMenuItem,
            this.подборШкафаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 499);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(807, 24);
            this.menuStrip1.TabIndex = 14;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // типыШкафовToolStripMenuItem
            // 
            this.типыШкафовToolStripMenuItem.Name = "типыШкафовToolStripMenuItem";
            this.типыШкафовToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
            this.типыШкафовToolStripMenuItem.Text = "Типы шкафов";
            this.типыШкафовToolStripMenuItem.Click += new System.EventHandler(this.типыШкафовToolStripMenuItem_Click);
            // 
            // профилиToolStripMenuItem
            // 
            this.профилиToolStripMenuItem.Name = "профилиToolStripMenuItem";
            this.профилиToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.профилиToolStripMenuItem.Text = "Профили";
            this.профилиToolStripMenuItem.Click += new System.EventHandler(this.профилиToolStripMenuItem_Click);
            // 
            // подборШкафаToolStripMenuItem
            // 
            this.подборШкафаToolStripMenuItem.Name = "подборШкафаToolStripMenuItem";
            this.подборШкафаToolStripMenuItem.Size = new System.Drawing.Size(103, 20);
            this.подборШкафаToolStripMenuItem.Text = "Подбор шкафа";
            // 
            // menuStrip2
            // 
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сохранитьToolStripMenuItem,
            this.экспортВExcelToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip2.Size = new System.Drawing.Size(807, 24);
            this.menuStrip2.TabIndex = 15;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.печатьToolStripMenuItem,
            this.сохранитьВExcelToolStripMenuItem});
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.сохранитьToolStripMenuItem.Text = "Печать";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // печатьToolStripMenuItem
            // 
            this.печатьToolStripMenuItem.Name = "печатьToolStripMenuItem";
            this.печатьToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.печатьToolStripMenuItem.Text = "Печать";
            this.печатьToolStripMenuItem.Click += new System.EventHandler(this.печатьToolStripMenuItem_Click);
            // 
            // сохранитьВExcelToolStripMenuItem
            // 
            this.сохранитьВExcelToolStripMenuItem.Name = "сохранитьВExcelToolStripMenuItem";
            this.сохранитьВExcelToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.сохранитьВExcelToolStripMenuItem.Text = "Сохранить в Excel";
            this.сохранитьВExcelToolStripMenuItem.Click += new System.EventHandler(this.сохранитьВExcelToolStripMenuItem_Click);
            // 
            // экспортВExcelToolStripMenuItem
            // 
            this.экспортВExcelToolStripMenuItem.Name = "экспортВExcelToolStripMenuItem";
            this.экспортВExcelToolStripMenuItem.Size = new System.Drawing.Size(103, 20);
            this.экспортВExcelToolStripMenuItem.Text = "Экспорт в Excel";
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(9, 39);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(148, 19);
            this.label6.TabIndex = 16;
            this.label6.Text = "Месторождение:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(402, 39);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 19);
            this.label7.TabIndex = 17;
            this.label7.Text = "№ КП:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.AI,
            this.DI,
            this.AO,
            this.DO,
            this.RS485PLK,
            this.RS485SHL,
            this.Type});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(11, 109);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(785, 157);
            this.dataGridView1.TabIndex = 18;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // Column1
            // 
            this.Column1.Frozen = true;
            this.Column1.HeaderText = "Месторождение";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 160;
            // 
            // Column2
            // 
            this.Column2.Frozen = true;
            this.Column2.HeaderText = "КП";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 50;
            // 
            // Column3
            // 
            this.Column3.Frozen = true;
            this.Column3.HeaderText = "Доб";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 50;
            // 
            // Column4
            // 
            this.Column4.Frozen = true;
            this.Column4.HeaderText = "Нагн";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 50;
            // 
            // AI
            // 
            this.AI.Frozen = true;
            this.AI.HeaderText = "AI";
            this.AI.MinimumWidth = 6;
            this.AI.Name = "AI";
            this.AI.ReadOnly = true;
            this.AI.Width = 45;
            // 
            // DI
            // 
            this.DI.Frozen = true;
            this.DI.HeaderText = "DI";
            this.DI.MinimumWidth = 6;
            this.DI.Name = "DI";
            this.DI.ReadOnly = true;
            this.DI.Width = 45;
            // 
            // AO
            // 
            this.AO.Frozen = true;
            this.AO.HeaderText = "AO";
            this.AO.MinimumWidth = 6;
            this.AO.Name = "AO";
            this.AO.ReadOnly = true;
            this.AO.Width = 45;
            // 
            // DO
            // 
            this.DO.Frozen = true;
            this.DO.HeaderText = "DO";
            this.DO.MinimumWidth = 6;
            this.DO.Name = "DO";
            this.DO.ReadOnly = true;
            this.DO.Width = 45;
            // 
            // RS485PLK
            // 
            this.RS485PLK.HeaderText = "RS485 (ПЛК)";
            this.RS485PLK.MinimumWidth = 6;
            this.RS485PLK.Name = "RS485PLK";
            this.RS485PLK.ReadOnly = true;
            this.RS485PLK.Width = 70;
            // 
            // RS485SHL
            // 
            this.RS485SHL.HeaderText = "RS485 (ШЛЮЗ)";
            this.RS485SHL.MinimumWidth = 6;
            this.RS485SHL.Name = "RS485SHL";
            this.RS485SHL.ReadOnly = true;
            this.RS485SHL.Width = 75;
            // 
            // Type
            // 
            this.Type.HeaderText = "Тип шкафа";
            this.Type.MinimumWidth = 6;
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            this.Type.Width = 125;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(303, 77);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(463, 21);
            this.label8.TabIndex = 19;
            this.label8.Text = "Требуемая информацинная ёмкость с учётом резерва:";
            // 
            // dataGridView2
            // 
            this.dataGridView2.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView2.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgType,
            this.dgAI,
            this.dgDI,
            this.dgAO,
            this.dgDO,
            this.dgRS485PLK,
            this.dgRS485SHL});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView2.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView2.Location = new System.Drawing.Point(13, 311);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(577, 186);
            this.dataGridView2.TabIndex = 23;
            // 
            // dgType
            // 
            this.dgType.HeaderText = "Тип";
            this.dgType.MinimumWidth = 6;
            this.dgType.Name = "dgType";
            this.dgType.ReadOnly = true;
            this.dgType.Width = 120;
            // 
            // dgAI
            // 
            this.dgAI.HeaderText = "AI";
            this.dgAI.MinimumWidth = 6;
            this.dgAI.Name = "dgAI";
            this.dgAI.ReadOnly = true;
            this.dgAI.Width = 50;
            // 
            // dgDI
            // 
            this.dgDI.HeaderText = "DI";
            this.dgDI.MinimumWidth = 6;
            this.dgDI.Name = "dgDI";
            this.dgDI.ReadOnly = true;
            this.dgDI.Width = 50;
            // 
            // dgAO
            // 
            this.dgAO.HeaderText = "AO";
            this.dgAO.MinimumWidth = 6;
            this.dgAO.Name = "dgAO";
            this.dgAO.ReadOnly = true;
            this.dgAO.Width = 50;
            // 
            // dgDO
            // 
            this.dgDO.HeaderText = "DO";
            this.dgDO.MinimumWidth = 6;
            this.dgDO.Name = "dgDO";
            this.dgDO.ReadOnly = true;
            this.dgDO.Width = 50;
            // 
            // dgRS485PLK
            // 
            this.dgRS485PLK.HeaderText = "RS485(ПЛК)";
            this.dgRS485PLK.MinimumWidth = 6;
            this.dgRS485PLK.Name = "dgRS485PLK";
            this.dgRS485PLK.ReadOnly = true;
            this.dgRS485PLK.Width = 115;
            // 
            // dgRS485SHL
            // 
            this.dgRS485SHL.HeaderText = "RS485(ШЛЮЗ)";
            this.dgRS485SHL.MinimumWidth = 6;
            this.dgRS485SHL.Name = "dgRS485SHL";
            this.dgRS485SHL.ReadOnly = true;
            this.dgRS485SHL.Width = 120;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(12, 279);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(260, 21);
            this.label12.TabIndex = 24;
            this.label12.Text = "Рекомендуемые типы шкафов:";
            // 
            // CalculationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 523);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.menuStrip2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip2;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "CalculationForm";
            this.Text = "Рассчёт";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CalculationForm_FormClosing);
            this.VisibleChanged += new System.EventHandler(this.CalculationForm_VisibleChanged);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem типыШкафовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem профилиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem подборШкафаToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgType;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgAI;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgDI;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgAO;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgDO;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgRS485PLK;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgRS485SHL;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem печатьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьВExcelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem экспортВExcelToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn AI;
        private System.Windows.Forms.DataGridViewTextBoxColumn DI;
        private System.Windows.Forms.DataGridViewTextBoxColumn AO;
        private System.Windows.Forms.DataGridViewTextBoxColumn DO;
        private System.Windows.Forms.DataGridViewTextBoxColumn RS485PLK;
        private System.Windows.Forms.DataGridViewTextBoxColumn RS485SHL;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
    }
}