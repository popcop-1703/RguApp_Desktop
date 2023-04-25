using ExcelDataReader;
using Microsoft.Office.Interop.Excel;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using DataTable = System.Data.DataTable;
using Excel = Microsoft.Office.Interop.Excel;

namespace RguApp_Desktop
{
    public partial class Form2 : Form
    {

        private string fileName = string.Empty;
        private string gender_text, style_text = "";
        private int distance, gender, style, point = 0;
        public double a, b, c, d, speed, Final_count, speed_2 = 0;

        public double time;
        public int Hour_int, Minute_int, Second_int, Millisecond_int = 0;
        public Form2()
        {
            InitializeComponent();
            Form1 frm = (Form1)this.Owner;
        }

        private void данныеПоОчкамToolStripMenuItem_Click(object sender, EventArgs e)
        {
            construct_table();
        }

        readonly DataGridViewComboBoxCell comboBoxCell1 = new DataGridViewComboBoxCell();
        readonly DataGridViewComboBoxCell comboBoxCell2 = new DataGridViewComboBoxCell();

        private void Form2_Load(object sender, EventArgs e)
        {
            clear_data();
            if (DataBase.transition == 1)
            {
                toolStripComboBox1.Items.Add("Времени");
                toolStripComboBox1.Items.Add("Скорости");
                construct_table();
            }
        }

        readonly DataGridViewComboBoxCell comboBoxCell3 = new DataGridViewComboBoxCell();
        private void add_combobox()
        {
            dataGridView1.Columns.Add("point_", "Очки");
            //ComboBox comboBoxCell1 = new ComboBox();
            //ComboBox comboBoxCell2 = new ComboBox();
            //ComboBox comboBoxCell3 = new ComboBox();

            comboBoxCell1.Items.Add("Мужской");
            comboBoxCell1.Items.Add("Женский");
            comboBoxCell2.Items.Add("Свободный");
            comboBoxCell2.Items.Add("Классический");
            comboBoxCell3.Items.Add("1000");
            comboBoxCell3.Items.Add("2000");
            comboBoxCell3.Items.Add("3000");
            comboBoxCell3.Items.Add("5000");
            comboBoxCell3.Items.Add("7500");
            comboBoxCell3.Items.Add("10000");
            comboBoxCell3.Items.Add("15000");
            comboBoxCell3.Items.Add("20000");
            comboBoxCell3.Items.Add("30000");
            comboBoxCell3.Items.Add("50000");
            comboBoxCell3.Items.Add("70000");
            comboBoxCell1.Value = "Мужской";
            comboBoxCell2.Value = "Свободный";
            comboBoxCell3.Value = "1000";
            dataGridView1.Rows[0].Cells[0] = comboBoxCell1;
            dataGridView1.Rows[0].Cells[1] = comboBoxCell2;
            dataGridView1.Rows[0].Cells[2] = comboBoxCell3;
        }


        private void construct_table()
        {
            clear_data();

            int o = 1;
            point = 1;
            gender = DataBase.gender;
            style = DataBase.style;

            dataGridView1.Columns.Add("point_", "Очки");
            dataGridView1.Columns.Add("dist1000", "1000");
            dataGridView1.Columns.Add("dist1000", "2000");
            dataGridView1.Columns.Add("dist1000", "3000");
            dataGridView1.Columns.Add("dist1000", "5000");
            dataGridView1.Columns.Add("dist1000", "7500");
            dataGridView1.Columns.Add("dist1000", "10000");
            dataGridView1.Columns.Add("dist1000", "15000");
            dataGridView1.Columns.Add("dist1000", "20000");
            dataGridView1.Columns.Add("dist1000", "30000");
            dataGridView1.Columns.Add("dist1000", "50000");
            dataGridView1.Columns.Add("dist1000", "70000");

            while (point <= 2145)
            {
                o = 1;
                dataGridView1.Rows.Add();
                while (o <= 11)
                {
                    string headerText = dataGridView1.Columns[o].HeaderText;
                    distance = Convert.ToInt32(headerText);
                    GetCoef();
                    speed = a * Math.Pow(point, 3) + b * Math.Pow(point, 2) + c * point + d;
                    time = (double)(Convert.ToInt32(headerText) / speed);
                    dataGridView1.Rows[point - 1].Cells[o].Value = timeToString(time);
                    o++;
                }

                dataGridView1.Rows[point - 1].Cells[0].Value = point;
                o++;
                point++;
            }
        }

        private void construct_table_speed()
        {
            clear_data();
            int o = 1;
            point = 1;
            gender = DataBase.gender;
            style = DataBase.style;

            dataGridView1.Columns.Add("point_", "Очки");
            dataGridView1.Columns.Add("dist1000", "1000");
            dataGridView1.Columns.Add("dist1000", "2000");
            dataGridView1.Columns.Add("dist1000", "3000");
            dataGridView1.Columns.Add("dist1000", "5000");
            dataGridView1.Columns.Add("dist1000", "7500");
            dataGridView1.Columns.Add("dist1000", "10000");
            dataGridView1.Columns.Add("dist1000", "15000");
            dataGridView1.Columns.Add("dist1000", "20000");
            dataGridView1.Columns.Add("dist1000", "30000");
            dataGridView1.Columns.Add("dist1000", "50000");
            dataGridView1.Columns.Add("dist1000", "70000");

            while (point <= 2145)
            {
                o = 1;
                dataGridView1.Rows.Add();
                while (o <= 11)
                {
                    string headerText = dataGridView1.Columns[o].HeaderText;
                    distance = Convert.ToInt32(headerText);
                    GetCoef();
                    speed = a * Math.Pow(point, 3) + b * Math.Pow(point, 2) + c * point + d;
                    dataGridView1.Rows[point - 1].Cells[o].Value = Math.Round(speed, 2) + " М/C";
                    o++;
                }

                dataGridView1.Rows[point - 1].Cells[0].Value = point;
                point++;
            }
        }

        private static String timeToString(double time)
        {
            double hour = Math.Floor(time / 3600),
                    min = Math.Floor(time / 60 % 60),
                    sec = Math.Floor(time / 1 % 60),
                    mil = Math.Round(time % 60 - Math.Floor(time % 60), 3),
                    sec2 = sec + mil;
            return hour.ToString("00") + ":" + min.ToString("00") + ":" + sec2.ToString("00.00");
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public double scale = Math.Pow(10, 2);


        private DataTableCollection tableCollection = null;


        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Excel.Application excelapp = new Microsoft.Office.Interop.Excel.Application();
            Workbook workbook = excelapp.Workbooks.Add();
            Worksheet worksheet = workbook.ActiveSheet;

            for (int i = 0; i < dataGridView1.RowCount + 1; i++)
            {
                for (int j = 1; j < dataGridView1.ColumnCount + 1; j++)
                {
                    if (i == 0)
                    {
                        worksheet.Rows[i + 1].Columns[j] = dataGridView1.Columns[j - 1].HeaderText;
                    }
                    else
                        worksheet.Rows[i + 1].Columns[j] = dataGridView1.Rows[i - 1].Cells[j - 1].Value;
                }
                
            }

            excelapp.AlertBeforeOverwriting = false;
            SaveFileDialog sfd = new SaveFileDialog()
            {
                Filter = "MS Excel dosuments (*.xlsx)|*.xlsx",
                DefaultExt = "*.xlsx",
                FileName = "1",
                Title = "Укажите директорию и имя файла для сохранения"
            };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                workbook.SaveAs(sfd.FileName);
            }
            excelapp.Quit();
            MessageBox.Show("Готово!");
        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var excel = new Excel.Application();

                var workBooks = excel.Workbooks;
                var workBook = workBooks.Add();
                var workSheet = (Excel.Worksheet)excel.ActiveSheet;

                workSheet.Cells[1, "A"] = "Пол";
                workSheet.Cells[1, "B"] = "Стиль";
                workSheet.Cells[1, "C"] = "Дистанция";
                workSheet.Cells[1, "D"] = "№";
                workSheet.Cells[1, "E"] = "Место";
                workSheet.Cells[1, "F"] = "Фамилия Имя";
                workSheet.Cells[1, "G"] = "Результат";
                workSheet.Cells[1, "H"] = "Очки";

                SaveFileDialog sfd = new SaveFileDialog()
                {
                    Filter = "MS Excel dosuments (*.xlsx)|*.xlsx",
                    DefaultExt = "*.xlsx",
                    FileName = "1",
                    Title = "Укажите директорию и имя файла для сохранения"
                };
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    workBook.SaveAs(sfd.FileName);
                }
                workBook.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.ToString());
            }

            MessageBox.Show("Файл " + "записан успешно!");
        }

        private void clear_data()
        {
            try
            {
                dataGridView1.Rows.Clear();
            }
            catch { MessageBox.Show("Ошибка", "Ошибка в очистке данных 1"); }

            try
            {
                dataGridView1.DataSource = null;
            }
            catch { MessageBox.Show("Ошибка", "Ошибка в очистке данных 2"); }

            try
            {
                dataGridView1.Columns.Clear();
            }
            catch { MessageBox.Show("Ошибка", "Ошибка в очистке данных 3"); }

            /*for (int p = 0; p< this.dataGridView1.Columns.Count; p++)
            {
                this.dataGridView1.Columns.RemoveAt(p);
                dataGridView1.Columns.Remove(dataGridView1.Columns[p]);
            }*/
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clear_data();
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
            add_combobox();
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

            foreach (DataTable tabe in tableCollection)
            {
                toolStripComboBox1.Items.Add(tabe.TableName);
            }

            toolStripComboBox1.SelectedIndex = 0;

        }
           


        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(DataBase.transition == 0)
            {
                DataTable table = tableCollection[Convert.ToString(toolStripComboBox1.SelectedItem)];

                dataGridView1.DataSource = table;
            }
            else if (DataBase.transition == 1)
            {
                // получаем выбранный пункт ToolStripComboBox
                ToolStripComboBox cmb = sender as ToolStripComboBox;
                string selectedTable = cmb.SelectedItem.ToString();

                // меняем источник данных DataGridView в зависимости от выбранного пункта
                if (selectedTable == "Времени")
                {
                    //dataGridView1.DataSource = new DataTable("Таблица 1");
                    construct_table();
                    // код заполнения таблицы Table1
                }
                else if (selectedTable == "Скорости")
                {
                    construct_table_speed();
                    // код заполнения таблицы Table2
                }
            }
 
        }


        private void подсчетToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();

            //dataGridView1.Rows.Add();

            try
            {
                gender_text = comboBoxCell1.Value.ToString();
                style_text = comboBoxCell2.Value.ToString();
                distance = Convert.ToInt32(comboBoxCell3.Value.ToString());

                GetGenderAndStyle();
                //MessageBox.Show(Convert.ToString(gender));
            }
            catch
            {
                MessageBox.Show("Ошибка в получении базовых значений");
            }

            GetCoef();

            for (int g = 0; g < dataGridView1.Rows.Count - 1; g++)
            {
                if (dataGridView1.Rows[g].Cells[6].Value != null || dataGridView1.Rows[g].Cells[6].Value.ToString() != "")
                {
                    string str = "";
                    speed = 0;
                    str = dataGridView1.Rows[g].Cells[6].Value.ToString();
                    string[] arr = str.Split(':', ',', '.', ';');
                    int[] intArray = new int[arr.Length];

                    for (int p = 0; p < arr.Length; p++)
                    {
                        intArray[p] = Convert.ToInt32(arr[p]);
                    }

                    if (arr.Length == 4)
                    {
                        Hour_int = intArray[0];
                        Minute_int = intArray[1];
                        Second_int = intArray[2];
                        Millisecond_int = intArray[3];
                    }
                    else if (arr.Length == 3)
                    {
                        Minute_int = intArray[0];
                        Second_int = intArray[1];
                        Millisecond_int = intArray[2];
                    }
                    else if (arr.Length == 2)
                    {
                        Second_int = intArray[0];
                        Millisecond_int = intArray[1];
                    }
                    else if (arr.Length == 1)
                    {
                        Millisecond_int = intArray[0];
                    }

                    Final_count = (Millisecond_int + (Second_int * 1000) + (Minute_int * 60 * 1000) + (Hour_int * 60 * 60 * 1000)) / 1000;
                    speed = distance / Final_count;
                    //расчет скорости 
                    //подсчет очков
                    for (int i = 0; i < 2200; i++)
                    {
                        speed_2 = a * Math.Pow(i, 3) + b * Math.Pow(i, 2) + c * i + d;
                        if (Math.Floor(speed_2) == Math.Floor(speed))
                        {
                            for (double j = 0; j < 1; j += 0.1)
                            {
                                speed_2 = a * Math.Pow(i, 3) + b * Math.Pow(i, 2) + c * i + d;
                                if ((Math.Ceiling(speed_2 * 10) / 10) == (Math.Ceiling(speed * 10) / 10))
                                {
                                    for (double k = 0; k < 0.1; k += 0.01)
                                    {
                                        speed_2 = a * Math.Pow(i, 3) + b * Math.Pow(i, 2) + c * i + d;
                                        if ((Math.Ceiling(speed_2 * scale) / scale) == (Math.Ceiling(speed * scale) / scale))
                                        {
                                            point = i;
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }

                    dataGridView1.Rows[g].Cells[7].Value = point;
                    point = 0;
                    for (int z = 0; z < intArray.Length; z++)
                    {
                        intArray[z] = 0;
                        arr[z] = "";
                    }
                }
                
            }
        }

        private void GetGenderAndStyle()
        {
            if (gender_text == "Мужской" || gender_text == "мужской")
            {
                gender = 1;
                DataBase.gender = 1;
            }
            else if (gender_text == "Женский" || gender_text == "женский")
            {
                gender = 2;
                DataBase.gender = 2;
            }
            else
                MessageBox.Show("Ошибка в получении пола");

            if (style_text == "Свободный" || style_text == "свободный")
            {
                DataBase.style = 1;
                style = 1;
            }
            else if (style_text == "Классический" || style_text == "классический")
            {
                style = 2;
                DataBase.style = 2;
            }
            else
                MessageBox.Show("Ошибка в получении стиля");

        }


        public void GetCoef()
        {
            if (distance == 1000 && gender == 1 && style == 1)
            {
                a = -3.800610269 * Math.Pow(10, -10);
                b = 5.351939033 * Math.Pow(10, -7);
                c = 0.002888134079;
                d = 4.166654127;
            }
            else if (distance == 1000 && gender == 1 && style == 2)
            {
                a = -3.446864478 * Math.Pow(10, -10);
                b = 4.462887807 * Math.Pow(10, -7);
                c = 0.002635557119;
                d = 4.61501587;
            }
            else if (distance == 1000 && gender == 2 && style == 1)
            {
                a = -3.114583333 * Math.Pow(10, -10);
                b = 4.344426407 * Math.Pow(10, -7);
                c = 0.00254557052;
                d = 3.71202381;
            }
            else if (distance == 1000 && gender == 2 && style == 2)
            {
                a = -2.767860199 * Math.Pow(10, -10);
                b = 3.483833439 * Math.Pow(10, -7);
                c = 0.0022779484;
                d = 3.6804441;
            } //2 км
            else if (distance == 2000 && gender == 1 && style == 1)
            {
                a = -3.879734848 * Math.Pow(10, -10);
                b = 5.567613636 * Math.Pow(10, -7);
                c = 0.0028709545;
                d = 4.1155;
            }
            else if (distance == 2000 && gender == 1 && style == 2)
            {
                a = -3.452335859 * Math.Pow(10, -10);
                b = 4.504626623 * Math.Pow(10, -7);
                c = 0.002626759019;
                d = 4.0375976;
            }
            else if (distance == 2000 && gender == 2 && style == 1)
            {
                a = -3.10290404 * Math.Pow(10, -10);
                b = 4.340205628 * Math.Pow(10, -7);
                c = 0.0025429538;
                d = 3.66107619;
            }
            else if (distance == 2000 && gender == 2 && style == 2)
            {
                a = -2.791877104 * Math.Pow(10, -10);
                b = 3.588915945 * Math.Pow(10, -7);
                c = 0.002265981542;
                d = 3.616415873;
            }//3 км
            else if (distance == 3000 && gender == 1 && style == 1)
            {
                a = -3.867529461 * Math.Pow(10, -10);
                b = 5.512599206 * Math.Pow(10, -7);
                c = 0.0028771030;
                d = 4.06270094;
            }
            else if (distance == 3000 && gender == 1 && style == 2)
            {
                a = -3.45223064 * Math.Pow(10, -10);
                b = 4.502444084 * Math.Pow(10, -7);
                c = 0.0026274173;
                d = 4.026130159;
            }
            else if (distance == 3000 && gender == 2 && style == 1)
            {
                a = -3.101536195 * Math.Pow(10, -10);
                b = 4.324062049 * Math.Pow(10, -7);
                c = 0.0025448159;
                d = 3.612701587;
            }
            else if (distance == 3000 && gender == 2 && style == 2)
            {
                a = -2.754945286 * Math.Pow(10, -10);
                b = 3.464619408 * Math.Pow(10, -7);
                c = 0.0022771097;
                d = 3.552539683;
            }// 5 км
            else if (distance == 5000 && gender == 1 && style == 1)
            {
                a = -3.857954545 * Math.Pow(10, -10);
                b = 5.492234848 * Math.Pow(10, -7);
                c = 0.002878109848;
                d = 3.972316667;
            }
            else if (distance == 5000 && gender == 1 && style == 2)
            {
                a = -3.428240741 * Math.Pow(10, -10);
                b = 4.5428309885 * Math.Pow(10, -7);
                c = 0.002632981542;
                d = 3.927349206;
            }
            else if (distance == 5000 && gender == 2 && style == 1)
            {
                a = -3.543034512 * Math.Pow(10, -10);
                b = 5.582160895 * Math.Pow(10, -7);
                c = 0.0024516010;
                d = 3.544426984;
            }
            else if (distance == 5000 && gender == 2 && style == 2)
            {
                a = -2.763888889 * Math.Pow(10, -10);
                b = 3.499972944 * Math.Pow(10, -7);
                c = 0.0022732693;
                d = 3.444945238;
            } //7.5 км
            else if (distance == 7500 && gender == 1 && style == 1)
            {
                a = -3.83733165 * Math.Pow(10, -10);
                b = 5.432720058 * Math.Pow(10, -7);
                c = 0.002882444204;
                d = 3.876275397;
            }
            else if (distance == 7500 && gender == 1 && style == 2)
            {
                a = -3.420664983 * Math.Pow(10, -10);
                b = 4.405068543 * Math.Pow(10, -7);
                c = 0.0026347245;
                d = 3.81270873;
            }
            else if (distance == 7500 && gender == 2 && style == 1)
            {
                a = -3.101430976 * Math.Pow(10, -10);
                b = 4.324693362 * Math.Pow(10, -7);
                c = 0.002544411496;
                d = 3.437629365;
            }
            else if (distance == 7500 && gender == 2 && style == 2)
            {
                a = -2.759259259 * Math.Pow(10, -10);
                b = 3.486138167 * Math.Pow(10, -7);
                c = 0.0022743788;
                d = 3.329843651;
            } // 10 км
            else if (distance == 10000 && gender == 1 && style == 1)
            {
                a = -3.835963805 * Math.Pow(10, -10);
                b = 5.430510462 * Math.Pow(10, -7);
                c = 0.0028823112;
                d = 3.795586508;
            }
            else if (distance == 10000 && gender == 1 && style == 2)
            {
                a = -3.424031987 * Math.Pow(10, -10);
                b = 4.418524531 * Math.Pow(10, -7);
                c = 0.002633435666;
                d = 3.71653651;
            }
            else if (distance == 10000 && gender == 2 && style == 1)
            {
                a = -3.11668771 * Math.Pow(10, -10);
                b = 4.367649711 * Math.Pow(10, -7);
                c = 0.002541034031;
                d = 3.361956349;
            }
            else if (distance == 10000 && gender == 2 && style == 2)
            {
                a = -2.759364478 * Math.Pow(10, -10);
                b = 3.485615079 * Math.Pow(10, -7);
                c = 0.002274428331;
                d = 3.233268254;
            }//15 км
            else if (distance == 15000 && gender == 1 && style == 1)
            {
                a = -3.834069865 * Math.Pow(10, -10);
                b = 5.430266955 * Math.Pow(10, -7);
                c = 0.002881810666;
                d = 3.666643651;
            }
            else if (distance == 15000 && gender == 1 && style == 2)
            {
                a = -3.430029461 * Math.Pow(10, -10);
                b = 4.433757215 * Math.Pow(10, -7);
                c = 0.002632288119;
                d = 3.563074603;
            }
            else if (distance == 15000 && gender == 2 && style == 1)
            {
                a = -3.111742424 * Math.Pow(10, -10);
                b = 4.4354220779 * Math.Pow(10, -7);
                c = 0.002542019481;
                d = 3.423982619;
            }
            else if (distance == 15000 && gender == 2 && style == 2)
            {
                a = -2.767150673 * Math.Pow(10, -10);
                b = 3.507323232 * Math.Pow(10, -7);
                c = 0.002272715067;
                d = 3.080122222;
            }//20 км
            else if (distance == 20000 && gender == 1 && style == 1)
            {
                a = -3.834806397 * Math.Pow(10, -10);
                b = 5.430122655 * Math.Pow(10, -7);
                c = 0.00288212025;
                d = 3.567584921;
            }
            else if (distance == 20000 && gender == 1 && style == 2)
            {
                a = -3.426346801 * Math.Pow(10, -10);
                b = 4.423439755 * Math.Pow(10, -7);
                c = 0.002633114658;
                d = 3.44575873;
            }
            else if (distance == 20000 && gender == 2 && style == 1)
            {
                a = -3.115214646 * Math.Pow(10, -10);
                b = 4.36482684 * Math.Pow(10, -7);
                c = 0.0025411621;
                d = 3.14677619;
            }
            else if (distance == 20000 && gender == 2 && style == 2)
            {
                a = -2.764941077 * Math.Pow(10, -10);
                b = 3.501208514 * Math.Pow(10, -7);
                c = 0.002273179173;
                d = 2.963479365;
            }//30 км
            else if (distance == 30000 && gender == 1 && style == 1)
            {
                a = -3.837647306 * Math.Pow(10, -10);
                b = 5.435560967 * Math.Pow(10, -7);
                c = 0.002881918951;
                d = 3.426342063;
            }
            else if (distance == 30000 && gender == 1 && style == 2)
            {
                a = -3.423295455 * Math.Pow(10, -10);
                b = 4.414772727 * Math.Pow(10, -7);
                c = 0.0026337386;
                d = 3.27905;
            }
            else if (distance == 30000 && gender == 2 && style == 1)
            {
                a = -3.118160774 * Math.Pow(10, -10);
                b = 4.37252886 * Math.Pow(10, -7);
                c = 0.002540577982;
                d = 3.013815079;
            }
            else if (distance == 30000 && gender == 2 && style == 2)
            {
                a = -2.739162458 * Math.Pow(10, -10);
                b = 3.417243867 * Math.Pow(10, -7);
                c = 0.002280146765;
                d = 2.796818254;
            }//50 км
            else if (distance == 50000 && gender == 1 && style == 1)
            {
                a = -3.838594276 * Math.Pow(10, -10);
                b = 5.438753608 * Math.Pow(10, -7);
                c = 0.002881617544;
                d = 3.260687302;
            }
            else if (distance == 50000 && gender == 1 && style == 2)
            {
                a = -3.425505051 * Math.Pow(10, -10);
                b = 4.420887446 * Math.Pow(10, -7);
                c = 0.002633274531;
                d = 3.084792857;
            }
            else if (distance == 50000 && gender == 2 && style == 1)
            {
                a = -3.116898148 * Math.Pow(10, -10);
                b = 4.36976912 * Math.Pow(10, -7);
                c = 0.0025407082;
                d = 2.857896032;
            }
            else if (distance == 50000 && gender == 2 && style == 2)
            {
                a = -2.765677609 * Math.Pow(10, -10);
                b = 3.503607504 * Math.Pow(10, -7);
                c = 0.002272980099;
                d = 2.606218254;
            } // 70 км
            else if (distance == 70000 && gender == 1 && style == 1)
            {
                a = -3.831123737 * Math.Pow(10, -10);
                b = 5.41880952 * Math.Pow(10, -7);
                c = 0.002883598304;
                d = 3.166219048;
            }
            else if (distance == 70000 && gender == 1 && style == 2)
            {
                a = -3.42645202 * Math.Pow(10, -10);
                b = 4.424188312 * Math.Pow(10, -7);
                c = 0.002632951479;
                d = 2.975057143;
            }
            else if (distance == 70000 && gender == 2 && style == 1)
            {
                a = -3.114832114 * Math.Pow(10, -10);
                b = 4.35728123 * Math.Pow(10, -7);
                c = 0.0025408408;
                d = 2.70420184;
            }
            else if (distance == 70000 && gender == 2 && style == 2)
            {
                a = -2.757154801 * Math.Pow(10, -10);
                b = 3.419801873 * Math.Pow(10, -7);
                c = 0.002265503937;
                d = 2.4524292077;
            }
        }
    }
}
