using CapacityCalculation;
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
        public TypeTecObj Type { get; set; }
        public int NumWell { get; set; }
        public AddEditWell()
        {
            InitializeComponent();
            comboBox1.Items.Add("Добывающая скважина");
            comboBox1.Items.Add("Нагнетательная скважина");
            comboBox1.Items.Add("Емкость подземная дренажная");
            comboBox1.Items.Add("Нагнетательный коллектор");
            comboBox1.Items.Add("Нефтегазосборный трубопровод от ИУ");
            comboBox1.Items.Add("Измерительная установка");
            comboBox1.Items.Add("УДЭ");
            comboBox1.Items.Add("ДФКУ");
            comboBox1.Items.Add("Блок контейнер НКУ");
            comboBox1.Items.Add("Шкаф ПС");
            comboBox1.Items.Add("Шкаф ОС");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text) || !string.IsNullOrEmpty(comboBox1.Text))
            {
                try
                {
                    NumWell = Convert.ToInt32(textBox1.Text);
                    TypeWell = comboBox1.SelectedItem.ToString();
                    switch (comboBox1.Text)
                    {
                        case "Добывающая скважина":
                            Type = TypeTecObj.DobSkvaz;
                            break;
                        case "Нагнетательная скважина":
                            Type = TypeTecObj.NagnSkvaz;
                            break;
                        case "Емкость подземная дренажная":
                            Type = TypeTecObj.EmkPodzDren;
                            break;
                        case "Нагнетательный коллектор":
                            Type = TypeTecObj.NagnCol;
                            break;
                        case "Нефтегазосборный трубопровод от ИУ":
                            Type = TypeTecObj.NeftegazTrub;
                            break;
                        case "Измерительная установка":
                            Type = TypeTecObj.IzmUst;
                            break;
                        case "УДЭ":
                            Type = TypeTecObj.UDE;
                            break;
                        case "ДФКУ":
                            Type = TypeTecObj.DFKU;
                            break;
                        case "Блок контейнер НКУ":
                            Type = TypeTecObj.BlokContNKU;
                            break;
                        case "Шкаф ПС":
                            Type = TypeTecObj.CabPS;
                            break;
                        case "Шкаф ОС":
                            Type = TypeTecObj.CabOS;
                            break;
                    }
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
