using BotAgent.Ifrit.DataExporter;
using CapacityCalculation;
using DGVPrinterHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CapacityСalculationUI
{
    public partial class CalcExcelForm : Form
    {
        CalculationForm calculationForm { get; set; }
        public CalcExcelForm(CalculationForm form)
        {
            InitializeComponent();
            calculationForm = form;
        }
        public List<string[]> ExcelList { get; set; } = new List<string[]>();
        public Cabinet PodCab { get; set; }
        private void CalcExcelForm_Load(object sender, EventArgs e)
        {
            int gridCount = 0;
            Excel excel = new Excel();
            excel.FileOpen(calculationForm.ExcelFileName);
            Cabinet SignalCount = new Cabinet();
            Cabinet SignalCountWithRez = new Cabinet();
            //i=1 так как 0ая строчка это названия колонок 
            for (int i = 0; i < excel.Rows.Count(); i++)
            {
                ExcelList.Add(new string[4]);
                ExcelList[i][0] = excel.Rows[i][0];
                ExcelList[i][1] = excel.Rows[i][1];
                ExcelList[i][2] = excel.Rows[i][2];
                ExcelList[i][3] = excel.Rows[i][3];
            }
            for (int i = 1; i < ExcelList.Count; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1["Column1", gridCount].Value = ExcelList[i][0];
                dataGridView1["Column2", gridCount].Value = ExcelList[i][1];
                dataGridView1["Column3", gridCount].Value = ExcelList[i][2];
                dataGridView1["Column4", gridCount].Value = ExcelList[i][3];

                SignalCount = Cabinet.SignalCount(Convert.ToInt32(ExcelList[i][2]), Convert.ToInt32(ExcelList[i][3]));
                SignalCountWithRez = Cabinet.Rezerv(SignalCount);
                dataGridView1["AI", gridCount].Value = SignalCountWithRez.SignalAI; dataGridView1["AO", gridCount].Value = SignalCountWithRez.SignalAO;
                dataGridView1["DI", gridCount].Value = SignalCountWithRez.SignalDI; dataGridView1["DO", gridCount].Value = SignalCountWithRez.SignalDO;
                dataGridView1["RS485PLK", gridCount].Value = SignalCountWithRez.SignalRS485PLK; dataGridView1["RS485SHL", gridCount].Value = SignalCountWithRez.SignalRS485SHL;
                Cabinet.PodborCab(SignalCountWithRez, calculationForm.CabinetForm.constCabs);
                PodCab = Cabinet.PodborCab(SignalCountWithRez, calculationForm.CabinetForm.constCabs);
                dataGridView1["Type", gridCount].Value = PodCab.Name;
                gridCount++;
            }
        }

        private void CalcExcelForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            calculationForm.ExcelPodb = false;
        }

        private void CalcButton_Click(object sender, EventArgs e)
        {
            saveFileDialog1.DefaultExt = ".xlsx";
            saveFileDialog1.Filter = ".xlsx|.xlsx";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK && saveFileDialog1.FileName.Length > 0)
            {
                Cursor.Current = Cursors.WaitCursor;
                Excel excelEx = new Excel();
                List<string> spisok = new List<string>();
                List<string> ColSpis = new List<string> { "Месторождение", "№ КП", "Доб.", "Нагн.","AI","DI","AO","DO","RS485(ПЛК)","RS485(ШЛЮЗ)", "Тип"};
                excelEx.Rows.Add(ColSpis);
                string[] spis = new string[11];
                //for (int i = 0; i < dataGridView1.RowCount; i++)
                //{
                //    if (dataGridView1["Column1",i].Value != null)
                //    {
                //       // spisok.Clear();
                //        spisok.Add(dataGridView1["Column1", i].Value.ToString()); spisok.Add(dataGridView1["Column2", i].Value.ToString());
                //        spisok.Add(dataGridView1["Column3", i].Value.ToString()); spisok.Add(dataGridView1["Column4", i].Value.ToString());
                //        spisok.Add(dataGridView1["AI", i].Value.ToString()); spisok.Add(dataGridView1["DI", i].Value.ToString());
                //        spisok.Add(dataGridView1["AO", i].Value.ToString()); spisok.Add(dataGridView1["DO", i].Value.ToString());
                //        spisok.Add(dataGridView1["RS485PLK", i].Value.ToString()); spisok.Add(dataGridView1["RS485SHL", i].Value.ToString());
                //        spisok.Add(dataGridView1["Type", i].Value.ToString());
                        
                //       // excelEx.Rows.Add(spisok);
                //    }
                    
                //}
                for(int i = 0; i < dataGridView1.RowCount; i++)
                {
                    if (dataGridView1["Column1", i].Value != null)
                    {
                        for(int j = 0; j < dataGridView1.ColumnCount; j++)
                        {
                            spis[j] = dataGridView1[j,i].Value.ToString();
                        }
                        excelEx.AddRow(spis);
                    }
                }
                
                excelEx.FileSave(saveFileDialog1.FileName,true);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            Margins margin = new Margins(30, 30, 30, 30);
            printer.PrintMargins = margin;
            printer.PrintDataGridView(dataGridView1);
        }
    }
}

