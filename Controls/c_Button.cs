using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace RguApp_Desktop.Controls
{
    public class c_Button : Button
    {
        #region --Свойства--
        public string TextHover { get; set; }
        private StringFormat SF = new StringFormat();
        private bool roundingEnable = false;
        [Description("Вкл/Выкл закругления объекта")]
        public bool RoundingEnable
        {
            get => roundingEnable;
            set
            {
                roundingEnable = value;
                Refresh();
            }
        }

        private int roundingPercent = 100;
        [DisplayName("Rounding [%]")]
        [DefaultValue(100)]
        [Description("Указывает радиус закругления объекта в процентном соотношении")]
        public int Rounding
        {
            get => roundingPercent;
            set
            {
                if (value >= 0 && value <= 100)
                {
                    roundingPercent = value;
                    Refresh();
                }
            }
        }
        #endregion

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.Clear(Parent.BackColor);

            // Отображение фона кнопки
            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);

            // Если включено закругление
            if (RoundingEnable)
            {
                float roundingValue = Height / 100F * Rounding;
                using (GraphicsPath rectPath = Design.RoundedRectangle(rect, roundingValue))
                {
                    g.DrawPath(new Pen(BackColor), rectPath);
                    g.FillPath(new SolidBrush(BackColor), rectPath);

                    // Отображение текста внутри кнопки
                    using (StringFormat sf = new StringFormat())
                    {
                        sf.Alignment = StringAlignment.Center;
                        sf.LineAlignment = StringAlignment.Center;

                        using (Brush textBrush = new SolidBrush(ForeColor))
                        {
                            g.DrawString(Text, Font, textBrush, rect, sf);
                        }
                    }
                }
            }
            else
            {
                // Отображение текста (без закругления)
                using (Brush textBrush = new SolidBrush(ForeColor))
                {
                    g.DrawString(Text, Font, textBrush, rect);
                }
            }
        }
    }
}