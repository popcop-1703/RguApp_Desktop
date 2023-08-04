using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RguApp_Desktop.Controls
{
    public class RoundedButton : Button
    {
        public RoundedButton()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
        }

        protected override void OnParentBackColorChanged(EventArgs e)
        {
            base.OnParentBackColorChanged(e);
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Отображение фона элемента с закругленными углами
            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);
            using (GraphicsPath rectPath = new GraphicsPath())
            {
                int roundingValue = 10;
                rectPath.AddArc(rect.X, rect.Y, roundingValue, roundingValue, 180, 90);
                rectPath.AddArc(rect.Width - roundingValue - 1, rect.Y, roundingValue, roundingValue, 270, 90);
                rectPath.AddArc(rect.Width - roundingValue - 1, rect.Height - roundingValue - 1, roundingValue, roundingValue, 0, 90);
                rectPath.AddArc(rect.X, rect.Height - roundingValue - 1, roundingValue, roundingValue, 90, 90);
                rectPath.CloseFigure();

                using (Brush backgroundBrush = new SolidBrush(Parent.BackColor))
                {
                    e.Graphics.FillPath(backgroundBrush, rectPath);
                }
            }

            // Отображение текста внутри элемента
            TextRenderer.DrawText(e.Graphics, Text, Font, rect, ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);
        }
    }
}
