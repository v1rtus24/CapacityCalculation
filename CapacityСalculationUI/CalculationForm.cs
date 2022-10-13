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
using DGVPrinterHelper;
using System.Drawing.Printing;

namespace CapacityСalculationUI
{
    public partial class CalculationForm : Form
    {
        private DataBase data;
        private List<string[]> dataField = new List<string[]>();
        private List<string[]> dataWellPad = new List<string[]>();
        public CabinetForm _cabinetForm { get; set; }

        private int idField { get; set; }
        private int idWellPad { get; set; }
        public CalculationForm(CabinetForm cabinetForm)
        {
            _cabinetForm = cabinetForm;
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
                double AIrez = Math.Ceiling(data.CalculationSignal("AI", idWellPad) + data.CalculationSignal("AI", idWellPad) * 0.2);
                double AOrez = Math.Ceiling(data.CalculationSignal("AO", idWellPad) + data.CalculationSignal("AO", idWellPad) * 0.2);
                double DIrez = Math.Ceiling(data.CalculationSignal("DI", idWellPad) + data.CalculationSignal("DI", idWellPad) * 0.3);
                double DOrez = Math.Ceiling(data.CalculationSignal("DO", idWellPad) + data.CalculationSignal("DO", idWellPad) * 0.3);
                int RS485PLK = data.CalculationSignal("RS485(ПЛК)", idWellPad);
                int RS485SHL= data.CalculationSignal("RS485(Шлюз)", idWellPad);
                dataGridView1["Column1", gridCount].Value = comboBox1.SelectedItem;
                dataGridView1["Column2", gridCount].Value = comboBox2.SelectedItem;
                dataGridView1["Column3", gridCount].Value = data.CalculationWell("Добывающая", idWellPad).ToString();
                dataGridView1["Column4", gridCount].Value = data.CalculationWell("Нагнетательная", idWellPad).ToString();
                dataGridView1["AI", gridCount].Value = AIrez;
                dataGridView1["AO", gridCount].Value = AOrez;
                dataGridView1["DI", gridCount].Value = DIrez;
                dataGridView1["DO", gridCount].Value = DOrez;
                dataGridView1["RS485PLK", gridCount].Value = RS485PLK;
                dataGridView1["RS485SHL", gridCount].Value = RS485SHL;
                List<string[]> typeCab = data.CalculationCabinet((int)AIrez, (int)DIrez, (int)AOrez, (int)DOrez, RS485PLK, RS485SHL);
                string types ="";
               for(int i = 0; i < typeCab.Count; i++)
                {
                    if (i == typeCab.Count - 1)
                    {
                        types += typeCab[i][0];
                        break;
                    }
                   types += typeCab[i][0] + ", ";
                }
                dataGridView1["Type", gridCount].Value = types;
                gridCount++;
                //double AIrez = Math.Ceiling(data.CalculationSignal("AI", idWellPad) + data.CalculationSignal("AI", idWellPad) * 0.2);
                //double AOrez = Math.Ceiling(data.CalculationSignal("AO", idWellPad) +data.CalculationSignal("AO", idWellPad) * 0.2);
                //double DIrez = Math.Ceiling(data.CalculationSignal("DI", idWellPad) + data.CalculationSignal("DI", idWellPad) * 0.3);
                //double DOrez = Math.Ceiling(data.CalculationSignal("DO", idWellPad) + data.CalculationSignal("DO", idWellPad) * 0.3);
                //label1.Text = AIrez.ToString();
                //label2.Text = DIrez.ToString();
                //label3.Text = AOrez.ToString();
                //label4.Text = DOrez.ToString();
                comboBox1.Text = "";
                comboBox2.Text = "";
                dataGridView1.CurrentCell = dataGridView1[0, dataGridView1.Rows.Count - 2];
                comboBox2.Items.Clear();

            }
            else
            {
                MessageBox.Show("Выберите месторожение и КП!");
            }
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedCells[0].Value != null)
            {
                int ind = -1;
                ind = dataGridView1.SelectedRows[0].Index;
                int AI, AO, DI, DO, RS485PLK, RS485SHL = 0;
                AI = Convert.ToInt32(dataGridView1["AI", ind].Value);
                AO = Convert.ToInt32(dataGridView1["AO", ind].Value);
                DI = Convert.ToInt32(dataGridView1["DI", ind].Value);
                DO = Convert.ToInt32(dataGridView1["DO", ind].Value);
                RS485PLK = Convert.ToInt32(dataGridView1["RS485PLK", ind].Value);
                RS485SHL = Convert.ToInt32(dataGridView1["RS485SHL", ind].Value);
                double AIrez = (double)dataGridView1["AI", ind].Value;
                double AOrez = (double)dataGridView1["AO", ind].Value;
                double DIrez = (double)dataGridView1["DI", ind].Value;
                double DOrez = (double)dataGridView1["DO", ind].Value;
                //label1.Text = AIrez.ToString();
                //label2.Text = DIrez.ToString();
                //label3.Text = AOrez.ToString();
                //label4.Text = DOrez.ToString();
                List<string[]> typeCab = data.CalculationCabinet((int)AIrez, (int)DIrez, (int)AOrez, (int)DOrez, RS485PLK, RS485SHL);
                dataGridView2.Rows.Clear();
                if (typeCab != null && dataGridView1.SelectedCells[0].Value != null)
                {
                    foreach (string[] s in typeCab)
                    {
                        dataGridView2.Rows.Add(s);
                    }
                }
            }
        }
        private void профилиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            _cabinetForm.profileForm.StartPosition = FormStartPosition.Manual;
            _cabinetForm.profileForm.Location = this.Location;
            _cabinetForm.profileForm.Show();
        }

        private void типыШкафовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            _cabinetForm.StartPosition = FormStartPosition.Manual;
            _cabinetForm.Location = this.Location;
            _cabinetForm.Show();
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

        private void обновитьБдToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataField.Clear();
            comboBox1.Items.Clear();
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

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        // обновление бд при изменении visible
        private void CalculationForm_VisibleChanged(object sender, EventArgs e)
        {
            dataField.Clear();
            comboBox1.Items.Clear();
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

        private void сохранитьВExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.DefaultExt = ".xlsx";
            saveFileDialog1.Filter = ".xlsx|.xlsx";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK && saveFileDialog1.FileName.Length > 0)
            {
                Cursor.Current = Cursors.WaitCursor;
                Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                var workbook = ExcelApp.Application.Workbooks.Add();
                ExcelApp.Columns[9].ColumnWidth = 15;
                ExcelApp.Columns[10].ColumnWidth = 15;
                ExcelApp.Columns[11].ColumnWidth = 25;
                ExcelApp.Cells[1, 1] = "Месторождение";
                ExcelApp.Cells[1, 2] = "№ КП";
                ExcelApp.Cells[1, 3] = "Доб.";
                ExcelApp.Cells[1, 4] = "Нагнет.";
                ExcelApp.Cells[1, 5] = "AI";
                ExcelApp.Cells[1, 6] = "DI";
                ExcelApp.Cells[1, 7] = "AO";
                ExcelApp.Cells[1, 8] = "DO";
                ExcelApp.Cells[1, 9] = "RS485(ПЛК)";
                ExcelApp.Cells[1, 10] = "RS485(ШЛЮЗ)";
                ExcelApp.Cells[1, 11] = "Тип шкафа";

                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                {
                    for (int j = 0; j < dataGridView1.RowCount; j++)
                    {
                        if (dataGridView1[i, j].Value != null)
                            ExcelApp.Cells[j + 2, i + 1] = (dataGridView1[i, j].Value).ToString();
                    }
                }
                ExcelApp.AlertBeforeOverwriting = true;
                workbook.SaveAs(saveFileDialog1.FileName);

                DialogResult dialogResult = MessageBox.Show("Сохранение завершено. Открыть файл?", "Экспорт .xlsx", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.Yes)
                {
                    ExcelApp.Visible = true;
                }
            }
        }

        private void печатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            Margins margin = new Margins(30, 30, 30, 30);
            printer.PrintMargins = margin;
            printer.PrintDataGridView(dataGridView1);
        }
    }
}
