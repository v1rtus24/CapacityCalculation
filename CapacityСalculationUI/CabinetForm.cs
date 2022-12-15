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
        public MainSpecCabForm mainSpecCabForm { get; set; }
        //создаем объект типа кабинет, который содержит в себе количество сигналов
        public Cabinet cabinet { get; set; } = new Cabinet();
        // объкеты других форм
        public CalculationForm calculationForm { get; set; } 
        public ProfileForm profileForm { get; set; }
        public LoginForm _loginForm { get; set; }
        public int idCab { get; set; } 
        public int idTable { get; set; }

        //тут используется агрегация. В конструктор CabinetForm передается ссылка на уже имеющийся объект LoginForm.
        // а также объявляются объкеты других форм
        public CabinetForm(LoginForm loginForm)
        {
            _loginForm = loginForm;
            InitializeComponent();
            
            calculationForm = new CalculationForm(this)
            {
                Visible = false
            };
            profileForm = new ProfileForm(this)
            {
                Visible = false
            };
            //mainSpecCabForm = new MainSpecCabForm(this)
            //{
            //    Visible = false
            //};

            UpdateCabinetTable();          
        }
    
        /// <summary>
        /// Обновление данных в таблице шкафов
        /// </summary>
        private void UpdateCabinetTable()
        {
            dataGridView1.DataSource = _loginForm.dataBase.ShowData("SELECT * FROM TOS");            
            dataGridView1.Columns[1].HeaderText = "Тип";
            dataGridView1.Columns[0].Width = 40;
            dataGridView1.Columns[2].Width = 80;
            dataGridView1.Columns[3].Width = 50;
            dataGridView1.Columns[4].Width = 50;
            dataGridView1.Columns[5].Width = 50;
            dataGridView1.Columns[6].Width = 80;
            dataGridView1.Columns[7].Width = 80;
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            UpdateCabinetTable();

        }
        private void AddCabinet()
        {
            AddEditCabinet form = new AddEditCabinet();
            if (form.ShowDialog() == DialogResult.OK)
            {
                _loginForm.dataBase.AddCabinet(form.cabinet);
                UpdateCabinetTable();
                dataGridView1.Rows[dataGridView1.RowCount - 2].Selected = true;
                if (MessageBox.Show("Добавить состав шкафа?", "Оборудование шкафа", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    _loginForm.dataBase.AddMainCabSpec((int)dataGridView1.Rows[dataGridView1.RowCount - 2].Cells[0].Value);
                }
                else 
                {
                    _loginForm.dataBase.AddMainCabSpec((int)dataGridView1.Rows[dataGridView1.RowCount - 2].Cells[0].Value);
                }
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
                    _loginForm.dataBase.UpdateCabinet(id, form.cabinet);
                    UpdateCabinetTable();
                    dataGridView1.Rows[idTable].Selected = true;

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
                    _loginForm.dataBase.DeleteCabinet(idCab);
                    UpdateCabinetTable();
                    dataGridView1.Rows[dataGridView1.RowCount - 2].Selected = true;
                }
                else { return; }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
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
            if(_loginForm.dataBase.sqlConnection.State == ConnectionState.Open)
            {
                _loginForm.dataBase.sqlConnection.Close();
            }
            System.Windows.Forms.Application.Exit();
        }

        private void выходToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (_loginForm.dataBase.sqlConnection.State == ConnectionState.Open)
            {
                _loginForm.dataBase.sqlConnection.Close();
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
                else
                    ExcelApp.Quit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var mainSpecCabForm = new MainSpecCabForm(this); 
            mainSpecCabForm.StartPosition = FormStartPosition.Manual;
            mainSpecCabForm.Location = this.Location;
            mainSpecCabForm.ShowDialog();
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows[0].Cells[0].Value != null)
                {
                    idCab = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
                    idTable = (int)dataGridView1.SelectedRows[0].Index;
                }
                else 
                    return;
            }
            catch
            {
                MessageBox.Show("Что-то произошло");
            }
        }

        private void CabinetForm_Load(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows[0].Cells[0].Value != null)
            {
                idCab = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
                idTable = (int)dataGridView1.SelectedRows[0].Index;
            }
        }
    }
}
