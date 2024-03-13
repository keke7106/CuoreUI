﻿using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CuoreUI.Controls
{
    public partial class cuiCircleProgressBar : UserControl
    {
        public cuiCircleProgressBar()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        private int privateBorderWidth = 2;
        public int BorderWidth
        {
            get
            {
                return privateBorderWidth;
            }
            set
            {
                privateBorderWidth = value;
                Invalidate();
            }
        }

        private int privateProgressValue = 2;
        public int ProgressValue
        {
            get
            {
                return privateProgressValue;
            }
            set
            {
                privateProgressValue = value;
                Invalidate();
            }
        }

        private int privateMinimumValue = 1;
        public int MinimumValue
        {
            get
            {
                return privateMinimumValue;
            }
            set
            {
                privateMinimumValue = value;
                Invalidate();
            }
        }

        private int privateMaximumValue = 3;
        public int MaximumValue
        {
            get
            {
                return privateMaximumValue;
            }
            set
            {
                privateMaximumValue = value;
                Invalidate();
            }
        }

        private Color privateNormalColor = Color.FromArgb(222, 222, 222);
        public Color NormalColor
        {
            get
            {
                return privateNormalColor;
            }
            set
            {
                privateNormalColor = value;
                Invalidate();
            }
        }

        private Color privateProgressColor = Color.MediumSlateBlue;
        public Color ProgressColor
        {
            get
            {
                return privateProgressColor;
            }
            set
            {
                privateProgressColor = value;
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            int circleWidth = Width - BorderWidth;
            int circleHeight = Height - BorderWidth;
            int borderHalf = BorderWidth / 2;

            MinimumSize = new Size(BorderWidth*2, BorderWidth * 2);

            float percent = (float)(ProgressValue - MinimumValue) / (MaximumValue - MinimumValue) * 100;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using (GraphicsPath path = new GraphicsPath())
            using (Pen pen = new Pen(NormalColor, BorderWidth))
            {
                path.AddArc(new Rectangle(borderHalf, borderHalf, circleWidth, circleHeight), (percent * 3.6f) - 92, 360 - (percent * 3.6f));
                e.Graphics.DrawPath(pen, path);
            }

            using (GraphicsPath path = new GraphicsPath())
            using (Pen pen = new Pen(ProgressColor, BorderWidth))
            {
                path.AddArc(new Rectangle(borderHalf, borderHalf, circleWidth, circleHeight), -92, percent * 3.6f);
                e.Graphics.DrawPath(pen, path);
            }
        }
    }
}
