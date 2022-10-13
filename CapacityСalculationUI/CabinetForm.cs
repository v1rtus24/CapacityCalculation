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
using System.Reflection;
using Microsoft.Office.Interop.Excel;
using System.Threading;
using DGVPrinterHelper; 

namespace CapacityСalculationUI
{
    
    public partial class CabinetForm : Form
    {
        public Cabinet cabinet { get; set; } = new Cabinet();
        public CalculationForm calculationForm { get; set; } 
        public ProfileForm profileForm { get; set; } 

        private DataBase data;
        public CabinetForm()
        {
            InitializeComponent();
            calculationForm = new CalculationForm(this)
            {
                Visible = false
            };
            profileForm = new ProfileForm(this)
            {
                Visible = false
            };
            data = new DataBase();
            data.sqlConnection.Open();
            UpdateCabinetTable();          
        }
    
        /// <summary>
        /// Обновление данных в таблице шкафов
        /// </summary>
        private void UpdateCabinetTable()
        {
            dataGridView1.DataSource = data.ShowData("SELECT * FROM TOS");
            dataGridView1.Columns[1].HeaderText = "Тип";
            dataGridView1.Columns[0].Width = 40;
            dataGridView1.Columns[2].Width = 80;
            dataGridView1.Columns[3].Width = 50;
            dataGridView1.Columns[4].Width = 50;
            dataGridView1.Columns[5].Width = 50;
            dataGridView1.Columns[6].Width = 80;
            dataGridView1.Columns[7].Width = 80;
        }



        private void AddCabinet()
        {
            AddEditCabinet form = new AddEditCabinet();
            if (form.ShowDialog() == DialogResult.OK)
            {
                data.AddCabinet(form.cabinet);
                UpdateCabinetTable();
            }
        }
        private void UpdateCabinet()
        {
            AddEditCabinet form = new AddEditCabinet();
            if (dataGridView1.SelectedRows[0].Cells[1].Value != null)
            {
                cabinet.Name = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                cabinet.SignalAI = (int)dataGridView1.SelectedRows[0].Cells[2].Value;
                cabinet.SignalAO = (int)dataGridView1.SelectedRows[0].Cells[3].Value;
                cabinet.SignalDI = (int)dataGridView1.SelectedRows[0].Cells[4].Value;
                cabinet.SignalDO = (int)dataGridView1.SelectedRows[0].Cells[5].Value;
                cabinet.SignalRS485PLK = (int)dataGridView1.SelectedRows[0].Cells[6].Value;
                cabinet.SignalRS485SHL = (int)dataGridView1.SelectedRows[0].Cells[7].Value;
                form.cabinet = cabinet;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    int id = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
                    data.UpdateCabinet(id, form.cabinet);
                    UpdateCabinetTable();
                }
            }
            else
            {
                MessageBox.Show("Выберите шкаф");
            }
        }
        private void DeleteCabinet()
        {
            try
            {
                if (dataGridView1.SelectedRows[0].Cells[0].Value != null)
                {
                    int id = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
                    data.DeleteCabinet(id);
                    UpdateCabinetTable();
                }
                else { return; }
            }
            catch
            {
                MessageBox.Show("Выберите шкаф");
            }
        }
        private void AddCabinetButton_Click_1(object sender, EventArgs e)
        {
            AddCabinet();
        }
        private void UpdateCabinetButton_Click_1(object sender, EventArgs e)
        {
            UpdateCabinet();
        }


        private void DeleteCabinetButton_Click_1(object sender, EventArgs e)
        {
            DeleteCabinet();
        }

        private void добавитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddCabinet();
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteCabinet();
        }

        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateCabinet();
        }

        private void CabinetForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(data.sqlConnection.State == ConnectionState.Open)
            {
                data.sqlConnection.Close();
            }
            System.Windows.Forms.Application.Exit();
        }

        private void выходToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (data.sqlConnection.State == ConnectionState.Open)
            {
                data.sqlConnection.Close();
            }
            System.Windows.Forms.Application.Exit();
        }

        private void подборШкафаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            calculationForm.StartPosition = FormStartPosition.Manual;
            calculationForm.Location = this.Location;
            calculationForm.Show();
        }
        private void профилиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            profileForm.StartPosition = FormStartPosition.Manual;
            profileForm.Location = this.Location;
            profileForm.Show();
        }


        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void pdfToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.PrintDataGridView(dataGridView1);
           
        }

        private void excelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.DefaultExt = ".xlsx";
            saveFileDialog1.Filter = ".xlsx|.xlsx";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK && saveFileDialog1.FileName.Length > 0)
            {
                Cursor.Current = Cursors.WaitCursor;
                Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                var workbook = ExcelApp.Application.Workbooks.Add();
                ExcelApp.Columns[7].ColumnWidth = 15;
                ExcelApp.Columns[8].ColumnWidth = 15;
                ExcelApp.Cells[1, 1] = "Id";
                ExcelApp.Cells[1, 2] = "Тип";
                ExcelApp.Cells[1, 3] = "AI";
                ExcelApp.Cells[1, 4] = "AO";
                ExcelApp.Cells[1, 5] = "DI";
                ExcelApp.Cells[1, 6] = "DO";
                ExcelApp.Cells[1, 7] = "RS485(ПЛК)";
                ExcelApp.Cells[1, 8] = "RS485(ШЛЮЗ)";

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
    }
}
