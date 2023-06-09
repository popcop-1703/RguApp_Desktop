﻿using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace RguApp_Desktop
{
    public partial class Form1 : Form
    {
        public int gender, style, distance = 1;
        public string[] distance_text = { "1 км", "2 км", "3 км", "5 км", "7.5 км", "10 км", "15 км", "20 км", "30 км", "50 км", "70 км" };
        public double a, b, c, d, speed, Final_count, speed_2 = 0;
        public int Hour_int, Minute_int, Second_int, Millisecond_int = 0;
        Form2 newForm2 = new Form2();

        private void button4_Click(object sender, EventArgs e)
        {
            DataBase.transition = 0;
            GetRadio();
            newForm2.Owner = this;
            newForm2.ShowDialog();
        }

        public double time;

        private void button5_Click(object sender, EventArgs e)
        {

            GetRadio();
            DataBase.transition = 1;
            newForm2.ShowDialog();
        }

       

        public int point, buttonCount;
        public double scale = Math.Pow(10, 2);

        public static Form1 SelfRef
        {
            get; set;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(buttonCount == 1 || buttonCount == 2)
            {
                action_button2();
            }
        }

        public Form1()
        {
            SelfRef = this;
            InitializeComponent();
            radioButton_male.Checked = true;
            radioButton_StyleFree.Checked = true;
            listBox1.Items.AddRange(distance_text);
            listBox1.SetSelected(0, true);

            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            button2.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
        }
        bool previousCheckedValue_gender = false;
        bool previousCheckedValue_style = false;

        private void radioButton_male_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_male.Checked && !previousCheckedValue_gender)
            {
                // Изменение выбранного RadioButton
                // Поместите здесь код, который нужно выполнить при изменении выбранного элемента RadioButton
                if (buttonCount == 1 || buttonCount == 2)
                {
                    action_button2();
                }
                previousCheckedValue_gender = true;
                radioButton_female.Checked = false; // Только для примера, чтобы снять выбор с другого RadioButton
            }
            else
            {
                previousCheckedValue_gender = false;
            }
        }

        private void radioButton_female_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_female.Checked && !previousCheckedValue_gender)
            {
                // Изменение выбранного RadioButton
                // Поместите здесь код, который нужно выполнить при изменении выбранного элемента RadioButton
                if (buttonCount == 1 || buttonCount == 2)
                {
                    action_button2();
                }
                previousCheckedValue_gender = true;
                radioButton_male.Checked = false; // Только для примера, чтобы снять выбор с другого RadioButton
            }
            else
            {
                previousCheckedValue_gender = false;
            }
        }

        private void radioButton_StyleFree_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_StyleFree.Checked && !previousCheckedValue_gender)
            {
                // Изменение выбранного RadioButton
                // Поместите здесь код, который нужно выполнить при изменении выбранного элемента RadioButton
                if (buttonCount == 1 || buttonCount == 2)
                {
                    action_button2();
                }
                previousCheckedValue_style = true;
                radioButton_StyleClassic.Checked = false; // Только для примера, чтобы снять выбор с другого RadioButton
            }
            else
            {
                previousCheckedValue_gender = false;
            }
        }

        private void radioButton_StyleClassic_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_StyleClassic.Checked && !previousCheckedValue_gender)
            {
                // Изменение выбранного RadioButton
                // Поместите здесь код, который нужно выполнить при изменении выбранного элемента RadioButton
                if (buttonCount == 1 || buttonCount == 2)
                {
                    action_button2();
                }
                previousCheckedValue_style = true;
                radioButton_StyleFree.Checked = false; // Только для примера, чтобы снять выбор с другого RadioButton
            }
            else
            {
                previousCheckedValue_gender = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label6.Text = "";
            label7.Text = "";

            label1.Text = "Введите время";
            label2.Text = "Часы";
            label3.Text = "Минуты";
            label4.Text = "Секунды";
            label5.Text = "Десятые";
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            button2.Visible = true;


            buttonCount = 1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label6.Text = "";
            label7.Text = "";

            label1.Text = "Введите желаемое количество очков";
            label2.Text = "Очки";
            label1.Visible = true;
            label2.Visible = true;
            textBox1.Visible = true;
            button2.Visible = true;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;

            buttonCount = 2;
        }

        private void action_button2()
        {
            GetRadio();
            GetDistance();
            GetCoef();


            label6.Text = "";
            label7.Text = "";
            point = 0;

            if (buttonCount == 1)
            {
                if (textBox1.Text == "")
                    Hour_int = 0;
                else
                    Hour_int = int.Parse(textBox1.Text);

                if (textBox2.Text == "")
                    Minute_int = 0;
                else
                    Minute_int = int.Parse(textBox2.Text);

                if (textBox3.Text == "")
                    Second_int = 0;
                else
                    Second_int = int.Parse(textBox3.Text);

                if (textBox4.Text == "")
                    Millisecond_int = 0;
                else
                    Millisecond_int = int.Parse(textBox4.Text);

                Final_count = (Millisecond_int + (Second_int * 1000) + (Minute_int * 60 * 1000) + (Hour_int * 60 * 60 * 1000)) / 1000;
                speed = distance / Final_count;

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

                if (speed >= 0 && point >= 0)
                {
                    if (speed <= 9)
                    {
                        label6.Text = "Ваша скорость = " + Math.Round(speed, 2) + " М/С";
                        label7.Text = "Ваше количество очков = " + point;
                    }
                    else
                    {
                        MessageBox.Show("Результат не является реалистичным", "Ошибка");
                    }
                }
                else
                {
                    MessageBox.Show("Результат не входит в очковый диапазон", "Ошибка");
                }


            }

            else if (buttonCount == 2)
            {
                if (textBox1.Text == "")
                    point = 0;
                else
                    point = int.Parse(textBox1.Text);

                if (point >= 0 && point <= 2100)
                {
                    speed = a * Math.Pow(point, 3) + b * Math.Pow(point, 2) + c * point + d;
                    time = (long)(distance / speed);

                    if (speed >= 0)
                    {
                        label6.Text = "Рекомендованная скорость = " + Math.Round(speed, 2) + " М/С";
                        label7.Text = "Результат = " + timeToString(time);
                    }
                    else
                    {
                        MessageBox.Show("Результат не входит в очковый диапазон", "Ошибка");
                    }
                }
                else
                {
                    MessageBox.Show("Введите целочисленное значение от 0 до 2100", "Ошибка");
                }
            }

            label6.Visible = true;
            label7.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            action_button2();


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

        public void GetRadio()
        {
            if (radioButton_male.Checked)
            {
                gender = 1;
                DataBase.gender = 1;
            }
            else if (radioButton_female.Checked)
            {
                gender = 2;
                DataBase.gender = 2;
            };

            if (radioButton_StyleFree.Checked)
            {
                style = 1;
                DataBase.style = 1;
            }
            else if (radioButton_StyleClassic.Checked)
            {
                style = 2;
                DataBase.style = 2;
            }
        }

        private void GetDistance()
        {
            switch (listBox1.SelectedIndex)
            {
                case 0:
                    distance = 1000;
                    break;
                case 1:
                    distance = 2000;
                    break;
                case 2:
                    distance = 3000;
                    break;
                case 3:
                    distance = 5000;
                    break;
                case 4:
                    distance = 7500;
                    break;
                case 5:
                    distance = 10000;
                    break;
                case 6:
                    distance = 15000;
                    break;
                case 7:
                    distance = 20000;
                    break;
                case 8:
                    distance = 30000;
                    break;
                case 9:
                    distance = 50000;
                    break;
                case 10:
                    distance = 70000;
                    break;
                default:
                    distance = 1000;
                    break;
            }
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
        /*private void GetGender(RadioButton rdoButton)
        {
            if (rdoButton.Checked)
            {
                MessageBox.Show(rdoButton.Text);
            }
        }*/
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }
    }
}
