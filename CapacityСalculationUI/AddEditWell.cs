using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapacityСalculationUI
{
    public partial class AddEditWell : Form
    {
        public string TypeWell { get; set; }   
        public int NumWell { get; set; }
        public AddEditWell()
        {
            InitializeComponent();
            comboBox1.Items.Add("Добывающая");
            comboBox1.Items.Add("Нагнетательная");
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text) || !string.IsNullOrEmpty(comboBox1.Text))
            {
                try
                {
                    NumWell = Convert.ToInt32(textBox1.Text);
                    TypeWell = comboBox1.SelectedItem.ToString();
                    DialogResult = DialogResult.OK;
                }
                catch
                {
                    MessageBox.Show("Проверьте правильность ввода");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Заполните все поля!");
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
