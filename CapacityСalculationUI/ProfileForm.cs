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
        //private DataBase data;
        public int idField { get; set; }
        public int idWellPad { get; set; }
        public int idWell { get; set; }
        public int idPhysChar { get; set; }
        public int indexDataGrid { get; set; } = 1;

        public CabinetForm CabinetForm { get; set; }

        public ProfileForm(CabinetForm cabinetForm)
        {
            CabinetForm = cabinetForm;
            InitializeComponent();
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
            FieldDataGridView.DataSource = CabinetForm.LoginForm.dataBase.ShowData("SELECT * FROM FIELD");
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
                WellPadDataGridView.DataSource = CabinetForm.LoginForm.dataBase.ShowData("SELECT * FROM WellPad WHERE Field_id =" + idField.ToString() + "");
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
                WellDataGridView.DataSource = CabinetForm.LoginForm.dataBase.ShowData("SELECT * FROM Well WHERE WellPad_id =" + idWellPad.ToString() + "");
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
                PhysCharDataGridView.DataSource = CabinetForm.LoginForm.dataBase.ShowData("SELECT * FROM PhysChar WHERE Well_id =" + idWell.ToString() + "");
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

        private void FieldDataGridView_SelectionChanged(object sender, EventArgs e)
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


        private void WellPadDataGridView_SelectionChanged(object sender, EventArgs e)
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
        private void WellDataGridView_SelectionChanged(object sender, EventArgs e)
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
            CabinetForm.StartPosition = FormStartPosition.Manual;
            CabinetForm.Location = this.Location;
            CabinetForm.Show();
        }

        private void подборШкафаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            CabinetForm.CalculationForm.StartPosition = FormStartPosition.Manual;
            CabinetForm.CalculationForm.Location = this.Location;
            CabinetForm.CalculationForm.Show();
        }    
     
        private void ProfileForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (CabinetForm.LoginForm.dataBase.sqlConnection.State == ConnectionState.Open)
            {
                CabinetForm.LoginForm.dataBase.sqlConnection.Close();
            }
            Application.Exit();
        }

        private void обновитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateFieldTable();
            WellDataGridView.DataSource = null;
            WellPadDataGridView.DataSource = null;
            PhysCharDataGridView.DataSource = null;
        }

        private void AddFieldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddEditField form = new AddEditField();
            if (form.ShowDialog() == DialogResult.OK)
            {
                CabinetForm.LoginForm.dataBase.AddField(form.FieldName);
                UpdateFieldTable();
                FieldDataGridView.Rows[FieldDataGridView.Rows.Count - 2].Selected = true;

            }
        }

        private void WellPadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddEditWellPad form = new AddEditWellPad();
            try
            {
                if (FieldDataGridView.SelectedRows[0].Cells[0].Value != null)
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        CabinetForm.LoginForm.dataBase.AddWellPad(idField, form.WellPadNum);
                        UpdateWellPadTable(idField);
                       WellPadDataGridView.Rows[WellPadDataGridView.Rows.Count - 2].Selected = true;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Выберите месторождение");
            }
        }

        private void AddWellToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new AddEditWell();
            try
            {
                if (WellPadDataGridView.SelectedRows[0].Cells[0].Value != null)
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        CabinetForm.LoginForm.dataBase.AddWell(idWellPad, form.NumWell, form.TypeWell);
                        UpdateWellTable(idWellPad);
                        WellDataGridView.Rows[WellDataGridView.Rows.Count - 2].Selected = true;

                    }
                }
            }
            catch
            {
                MessageBox.Show("Выберите КП");
            }
        }

        private void PhysCharToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new AddEditPhysChar();
            try
            {
                if (WellDataGridView.SelectedRows[0].Cells[0].Value != null)
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        idWell = (int)WellDataGridView.SelectedRows[0].Cells[0].Value;
                        CabinetForm.LoginForm.dataBase.AddPhysChar(idWell, form.NamePhysChar, form.Signal);
                        UpdatePhysCharTable(idWell);
                       PhysCharDataGridView.Rows[PhysCharDataGridView.Rows.Count - 2].Selected = true;

                    }
                }
            }
            catch
            {
                MessageBox.Show("Выберите скважину");
            }
        }

        private void UpdateFieldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (FieldDataGridView.SelectedRows[0].Cells[0].Value != null)
                {
                    idField = (int)FieldDataGridView.SelectedRows[0].Cells[0].Value;
                    AddEditField form = new AddEditField();
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        CabinetForm.LoginForm.dataBase.UpdateField(form.FieldName, idField);
                        UpdateFieldTable();
                        FieldDataGridView.Rows[indexDataGrid].Selected = true;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Выберите месторождение");
            }
        }

        private void UpdateWellPadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (WellPadDataGridView.SelectedRows[0].Cells[0].Value != null)
                {
                    idWellPad = (int)WellPadDataGridView.SelectedRows[0].Cells[0].Value;

                    AddEditWellPad form = new AddEditWellPad();
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        CabinetForm.LoginForm.dataBase.UpdateWellPad(form.WellPadNum, idWellPad);
                        UpdateWellPadTable(idField);
                        WellPadDataGridView.Rows[indexDataGrid].Selected = true;

                    }
                }
            }
            catch
            {
                MessageBox.Show("Выберите КП");
            }
        }

        private void UpdateWellToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (WellDataGridView.SelectedRows[0].Cells[0].Value != null)
                {
                    idWell = (int)WellDataGridView.SelectedRows[0].Cells[0].Value;

                    AddEditWell form = new AddEditWell();
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        CabinetForm.LoginForm.dataBase.UpdateWell(form.NumWell, form.TypeWell, idWell);
                        UpdateWellTable(idWellPad);
                        WellDataGridView.Rows[indexDataGrid].Selected = true;

                    }
                }
            }
            catch
            {
                MessageBox.Show("Выберите скважину!");
            }
        }

        private void UpdatePhysCharToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (PhysCharDataGridView.SelectedRows[0].Cells[0].Value != null)
                {
                    idPhysChar = (int)PhysCharDataGridView.SelectedRows[0].Cells[0].Value;

                    AddEditPhysChar form = new AddEditPhysChar();
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        CabinetForm.LoginForm.dataBase.UpdatePhysChar(form.NamePhysChar, form.Signal, idPhysChar);
                        UpdatePhysCharTable(idWell);
                        PhysCharDataGridView.Rows[indexDataGrid].Selected = true;

                    }
                }
            }
            catch
            {
                MessageBox.Show("Выберите подключение!");
            }
        }

        private void DeleteFieldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (FieldDataGridView.SelectedRows[0].Cells[0].Value != null)
                {
                    idField = (int)FieldDataGridView.SelectedRows[0].Cells[0].Value;
                    CabinetForm.LoginForm.dataBase.DeleteField(idField);
                    UpdateFieldTable();
                }
            }
            catch
            {
                MessageBox.Show("Выберите месторождение");
            }
        }

        private void DeleteWellPadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (WellPadDataGridView.SelectedRows[0].Cells[0].Value != null)
                {
                    idWellPad = (int)WellPadDataGridView.SelectedRows[0].Cells[0].Value;
                    CabinetForm.LoginForm.dataBase.DeleteWellPad(idWellPad);
                    UpdateWellPadTable(idField);
                    WellDataGridView.DataSource = null;
                    PhysCharDataGridView.DataSource = null;
                }
            }
            catch
            {
                MessageBox.Show("Выберите КП");
            }
        }

        private void DeleteWellToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (WellDataGridView.SelectedRows[0].Cells[0].Value != null)
                {
                    idWell = (int)WellDataGridView.SelectedRows[0].Cells[0].Value;
                    CabinetForm.LoginForm.dataBase.DeleteWell(idWell);
                    UpdateWellTable(idWellPad);
                    PhysCharDataGridView.DataSource = null;
                }
            }
            catch
            {
                MessageBox.Show("Выберите скважину");
            }
        }

        private void DeletePhysCharToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (PhysCharDataGridView.SelectedRows[0].Cells[0].Value != null)
                {
                    idPhysChar = (int)PhysCharDataGridView.SelectedRows[0].Cells[0].Value;
                    CabinetForm.LoginForm.dataBase.DeletePhysChar(idPhysChar);
                    UpdatePhysCharTable(idWell);
                }
            }
            catch
            {
                MessageBox.Show("Выберите подключение");
            }
        }

        private void WellDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexDataGrid = WellDataGridView.SelectedRows[0].Index;
        }

        private void PhysCharDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexDataGrid = PhysCharDataGridView.SelectedRows[0].Index;
        }

        private void FieldDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexDataGrid = FieldDataGridView.SelectedRows[0].Index;
        }

        private void WellPadDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexDataGrid = WellPadDataGridView.SelectedRows[0].Index;

        }
    }
}

