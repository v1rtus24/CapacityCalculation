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
using System.Data.SqlClient;

namespace CapacityСalculationUI
{
    
    public partial class CabinetForm : Form
    {
        public MainSpecCabForm mainSpecCabForm { get; set; }
        //создаем объект типа кабинет, который содержит в себе количество сигналов
        public Cabinet CabinetTM { get; set; } = new Cabinet();
        // объкеты других форм
        public CalculationForm CalculationForm { get; set; } 
        public ProfileForm ProfileForm { get; set; }
        public LoginForm LoginForm { get; set; }
        public int CabID { get; set; } 
        public int TableID { get; set; }
        public List<Cabinet> constCabs { get; set; }
        ToolTip t = new ToolTip();

        //тут используется агрегация. В конструктор CabinetForm передается ссылка на уже имеющийся объект LoginForm.
        // а также объявляются объкеты других форм
        public CabinetForm(LoginForm loginForm)
        {
            constCabs = new List<Cabinet>(){new Cabinet("Тип 1",32,38,0,0,2,3), new Cabinet("Тип 2", 48, 59, 0, 0, 2, 5),
                new Cabinet("Тип 3", 63, 76, 0, 0, 2, 6), new Cabinet("Тип 4", 4, 24, 0, 0, 4, 3),
                new Cabinet("Тип 5", 4, 39, 0, 0, 7, 5), new Cabinet("Тип 6", 4, 52, 0, 0, 9, 6) };
            
            LoginForm = loginForm;
            InitializeComponent();
            if (!loginForm.localLogin)
            {
                CalculationForm = new CalculationForm(this)
                {
                    Visible = false
                };
                ProfileForm = new ProfileForm(this)
                {
                    Visible = false
                };
                UpdateCabinetTableOnline();
            }
            else
            {
                UpdateCabinetTableLocal();
                ProfileForm = new ProfileForm(this)
                {
                    Visible = false
                };
                CalculationForm = new CalculationForm(this)
                {
                    Visible = false
                };
            }
        }
    
        /// <summary>
        /// Обновление данных в таблице шкафов c подключением к БД
        /// </summary>
        private void UpdateCabinetTableOnline()
        {          
            //dataGridView1.DataSource = LoginForm.dataBase.ShowData("SELECT * FROM TOS");            
            //dataGridView1.Columns[1].HeaderText = "Тип";
            //dataGridView1.Columns[0].Visible = false;
            //dataGridView1.Columns[2].Width = 80;
            //dataGridView1.Columns[3].Width = 50;
            //dataGridView1.Columns[4].Width = 50;
            //dataGridView1.Columns[5].Width = 50;
            //dataGridView1.Columns[6].Width = 80;
            //dataGridView1.Columns[7].Width = 80;
            dataGridView1.Rows.Clear();
            SqlCommand command = new SqlCommand("SELECT * FROM TOS",LoginForm.dataBase.sqlConnection);
            SqlDataReader reader = command.ExecuteReader();
            int ind = 0;
            while (reader.Read())
            {
                dataGridView1.Rows.Add();
                dataGridView1[0, ind].Value = reader[0].ToString();
                dataGridView1[1, ind].Value = reader[1].ToString();
                dataGridView1[2, ind].Value = reader[2].ToString();
                dataGridView1[3, ind].Value = reader[3].ToString();
                dataGridView1[4, ind].Value = reader[4].ToString();
                dataGridView1[5, ind].Value = reader[5].ToString();
                dataGridView1[6, ind].Value = reader[6].ToString();
                dataGridView1[7, ind].Value = reader[7].ToString();
                ind++;
            }
            reader.Close();
        }

        private void UpdateCabinetTableLocal()
        {
            int ind = 0;
            foreach (var cab in constCabs)
            {
                dataGridView1.Rows.Add();
                dataGridView1[1, ind].Value = cab.Name;
                dataGridView1[2, ind].Value = cab.SignalAI;
                dataGridView1[3, ind].Value = cab.SignalAO;
                dataGridView1[4, ind].Value = cab.SignalDI;
                dataGridView1[5, ind].Value = cab.SignalDO;
                dataGridView1[6, ind].Value = cab.SignalRS485PLK;
                dataGridView1[7, ind].Value = cab.SignalRS485SHL;
                ind++;
            }
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (!LoginForm.localLogin)
            {
                UpdateCabinetTableOnline();
            }
            else
            {
                MessageBox.Show("Для обновления списка типов необходимо подключение к БД!","Используется локальная версия",
                    MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }
        private void AddCabinet()
        {
            if (!LoginForm.localLogin)
            {
                AddEditCabinet form = new AddEditCabinet();
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoginForm.dataBase.AddCabinet(form.CabinetTM);
                    UpdateCabinetTableOnline();
                    dataGridView1.Rows[dataGridView1.RowCount - 2].Selected = true;
                    if (MessageBox.Show("Добавить состав шкафа?", "Оборудование шкафа", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        try
                        {
                            int id = Convert.ToInt32(dataGridView1.Rows[dataGridView1.RowCount - 2].Cells[0].Value.ToString());
                            LoginForm.dataBase.AddMainCabSpec(id);
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else
                    {
                        LoginForm.dataBase.AddMainCabSpec((int)dataGridView1.Rows[dataGridView1.RowCount - 2].Cells[0].Value);
                    }
                }
            }
            else
            {
                MessageBox.Show("Для добавления новых типов шкафов необходимо подключение к БД!", "Используется локальная версия",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void UpdateCabinet()
        {
            if (!LoginForm.localLogin)
            {
                AddEditCabinet form = new AddEditCabinet();
                if (dataGridView1.SelectedRows[0].Cells[1].Value != null)
                {
                    CabinetTM.Name = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                    CabinetTM.SignalAI = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[2].Value.ToString());
                    CabinetTM.SignalAO = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[3].Value.ToString());
                    CabinetTM.SignalDI = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[4].Value.ToString());
                    CabinetTM.SignalDO = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[5].Value.ToString());
                    CabinetTM.SignalRS485PLK = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[6].Value.ToString());
                    CabinetTM.SignalRS485SHL = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[7].Value.ToString());
                    form.CabinetTM = CabinetTM;
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        int id = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
                        LoginForm.dataBase.UpdateCabinet(id, form.CabinetTM);
                        UpdateCabinetTableOnline();
                        dataGridView1.Rows[TableID].Selected = true;
                    }
                }
                else
                {
                    MessageBox.Show("Выберите шкаф");
                }
            }
            else
            {
                MessageBox.Show("Для добавления новых типов шкафов необходимо подключение к БД!", "Используется локальная версия",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DeleteCabinet()
        {
            if (!LoginForm.localLogin)
            {
                try
                {
                    if (dataGridView1.SelectedRows[0].Cells[0].Value != null)
                    {
                        LoginForm.dataBase.DeleteCabinet(CabID);
                        UpdateCabinetTableOnline();
                        dataGridView1.Rows[dataGridView1.RowCount - 2].Selected = true;
                    }
                    else
                    {
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Для добавления новых типов шкафов необходимо подключение к БД!", "Используется локальная версия",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (!LoginForm.localLogin)
            {
                if (LoginForm.dataBase.sqlConnection.State == ConnectionState.Open)
                {
                    LoginForm.dataBase.sqlConnection.Close();
                }
                System.Windows.Forms.Application.Exit();
            }
            else
                System.Windows.Forms.Application.Exit();
        }

        private void выходToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!LoginForm.localLogin)
            {
                if (LoginForm.dataBase.sqlConnection.State == ConnectionState.Open)
                {
                    LoginForm.dataBase.sqlConnection.Close();
                }
                System.Windows.Forms.Application.Exit();
            }
            else
                System.Windows.Forms.Application.Exit();
        }

        private void подборШкафаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            CalculationForm.StartPosition = FormStartPosition.Manual;
            CalculationForm.Location = this.Location;
            CalculationForm.Show();
        }
        private void профилиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            ProfileForm.StartPosition = FormStartPosition.Manual;
            ProfileForm.Location = this.Location;
            ProfileForm.Show();
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
                ExcelApp.Columns.HorizontalAlignment = HorizontalAlignment.Center;
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
                        else
                            break;
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
            if (!LoginForm.localLogin)
            {
                var mainSpecCabForm = new MainSpecCabForm(this);
                mainSpecCabForm.StartPosition = FormStartPosition.Manual;
                mainSpecCabForm.Location = this.Location;
                mainSpecCabForm.ShowDialog();
            }
            else
            {
                if (dataGridView1.SelectedRows[0].Index == 0)
                {
                    MessageBox.Show("- Шкаф ТМ должен обеспечивать возможность приема и передачи данных по интерфейсу RS-485 через шлюз сбора" +
                        " данных не менее чем по 3-м портам (подключение ЭЦН, ЛСУ ИУ).\n- ПЛК шкафа ТМ должен " +
                        "обеспечивать возможность приема (передачи) данных по интерфейсу RS-485 по 2-м портам.\n" +
                        "- Оборудования шкафа ТМ должно быть совместимо с системой телеметрии «Телескоп+»", "Прочие требование",MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (dataGridView1.SelectedRows[0].Index == 1)
                {
                    MessageBox.Show("- Шкаф ТМ должен обеспечивать возможность приема и передачи данных по интерфейсу RS-485 через шлюз сбора" +
                        " данных не менее чем по 5-м портам (подключение ЭЦН, ЛСУ ИУ).\n- ПЛК шкафа ТМ должен " +
                        "обеспечивать возможность приема (передачи) данных по интерфейсу RS-485 по 2-м портам.\n" +
                        "- Оборудования шкафа ТМ должно быть совместимо с системой телеметрии «Телескоп+»", "Прочие требование", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (dataGridView1.SelectedRows[0].Index == 2)
                {
                    MessageBox.Show("- Шкаф ТМ должен обеспечивать возможность приема и передачи данных по интерфейсу RS-485 через шлюз сбора" +
                        " данных не менее чем по 6-м портам (подключение ЭЦН, ЛСУ ИУ).\n- ПЛК шкафа ТМ должен " +
                        "обеспечивать возможность приема (передачи) данных по интерфейсу RS-485 по 2-м портам.\n" +
                        "- Оборудования шкафа ТМ должно быть совместимо с системой телеметрии «Телескоп+»", "Прочие требование", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (dataGridView1.SelectedRows[0].Index == 3)
                {
                    MessageBox.Show("- Шкаф ТМ должен обеспечивать возможность приема и передачи данных по интерфейсу RS-485 через шлюз сбора" +
                        " данных не менее чем по 3-м портам (подключение ЭЦН, ЛСУ ИУ).\n- ПЛК шкафа ТМ должен " +
                        "обеспечивать возможность приема (передачи) данных по интерфейсу RS-485 по 4-м портам.\n" +
                        "- Оборудования шкафа ТМ должно быть совместимо с системой телеметрии «Телескоп+»", "Прочие требование", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (dataGridView1.SelectedRows[0].Index == 4)
                {
                    MessageBox.Show("- Шкаф ТМ должен обеспечивать возможность приема и передачи данных по интерфейсу RS-485 через шлюз сбора" +
                        " данных не менее чем по 5-м портам (подключение ЭЦН, ЛСУ ИУ).\n- ПЛК шкафа ТМ должен " +
                        "обеспечивать возможность приема (передачи) данных по интерфейсу RS-485 по 7-м портам.\n" +
                        "- Оборудования шкафа ТМ должно быть совместимо с системой телеметрии «Телескоп+»", "Прочие требование", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (dataGridView1.SelectedRows[0].Index == 5)
                {
                    MessageBox.Show("- Шкаф ТМ должен обеспечивать возможность приема и передачи данных по интерфейсу RS-485 через шлюз сбора" +
                        " данных не менее чем по 6-м портам (подключение ЭЦН, ЛСУ ИУ).\n- ПЛК шкафа ТМ должен " +
                        "обеспечивать возможность приема (передачи) данных по интерфейсу RS-485 по 9-м портам.\n" +
                        "- Оборудования шкафа ТМ должно быть совместимо с системой телеметрии «Телескоп+»", "Прочие требование", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //
            try
            {
                if (dataGridView1.SelectedRows[0].Cells[0].Value != null)
                {
                    CabID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                    TableID = (int)dataGridView1.SelectedRows[0].Index;
                }
                else 
                    return;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CabinetForm_Load(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows[0].Cells[0].Value != null)
                {
                    CabID = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
                    TableID = (int)dataGridView1.SelectedRows[0].Index;
                }
            }
            catch
            {
                return;
            }
        }

    }
}
