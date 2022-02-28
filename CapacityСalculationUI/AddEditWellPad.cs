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
    public partial class AddEditWellPad : Form
    {
        public int WellPadNum { get; set; }
        public AddEditWellPad()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                try
                {
                    WellPadNum = Convert.ToInt32(textBox1.Text);
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
