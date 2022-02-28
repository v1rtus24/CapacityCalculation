namespace CapacityСalculationUI
{
    partial class ProfileForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.WellDataGridView = new System.Windows.Forms.DataGridView();
            this.DeleteWellButton = new System.Windows.Forms.Button();
            this.AddWellButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.WellPadDataGridView = new System.Windows.Forms.DataGridView();
            this.DeleteWellPadButton = new System.Windows.Forms.Button();
            this.AddWellPadButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.UpdateFIeldButton = new System.Windows.Forms.Button();
            this.FieldDataGridView = new System.Windows.Forms.DataGridView();
            this.DeleteFieldButton = new System.Windows.Forms.Button();
            this.AddFieldButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.типыШкафовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.профилиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.подборШкафаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.PhysCharDataGridView = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.DeletePhysCharButton = new System.Windows.Forms.Button();
            this.AddPhysCharButton = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WellDataGridView)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WellPadDataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FieldDataGridView)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PhysCharDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.WellDataGridView);
            this.groupBox3.Controls.Add(this.DeleteWellButton);
            this.groupBox3.Controls.Add(this.AddWellButton);
            this.groupBox3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox3.Location = new System.Drawing.Point(416, 11);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(211, 320);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Скважина";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(88, 23);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 19);
            this.label4.TabIndex = 11;
            this.label4.Text = "Тип";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(11, 23);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 19);
            this.label3.TabIndex = 10;
            this.label3.Text = "Номер";
            // 
            // WellDataGridView
            // 
            this.WellDataGridView.AccessibleDescription = "";
            this.WellDataGridView.AllowUserToResizeColumns = false;
            this.WellDataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.WellDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.WellDataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.WellDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.WellDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            this.WellDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.WellDataGridView.ColumnHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.WellDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.WellDataGridView.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.WellDataGridView.Location = new System.Drawing.Point(14, 47);
            this.WellDataGridView.Margin = new System.Windows.Forms.Padding(2);
            this.WellDataGridView.MultiSelect = false;
            this.WellDataGridView.Name = "WellDataGridView";
            this.WellDataGridView.ReadOnly = true;
            this.WellDataGridView.RowHeadersVisible = false;
            this.WellDataGridView.RowHeadersWidth = 51;
            this.WellDataGridView.RowTemplate.Height = 24;
            this.WellDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.WellDataGridView.Size = new System.Drawing.Size(192, 206);
            this.WellDataGridView.TabIndex = 10;
            this.WellDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.WellDataGridView_CellClick);
            // 
            // DeleteWellButton
            // 
            this.DeleteWellButton.Location = new System.Drawing.Point(4, 269);
            this.DeleteWellButton.Margin = new System.Windows.Forms.Padding(2);
            this.DeleteWellButton.Name = "DeleteWellButton";
            this.DeleteWellButton.Size = new System.Drawing.Size(60, 19);
            this.DeleteWellButton.TabIndex = 8;
            this.DeleteWellButton.Text = "Удалить";
            this.DeleteWellButton.UseVisualStyleBackColor = true;
            this.DeleteWellButton.Click += new System.EventHandler(this.DeleteWellButton_Click);
            // 
            // AddWellButton
            // 
            this.AddWellButton.Location = new System.Drawing.Point(87, 271);
            this.AddWellButton.Margin = new System.Windows.Forms.Padding(2);
            this.AddWellButton.Name = "AddWellButton";
            this.AddWellButton.Size = new System.Drawing.Size(60, 19);
            this.AddWellButton.TabIndex = 7;
            this.AddWellButton.Text = "Добавить";
            this.AddWellButton.UseVisualStyleBackColor = true;
            this.AddWellButton.Click += new System.EventHandler(this.AddWellButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.WellPadDataGridView);
            this.groupBox2.Controls.Add(this.DeleteWellPadButton);
            this.groupBox2.Controls.Add(this.AddWellPadButton);
            this.groupBox2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(236, 11);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(175, 320);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Кустовая площадка";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(10, 23);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 19);
            this.label2.TabIndex = 8;
            this.label2.Text = "Номер КП";
            // 
            // WellPadDataGridView
            // 
            this.WellPadDataGridView.AccessibleDescription = "";
            this.WellPadDataGridView.AllowUserToResizeColumns = false;
            this.WellPadDataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.WellPadDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.WellPadDataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.WellPadDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.WellPadDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            this.WellPadDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.WellPadDataGridView.ColumnHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.WellPadDataGridView.DefaultCellStyle = dataGridViewCellStyle4;
            this.WellPadDataGridView.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.WellPadDataGridView.Location = new System.Drawing.Point(13, 49);
            this.WellPadDataGridView.Margin = new System.Windows.Forms.Padding(2);
            this.WellPadDataGridView.MultiSelect = false;
            this.WellPadDataGridView.Name = "WellPadDataGridView";
            this.WellPadDataGridView.ReadOnly = true;
            this.WellPadDataGridView.RowHeadersVisible = false;
            this.WellPadDataGridView.RowHeadersWidth = 51;
            this.WellPadDataGridView.RowTemplate.Height = 24;
            this.WellPadDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.WellPadDataGridView.Size = new System.Drawing.Size(158, 206);
            this.WellPadDataGridView.TabIndex = 9;
            this.WellPadDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.WellPadDataGridView_CellClick);
            // 
            // DeleteWellPadButton
            // 
            this.DeleteWellPadButton.Location = new System.Drawing.Point(76, 259);
            this.DeleteWellPadButton.Margin = new System.Windows.Forms.Padding(2);
            this.DeleteWellPadButton.Name = "DeleteWellPadButton";
            this.DeleteWellPadButton.Size = new System.Drawing.Size(38, 28);
            this.DeleteWellPadButton.TabIndex = 8;
            this.DeleteWellPadButton.Text = "Удалить";
            this.DeleteWellPadButton.UseVisualStyleBackColor = true;
            this.DeleteWellPadButton.Click += new System.EventHandler(this.DeleteWellPadButton_Click);
            // 
            // AddWellPadButton
            // 
            this.AddWellPadButton.Location = new System.Drawing.Point(13, 271);
            this.AddWellPadButton.Margin = new System.Windows.Forms.Padding(2);
            this.AddWellPadButton.Name = "AddWellPadButton";
            this.AddWellPadButton.Size = new System.Drawing.Size(52, 19);
            this.AddWellPadButton.TabIndex = 7;
            this.AddWellPadButton.Text = "Добавить";
            this.AddWellPadButton.UseVisualStyleBackColor = true;
            this.AddWellPadButton.Click += new System.EventHandler(this.AddWellPadButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.UpdateFIeldButton);
            this.groupBox1.Controls.Add(this.FieldDataGridView);
            this.groupBox1.Controls.Add(this.DeleteFieldButton);
            this.groupBox1.Controls.Add(this.AddFieldButton);
            this.groupBox1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(9, 11);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(223, 320);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Месторождение";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(11, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 19);
            this.label1.TabIndex = 7;
            this.label1.Text = "Название";
            // 
            // UpdateFIeldButton
            // 
            this.UpdateFIeldButton.Location = new System.Drawing.Point(70, 265);
            this.UpdateFIeldButton.Margin = new System.Windows.Forms.Padding(2);
            this.UpdateFIeldButton.Name = "UpdateFIeldButton";
            this.UpdateFIeldButton.Size = new System.Drawing.Size(71, 27);
            this.UpdateFIeldButton.TabIndex = 6;
            this.UpdateFIeldButton.Text = "Изменить";
            this.UpdateFIeldButton.UseVisualStyleBackColor = true;
            this.UpdateFIeldButton.Click += new System.EventHandler(this.UpdateFIeldButton_Click);
            // 
            // FieldDataGridView
            // 
            this.FieldDataGridView.AccessibleDescription = "";
            this.FieldDataGridView.AllowUserToResizeColumns = false;
            this.FieldDataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.FieldDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.FieldDataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.FieldDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.FieldDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            this.FieldDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FieldDataGridView.ColumnHeadersVisible = false;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.FieldDataGridView.DefaultCellStyle = dataGridViewCellStyle6;
            this.FieldDataGridView.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.FieldDataGridView.Location = new System.Drawing.Point(12, 47);
            this.FieldDataGridView.Margin = new System.Windows.Forms.Padding(2);
            this.FieldDataGridView.MultiSelect = false;
            this.FieldDataGridView.Name = "FieldDataGridView";
            this.FieldDataGridView.ReadOnly = true;
            this.FieldDataGridView.RowHeadersVisible = false;
            this.FieldDataGridView.RowHeadersWidth = 51;
            this.FieldDataGridView.RowTemplate.Height = 24;
            this.FieldDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.FieldDataGridView.Size = new System.Drawing.Size(206, 206);
            this.FieldDataGridView.TabIndex = 5;
            this.FieldDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.FieldDataGridView_CellClick);
            // 
            // DeleteFieldButton
            // 
            this.DeleteFieldButton.Location = new System.Drawing.Point(146, 267);
            this.DeleteFieldButton.Margin = new System.Windows.Forms.Padding(2);
            this.DeleteFieldButton.Name = "DeleteFieldButton";
            this.DeleteFieldButton.Size = new System.Drawing.Size(73, 26);
            this.DeleteFieldButton.TabIndex = 3;
            this.DeleteFieldButton.Text = "Удалить";
            this.DeleteFieldButton.UseVisualStyleBackColor = true;
            this.DeleteFieldButton.Click += new System.EventHandler(this.DeleteFieldButton_Click);
            // 
            // AddFieldButton
            // 
            this.AddFieldButton.Location = new System.Drawing.Point(4, 265);
            this.AddFieldButton.Margin = new System.Windows.Forms.Padding(2);
            this.AddFieldButton.Name = "AddFieldButton";
            this.AddFieldButton.Size = new System.Drawing.Size(61, 32);
            this.AddFieldButton.TabIndex = 2;
            this.AddFieldButton.Text = "Добавить";
            this.AddFieldButton.UseVisualStyleBackColor = true;
            this.AddFieldButton.Click += new System.EventHandler(this.AddFieldButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.типыШкафовToolStripMenuItem,
            this.профилиToolStripMenuItem,
            this.подборШкафаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 333);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(899, 24);
            this.menuStrip1.TabIndex = 13;
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
            // 
            // подборШкафаToolStripMenuItem
            // 
            this.подборШкафаToolStripMenuItem.Name = "подборШкафаToolStripMenuItem";
            this.подборШкафаToolStripMenuItem.Size = new System.Drawing.Size(103, 20);
            this.подборШкафаToolStripMenuItem.Text = "Подбор шкафа";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.PhysCharDataGridView);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.DeletePhysCharButton);
            this.groupBox4.Controls.Add(this.AddPhysCharButton);
            this.groupBox4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox4.Location = new System.Drawing.Point(631, 11);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox4.Size = new System.Drawing.Size(260, 320);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Подключения";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(91, 23);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(149, 19);
            this.label5.TabIndex = 13;
            this.label5.Text = "Тип подключения";
            // 
            // PhysCharDataGridView
            // 
            this.PhysCharDataGridView.AccessibleDescription = "";
            this.PhysCharDataGridView.AllowUserToResizeColumns = false;
            this.PhysCharDataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.PhysCharDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.PhysCharDataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.PhysCharDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PhysCharDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            this.PhysCharDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PhysCharDataGridView.ColumnHeadersVisible = false;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.PhysCharDataGridView.DefaultCellStyle = dataGridViewCellStyle8;
            this.PhysCharDataGridView.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.PhysCharDataGridView.Location = new System.Drawing.Point(9, 49);
            this.PhysCharDataGridView.Margin = new System.Windows.Forms.Padding(2);
            this.PhysCharDataGridView.MultiSelect = false;
            this.PhysCharDataGridView.Name = "PhysCharDataGridView";
            this.PhysCharDataGridView.ReadOnly = true;
            this.PhysCharDataGridView.RowHeadersVisible = false;
            this.PhysCharDataGridView.RowHeadersWidth = 51;
            this.PhysCharDataGridView.RowTemplate.Height = 24;
            this.PhysCharDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.PhysCharDataGridView.Size = new System.Drawing.Size(246, 206);
            this.PhysCharDataGridView.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(15, 23);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 19);
            this.label6.TabIndex = 12;
            this.label6.Text = "Имя";
            // 
            // DeletePhysCharButton
            // 
            this.DeletePhysCharButton.Location = new System.Drawing.Point(94, 263);
            this.DeletePhysCharButton.Margin = new System.Windows.Forms.Padding(2);
            this.DeletePhysCharButton.Name = "DeletePhysCharButton";
            this.DeletePhysCharButton.Size = new System.Drawing.Size(60, 19);
            this.DeletePhysCharButton.TabIndex = 8;
            this.DeletePhysCharButton.Text = "Удалить";
            this.DeletePhysCharButton.UseVisualStyleBackColor = true;
            // 
            // AddPhysCharButton
            // 
            this.AddPhysCharButton.Location = new System.Drawing.Point(18, 260);
            this.AddPhysCharButton.Margin = new System.Windows.Forms.Padding(2);
            this.AddPhysCharButton.Name = "AddPhysCharButton";
            this.AddPhysCharButton.Size = new System.Drawing.Size(60, 19);
            this.AddPhysCharButton.TabIndex = 7;
            this.AddPhysCharButton.Text = "Добавить";
            this.AddPhysCharButton.UseVisualStyleBackColor = true;
            this.AddPhysCharButton.Click += new System.EventHandler(this.AddPhysCharButton_Click);
            // 
            // ProfileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 357);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ProfileForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProfileForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ProfileForm_FormClosed);
            this.Load += new System.EventHandler(this.ProfileForm_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WellDataGridView)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WellPadDataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FieldDataGridView)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PhysCharDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button DeleteWellButton;
        private System.Windows.Forms.Button AddWellButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button DeleteWellPadButton;
        private System.Windows.Forms.Button AddWellPadButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button UpdateFIeldButton;
        private System.Windows.Forms.DataGridView FieldDataGridView;
        private System.Windows.Forms.Button DeleteFieldButton;
        private System.Windows.Forms.Button AddFieldButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem типыШкафовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem профилиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem подборШкафаToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button DeletePhysCharButton;
        private System.Windows.Forms.Button AddPhysCharButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView WellPadDataGridView;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView WellDataGridView;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView PhysCharDataGridView;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}