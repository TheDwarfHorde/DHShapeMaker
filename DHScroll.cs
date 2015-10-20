using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ShapeMaker
{
    public partial class dhScroll : UserControl
    {

        float realVal = .5f;
        float minvalue = 0;
        float maxvalue = 10;
        bool scrolling = false;
        int gState = 0;

        Color basecolor = Color.FromArgb(189, 189, 189);
        Color shadowcolor = Color.SlateGray;

        public delegate void ValueChangedEventHandler(object sender, float e);
        public event ValueChangedEventHandler ValueChanged;

        public dhScroll()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer
                | ControlStyles.UserPaint, true);
        }

        public float Value
        {
            get { return adjustment(); }
            set
            {
                float v = (value > maxvalue) ? maxvalue : (value < minvalue) ? minvalue : value;
                realVal = (v - minvalue) / (maxvalue - minvalue);
                this.Refresh();
            }
        }
        public float minValue
        {
            get { return minvalue; }
            set
            {
                minvalue = (value < maxvalue) ? value : maxvalue - .1f;
                this.Refresh();
            }
        }
        public float maxValue
        {
            get { return maxvalue; }
            set
            {
                maxvalue = (value > minvalue) ? value : minvalue + .1f;
                this.Refresh();
            }
        }


        protected void OnValueChanged(float e)
        {
            if (this.ValueChanged != null) this.ValueChanged(this, e);
        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            //base.OnPaintBackground(e);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            GraphicsUnit gu = GraphicsUnit.Pixel;

            int off = (int)(25f * this.ClientRectangle.Width / 156);
            int blip = (int)(96f * this.ClientRectangle.Width / 156);
            Rectangle rct = new Rectangle(0, 0, this.ClientRectangle.Width,
                this.ClientRectangle.Height);
            Rectangle hrct = new Rectangle(0, 0, (int)(11f * this.ClientRectangle.Width / 156),
                (int)(this.ClientRectangle.Height));
            e.Graphics.FillRectangle(new SolidBrush(basecolor), this.ClientRectangle);
            float z = realVal;

            int span = (int)(z * blip);
            Rectangle preSpan = new Rectangle(off + span, 0, hrct.Width, hrct.Height);
            if (gState == 0)
            {
                e.Graphics.DrawImage(Properties.Resources.leftarrow, rct,
                    Properties.Resources.leftarrow.GetBounds(ref gu), GraphicsUnit.Pixel);
                e.Graphics.DrawImage(Properties.Resources.sliderHandle, preSpan,
                    Properties.Resources.sliderHandle.GetBounds(ref gu), GraphicsUnit.Pixel);
            }
            else if (gState == 1)
            {
                e.Graphics.DrawImage(Properties.Resources.leftarrowLit, rct,
                    Properties.Resources.leftarrowLit.GetBounds(ref gu), GraphicsUnit.Pixel);
                e.Graphics.DrawImage(Properties.Resources.sliderHandle, preSpan,
                    Properties.Resources.sliderHandle.GetBounds(ref gu), GraphicsUnit.Pixel);
            }
            else if (gState == 2)
            {
                e.Graphics.DrawImage(Properties.Resources.rightarrowLit, rct,
                    Properties.Resources.rightarrowLit.GetBounds(ref gu), GraphicsUnit.Pixel);
                e.Graphics.DrawImage(Properties.Resources.sliderHandle, preSpan,
                    Properties.Resources.sliderHandle.GetBounds(ref gu), GraphicsUnit.Pixel);

            }
            else if (gState == 3)
            {
                e.Graphics.DrawImage(Properties.Resources.leftarrow, rct,
                    Properties.Resources.leftarrow.GetBounds(ref gu), GraphicsUnit.Pixel);
                e.Graphics.DrawImage(Properties.Resources.sliderHandleLit, preSpan,
                    Properties.Resources.sliderHandleLit.GetBounds(ref gu), GraphicsUnit.Pixel); ;
            }

            //base.OnPaint(e);
        }

        private void dhScroll_MouseDown(object sender, MouseEventArgs e)
        {
            float off = this.ClientSize.Width * .15f;
            float blip = this.ClientSize.Width * .1f;
            RectangleF r1 = new RectangleF(0, 0, off, this.ClientSize.Height);
            RectangleF r2 = new RectangleF(this.ClientSize.Width - off, 0,
                this.ClientSize.Width - off, this.ClientSize.Height);
            float span = realVal * (this.ClientSize.Width - off - off - blip);
            RectangleF r3 = new RectangleF(off + span, 0, blip, this.ClientSize.Height);

            if (r1.Contains(e.Location))
            {
                realVal = readjustment(adjustment() - 10);
                gState = 1;
            }
            else if (r2.Contains(e.Location))
            {
                realVal = readjustment(adjustment() + 10);
                gState = 2;
            }
            else if (r3.Contains(e.Location))
            {
                gState = 3;
                scrolling = true;
            }
            this.Refresh();
        }

        private void dhScroll_MouseUp(object sender, MouseEventArgs e)
        {
            scrolling = false;
            gState = 0;
            OnValueChanged(adjustment());
            this.Refresh();
        }

        private void dhScroll_MouseMove(object sender, MouseEventArgs e)
        {
            if (!scrolling) return;
            gState = 3;
            float off = this.ClientSize.Width * .15f;
            float blip = this.ClientSize.Width * .1f;
            Rectangle r = this.ClientRectangle;
            int ex = e.Location.X - (int)blip / 2;
            if (r.Contains(e.Location))
            {
                realVal = ((float)ex - off) / (this.ClientSize.Width - off - off - blip);
                realVal = (realVal > 1) ? 1f : (realVal < 0) ? 0 : realVal;
                OnValueChanged(adjustment());
                this.Refresh();
            }
        }
        private float adjustment()
        {
            return realVal * (maxvalue - minvalue) + minvalue;
        }
        private float readjustment(float value)
        {
            float v = (value > maxvalue) ? maxvalue : (value < minvalue) ? minvalue : value;
            return (v - minvalue) / (maxvalue - minvalue);
        }
    }

}
