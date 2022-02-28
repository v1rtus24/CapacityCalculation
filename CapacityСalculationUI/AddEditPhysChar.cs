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
    public partial class AddEditPhysChar : Form
    {
        public string NamePhysChar { get; set; }
        public string Signal { get; set; }
        public AddEditPhysChar()
        {
            InitializeComponent();
            comboBox1.Items.Add("AI");
            comboBox1.Items.Add("AO");
            comboBox1.Items.Add("DI");
            comboBox1.Items.Add("DO");
            comboBox1.Items.Add("RS485(ПЛК)");
            comboBox1.Items.Add("RS485(Шлюз)");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text) && comboBox1.SelectedItem != null)
            {
                NamePhysChar = textBox1.Text;
                Signal = comboBox1.SelectedItem.ToString();
                DialogResult = DialogResult.OK;
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
