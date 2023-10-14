﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RguApp_Desktop.Controls;
using RguApp_Desktop.Components;

namespace RguApp_Desktop
{
    public partial class MainForm : Form
    {
        //TableForm newForm2 = new TableForm();

        public MainForm()
        {
            InitializeComponent();
            // button1.ImageAlign = ContentAlignment.TopCenter;
            // button1.TextImageRelation = TextImageRelation.ImageAboveText;
            button1.Text = "Подсчет очков";
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
           PoForm formPoint = new PoForm();
            formPoint.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            DataBase.flagTable = false;
            TableForm newForm2 = new TableForm();
            DataBase.transition = 0;
            //GetRadio();
            newForm2.Owner = this;
            newForm2.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataBase.flagTable = true;
            TableForm newForm2 = new TableForm();
            //GetRadio();
            //DataBase.gender = 1;
            //DataBase.style = 1;
            DataBase.transition = 1;
            newForm2.Show();
        }
    }
}
