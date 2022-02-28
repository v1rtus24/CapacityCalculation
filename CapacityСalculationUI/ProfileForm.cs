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

namespace CapacityСalculationUI
{
    public partial class ProfileForm : Form
    {
        private DataBase data;
        public int idField { get; set; }
        public int idWellPad { get; set; }
        public int idWell { get; set; }
        public ProfileForm()
        {
            InitializeComponent();
            data = new DataBase();
            data.sqlConnection.Open();
        }
        private void ProfileForm_Load(object sender, EventArgs e)
        {
            UpdateFieldTable();
        }

        /// <summary>
        /// Обновление данных в таблице месторождений
        /// </summary>
        private void UpdateFieldTable()
        {
            FieldDataGridView.DataSource = data.ShowData("SELECT * FROM FIELD");
            FieldDataGridView.Columns[0].Visible = false;
            FieldDataGridView.Columns[1].Width = 180;
            FieldDataGridView.ClearSelection();
        }

        /// <summary>
        /// Обновление данных в таблице КП
        /// </summary>
        private void UpdateWellPadTable(int idField)
        {
            try
            {
                WellPadDataGridView.DataSource = data.ShowData("SELECT * FROM WellPad WHERE Field_id =" + idField.ToString() + "");
                WellPadDataGridView.Columns[0].Visible = false;
                WellPadDataGridView.Columns[2].Visible = false;
                WellPadDataGridView.Columns[1].Width = 140;
                WellPadDataGridView.ClearSelection();

            }
            catch 
            {
                return;
            }
        }

        private void UpdateWellTable(int idWellPad)
        {
            try
            {
                WellDataGridView.DataSource = data.ShowData("SELECT * FROM Well WHERE WellPad_id =" + idWellPad.ToString() + "");
                WellDataGridView.Columns[0].Visible = false;
                WellDataGridView.Columns[3].Visible = false;
                WellDataGridView.Columns[1].Width = 45;
                WellDataGridView.Columns[2].Width = 130;
                WellDataGridView.ClearSelection();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void UpdatePhysCharTable(int idWell)
        {
            try
            {
                PhysCharDataGridView.DataSource = data.ShowData("SELECT * FROM PhysChar WHERE Well_id =" + idWell.ToString() + "");
                PhysCharDataGridView.Columns[0].Visible = false;
                PhysCharDataGridView.Columns[3].Visible = false;
                PhysCharDataGridView.Columns[1].Width = 180;
                PhysCharDataGridView.Columns[2].Width = 50;
                PhysCharDataGridView.ClearSelection();

            }
            catch
            {
                return;
            }
        }
        private void AddFieldButton_Click(object sender, EventArgs e)
        {
            AddEditField form = new AddEditField();
            if (form.ShowDialog() == DialogResult.OK)
            {
                data.AddField(form.FieldName);
                UpdateFieldTable();
            }
        }

        private void UpdateFIeldButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (FieldDataGridView.SelectedRows[0].Cells[0].Value != null)
                {
                    idField = (int)FieldDataGridView.SelectedRows[0].Cells[0].Value;
                    AddEditField form = new AddEditField();
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        data.UpdateField(form.FieldName, idField);
                        UpdateFieldTable();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Выберите месторождение");
            }
        }

        private void DeleteFieldButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (FieldDataGridView.SelectedRows[0].Cells[0].Value != null)
                {
                    idField = (int)FieldDataGridView.SelectedRows[0].Cells[0].Value;
                    data.DeleteField(idField);
                    UpdateFieldTable();
                }
            }
            catch
            {
                MessageBox.Show("Выберите месторождение");
            }
        }

        private void AddWellPadButton_Click(object sender, EventArgs e)
        {
            AddEditWellPad form = new AddEditWellPad();
            if (form.ShowDialog() == DialogResult.OK)
            {
                data.AddWellPad(idField, form.WellPadNum);
                UpdateWellPadTable(idField);
            }
        }

        private void DeleteWellPadButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (WellPadDataGridView.SelectedRows[0].Cells[0].Value != null)
                {
                    idWellPad = (int)WellPadDataGridView.SelectedRows[0].Cells[0].Value;
                    data.DeleteWellPad(idWellPad);
                    UpdateWellPadTable(idField);
                }
            }
            catch
            {
                MessageBox.Show("Выберите КП");
            }
        }

        private void AddWellButton_Click(object sender, EventArgs e)
        {
            var form = new AddEditWell();
            try
            {
                if (WellPadDataGridView.SelectedRows[0].Cells[0].Value != null)
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        data.AddWell(idWellPad, form.NumWell, form.TypeWell);
                        UpdateWellTable(idWellPad);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Выберите КП");
            }
        }

        private void DeleteWellButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (WellDataGridView.SelectedRows[0].Cells[0].Value != null)
                {
                    idWell = (int)WellDataGridView.SelectedRows[0].Cells[0].Value;
                    data.DeleteWell(idWell);
                    UpdateWellTable(idWellPad);
                    WellPadDataGridView.DataSource = null;
                    WellDataGridView.DataSource = null;
                    PhysCharDataGridView.DataSource = null;
                }
            }
            catch
            {
                MessageBox.Show("Выберите скважину");
            }
        }

        private void ProfileForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (data.sqlConnection.State == ConnectionState.Open)
            {
                data.sqlConnection.Close();
            }
            Application.Exit();
        }


        private void AddPhysCharButton_Click(object sender, EventArgs e)
        {
            var form = new AddEditPhysChar();
            try
            {
                if (WellDataGridView.SelectedRows[0].Cells[0].Value != null)
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {idWell = (int)WellDataGridView.SelectedRows[0].Cells[0].Value;
                        data.AddPhysChar(idWell, form.NamePhysChar, form.Signal);
                        UpdatePhysCharTable(idWell);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Выберите скважину");
            }
        }

        private void FieldDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (FieldDataGridView.SelectedRows[0].Cells[0].Value != null)
                {
                    idField = (int)FieldDataGridView.SelectedRows[0].Cells[0].Value;
                    UpdateWellPadTable(idField);
                    WellDataGridView.DataSource = null;
                    PhysCharDataGridView.DataSource = null;
                }
            }
            catch
            {
                return;
            }
            
        }

        private void WellPadDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (WellPadDataGridView.SelectedRows[0].Cells[0].Value != null)
                {
                    idWellPad = (int)WellPadDataGridView.SelectedRows[0].Cells[0].Value;
                    UpdateWellTable(idWellPad);
                    PhysCharDataGridView.DataSource = null;
                }
            }
            catch
            {
                return;
            }
        }

        private void WellDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (WellDataGridView.SelectedRows[0].Cells[0].Value != null)
                {
                    idWell = (int)WellDataGridView.SelectedRows[0].Cells[0].Value;
                    UpdatePhysCharTable(idWell);
                }
            }
            catch
            {
                return;
            }
        }

        private void типыШкафовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form = new CabinetForm();
            form.StartPosition = FormStartPosition.Manual;
            form.Location = this.Location;
            form.Show();
        }
    }
}
