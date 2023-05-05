﻿using System;
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
        //private DataBase data;
        private List<string[]> DataField = new List<string[]>();
        private List<string[]> dataWellPad = new List<string[]>();
        public Cabinet CurrentCab { get; set; }
        List<Cabinet> TypeCabs { get; set; }
        public CabinetForm CabinetForm { get; set; }
        public LoginForm LoginForm { get; set; }
        private int FieldID { get; set; }
        private int WellPadID { get; set; }
        public CalculationForm(CabinetForm cabinetForm)
        {
            CabinetForm = cabinetForm;
            LoginForm = cabinetForm.LoginForm;
            InitializeComponent();
            if (LoginForm.localLogin)
            {

            }
            else
            {
                string query = "SELECT * FROM Field";
                using (SqlCommand sqlCommand = new SqlCommand(query, CabinetForm.LoginForm.dataBase.sqlConnection))
                {
                    SqlDataReader dataReader = sqlCommand.ExecuteReader();
                    while (dataReader.Read())
                    {
                        DataField.Add(new string[2]);
                        DataField[DataField.Count - 1][0] = dataReader[0].ToString();
                        DataField[DataField.Count - 1][1] = dataReader[1].ToString();
                    }
                    dataReader.Close();
                }
                for (int i = 0; i < DataField.Count; i++)
                {
                    comboBox1.Items.Add(DataField[i][1]);
                }
            }
            ALLRadioButton.Enabled = false; AIRadioButton.Enabled = false; DIRadioButton.Enabled = false;
            AORadioButton.Enabled = false; DORadioButton.Enabled = false; RS485PLKRadioButton.Enabled = false;
            RS485SHLRadioButton.Enabled = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            dataWellPad.Clear();
            FieldID = Convert.ToInt32(DataField[comboBox1.SelectedIndex][0]);
            string query = "SELECT * FROM WellPad WHERE Field_id =" + FieldID + "";
            using (SqlCommand sqlCommand = new SqlCommand(query, CabinetForm.LoginForm.dataBase.sqlConnection))
            {
                SqlDataReader dataReader = sqlCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    dataWellPad.Add(new string[2]);
                    dataWellPad[dataWellPad.Count - 1][0] = dataReader[0].ToString();
                    dataWellPad[dataWellPad.Count - 1][1] = dataReader[1].ToString();
                }
                dataReader.Close();
            }
            for (int i = 0; i < dataWellPad.Count; i++)
            {
                comboBox2.Items.Add(dataWellPad[i][1]);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            WellPadID = Convert.ToInt32(dataWellPad[comboBox2.SelectedIndex][0]);
        }

        private int gridCount { get; set; } = 0;

        private void CalcButton_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "" && comboBox2.Text != "")
            {
                dataGridView1.Rows.Add();
                double AIrez = Math.Ceiling(LoginForm.dataBase.CalculationSignal("AI", WellPadID) + LoginForm.dataBase.CalculationSignal("AI", WellPadID) * 0.2);
                double AOrez = Math.Ceiling(LoginForm.dataBase.CalculationSignal("AO", WellPadID) + LoginForm.dataBase.CalculationSignal("AO", WellPadID) * 0.2);
                double DIrez = Math.Ceiling(LoginForm.dataBase.CalculationSignal("DI", WellPadID) + LoginForm.dataBase.CalculationSignal("DI", WellPadID) * 0.3);
                double DOrez = Math.Ceiling(LoginForm.dataBase.CalculationSignal("DO", WellPadID) + LoginForm.dataBase.CalculationSignal("DO", WellPadID) * 0.3);
                int RS485PLK = LoginForm.dataBase.CalculationSignal("RS485(ПЛК)", WellPadID);
                int RS485SHL= LoginForm.dataBase.CalculationSignal("RS485(Шлюз)", WellPadID);
                dataGridView1["Column1", gridCount].Value = comboBox1.SelectedItem;
                dataGridView1["Column2", gridCount].Value = comboBox2.SelectedItem;
                dataGridView1["Column3", gridCount].Value = LoginForm.dataBase.CalculationWell("Добывающая", WellPadID).ToString();
                dataGridView1["Column4", gridCount].Value = LoginForm.dataBase.CalculationWell("Нагнетательная", WellPadID).ToString();
                dataGridView1["AI", gridCount].Value = AIrez;
                dataGridView1["AO", gridCount].Value = AOrez;
                dataGridView1["DI", gridCount].Value = DIrez;
                dataGridView1["DO", gridCount].Value = DOrez;
                dataGridView1["RS485PLK", gridCount].Value = RS485PLK;
                dataGridView1["RS485SHL", gridCount].Value = RS485SHL;
                TypeCabs = LoginForm.dataBase.CalculationCabinet((int)AIrez, (int)DIrez, (int)AOrez, (int)DOrez, RS485PLK, RS485SHL);
                CurrentCab = new Cabinet("name", (int)AIrez, (int)DIrez, (int)AOrez, (int)DOrez, RS485PLK, RS485SHL);
                dataGridView2.Rows.Clear();
                Cabinet PodCab = Cabinet.FilterAllSignal(TypeCabs, CurrentCab);
                string[] cab = new string[7];
                cab[0] = PodCab.Name; cab[1] = PodCab.SignalAI.ToString(); cab[2] = PodCab.SignalDI.ToString();
                cab[3] = PodCab.SignalAO.ToString(); cab[4] = PodCab.SignalDO.ToString(); cab[5] = PodCab.SignalRS485PLK.ToString();
                cab[6] = PodCab.SignalRS485SHL.ToString();
                dataGridView2.Rows.Add(cab);
                
                //if (typeCabs != null && dataGridView1.SelectedCells[0].Value != null)
                //{
                //    string[] cabs = new string[7];
                //    for(int i = 0; i < typeCabs.Count; i++)
                //    {
                //        cabs[0] = typeCabs[i].Name; cabs[1] = typeCabs[i].SignalAI.ToString(); cabs[2] = typeCabs[i].SignalDI.ToString();
                //        cabs[3] = typeCabs[i].SignalAO.ToString(); cabs[4] = typeCabs[i].SignalDO.ToString(); cabs[5] = typeCabs[i].SignalRS485PLK.ToString();
                //        cabs[6] = typeCabs[i].SignalRS485SHL.ToString();
                //        dataGridView2.Rows.Add(cabs);
                //    }
                //}
                //for (int i = 0; i < typeCabs.Count; i++)
                //{
                //    if (i == typeCabs.Count - 1)
                //    {
                //        types += typeCabs[i].Name;
                //        break;
                //    }
                //    types += typeCabs[i].Name + ", ";
                //}
                dataGridView1["Type", gridCount].Value = PodCab.Name;
                gridCount++;
                comboBox1.Text = "";
                comboBox2.Text = "";
                dataGridView1.CurrentCell = dataGridView1[0, dataGridView1.Rows.Count - 2];
                comboBox2.Items.Clear();
                foreach (RadioButton control in groupBox1.Controls)
                {
                    if (control.GetType() == typeof(System.Windows.Forms.RadioButton))
                    {
                        control.Checked = false;
                    }
                }

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
                dataGridView2.Rows.Clear();
                int ind = -1;
                ind = dataGridView1.SelectedRows[0].Index;
                int AI, AO, DI, DO, RS485PLK, RS485SHL;
                AI = Convert.ToInt32(dataGridView1["AI", ind].Value);
                AO = Convert.ToInt32(dataGridView1["AO", ind].Value);
                DI = Convert.ToInt32(dataGridView1["DI", ind].Value);
                DO = Convert.ToInt32(dataGridView1["DO", ind].Value);
                RS485PLK = Convert.ToInt32(dataGridView1["RS485PLK", ind].Value);
                RS485SHL = Convert.ToInt32(dataGridView1["RS485SHL", ind].Value);
                CurrentCab = new Cabinet("name", AI, DI, AO, DO, RS485PLK, RS485SHL);
                TypeCabs = CabinetForm.LoginForm.dataBase.CalculationCabinet(AI, DI, AO, DO, RS485PLK, RS485SHL);               
                Cabinet PodCab = Cabinet.FilterAllSignal(TypeCabs, CurrentCab);
                string[] cab = new string[7];
                cab[0] = PodCab.Name; cab[1] = PodCab.SignalAI.ToString(); cab[2] = PodCab.SignalDI.ToString();
                cab[3] = PodCab.SignalAO.ToString(); cab[4] = PodCab.SignalDO.ToString(); cab[5] = PodCab.SignalRS485PLK.ToString();
                cab[6] = PodCab.SignalRS485SHL.ToString();
                dataGridView2.Rows.Add(cab);
                foreach (RadioButton control in groupBox1.Controls)
                {
                    if (control.GetType() == typeof(System.Windows.Forms.RadioButton))
                    {
                        control.Checked = false;
                    }
                }
            }
        }
        private void профилиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            CabinetForm.ProfileForm.StartPosition = FormStartPosition.Manual;
            CabinetForm.ProfileForm.Location = this.Location;
            CabinetForm.ProfileForm.Show();
        }

        private void типыШкафовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            CabinetForm.StartPosition = FormStartPosition.Manual;
            CabinetForm.Location = this.Location;
            CabinetForm.Show();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CabinetForm.LoginForm.dataBase.sqlConnection.State == ConnectionState.Open)
            {
                CabinetForm.LoginForm.dataBase.sqlConnection.Close();
            }
            Application.Exit();
        }

        private void CalculationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CabinetForm.LoginForm.dataBase.sqlConnection.State == ConnectionState.Open)
            {
                CabinetForm.LoginForm.dataBase.sqlConnection.Close();
            }
            Application.Exit();
        }

        private void обновитьБдToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataField.Clear();
            comboBox1.Items.Clear();
            string query = "SELECT * FROM Field";
            SqlCommand sqlCommand = new SqlCommand(query, CabinetForm.LoginForm.dataBase.sqlConnection);
            SqlDataReader dataReader = sqlCommand.ExecuteReader();
            while (dataReader.Read())
            {
                DataField.Add(new string[2]);
                DataField[DataField.Count - 1][0] = dataReader[0].ToString();
                DataField[DataField.Count - 1][1] = dataReader[1].ToString();
            }
            dataReader.Close();
            for (int i = 0; i < DataField.Count; i++)
            {
                comboBox1.Items.Add(DataField[i][1]);
            }
        }

        // обновление бд при изменении visible
        private void CalculationForm_VisibleChanged(object sender, EventArgs e)
        {
            DataField.Clear();
            comboBox1.Items.Clear();
            string query = "SELECT * FROM Field";
            using (SqlCommand sqlCommand = new SqlCommand(query, CabinetForm.LoginForm.dataBase.sqlConnection))
            {
                SqlDataReader dataReader = sqlCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    DataField.Add(new string[2]);
                    DataField[DataField.Count - 1][0] = dataReader[0].ToString();
                    DataField[DataField.Count - 1][1] = dataReader[1].ToString();
                }
                dataReader.Close();
            }
            for (int i = 0; i < DataField.Count; i++)
            {
                comboBox1.Items.Add(DataField[i][1]);
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                foreach (RadioButton control in groupBox1.Controls)
                {
                    if (control.GetType() == typeof(System.Windows.Forms.RadioButton))
                    {
                        control.Enabled = true;
                    }
                }
            }
            else
            {
                foreach (RadioButton control in groupBox1.Controls)
                {
                    if (control.GetType() == typeof(System.Windows.Forms.RadioButton))
                    {
                        control.Checked = false;
                        control.Enabled = false;
                    }
                }
            }
        }
        //заполнение второй дг всеми подходящими шкафами
        public void InsertCabsInDG()
        {
            int ind = -1;
            ind = dataGridView1.SelectedRows[0].Index;
            int AI, AO, DI, DO, RS485PLK, RS485SHL;
            AI = Convert.ToInt32(dataGridView1["AI", ind].Value);
            AO = Convert.ToInt32(dataGridView1["AO", ind].Value);
            DI = Convert.ToInt32(dataGridView1["DI", ind].Value);
            DO = Convert.ToInt32(dataGridView1["DO", ind].Value);
            RS485PLK = Convert.ToInt32(dataGridView1["RS485PLK", ind].Value);
            RS485SHL = Convert.ToInt32(dataGridView1["RS485SHL", ind].Value);
            TypeCabs = CabinetForm.LoginForm.dataBase.CalculationCabinet(AI, DI, AO, DO, RS485PLK, RS485SHL);
            dataGridView2.Rows.Clear();
            if (TypeCabs != null && dataGridView1.SelectedCells[0].Value != null)
            {
                string[] cabs = new string[7];
                for (int i = 0; i < TypeCabs.Count; i++)
                {
                    cabs[0] = TypeCabs[i].Name; cabs[1] = TypeCabs[i].SignalAI.ToString(); cabs[2] = TypeCabs[i].SignalDI.ToString();
                    cabs[3] = TypeCabs[i].SignalAO.ToString(); cabs[4] = TypeCabs[i].SignalDO.ToString(); cabs[5] = TypeCabs[i].SignalRS485PLK.ToString();
                    cabs[6] = TypeCabs[i].SignalRS485SHL.ToString();
                    dataGridView2.Rows.Add(cabs);
                }
            }
            else
                return;
        }
        public void InsertCabsInDG(TypeSignal typeSignal)
        {
            dataGridView2.Rows.Clear();
            int ind = -1;
            ind = dataGridView1.SelectedRows[0].Index;
            int AI, AO, DI, DO, RS485PLK, RS485SHL;
            AI = Convert.ToInt32(dataGridView1["AI", ind].Value);
            AO = Convert.ToInt32(dataGridView1["AO", ind].Value);
            DI = Convert.ToInt32(dataGridView1["DI", ind].Value);
            DO = Convert.ToInt32(dataGridView1["DO", ind].Value);
            RS485PLK = Convert.ToInt32(dataGridView1["RS485PLK", ind].Value);
            RS485SHL = Convert.ToInt32(dataGridView1["RS485SHL", ind].Value);
            CurrentCab = new Cabinet("name", AI, DI, AO, DO, RS485PLK, RS485SHL);
            TypeCabs = CabinetForm.LoginForm.dataBase.CalculationCabinet(AI, DI, AO, DO, RS485PLK, RS485SHL);
            List<Cabinet> SortCabs = Cabinet.FilterSignal(TypeCabs, CurrentCab, typeSignal);
            if (TypeCabs != null && dataGridView1.SelectedCells[0].Value != null)
            {
                string[] cabs = new string[7];
                for (int i = 0; i < SortCabs.Count; i++)
                {
                    cabs[0] = SortCabs[i].Name; cabs[1] = SortCabs[i].SignalAI.ToString(); cabs[2] = SortCabs[i].SignalDI.ToString();
                    cabs[3] = SortCabs[i].SignalAO.ToString(); cabs[4] = SortCabs[i].SignalDO.ToString(); cabs[5] = SortCabs[i].SignalRS485PLK.ToString();
                    cabs[6] = SortCabs[i].SignalRS485SHL.ToString();
                    dataGridView2.Rows.Add(cabs);
                }
            }
            else
                return;
        }

        private void ALLRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (ALLRadioButton.Checked == true)
            {
                InsertCabsInDG();
            }
        }

        private void AIRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (AIRadioButton.Checked == true)
                InsertCabsInDG(TypeSignal.AI);
        }

        private void DIRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (DIRadioButton.Checked == true)
                InsertCabsInDG(TypeSignal.DI);
        }

        private void AORadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (AORadioButton.Checked == true)
                InsertCabsInDG(TypeSignal.AO);
        }

        private void DORadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (DORadioButton.Checked == true)
                InsertCabsInDG(TypeSignal.DO);
        }

        private void RS485PLKRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (RS485PLKRadioButton.Checked == true)
                InsertCabsInDG(TypeSignal.RS485PLK);
        }

        private void RS485SHLRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (RS485SHLRadioButton.Checked == true)
                InsertCabsInDG(TypeSignal.RS485SHL);
        }

        private void pDFПечатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            Margins margin = new Margins(30, 30, 30, 30);
            printer.PrintMargins = margin;
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
                else
                    ExcelApp.Quit();
            }
        }
    }
}
