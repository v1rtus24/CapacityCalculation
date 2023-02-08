using Microsoft.Office.Interop.Excel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using DataTable = System.Data.DataTable;
using ToolTip = System.Windows.Forms.ToolTip;

namespace CapacityСalculationUI
{
    public partial class MainSpecCabForm : Form
    {
        public int idCab { get; set; }
        public CabinetForm _cabinetForm { get; set; }
        public plcForm plcForm { get; set; }
        public List<int> idCabs { get; set; }
        public List<string[]> plcs = new List<string[]>();
        ToolTip t = new ToolTip();
        public MainSpecCabForm(CabinetForm cabinetForm)
        {
            _cabinetForm = cabinetForm;
            InitializeComponent();
            comboBox2.Items.Add("IP20");
            comboBox2.Items.Add("IP21");
            comboBox2.Items.Add("IP22");
            comboBox2.Items.Add("IP23");
            comboBox2.Items.Add("IP54");
            comboBox2.Items.Add("IP65");
            comboBox2.Items.Add("IP66");
        }
        public void UpdatePLClist()
        {
            string query1 = "SELECT PLC.Id, PLC.brand,PLC.model FROM PLC  ";
            SqlCommand sqlCommand = new SqlCommand(query1, _cabinetForm.LoginForm.dataBase.sqlConnection);
            SqlDataReader dataReader = sqlCommand.ExecuteReader();
            while (dataReader.Read())
            {
                plcs.Add(new string[3]);
                plcs[plcs.Count - 1][0] = dataReader[0].ToString();
                plcs[plcs.Count - 1][1] = dataReader[1].ToString();
                plcs[plcs.Count - 1][2] = dataReader[2].ToString();
            }
            dataReader.Close();
            for (int i = 0; i < plcs.Count; i++)
            {
                comboBox1.Items.Add(plcs[i][1] + " " + plcs[i][2]);
            }
            idCab = _cabinetForm.CabID;
            string querry = "SELECT MainCabSpec.ip,MainCabSpec.mission,MainCabSpec.size,MainCabSpec.placing, PLC.brand,PLC.model, MainCabSpec.massa " +
            "FROM MainCabSpec " +
            "JOIN PLC ON PLC.Id = MainCabSpec.PLC_id " +
            "WHERE MainCabSpec.Id = " + idCab + "";
            // dataGridView1.DataSource = _cabinetForm._loginForm.dataBase.ShowData(querry);
            DataTable dataTable = new DataTable();
            dataTable = _cabinetForm.LoginForm.dataBase.DataTable(querry);
            try
            {
                if (dataTable.Rows[0][0] != null)
                {
                    comboBox2.Text = dataTable.Rows[0][0].ToString();
                    textBox2.Text = dataTable.Rows[0][1].ToString();
                    textBox3.Text = dataTable.Rows[0][2].ToString();
                    textBox4.Text = dataTable.Rows[0][3].ToString();
                    comboBox1.Text = dataTable.Rows[0][4].ToString() + " " + dataTable.Rows[0][5].ToString();
                    MasTextBox.Text = dataTable.Rows[0][6].ToString();
                }
                else
                {
                    comboBox2.Text = "";textBox2.Text = ""; textBox3.Text = "";
                    textBox4.Text = ""; comboBox1.Text = ""; MasTextBox.Text = "";
                }
            }
            catch
            {
                return;
            }
        }
        
        private void MainSpecCabForm_Load(object sender, EventArgs e)
        {
            checkBox1.Checked = false; comboBox2.Enabled = false; textBox2.Enabled = false; 
            textBox3.Enabled = false;textBox4.Enabled = false;comboBox1.Enabled = false;
            MasTextBox.Enabled = false;
            UpdatePLClist();
        }

        private void plcButton_Click(object sender, EventArgs e)
        {
            plcForm = new plcForm(this);
            plcForm.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                comboBox2.Enabled = true; textBox2.Enabled = true; textBox3.Enabled = true;
                textBox4.Enabled = true; comboBox1.Enabled = true; MasTextBox.Enabled = true;
            }
            else
            {
                comboBox2.Enabled = false; textBox2.Enabled = false; textBox3.Enabled = false;
                textBox4.Enabled = false; comboBox1.Enabled = false; MasTextBox.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int idPLC = Convert.ToInt32(plcs[comboBox1.SelectedIndex][0]);
                _cabinetForm.LoginForm.dataBase.UpdateMainCabSpec(idCab, idPLC,
                    comboBox2.Text, textBox2.Text, textBox3.Text, textBox4.Text, MasTextBox.Text);
                MessageBox.Show("Изменения сохранены!", "Состав шкафа управления", MessageBoxButtons.OK);
                checkBox1.Checked = false;
            }
            catch 
            {
                MessageBox.Show("Выберите ПЛК!");
            }
        }

        private void MainSpecCabForm_Leave(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void MainSpecCabForm_VisibleChanged(object sender, EventArgs e)
        {
        }

        private void MainSpecCabForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private void label4_MouseMove(object sender, MouseEventArgs e)
        {    
            t.SetToolTip(label4, "Нажмите для подсказки");      
        }

        private void label4_Click(object sender, EventArgs e)
        {
            var klim = new KlimatForm();
            klim.Show();
        }


        private void label1_Click(object sender, EventArgs e)
        {
            var ip = new ipForm();
            ip.Show();
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            t.SetToolTip(label1, "Нажмите для подсказки");
        }
    }
}
