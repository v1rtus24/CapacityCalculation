using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapacityCalculation;

namespace CapacityСalculationUI
{
    public partial class LoginForm : Form
    {
        public CabinetForm cabinetForm { get; set; }
        public DataBase dataBase { get; set; }
        public LoginForm()
        {
            InitializeComponent();
            dataBase = new DataBase();
        }
        //DESKTOP-8GHSQ0R\SQLEXPRESS
        private void button1_Click(object sender, EventArgs e)
        {
            dataBase.ConnectionString = $@"Data Source=tcp: DESKTOP-8GHSQ0R\SQLEXPRESS,1433;
                                                        Initial Catalog=DBof;Persist Security Info=True;User ID={LoginTextBox.Text};Password={PasswordTextBox.Text}";

            dataBase.sqlConnection = new SqlConnection(dataBase.ConnectionString);
            
                try
                {
                    dataBase.sqlConnection.Open();
                    cabinetForm = new CabinetForm(this);
                    cabinetForm.Show();
                this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"При подключени произошла ошибка: {ex.Message}");
                }
            
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }
    }
}