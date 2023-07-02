using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RguApp_Desktop.Controls;
using RguApp_Desktop.Components;


namespace RguApp_Desktop
{
    public partial class PointForm : Form
    {
        public PointForm()
        {
            InitializeComponent();
            //Image backgroundImage = Image.FromFile("Resources/bg.png");
        }

        private void PointForm_SizeChanged(object sender, EventArgs e)
        {
            // Установите изображение в качестве фона формы
            //this.BackgroundImage = backgroundImage;

            // Установите свойство BackgroundImageLayout как "Zoom"
            this.BackgroundImageLayout = ImageLayout.Zoom;
        }
    }
}
