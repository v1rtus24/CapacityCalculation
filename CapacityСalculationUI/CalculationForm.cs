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
using ExcelDataReader;
using BotAgent.Ifrit.DataExporter;

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
        public bool ExcelPodb { get; set; } = false;
        public CalculationForm(CabinetForm cabinetForm)
        {
            CabinetForm = cabinetForm;
            LoginForm = cabinetForm.LoginForm;
            InitializeComponent();
            if (!LoginForm.localLogin)
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
                ALLRadioButton.Enabled = false; AIRadioButton.Enabled = false; DIRadioButton.Enabled = false;
                AORadioButton.Enabled = false; DORadioButton.Enabled = false; RS485PLKRadioButton.Enabled = false;
                RS485SHLRadioButton.Enabled = false;
            }
            else
            {
                groupBox1.Visible = false;
                checkBox1.Visible = false;
                comboBox1.Items.Clear();
                foreach (var fil in CabinetForm.ProfileForm.Fields)
                {
                    comboBox1.Items.Add(fil.Name);
                }
            }
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!LoginForm.localLogin)
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
            else
            {
                FieldID = Convert.ToInt32(comboBox1.SelectedIndex);
                comboBox2.Items.Clear();
                comboBox2.Text = "";
                foreach (var wellpad in CabinetForm.ProfileForm.Fields[FieldID].WellPads)
                {
                    comboBox2.Items.Add(wellpad.Num);
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!LoginForm.localLogin)
            {
                WellPadID = Convert.ToInt32(dataWellPad[comboBox2.SelectedIndex][0]);
            }
            else
            {

            }
        }

        private int gridCount { get; set; } = 0;

        private void CalcButton_Click(object sender, EventArgs e)
        {
            if (!LoginForm.localLogin)
            {
               
                if (comboBox1.Text != "" && comboBox2.Text != "")
                {
                    dataGridView1.Rows.Add();
                    double AIrez = Math.Ceiling(LoginForm.dataBase.CalculationSignal("AI", WellPadID) + LoginForm.dataBase.CalculationSignal("AI", WellPadID) * 0.2);
                    double AOrez = Math.Ceiling(LoginForm.dataBase.CalculationSignal("AO", WellPadID) + LoginForm.dataBase.CalculationSignal("AO", WellPadID) * 0.2);
                    double DIrez = Math.Ceiling(LoginForm.dataBase.CalculationSignal("DI", WellPadID) + LoginForm.dataBase.CalculationSignal("DI", WellPadID) * 0.3);
                    double DOrez = Math.Ceiling(LoginForm.dataBase.CalculationSignal("DO", WellPadID) + LoginForm.dataBase.CalculationSignal("DO", WellPadID) * 0.3);
                    int RS485PLK = LoginForm.dataBase.CalculationSignal("RS485(ПЛК)", WellPadID);
                    int RS485SHL = LoginForm.dataBase.CalculationSignal("RS485(Шлюз)", WellPadID);
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

                    /* if (typeCabs != null && dataGridView1.SelectedCells[0].Value != null)
                     {
                         string[] cabs = new string[7];
                         for (int i = 0; i < typeCabs.Count; i++)
                         {
                             cabs[0] = typeCabs[i].Name; cabs[1] = typeCabs[i].SignalAI.ToString(); cabs[2] = typeCabs[i].SignalDI.ToString();
                             cabs[3] = typeCabs[i].SignalAO.ToString(); cabs[4] = typeCabs[i].SignalDO.ToString(); cabs[5] = typeCabs[i].SignalRS485PLK.ToString();
                             cabs[6] = typeCabs[i].SignalRS485SHL.ToString();
                             dataGridView2.Rows.Add(cabs);
                         }
                     }
                     for (int i = 0; i < typeCabs.Count; i++)
                     {
                         if (i == typeCabs.Count - 1)
                         {
                             types += typeCabs[i].Name;
                             break;
                         }
                         types += typeCabs[i].Name + ", ";
                     }*/
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
            else
            {
                if (comboBox1.Text != "" && comboBox2.Text != "")
                {
                    dataGridView1.Rows.Add();
                    dataGridView1["Column1", gridCount].Value = comboBox1.SelectedItem;
                    dataGridView1["Column2", gridCount].Value = comboBox2.SelectedItem;
                    wellCount = CabinetForm.ProfileForm.Fields[comboBox1.SelectedIndex].WellPads[comboBox2.SelectedIndex].WellCount(TypeTecObj.DobSkvaz);
                    injCount = CabinetForm.ProfileForm.Fields[comboBox1.SelectedIndex].WellPads[comboBox2.SelectedIndex].WellCount(TypeTecObj.NagnSkvaz);
                    dataGridView1["Column3", gridCount].Value = CabinetForm.ProfileForm.Fields[comboBox1.SelectedIndex].WellPads[comboBox2.SelectedIndex].WellCount(TypeTecObj.DobSkvaz);
                    dataGridView1["Column4", gridCount].Value = CabinetForm.ProfileForm.Fields[comboBox1.SelectedIndex].WellPads[comboBox2.SelectedIndex].WellCount(TypeTecObj.NagnSkvaz);
                    //Считаем все сигналы на площадке
                    Cabinet SignalCount = CabinetForm.ProfileForm.Fields[comboBox1.SelectedIndex].WellPads[comboBox2.SelectedIndex].SignalCount(wellCount, injCount);
                    //считаем резерв
                    Cabinet SignalCountWithRez = Cabinet.Rezerv(SignalCount);
                    dataGridView1["AI", gridCount].Value = SignalCountWithRez.SignalAI; dataGridView1["AO", gridCount].Value = SignalCountWithRez.SignalAO;
                    dataGridView1["DI", gridCount].Value = SignalCountWithRez.SignalDI; dataGridView1["DO", gridCount].Value = SignalCountWithRez.SignalDO;
                    dataGridView1["RS485PLK", gridCount].Value = SignalCountWithRez.SignalRS485PLK; dataGridView1["RS485SHL", gridCount].Value = SignalCountWithRez.SignalRS485SHL;
                    Cabinet.PodborCab(SignalCountWithRez, CabinetForm.constCabs);
                    PodCab = Cabinet.PodborCab(SignalCountWithRez, CabinetForm.constCabs);
                    dataGridView1["Type", gridCount].Value = PodCab.Name;
                    gridCount++;
                    dataGridView1.CurrentCell = dataGridView1[0, dataGridView1.Rows.Count - 2];

                }

            }
        }

        public Cabinet PodCab { get; set; }
        public int wellCount { get; set; }
        public int injCount { get; set; }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!LoginForm.localLogin)
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
            else
            {
                if (dataGridView1.SelectedRows[0].Cells[0] != null)
                {
                    PodborKlik();
                }
            }
        }
        public void PodborKlik()
        {
            wellCount = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[2].Value);
            injCount = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[3].Value);
            //Считаем все сигналы на площадке
            Cabinet SignalCount = Cabinet.SignalCount(wellCount, injCount);
            //считаем резерв
            Cabinet SignalCountWithRez = Cabinet.Rezerv(SignalCount);
            Cabinet.PodborCab(SignalCountWithRez, CabinetForm.constCabs);
            PodCab = Cabinet.PodborCab(SignalCountWithRez, CabinetForm.constCabs);
            dataGridView2.Rows.Clear();
            dataGridView2.Rows.Add();
            dataGridView2["dgType", 0].Value = PodCab.Name;
            dataGridView2["dgAI", 0].Value = PodCab.SignalAI;
            dataGridView2["dgDI", 0].Value = PodCab.SignalDI;
            dataGridView2["dgAO", 0].Value = PodCab.SignalAO;
            dataGridView2["dgDO", 0].Value = PodCab.SignalDO;
            dataGridView2["dgRS485PLK", 0].Value = PodCab.SignalRS485PLK;
            dataGridView2["dgRS485SHL", 0].Value = PodCab.SignalRS485SHL;
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (!LoginForm.localLogin)
            {
            }
            else if (LoginForm.localLogin && !ExcelPodb)
            {
                PodborKlik();
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
            if (!LoginForm.localLogin)
            {
                if (CabinetForm.LoginForm.dataBase.sqlConnection.State == ConnectionState.Open)
                {
                    CabinetForm.LoginForm.dataBase.sqlConnection.Close();
                }
            }
            else
            {

            }
            Application.Exit();

        }

        private void CalculationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!LoginForm.localLogin)
            {
                if (CabinetForm.LoginForm.dataBase.sqlConnection.State == ConnectionState.Open)
                {
                    CabinetForm.LoginForm.dataBase.sqlConnection.Close();
                }

            }
            else
            {

            }
            Application.Exit();
        }

        private void обновитьБдToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!LoginForm.localLogin)
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
            else
            {

            }
        }

        // обновление бд при изменении visible
        private void CalculationForm_VisibleChanged(object sender, EventArgs e)
        {
            comboBox1.Text = "";
            comboBox2.Text = "";
            if (!LoginForm.localLogin)
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
            else
            {
                comboBox1.Items.Clear();
                foreach (var fil in CabinetForm.ProfileForm.Fields)
                {
                    comboBox1.Items.Add(fil.Name);
                }
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
            if (!LoginForm.localLogin)
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
                else { return; }
            }
            else
            {

            }
        }
        public void InsertCabsInDG(TypeSignal typeSignal)
        {
            if (!LoginForm.localLogin)
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
                else { return; }
            }
            else
            {

            }
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
                Excel excelEx = new Excel();
                List<string> spisok = new List<string>();
                List<string> ColSpis = new List<string> { "Месторождение", "№ КП", "Доб.", "Нагн.", "AI", "DI", "AO", "DO", "RS485(ПЛК)", "RS485(ШЛЮЗ)", "Тип" };
                excelEx.Rows.Add(ColSpis);
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    if (dataGridView1["Column1", i].Value != null)
                    {
                        spisok.Clear();
                        spisok.Add(dataGridView1["Column1", i].Value.ToString()); spisok.Add(dataGridView1["Column2", i].Value.ToString());
                        spisok.Add(dataGridView1["Column3", i].Value.ToString()); spisok.Add(dataGridView1["Column4", i].Value.ToString());
                        spisok.Add(dataGridView1["AI", i].Value.ToString()); spisok.Add(dataGridView1["DI", i].Value.ToString());
                        spisok.Add(dataGridView1["AO", i].Value.ToString()); spisok.Add(dataGridView1["DO", i].Value.ToString());
                        spisok.Add(dataGridView1["RS485PLK", i].Value.ToString()); spisok.Add(dataGridView1["RS485SHL", i].Value.ToString());
                        spisok.Add(dataGridView1["Type", i].Value.ToString());
                        excelEx.Rows.Add(spisok);
                    }

                }

                excelEx.FileSave(saveFileDialog1.FileName, true);
            }
            
        }
        public string ExcelFileName { get; set; }
        private void загрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExcelPodb = true;
            dataGridView1.Rows.Clear();
            int gridCount = 0;
            
            if (openFileDialog1.ShowDialog() == DialogResult.OK && openFileDialog1.FileName.Length > 0)
            {
                CalcExcelForm calcExcelForm = new CalcExcelForm(this);
                ExcelFileName = openFileDialog1.FileName;
                Cursor.Current = Cursors.WaitCursor;

                calcExcelForm.ShowDialog();
                
            }
        }
    }
}
