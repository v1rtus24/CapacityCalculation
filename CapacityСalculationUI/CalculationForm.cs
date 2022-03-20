using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapacityCalculation;

namespace CapacityСalculationUI
{
    public partial class CalculationForm : Form
    {
        private DataBase data;
        private List<string[]> dataField = new List<string[]>();
        private List<string[]> dataWellPad = new List<string[]>();
        private int idField { get; set; }
        private int idWellPad { get; set; }
        public CalculationForm()
        {
            InitializeComponent();
            data = new DataBase();
            data.sqlConnection.Open();
            string query = "SELECT * FROM Field";
            SqlCommand sqlCommand = new SqlCommand(query, data.sqlConnection);
            SqlDataReader dataReader = sqlCommand.ExecuteReader();
            while (dataReader.Read())
            {
                dataField.Add(new string[2]);
                dataField[dataField.Count - 1][0] = dataReader[0].ToString();
                dataField[dataField.Count - 1][1] = dataReader[1].ToString();
            }
            dataReader.Close();
            for (int i = 0; i < dataField.Count; i++)
            {
                comboBox1.Items.Add(dataField[i][1]);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            dataWellPad.Clear();
            idField = Convert.ToInt32(dataField[comboBox1.SelectedIndex][0]);
            string query = "SELECT * FROM WellPad WHERE Field_id =" + idField + "";
            SqlCommand sqlCommand = new SqlCommand(query, data.sqlConnection);
            SqlDataReader dataReader = sqlCommand.ExecuteReader();
            while (dataReader.Read())
            {
                dataWellPad.Add(new string[2]);
                dataWellPad[dataWellPad.Count - 1][0] = dataReader[0].ToString();
                dataWellPad[dataWellPad.Count - 1][1] = dataReader[1].ToString();
            }
            dataReader.Close();
            for (int i = 0; i < dataWellPad.Count; i++)
            {
                comboBox2.Items.Add(dataWellPad[i][1]);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            idWellPad = Convert.ToInt32(dataWellPad[comboBox2.SelectedIndex][0]);
        }

        private int gridCount { get; set; } = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "" && comboBox2.Text != "")
            {
                dataGridView1.Rows.Add();
                dataGridView1["Column1", gridCount].Value = comboBox1.SelectedItem;
                dataGridView1["Column2", gridCount].Value = comboBox2.SelectedItem;
                dataGridView1["Column3", gridCount].Value = data.CalculationWell("Добывающая", idWellPad, data.sqlConnection).ToString();
                dataGridView1["Column4", gridCount].Value = data.CalculationWell("Нагнетательная", idWellPad, data.sqlConnection).ToString();
                dataGridView1["AI", gridCount].Value = data.CalculationSignal("AI", idWellPad, data.sqlConnection).ToString();
                dataGridView1["AO", gridCount].Value = data.CalculationSignal("AO", idWellPad, data.sqlConnection).ToString();
                dataGridView1["DI", gridCount].Value = data.CalculationSignal("DI", idWellPad, data.sqlConnection).ToString();
                dataGridView1["DO", gridCount].Value = data.CalculationSignal("DO", idWellPad, data.sqlConnection).ToString();
                dataGridView1["RS485PLK", gridCount].Value = data.CalculationSignal("RS485(ПЛК)", idWellPad, data.sqlConnection).ToString();
                dataGridView1["RS485SHL", gridCount].Value = data.CalculationSignal("RS485(Шлюз)", idWellPad, data.sqlConnection).ToString();
                gridCount++;
                double AIrez = Math.Ceiling(data.CalculationSignal("AI", idWellPad, data.sqlConnection) + data.CalculationSignal("AI", idWellPad, data.sqlConnection) * 0.2);
                double AOrez = Math.Ceiling(data.CalculationSignal("AO", idWellPad, data.sqlConnection) +data.CalculationSignal("AO", idWellPad, data.sqlConnection) * 0.2);
                double DIrez = Math.Ceiling(data.CalculationSignal("DI", idWellPad, data.sqlConnection) + data.CalculationSignal("DI", idWellPad, data.sqlConnection) * 0.3);
                double DOrez = Math.Ceiling(data.CalculationSignal("DO", idWellPad, data.sqlConnection) + data.CalculationSignal("DO", idWellPad, data.sqlConnection) * 0.3);
                label1.Text = AIrez.ToString();
                label2.Text = DIrez.ToString();
                label3.Text = AOrez.ToString();
                label4.Text = DOrez.ToString();
                comboBox1.Text = "";
                comboBox2.Text = "";
            }
            else
            {
                MessageBox.Show("Выберите месторожение и КП!");
            }
        }

        private void профилиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form = new ProfileForm();
            form.StartPosition = FormStartPosition.Manual;
            form.Location = this.Location;
            form.Show();
        }

        private void типыШкафовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form = new CabinetForm();
            form.StartPosition = FormStartPosition.Manual;
            form.Location = this.Location;
            form.Show();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (data.sqlConnection.State == ConnectionState.Open)
            {
                data.sqlConnection.Close();
            }
            Application.Exit();
        }

        private void CalculationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (data.sqlConnection.State == ConnectionState.Open)
            {
                data.sqlConnection.Close();
            }
            Application.Exit();
        }
    }
}
