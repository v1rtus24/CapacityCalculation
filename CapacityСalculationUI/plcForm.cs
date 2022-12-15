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
    public partial class plcForm : Form
    {
        public MainSpecCabForm _mainSpecCabForm { get; set; }
        public int IndexDataG { get; set; }

        public int idPLC { get; set; }
        public plcForm(MainSpecCabForm mainSpecCabForm)
        {
            _mainSpecCabForm = mainSpecCabForm;
            InitializeComponent();
        }
       
        void UpdateTable()
        {
            string querry = "SELECT * FROM PLC";
            dataGridView1.DataSource = _mainSpecCabForm._cabinetForm._loginForm.dataBase.ShowData(querry);
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Производитель";
            dataGridView1.Columns[2].HeaderText = "Модель";
            dataGridView1.Columns[3].HeaderText = "Защита";
            dataGridView1.Columns[4].HeaderText = "Остальное";
        }
        private void plcForm_Load(object sender, EventArgs e)
        {
            UpdateTable();
        }

        private void AddPLC_Click(object sender, EventArgs e)
        {
            AddEditPLC editPLC = new AddEditPLC();
            try
            {
                if (dataGridView1.SelectedRows[0].Cells[0].Value != null)
                {
                    if (editPLC.ShowDialog() == DialogResult.OK)
                    {
                        _mainSpecCabForm._cabinetForm._loginForm.dataBase.AddPLC(editPLC.Model, editPLC.Model, editPLC.Ip, editPLC.Other);
                        UpdateTable();
                        dataGridView1.Rows[dataGridView1.Rows.Count - 2].Selected = true;

                    }
                }
            }
            catch
            {
                MessageBox.Show("Выберите ПЛК");
            }

        }

        private void UpdatePLC_Click(object sender, EventArgs e)
        {
            AddEditPLC editPLC = new AddEditPLC();
            try
            {
                if (dataGridView1.SelectedRows[0].Cells[0].Value != null)
                {
                    idPLC = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
                    editPLC.Brand = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                    editPLC.Model = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                    editPLC.Ip = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                    editPLC.Other = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                    if (editPLC.ShowDialog() == DialogResult.OK)
                    {
                       _mainSpecCabForm._cabinetForm._loginForm.dataBase.UpdatePLC(idPLC,editPLC.Brand, editPLC.Model, editPLC.Ip, editPLC.Other);
                        UpdateTable();
                        dataGridView1.Rows[IndexDataG].Selected = true;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DelPLC_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows[0].Cells[0].Value != null)
                {
                    idPLC = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
                     if (MessageBox.Show("Удалить ПЛК из списка","Внимание!",MessageBoxButtons.OKCancel) == DialogResult.OK)
                     {
                    _mainSpecCabForm._cabinetForm._loginForm.dataBase.DeletePLC(idPLC);
                       UpdateTable();
                        dataGridView1.Rows[dataGridView1.Rows.Count - 2].Selected = true;

                    }
                }
                else { return; }
            }
            catch
            {
                MessageBox.Show("Выберите ПЛК");
            }
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            IndexDataG = dataGridView1.SelectedRows[0].Index;

        }

        private void plcForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }


    }
}
