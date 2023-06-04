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
    public partial class AddEditPLC : Form
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Ip { get; set; }
        public string Other { get; set; }
        ToolTip t = new ToolTip();

        public AddEditPLC()
        {
            InitializeComponent();
            comboBox1.Items.Add("IP20");
            comboBox1.Items.Add("IP21");
            comboBox1.Items.Add("IP22");
            comboBox1.Items.Add("IP23");
            comboBox1.Items.Add("IP54");
            comboBox1.Items.Add("IP65");
            comboBox1.Items.Add("IP66");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(comboBox1.Text)
                && !string.IsNullOrEmpty(textBox2.Text))
            {
                Brand = textBox1.Text;
                Model = textBox2.Text;
                Ip = comboBox1.Text;
                Other = textBox3.Text;
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

        private void AddEditPLC_Load(object sender, EventArgs e)
        {
            if (Brand != null && Model !=null)
            {
                textBox1.Text = Brand;
                textBox2.Text = Model;
                comboBox1.Text = Ip;
                textBox3.Text = Other;
            }
        }

        private void ipButton_Click(object sender, EventArgs e)
        {
            var ip = new ipForm();
            ip.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            var ip = new ipForm();
            ip.Show();
        }

        private void label3_MouseMove(object sender, MouseEventArgs e)
        {
            t.SetToolTip(label3, "Нажмите для подсказки");
        }
    }
}
