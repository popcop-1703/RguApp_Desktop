using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ExcelDataReader;

namespace RguApp_Desktop
{
    public partial class Form2 : Form
    {

        private string fileName = string.Empty;
        private string gender_text, style_text, distance_text = "";
        private int distance, gender, style = 0;
        public double a, b, c, d, speed, Final_count, speed_2 = 0;

        private DataTableCollection tableCollection = null;
        private Form1 refForm;
        public Form2(Form1 refForm)
        {
            InitializeComponent();
            this.refForm = refForm;
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult res = openFileDialog1.ShowDialog();

                if (res == DialogResult.OK)
                {
                    fileName = openFileDialog1.FileName;

                    Text = fileName;

                    OpenExcelFile(fileName);
                }
                else
                {
                    throw new Exception("Файл не выбран");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибика", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenExcelFile(string path)
        {
            FileStream stream = File.Open(path, FileMode.Open, FileAccess.Read);

            IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream);

            DataSet db = reader.AsDataSet(new ExcelDataSetConfiguration()
            {
                ConfigureDataTable = (x) => new ExcelDataTableConfiguration()
                {
                    UseHeaderRow = true,
                }
            });

            tableCollection = db.Tables;

            toolStripComboBox1.Items.Clear();  

            foreach(DataTable tabe in tableCollection)
            {
                 toolStripComboBox1.Items.Add(tabe.TableName);
            }

            toolStripComboBox1.SelectedIndex = 0;
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable table = tableCollection[Convert.ToString(toolStripComboBox1.SelectedItem)];

            dataGridView1.DataSource = table;
        }

        private void подсчетToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                gender_text = dataGridView1[0,0].Value.ToString();
                style_text = dataGridView1[1,0].Value.ToString();
                distance_text = dataGridView1[2, 0].Value.ToString();
                //MessageBox.Show(gender);
                GetGenderAndStyle();
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
            
            distance = Convert.ToInt32(distance_text);

            if (Form1.SelfRef != null)
            {
                Form1.SelfRef.GetCoef();
            }
            MessageBox.Show(Convert.ToString(a));
        }
        
        private void GetGenderAndStyle()
        {
            if (gender_text == "Мужской" || gender_text == "мужской")
                gender = 1;
            else if (gender_text == "Женский" || gender_text == "женский")
                gender = 2;
            else
                MessageBox.Show("Ошибка в получении пола");

            if (style_text == "Свободный" || style_text == "свободный")
                style = 1;
            else if (style_text == "Классический" || style_text == "классический")
                style = 2;
            else
                MessageBox.Show("Ошибка в получении стиля");
            //
        }
    }
}
