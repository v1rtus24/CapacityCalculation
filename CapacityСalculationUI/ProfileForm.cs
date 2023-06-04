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
        public List<Field> Fields { get; set; }

        public CabinetForm cabinetForm { get; set; }

        public ProfileForm(CabinetForm cabinetForm)
        {
            this.cabinetForm = cabinetForm;
            InitializeComponent();
            openFileDialog1.Title = "Выберите файл с профилями.";
            if (!cabinetForm.LoginForm.localLogin)
            {
                textBox1.Visible = false;
                UpdateFieldTableOnline();
                сохранитьToolStripMenuItem.Enabled = false;
                загрузитьToolStripMenuItem.Enabled = false;
                groupBox5.Visible = false;

            }
            else
            {
                PhysCharToolStripMenuItem.Visible = false;
                PhysCharDataGridView.Visible = false;
                label3.Text = "Объекты";
                label4.Visible = false;
                //добавление столбцов в таблицы
                Fields = new List<Field>();
                FieldDataGridView.Columns.Add("Col1", "Name");
                FieldDataGridView.Columns[0].Width = 180;
                WellPadDataGridView.Columns.Add("Col1", "Name");
                WellPadDataGridView.Columns[0].Width = 50 ;
                WellDataGridView.Columns.Add("Col1", "Name5");
                WellDataGridView.Columns.Add("Col2", "Name2");
                WellDataGridView.Columns[0].Width = 0;
                WellDataGridView.Columns[1].Width = 310;
                label5.Visible = false;
                label6.Text = "Примечание";
                PhysCharDataGridView.Columns.Add("Col1", "Name");
                PhysCharDataGridView.Columns.Add("Col2", "Name2");
                PhysCharDataGridView.Columns[0].Width = 0;
                PhysCharDataGridView.Columns[1].Width = 220;
                Fields = SaveLoad.LoadFromFile(SaveLoad.FilePath);
                if (Fields.Count < 1)
                {
                    DialogResult dg = MessageBox.Show("Профили на этом ПК не найдены.\n" +
                        "Загрузить профили?", "Профили", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (dg == DialogResult.OK)
                    {
                        if (openFileDialog1.ShowDialog() == DialogResult.OK && openFileDialog1.FileName.Length > 0)
                        {
                            try
                            {
                                Fields.Clear();
                                Fields = SaveLoad.LoadFromFile(openFileDialog1.FileName);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                    }
                }
                UpdateFieldTableLocal();
                this.Show();
            }
        }

        private void ProfileForm_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Обновление данных в таблице месторождений
        /// </summary>
        private void UpdateFieldTableOnline()
        {
            FieldDataGridView.DataSource = cabinetForm.LoginForm.dataBase.ShowData("SELECT * FROM FIELD");
            FieldDataGridView.Columns[0].Visible = false;
            FieldDataGridView.Columns[1].Width = 180;
            FieldDataGridView.ClearSelection();
        }

        // обновление данных в таблице без подключения
        private void UpdateFieldTableLocal()
        {
            FieldDataGridView.Rows.Clear();
            int ind = 0;
            foreach (var field in Fields)
            {
                FieldDataGridView.Rows.Add();
                FieldDataGridView[0, ind].Value = field.Name;
                ind++;
            }
            FieldDataGridView.ClearSelection();
            WellPadDataGridView.Rows.Clear();
            WellDataGridView.Rows.Clear();
            textBox1.Text = "";
            PhysCharDataGridView.Rows.Clear();

        }

        /// <summary>
        /// Обновление данных в таблице КП
        /// </summary>
        private void UpdateWellPadTableOnline(int idField)
        {
            if (!cabinetForm.LoginForm.localLogin)
            {
                try
                {
                    WellPadDataGridView.DataSource = cabinetForm.LoginForm.dataBase.ShowData("SELECT * FROM WellPad WHERE Field_id =" + idField.ToString() + "");
                    WellPadDataGridView.Columns[0].Visible = false;
                    WellPadDataGridView.Columns[2].Visible = false;
                    WellPadDataGridView.Columns[1].Width = 50;
                    WellPadDataGridView.ClearSelection();
                }
                catch
                {
                    return;
                }
            }
        }

        // обновление данных в таблице без подключения
        private void UpdateWellPadTableLocal(int idField)
        {
            WellPadDataGridView.Rows.Clear();
            int ind = 0;
            foreach (var wellpad in Fields[idField].WellPads)
            {
                WellPadDataGridView.Rows.Add();
                WellPadDataGridView[0, ind].Value = wellpad.Num;
                ind++;
            }
            WellPadDataGridView.ClearSelection();

        }
        private void UpdateWellTableOnline(int idWellPad)
        {
            if (!cabinetForm.LoginForm.localLogin)
            {
                try
                {
                    WellDataGridView.DataSource = cabinetForm.LoginForm.dataBase.ShowData("SELECT * FROM Well WHERE WellPad_id =" + idWellPad.ToString() + "");
                    WellDataGridView.Columns[0].Visible = false;
                    WellDataGridView.Columns[3].Visible = false;
                    WellDataGridView.Columns[1].Width = 45;
                    WellDataGridView.Columns[2].Width = 240;
                    WellDataGridView.ClearSelection();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
        }

        // обновление данных в таблице без подключения
        private void UpdateWellTableLocal(int idWellPad)
        {
            WellDataGridView.Rows.Clear();
            int ind = 0;
            foreach (var well in Fields[idField].WellPads[idWellPad].tecObjects)
            {
                WellDataGridView.Rows.Add();
                WellDataGridView[1, ind].Value = well.Name;
                //WellDataGridView[1, ind].Value = well.TypeWell;
                ind++;
            }
            WellDataGridView.ClearSelection();

        }

        private void UpdatePhysCharTableOnline(int idWell)
        {
            if (!cabinetForm.LoginForm.localLogin)
            {
                try
                {
                    PhysCharDataGridView.DataSource = cabinetForm.LoginForm.dataBase.ShowData("SELECT * FROM PhysChar WHERE Well_id =" + idWell.ToString() + "");
                    PhysCharDataGridView.Columns[0].Visible = false;
                    PhysCharDataGridView.Columns[3].Visible = false;
                    PhysCharDataGridView.Columns[1].Width = 180;
                    PhysCharDataGridView.Columns[2].Width = 70;
                    PhysCharDataGridView.ClearSelection();

                }
                catch
                {
                    return;
                }
            }
        }
        private void UpdatePhysCharTableLocal(int idWell)
        {
            textBox1.Text = "";
            PhysCharDataGridView.Rows.Clear();
            int ind = 0;
            //foreach (var sig in Fields[idField].WellPads[idWellPad].Wells[idWell].Signals)
            //{
            //    PhysCharDataGridView.Rows.Add();
            //    PhysCharDataGridView[0, ind].Value = sig.NameSignal;
            //    PhysCharDataGridView[1, ind].Value = sig.TypeSignal;
            //    ind++;
            //}
            PhysCharDataGridView.Rows.Add();
            PhysCharDataGridView.Rows[0].Height = 50;
            PhysCharDataGridView[1, ind].Value = Fields[idField].WellPads[idWellPad].tecObjects[idWell].Info;
            textBox1.Text = Fields[idField].WellPads[idWellPad].tecObjects[idWell].Info;
        }

        private void обновитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!cabinetForm.LoginForm.localLogin)
            {
                UpdateFieldTableOnline();
                WellDataGridView.DataSource = null;
                WellPadDataGridView.DataSource = null;
                PhysCharDataGridView.DataSource = null;
            }
            else
            {
                UpdateFieldTableLocal();
            }
        }

        private void AddFieldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddField();
        }

        private void AddField()
        {
            AddEditField form = new AddEditField();
            if (!cabinetForm.LoginForm.localLogin)
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    cabinetForm.LoginForm.dataBase.AddField(form.FieldName);
                    UpdateFieldTableOnline();
                    FieldDataGridView.Rows[FieldDataGridView.Rows.Count - 2].Selected = true;
                }
            }
            else
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    Fields.Add(new Field(form.FieldName));
                    UpdateFieldTableLocal();
                    FieldDataGridView.Rows[FieldDataGridView.Rows.Count - 2].Selected = true;
                }
            }
        }
        private void AddWellPad()
        {
            AddEditWellPad form = new AddEditWellPad();
            if (!cabinetForm.LoginForm.localLogin)
            {
                try
                {
                    if (FieldDataGridView.SelectedRows[0].Cells[0].Value != null)
                    {
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            cabinetForm.LoginForm.dataBase.AddWellPad(idField, form.WellPadNum);
                            UpdateWellPadTableOnline(idField);
                            WellPadDataGridView.Rows[WellPadDataGridView.Rows.Count - 2].Selected = true;
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Выберите месторождение");
                }
            }
            else
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    if (FieldDataGridView.SelectedRows[0].Cells[0].Value != null)
                    {
                        idField = FieldDataGridView.SelectedRows[0].Index;
                        Fields[idField].WellPads.Add(new WellPad(form.WellPadNum));
                        UpdateWellPadTableLocal(idField);
                        WellPadDataGridView.Rows[WellPadDataGridView.Rows.Count - 2].Selected = true;
                    }
                    else
                        return;
                }
            }
        }
        private void WellPadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddWellPad();
        }
        private void AddWell()
        {
            var form = new AddEditWell();
            if (!cabinetForm.LoginForm.localLogin)
            {
                try
                {
                    if (WellPadDataGridView.SelectedRows[0].Cells[0].Value != null)
                    {
                        if (form.ShowDialog() == DialogResult.OK)
                        { 
                            cabinetForm.LoginForm.dataBase.AddWell(idWellPad, form.NumWell, form.TypeWell);
                            UpdateWellTableOnline(idWellPad);
                            WellDataGridView.Rows[WellDataGridView.Rows.Count - 2].Selected = true;
                    }
                    }
                }
                catch
                {
                    MessageBox.Show("Выберите КП");
                }
            }
            else
            {
                if (form.ShowDialog() == DialogResult.OK)
                {

                    if (WellPadDataGridView.SelectedRows[0].Cells[0].Value != null)
                    {
                        idWellPad = WellPadDataGridView.SelectedRows[0].Index;
                        for(int i =0; i < form.ObjectCount; i++)
                        {
                            Fields[idField].WellPads[idWellPad].tecObjects.Add(new TecObject(form.Type));

                        }
                        UpdateWellTableLocal(idWellPad);
                        WellDataGridView.Rows[WellDataGridView.Rows.Count - 2].Selected = true;
                    }
                    else
                        return;
                }
            }
        }
        private void AddWellToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddWell();
        }

        private void AddPhysChar()
        {
            var form = new AddEditPhysChar();
            if (!cabinetForm.LoginForm.localLogin)
            {
                try
                {
                    if (WellDataGridView.SelectedRows[0].Cells[0].Value != null)
                    {
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            idWell = (int)WellDataGridView.SelectedRows[0].Cells[0].Value;
                            cabinetForm.LoginForm.dataBase.AddPhysChar(idWell, form.NamePhysChar, form.Signal);
                            UpdatePhysCharTableOnline(idWell);
                            PhysCharDataGridView.Rows[PhysCharDataGridView.Rows.Count - 2].Selected = true;

                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Выберите скважину");
                }
            }
            else
            {               
                return;
                
            }
        }
        private void PhysCharToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddPhysChar();
        }

        private void UpdateField()
        {
            AddEditField form = new AddEditField();

            if (!cabinetForm.LoginForm.localLogin)
            {
                try
                {
                    if (FieldDataGridView.SelectedRows[0].Cells[0].Value != null)
                    {
                        idField = (int)FieldDataGridView.SelectedRows[0].Cells[0].Value;
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            cabinetForm.LoginForm.dataBase.UpdateField(form.FieldName, idField);
                            UpdateFieldTableOnline();
                            FieldDataGridView.Rows[indexDataGrid].Selected = true;
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Выберите месторождение");
                }
            }
            else
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    if (FieldDataGridView.SelectedRows[0].Cells[0].Value != null)
                    {
                        idField = FieldDataGridView.SelectedRows[0].Index;
                        Fields[idField].Name = form.FieldName;
                        UpdateFieldTableLocal();
                        FieldDataGridView.Rows[indexDataGrid].Selected = true;
                    }
                    else
                        return;
                }
            }
        }
        private void UpdateFieldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateField();
        }
        private void UpdateWellPad()
        {
            AddEditWellPad form = new AddEditWellPad();

            if (!cabinetForm.LoginForm.localLogin)
            {
                try
                {
                    if (WellPadDataGridView.SelectedRows[0].Cells[0].Value != null)
                    {
                        idWellPad = (int)WellPadDataGridView.SelectedRows[0].Cells[0].Value;
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            cabinetForm.LoginForm.dataBase.UpdateWellPad(form.WellPadNum, idWellPad);
                            UpdateWellPadTableOnline(idField);
                            WellPadDataGridView.Rows[indexDataGrid].Selected = true;

                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Выберите КП");
                }
            }
            else
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    if (WellPadDataGridView.SelectedRows[0].Cells[0].Value != null)
                    {
                        idField = FieldDataGridView.SelectedRows[0].Index;
                        idWellPad = WellPadDataGridView.SelectedRows[0].Index;
                        Fields[idField].WellPads[idWellPad].Num = form.WellPadNum;
                        UpdateWellPadTableLocal(idField);
                        WellPadDataGridView.Rows[indexDataGrid].Selected = true;
                    }
                    else
                        return;
                }
            }
        }
        private void UpdateWellPadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateWellPad();
        }

        private void UpdateWell()
        {
            AddEditWell form = new AddEditWell();
            if (!cabinetForm.LoginForm.localLogin)
            {
                try
                {
                    if (WellDataGridView.SelectedRows[0].Cells[0].Value != null)
                    {
                        idWell = (int)WellDataGridView.SelectedRows[0].Cells[0].Value;
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            cabinetForm.LoginForm.dataBase.UpdateWell(form.NumWell, form.TypeWell, idWell);
                            UpdateWellTableOnline(idWellPad);
                            WellDataGridView.Rows[indexDataGrid].Selected = true;

                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Выберите скважину!");
                }
            }
            else
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    if (WellDataGridView.SelectedRows[0].Cells[1].Value != null)
                    {
                        idField = FieldDataGridView.SelectedRows[0].Index;
                        idWellPad = WellPadDataGridView.SelectedRows[0].Index;
                        idWell = WellDataGridView.SelectedRows[0].Index;
                        Fields[idField].WellPads[idWellPad].tecObjects[idWell] = new TecObject(form.Type);
                        UpdateWellTableLocal(idWellPad);
                        WellDataGridView.Rows[indexDataGrid].Selected = true;
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }
        private void UpdateWellToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateWell();
        }
       private void UpdatePhysChar()
        {
            AddEditPhysChar form = new AddEditPhysChar();
            if (!cabinetForm.LoginForm.localLogin)
            {
                try
                {
                    if (PhysCharDataGridView.SelectedRows[0].Cells[0].Value != null)
                    {
                        idPhysChar = (int)PhysCharDataGridView.SelectedRows[0].Cells[0].Value;
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            cabinetForm.LoginForm.dataBase.UpdatePhysChar(form.NamePhysChar, form.Signal, idPhysChar);
                            UpdatePhysCharTableOnline(idWell);
                            PhysCharDataGridView.Rows[indexDataGrid].Selected = true;

                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Выберите подключение!");
                }
            }
            else
            {
               return;            
            }
        } 
        private void UpdatePhysCharToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdatePhysChar();
        }

        private void DeleteField()
        {
            if (!cabinetForm.LoginForm.localLogin)
            {
                try
                {
                    if (FieldDataGridView.SelectedRows[0].Cells[0].Value != null)
                    {
                        idField = (int)FieldDataGridView.SelectedRows[0].Cells[0].Value;
                        cabinetForm.LoginForm.dataBase.DeleteField(idField);
                        UpdateFieldTableOnline();
                        FieldDataGridView.Rows[FieldDataGridView.Rows.Count - 2].Selected = true;
                    }
                }
                catch
                {
                    MessageBox.Show("Выберите месторождение");
                }
            }
            else
            {
                if (FieldDataGridView.SelectedRows[0].Cells[0].Value != null)
                {
                    idField = FieldDataGridView.SelectedRows[0].Index;
                    Fields.RemoveAt(idField);
                    UpdateFieldTableLocal();
                    try
                    {
                        FieldDataGridView.Rows[FieldDataGridView.Rows.Count - 2].Selected = true;
                    }
                    catch
                    {
                        return;
                    }
                }
                else
                    return;

            }
        }
        private void DeleteFieldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteField();
        }
        private void DeleteWellPad()
        {
            if (!cabinetForm.LoginForm.localLogin)
            {
                try
                {
                    if (WellPadDataGridView.SelectedRows[0].Cells[0].Value != null)
                    {
                        idWellPad = (int)WellPadDataGridView.SelectedRows[0].Cells[0].Value;
                        cabinetForm.LoginForm.dataBase.DeleteWellPad(idWellPad);
                        UpdateWellPadTableOnline(idField);
                        WellPadDataGridView.Rows[WellPadDataGridView.Rows.Count - 2].Selected = true;

                        WellDataGridView.DataSource = null;
                        PhysCharDataGridView.DataSource = null;
                    }
                }
                catch
                {
                    MessageBox.Show("Выберите КП");
                }
            }
            else
            {
                if (WellPadDataGridView.SelectedRows[0].Cells[0].Value != null)
                {
                    idField = FieldDataGridView.SelectedRows[0].Index;
                    idWellPad = WellPadDataGridView.SelectedRows[0].Index;
                    Fields[idField].WellPads.RemoveAt(idWellPad);
                    UpdateWellPadTableLocal(idField);
                    try
                    {
                        WellPadDataGridView.Rows[WellPadDataGridView.Rows.Count - 2].Selected = true;
                    }
                    catch
                    {
                        return;
                    }
                }
                else
                    return;
            }
        }
        private void DeleteWellPadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteWellPad();
        }

        private void DeleteWell()
        {
            if (!cabinetForm.LoginForm.localLogin)
            {
                try
                {
                    if (WellDataGridView.SelectedRows[0].Cells[0].Value != null)
                    {
                        idWell = (int)WellDataGridView.SelectedRows[0].Cells[0].Value;
                        cabinetForm.LoginForm.dataBase.DeleteWell(idWell);
                        UpdateWellTableOnline(idWellPad);
                        WellDataGridView.Rows[WellDataGridView.Rows.Count - 2].Selected = true;

                        PhysCharDataGridView.DataSource = null;
                    }
                }
                catch
                {
                    MessageBox.Show("Выберите скважину");
                }
            }
            else
            {
                try
                {
                    if (WellDataGridView.SelectedRows[0].Cells[1].Value != null)
                    {
                        idField = FieldDataGridView.SelectedRows[0].Index;
                        idWellPad = WellPadDataGridView.SelectedRows[0].Index;
                        idWell = WellDataGridView.SelectedRows[0].Index;
                        Fields[idField].WellPads[idWellPad].tecObjects.RemoveAt(idWell);
                        UpdateWellTableLocal(idWellPad);
                        try
                        {
                            WellDataGridView.Rows[WellDataGridView.Rows.Count - 2].Selected = true;
                        }
                        catch { return; }
                    }
                }
                catch { return; }
            }
        }
        private void DeleteWellToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteWell();
        }

        private void DeletePhysChar()
        {
            if (!cabinetForm.LoginForm.localLogin)
            {
                try
                {
                    if (PhysCharDataGridView.SelectedRows[0].Cells[0].Value != null)
                    {
                        idPhysChar = (int)PhysCharDataGridView.SelectedRows[0].Cells[0].Value;
                        cabinetForm.LoginForm.dataBase.DeletePhysChar(idPhysChar);
                        UpdatePhysCharTableOnline(idWellPad);
                    }
                }
                catch
                {
                    MessageBox.Show("Выберите подключение");
                }
            }
            else
            {
                
                    return;
            }
        }
        private void DeletePhysCharToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeletePhysChar();
        }

        private void WellDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexDataGrid = WellDataGridView.SelectedRows[0].Index;
            if (!cabinetForm.LoginForm.localLogin)
            {
                try
                {
                    if (WellDataGridView.SelectedRows[0].Cells[0].Value != null)
                    {
                        idWell = (int)WellDataGridView.SelectedRows[0].Cells[0].Value;
                        UpdatePhysCharTableOnline(idWell);
                    }
                }
                catch
                {
                    return;
                }
            }
            else
            {
                try
                {
                    idWell = WellDataGridView.SelectedRows[0].Index;
                    UpdatePhysCharTableLocal(idWell);
                }
                catch
                {
                    return;
                }
            }
        }

        private void PhysCharDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexDataGrid = PhysCharDataGridView.SelectedRows[0].Index;
        }

        private void FieldDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexDataGrid = FieldDataGridView.SelectedRows[0].Index;
            if (!cabinetForm.LoginForm.localLogin)
            {
                try
                {
                    if (FieldDataGridView.SelectedRows[0].Cells[0].Value != null)
                    {
                        idField = (int)FieldDataGridView.SelectedRows[0].Cells[0].Value;
                        UpdateWellPadTableOnline(idField);
                        WellDataGridView.DataSource = null;
                        PhysCharDataGridView.DataSource = null;
                    }
                }
                catch
                {
                    return;
                }
            }
            else
            {
                try
                {
                    idField = FieldDataGridView.SelectedRows[0].Index;
                    UpdateWellPadTableLocal(idField);
                    WellDataGridView.Rows.Clear();
                    textBox1.Text = "";
                    PhysCharDataGridView.Rows.Clear();
                    LabelCountWell();
                }
                catch
                {
                    return;
                }

            }
        }
        
        //отоброжение количества скважин
        public void LabelCountWell()
        {
            if (WellPadDataGridView.SelectedRows.Count>0)
            {
                labelCountInj.Visible = true;
                labelCountProd.Visible = true;
                labelCountProd.Text = Fields[idField].WellPads[idWellPad].WellCount(TypeTecObj.DobSkvaz).ToString();
                labelCountInj.Text = Fields[idField].WellPads[idWellPad].WellCount(TypeTecObj.NagnSkvaz).ToString();
            }
            else
            {
                labelCountInj.Visible = false;
                labelCountProd.Visible = false;
            }
        }

        private void WellPadDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexDataGrid = WellPadDataGridView.SelectedRows[0].Index;
            if (!cabinetForm.LoginForm.localLogin)
            {
                try
                {
                    if (WellPadDataGridView.SelectedRows[0].Cells[0].Value != null)
                    {
                        idWellPad = (int)WellPadDataGridView.SelectedRows[0].Cells[0].Value;
                        UpdateWellTableOnline(idWellPad);
                        PhysCharDataGridView.DataSource = null;
                    }
                }
                catch
                {
                    return;
                }
            }
            else
            {
                try
                {
                    idWellPad = WellPadDataGridView.SelectedRows[0].Index;
                    UpdateWellTableLocal(idWellPad);
                    textBox1.Text = "";
                    PhysCharDataGridView.Rows.Clear();
                    LabelCountWell();

                }
                catch
                {
                    return;
                }

            }

        }

        string Pozition { get; set; }
        private void FieldDataGridView_MouseClick_1(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(MousePosition);
                Pozition = "Field";
            }
        }
        private void WellPadDataGridView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(MousePosition);
                Pozition = "WellPad";
            }
        }
        private void WellDataGridView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(MousePosition);
                Pozition = "Well";
            }
        }
        private void PhysCharDataGridView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(MousePosition);
                Pozition = "PhysChar";
            }
        }
        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Pozition == "Field")
            {
                AddField();
            }
            if (Pozition == "WellPad")
            {
                AddWellPad();
            }
            if (Pozition == "Well")
            {
                AddWell();
            }
            if (Pozition == "PhysChar")
            {
                AddPhysChar();
            }
        }

        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Pozition == "Field")
            {
                UpdateField();
            }
            if (Pozition == "WellPad")
            {
                UpdateWellPad();
            }
            if (Pozition == "Well")
            {
                UpdateWell();
            }
            if (Pozition == "PhysChar")
            {
                UpdatePhysChar();
            }
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Pozition == "Field")
            {
                DeleteField();
            }
            if (Pozition == "WellPad")
            {
                DeleteWellPad();
            }
            if (Pozition == "Well")
            {
                DeleteWell();
            }
            if (Pozition == "PhysChar")
            {
               DeletePhysChar();
            }
            
        }
        private void типыШкафовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            cabinetForm.StartPosition = FormStartPosition.Manual;
            cabinetForm.Location = this.Location;
            cabinetForm.Show();
        }

        private void подборШкафаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            cabinetForm.CalculationForm.StartPosition = FormStartPosition.Manual;
            cabinetForm.CalculationForm.Location = this.Location;
            cabinetForm.CalculationForm.Show();
        }

        private void ProfileForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!cabinetForm.LoginForm.localLogin)
            {
                if (cabinetForm.LoginForm.dataBase.sqlConnection.State == ConnectionState.Open)
                {
                    cabinetForm.LoginForm.dataBase.sqlConnection.Close();
                }
            }
            else
            {
                try
                {
                    SaveLoad.SaveToFile<List<Field>>(Fields, SaveLoad.FilePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            Application.Exit();
        }

        private void FieldDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (!cabinetForm.LoginForm.localLogin)
            {
                try
                {
                    if (FieldDataGridView.SelectedRows[0].Cells[0].Value != null)
                    {
                        idField = (int)FieldDataGridView.SelectedRows[0].Cells[0].Value;
                        UpdateWellPadTableOnline(idField);
                        WellDataGridView.DataSource = null;
                        PhysCharDataGridView.DataSource = null;
                    }
                }
                catch
                {
                    return;
                }
            }
            else
            {
                try
                {
                    idField = FieldDataGridView.SelectedRows[0].Index;
                    UpdateWellPadTableLocal(idField);
                    WellDataGridView.Rows.Clear();
                    textBox1.Text = "";
                    PhysCharDataGridView.Rows.Clear();
                }
                catch
                {
                    return;
                }
            }
        }

        private void WellPadDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (!cabinetForm.LoginForm.localLogin)
            {
                try
                {
                    if (WellPadDataGridView.SelectedRows[0].Cells[0].Value != null)
                    {
                        idWellPad = (int)WellPadDataGridView.SelectedRows[0].Cells[0].Value;
                        UpdateWellTableOnline(idWellPad);
                        PhysCharDataGridView.DataSource = null;
                    }
                }
                catch
                {
                    return;
                }
            }
            else
            {
                try
                {
                    idWellPad = WellPadDataGridView.SelectedRows[0].Index;
                    UpdateWellTableLocal(idWellPad);
                    textBox1.Text = "";
                    PhysCharDataGridView.Rows.Clear();
                }
                catch
                {
                    return;
                }

            }
        }

        private void WellDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (!cabinetForm.LoginForm.localLogin)
            {
                try
                {
                    if (WellDataGridView.SelectedRows[0].Cells[0].Value != null)
                    {
                        idWell = (int)WellDataGridView.SelectedRows[0].Cells[0].Value;
                        UpdatePhysCharTableOnline(idWell);
                    }
                }
                catch
                {
                    return;
                }
            }
            else
            {
                try
                {
                    idWell = WellDataGridView.SelectedRows[0].Index;
                    textBox1.Text = Fields[idField].WellPads[idWellPad].tecObjects[idWell].Info;
                    UpdatePhysCharTableLocal(idWell);
                }
                catch
                {
                    return;
                }
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void загрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK && openFileDialog1.FileName.Length > 0)
            {
                try
                {
                    Fields.Clear();
                    Fields = SaveLoad.LoadFromFile(openFileDialog1.FileName);
                    UpdateFieldTableLocal();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void поУмолчаниюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SaveLoad.SaveToFile<List<Field>>(Fields, SaveLoad.FilePath);
                MessageBox.Show("Файл с сохранёнными профилями расположен по следующему пути:\nДокументы\\CapacityCalc\\profiles.json",
                    "Файл успешно сохранился!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void выбратьПутьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "profiles.json";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK && saveFileDialog1.FileName.Length > 0)
            {
                try
                {
                    SaveLoad.SaveToFile<List<Field>>(Fields, saveFileDialog1.FileName);
                    MessageBox.Show($"Файл с сохранёнными профилями расположен по следующему пути:{saveFileDialog1.FileName}",
                        "Файл успешно сохранился!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

     
    }
}

