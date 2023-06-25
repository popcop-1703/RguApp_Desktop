using System;
using System.Windows.Forms;

namespace RguApp_Desktop
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var form = new MainForm();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.WindowState = FormWindowState.Normal;
            form.Size = new System.Drawing.Size(Screen.PrimaryScreen.WorkingArea.Width / 2, Screen.PrimaryScreen.WorkingArea.Height);
            Application.Run(form);
        }
    }
}
