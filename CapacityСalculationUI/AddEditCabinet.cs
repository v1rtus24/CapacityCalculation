using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapacityCalculation;

namespace CapacityСalculationUI
{
    public partial class AddEditCabinet : Form
    {
        public Cabinet cabinet { get; set; } 
        public AddEditCabinet()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrEmpty(textBox3.Text)
                   && !string.IsNullOrEmpty(textBox4.Text) && !string.IsNullOrEmpty(textBox5.Text)
                   && !string.IsNullOrEmpty(textBox6.Text) && !string.IsNullOrEmpty(textBox7.Text))
                {
                    cabinet = new Cabinet();
                    cabinet.Name = textBox1.Text;
                    cabinet.SignalAI = Convert.ToInt32(textBox2.Text);
                    cabinet.SignalAO = Convert.ToInt32(textBox3.Text);
                    cabinet.SignalDI = Convert.ToInt32(textBox4.Text);
                    cabinet.SignalDO = Convert.ToInt32(textBox5.Text);
                    cabinet.SignalRS485PLK = Convert.ToInt32(textBox6.Text);
                    cabinet.SignalRS485SHL = Convert.ToInt32(textBox7.Text);
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Заполните все поля!");
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Несоответсвие типов(Проверьте ввод данных)");
            }
        }

        private void AddCabinet_Load(object sender, EventArgs e)
        {
            if (cabinet != null)
            {
                textBox1.Text = cabinet.Name;
                textBox2.Text = cabinet.SignalAI.ToString();
                textBox3.Text = cabinet.SignalAO.ToString();
                textBox4.Text = cabinet.SignalDI.ToString();
                textBox5.Text = cabinet.SignalDO.ToString();
                textBox6.Text = cabinet.SignalRS485PLK.ToString();
                textBox7.Text = cabinet.SignalRS485SHL.ToString();
            }
        }
    }
}
