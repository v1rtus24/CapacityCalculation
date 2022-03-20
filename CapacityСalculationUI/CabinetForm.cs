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
    public partial class CabinetForm : Form
    {
        public Cabinet cabinet { get; set; } = new Cabinet();
        private DataBase data;
        public CabinetForm()
        {
            InitializeComponent();
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
            dataGridView1.Columns[0].Width = 40;
            dataGridView1.Columns[2].Width = 80;
            dataGridView1.Columns[3].Width = 50;
            dataGridView1.Columns[4].Width = 50;
            dataGridView1.Columns[5].Width = 50;
            dataGridView1.Columns[6].Width = 80;
            dataGridView1.Columns[7].Width = 80;
        }


        private void профилиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form = new ProfileForm();
            form.StartPosition = FormStartPosition.Manual;
            form.Location = this.Location;
            form.Show();
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
            Application.Exit();
        }

        private void выходToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (data.sqlConnection.State == ConnectionState.Open)
            {
                data.sqlConnection.Close();
            }
            Application.Exit();
        }

        private void подборШкафаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form = new CalculationForm();
            form.StartPosition = FormStartPosition.Manual;
            form.Location = this.Location;
            form.Show();
        }
    }
}
