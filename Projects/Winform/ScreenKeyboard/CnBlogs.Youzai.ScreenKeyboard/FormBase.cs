using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace CnBlogs.Youzai.ScreenKeyboard {
    public class FormBase : Form {
        private PaintColor paintColor;

        public FormBase() {
            this.paintColor = new PaintColor();
        }

        protected override void OnPaint(PaintEventArgs e) {
            if (base.ClientRectangle.IsEmpty) {
                return;
            }

            using (Brush brush = new LinearGradientBrush(base.ClientRectangle,
                this.paintColor.startColor, this.paintColor.endColor, LinearGradientMode.Vertical)) {
                e.Graphics.FillRectangle(brush, base.ClientRectangle);
            }

            base.OnPaint(e);
        }

        private class PaintColor {
            internal Color startColor;
            internal Color endColor;

            public PaintColor() {
                this.startColor = Color.FromArgb(88, 134, 213);
                this.endColor = Color.FromArgb(4, 57, 149);
            }
        }
    }
}
