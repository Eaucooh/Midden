using System;
using System.Windows.Forms;
using System.Drawing;

namespace CnBlogs.Youzai.ScreenKeyboard {
    internal class KeyboardLight : UserControl {
        private bool on;
        private KeyboardButton assositeButton;
        private static readonly Size SIZE = new Size(16, 16);

        public KeyboardLight() {
            base.Size = SIZE;
            this.on = false;
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.UpdateStyles();
            this.BackColor = Color.Transparent;
        }

        public KeyboardButton AssositeButton {
            set {
                if (!object.ReferenceEquals(this.assositeButton, value)) {
                    this.assositeButton = value;
                    this.assositeButton.CheckChanged += AssositeButtonOnCheckChanged;
                }
            }
        }

        public bool On {
            get {
                return this.on;
            }
        }

        private void AssositeButtonOnCheckChanged(object sender, CheckChangedEventArgs e) {
            this.on = e.Checked;
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            Rectangle rect = new Rectangle(0, 0, base.ClientSize.Width - 1, base.ClientSize.Height - 1);

            using (Pen pen = this.on ? new Pen(Color.FromArgb(0, 0, 128)) : new Pen(Color.FromArgb(59, 97, 156))) {
                g.DrawEllipse(pen, rect);
            }

            using (Brush brush = this.on ? new SolidBrush(Color.Yellow) : new SolidBrush(Color.White)) {
                if (rect.Width > 3 && rect.Height > 3) {
                    rect.Inflate(-1, -1);
                    g.FillEllipse(Brushes.WhiteSmoke, rect);
                    rect.Inflate(-2, -2);

                    g.FillEllipse(brush, rect);
                }
            }
        }
    }
}
