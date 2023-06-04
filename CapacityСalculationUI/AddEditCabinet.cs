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
        public Cabinet CabinetTM { get; set; } 
        public AddEditCabinet()
        {
            InitializeComponent();
        }

        private void AddCabinet_Load(object sender, EventArgs e)
        {
            if (CabinetTM != null)
            {
                textBox1.Text = CabinetTM.Name;
                textBox2.Text = CabinetTM.SignalAI.ToString();
                textBox3.Text = CabinetTM.SignalAO.ToString();
                textBox4.Text = CabinetTM.SignalDI.ToString();
                textBox5.Text = CabinetTM.SignalDO.ToString();
                textBox6.Text = CabinetTM.SignalRS485PLK.ToString();
                textBox7.Text = CabinetTM.SignalRS485SHL.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OkButton_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrEmpty(textBox3.Text)
                   && !string.IsNullOrEmpty(textBox4.Text) && !string.IsNullOrEmpty(textBox5.Text)
                   && !string.IsNullOrEmpty(textBox6.Text) && !string.IsNullOrEmpty(textBox7.Text))
                {
                    CabinetTM = new Cabinet();
                    CabinetTM.Name = textBox1.Text;
                    CabinetTM.SignalAI = Convert.ToInt32(textBox2.Text);
                    CabinetTM.SignalAO = Convert.ToInt32(textBox3.Text);
                    CabinetTM.SignalDI = Convert.ToInt32(textBox4.Text);
                    CabinetTM.SignalDO = Convert.ToInt32(textBox5.Text);
                    CabinetTM.SignalRS485PLK = Convert.ToInt32(textBox6.Text);
                    CabinetTM.SignalRS485SHL = Convert.ToInt32(textBox7.Text);
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
    }
}
