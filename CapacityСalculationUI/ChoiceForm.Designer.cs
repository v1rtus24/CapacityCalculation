namespace CapacityСalculationUI
{
    partial class ChoiceForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChoiceForm));
            this.FieldRadioButton = new System.Windows.Forms.RadioButton();
            this.WellPadRadioButton = new System.Windows.Forms.RadioButton();
            this.WellRadioButton = new System.Windows.Forms.RadioButton();
            this.PhysCharRadioButton = new System.Windows.Forms.RadioButton();
            this.OkeyButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // FieldRadioButton
            // 
            this.FieldRadioButton.AutoSize = true;
            this.FieldRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FieldRadioButton.Location = new System.Drawing.Point(12, 21);
            this.FieldRadioButton.Name = "FieldRadioButton";
            this.FieldRadioButton.Size = new System.Drawing.Size(167, 24);
            this.FieldRadioButton.TabIndex = 0;
            this.FieldRadioButton.TabStop = true;
            this.FieldRadioButton.Text = "Месторождение";
            this.FieldRadioButton.UseVisualStyleBackColor = true;
            // 
            // WellPadRadioButton
            // 
            this.WellPadRadioButton.AutoEllipsis = true;
            this.WellPadRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.WellPadRadioButton.Location = new System.Drawing.Point(12, 47);
            this.WellPadRadioButton.Name = "WellPadRadioButton";
            this.WellPadRadioButton.Size = new System.Drawing.Size(181, 52);
            this.WellPadRadioButton.TabIndex = 1;
            this.WellPadRadioButton.TabStop = true;
            this.WellPadRadioButton.Text = "Кустовая площадка";
            this.WellPadRadioButton.UseVisualStyleBackColor = true;
            // 
            // WellRadioButton
            // 
            this.WellRadioButton.AutoSize = true;
            this.WellRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.WellRadioButton.Location = new System.Drawing.Point(12, 105);
            this.WellRadioButton.Name = "WellRadioButton";
            this.WellRadioButton.Size = new System.Drawing.Size(113, 24);
            this.WellRadioButton.TabIndex = 2;
            this.WellRadioButton.TabStop = true;
            this.WellRadioButton.Text = "Скважина";
            this.WellRadioButton.UseVisualStyleBackColor = true;
            // 
            // PhysCharRadioButton
            // 
            this.PhysCharRadioButton.AutoSize = true;
            this.PhysCharRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PhysCharRadioButton.Location = new System.Drawing.Point(12, 135);
            this.PhysCharRadioButton.Name = "PhysCharRadioButton";
            this.PhysCharRadioButton.Size = new System.Drawing.Size(147, 24);
            this.PhysCharRadioButton.TabIndex = 3;
            this.PhysCharRadioButton.TabStop = true;
            this.PhysCharRadioButton.Text = "Подключения";
            this.PhysCharRadioButton.UseVisualStyleBackColor = true;
            // 
            // OkeyButton
            // 
            this.OkeyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OkeyButton.Location = new System.Drawing.Point(35, 185);
            this.OkeyButton.Name = "OkeyButton";
            this.OkeyButton.Size = new System.Drawing.Size(90, 30);
            this.OkeyButton.TabIndex = 4;
            this.OkeyButton.Text = "Ok";
            this.OkeyButton.UseVisualStyleBackColor = true;
            this.OkeyButton.Click += new System.EventHandler(this.OkeyButton_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(131, 185);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(90, 30);
            this.button2.TabIndex = 5;
            this.button2.Text = "Отмена";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ChoiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(263, 238);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.OkeyButton);
            this.Controls.Add(this.PhysCharRadioButton);
            this.Controls.Add(this.WellRadioButton);
            this.Controls.Add(this.WellPadRadioButton);
            this.Controls.Add(this.FieldRadioButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ChoiceForm";
            this.Text = "Выберите";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton FieldRadioButton;
        private System.Windows.Forms.RadioButton WellPadRadioButton;
        private System.Windows.Forms.RadioButton WellRadioButton;
        private System.Windows.Forms.RadioButton PhysCharRadioButton;
        private System.Windows.Forms.Button OkeyButton;
        private System.Windows.Forms.Button button2;
    }
}