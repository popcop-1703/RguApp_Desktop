using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class c_GroupBox : GroupBox
{
    public int Radius { get; set; } = 10;

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        Graphics graphics = e.Graphics;

        using (GraphicsPath path = new GraphicsPath())
        {
            Rectangle rect = new Rectangle(ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width - 1, ClientRectangle.Height - 1);
            int diameter = Radius * 2;

            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
            path.AddArc(rect.Width - diameter, rect.Y, diameter, diameter, 270, 90);
            path.AddArc(rect.Width - diameter, rect.Height - diameter, diameter, diameter, 0, 90);
            path.AddArc(rect.X, rect.Height - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();

            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.DrawPath(new Pen(BackColor), path);
            graphics.FillPath(new SolidBrush(BackColor), path);
        }
    }
}
