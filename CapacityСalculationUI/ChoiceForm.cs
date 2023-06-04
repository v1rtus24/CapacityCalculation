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
    public partial class ChoiceForm : Form
    {
        public bool fieldCheck { get; set; } = false;
        public bool wellCheck { get; set; } = false;
        public bool wellPadCheck { get; set; } = false;
        public bool physCharCheck { get; set; } = false;


        public ChoiceForm()
        {
            InitializeComponent();
        }

        private void OkeyButton_Click(object sender, EventArgs e)
        {
            if (FieldRadioButton.Checked)
            {
                fieldCheck = true;
                DialogResult = DialogResult.OK;
            }
            else if (WellRadioButton.Checked)
            {
                wellCheck = true;
                DialogResult = DialogResult.OK;
            }
            else if (WellPadRadioButton.Checked)
            {
                wellPadCheck = true;
                DialogResult = DialogResult.OK;
            }
           
            else if (PhysCharRadioButton.Checked)
            {
                physCharCheck = true;
                DialogResult = DialogResult.OK;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
