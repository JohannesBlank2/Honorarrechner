using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Honorar_Rechner
{
    public class ColoredCheckBox : CheckBox
    {
        public Color CheckedBoxColor { get; set; } = Color.Aquamarine;
        public Color CheckmarkColor { get; set; } = Color.Black;
        public int CornerRadius { get; set; } = 4;

        public ColoredCheckBox()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.BackColor = Color.Transparent;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Hintergrund der Checkbox-Zeichenfläche säubern
            using (SolidBrush backBrush = new SolidBrush(this.Parent.BackColor))
            {
                e.Graphics.FillRectangle(backBrush, this.ClientRectangle);
            }

            Rectangle box = new Rectangle(0, 2, 16, 16);

            // Rundes Rechteck erzeugen
            using (GraphicsPath path = RoundedRect(box, CornerRadius))
            using (Brush brush = new SolidBrush(this.Checked ? CheckedBoxColor : Color.White))
            using (Pen border = new Pen(Color.Gray))
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.FillPath(brush, path);
                e.Graphics.DrawPath(border, path);
            }

            // Haken zeichnen
            if (this.Checked)
            {
                using (Pen checkPen = new Pen(CheckmarkColor, 2))
                {
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    e.Graphics.DrawLines(checkPen, new Point[] {
                new Point(4, 9),
                new Point(7, 12),
                new Point(12, 5)
            });
                }
            }

            // Text nur zeichnen, wenn vorhanden
            if (!string.IsNullOrEmpty(this.Text))
            {
                TextRenderer.DrawText(e.Graphics, this.Text, this.Font,
                    new Point(22, 2), this.ForeColor);
            }
        }


        // Hilfsmethode für runde Ecken
        private GraphicsPath RoundedRect(Rectangle bounds, int radius)
        {
            int diameter = radius * 2;
            GraphicsPath path = new GraphicsPath();
            path.AddArc(bounds.X, bounds.Y, diameter, diameter, 180, 90);
            path.AddArc(bounds.Right - diameter, bounds.Y, diameter, diameter, 270, 90);
            path.AddArc(bounds.Right - diameter, bounds.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}
