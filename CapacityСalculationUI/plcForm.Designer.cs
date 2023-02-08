namespace CapacityСalculationUI
{
    partial class plcForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.AddPLC = new System.Windows.Forms.Button();
            this.UpdatePLC = new System.Windows.Forms.Button();
            this.DelPLC = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(11, 11);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(402, 226);
            this.dataGridView1.TabIndex = 7;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // AddPLC
            // 
            this.AddPLC.BackColor = System.Drawing.SystemColors.ControlLight;
            this.AddPLC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddPLC.Location = new System.Drawing.Point(11, 241);
            this.AddPLC.Margin = new System.Windows.Forms.Padding(2);
            this.AddPLC.Name = "AddPLC";
            this.AddPLC.Size = new System.Drawing.Size(80, 25);
            this.AddPLC.TabIndex = 20;
            this.AddPLC.Text = "Добавить";
            this.AddPLC.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.AddPLC.UseVisualStyleBackColor = false;
            this.AddPLC.Click += new System.EventHandler(this.AddPLC_Click);
            // 
            // UpdatePLC
            // 
            this.UpdatePLC.Location = new System.Drawing.Point(95, 241);
            this.UpdatePLC.Margin = new System.Windows.Forms.Padding(2);
            this.UpdatePLC.Name = "UpdatePLC";
            this.UpdatePLC.Size = new System.Drawing.Size(80, 25);
            this.UpdatePLC.TabIndex = 21;
            this.UpdatePLC.Text = "Изменить";
            this.UpdatePLC.UseVisualStyleBackColor = true;
            this.UpdatePLC.Click += new System.EventHandler(this.UpdatePLC_Click);
            // 
            // DelPLC
            // 
            this.DelPLC.Location = new System.Drawing.Point(179, 242);
            this.DelPLC.Margin = new System.Windows.Forms.Padding(2);
            this.DelPLC.Name = "DelPLC";
            this.DelPLC.Size = new System.Drawing.Size(80, 25);
            this.DelPLC.TabIndex = 22;
            this.DelPLC.Text = "Удалить";
            this.DelPLC.UseVisualStyleBackColor = true;
            this.DelPLC.Click += new System.EventHandler(this.DelPLC_Click);
            // 
            // plcForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 272);
            this.Controls.Add(this.DelPLC);
            this.Controls.Add(this.UpdatePLC);
            this.Controls.Add(this.AddPLC);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "plcForm";
            this.Text = "Список ПЛК";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.plcForm_FormClosing);
            this.Load += new System.EventHandler(this.plcForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button AddPLC;
        private System.Windows.Forms.Button UpdatePLC;
        private System.Windows.Forms.Button DelPLC;
    }
}