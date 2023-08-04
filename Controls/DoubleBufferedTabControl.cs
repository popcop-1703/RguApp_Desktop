using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

public class DoubleBufferedTabControl : TabControl
{
    public DoubleBufferedTabControl()
    {
        DoubleBuffered = true;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        using (var brush = new SolidBrush(BackColor))
        {
            e.Graphics.FillRectangle(brush, ClientRectangle);
        }
        base.OnPaint(e);
    }
}
