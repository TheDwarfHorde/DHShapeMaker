using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace Controlz
{
    public partial class BigKnobs : UserControl
    {
        public BigKnobs()
        {
            InitializeComponent();
        }
        float rtate = 0;
        float minvalue = 0;
        float maxvalue = 10;
        float offset = 0;
        float span = 270;
        float spinrate = 1;
        float touchpoint = 0;
        bool rtating = false;
        Image BottomImage, MidImage, TopImage;

        public float Value
        {
            get { return adjustment(); }
            set
            {
                rtate = (value - minvalue) * span / (maxvalue - minvalue);
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

        public float Offset
        {
            get { return offset; }
            set
            {
                offset = (value >= -10f) ? value : 0f;
                this.Refresh();
            }
        }
        public float Span
        {
            get { return span; }
            set
            {
                span = (value < 360) ? value : 359f;
                this.Refresh();
            }
        }

        public float SpinRate
        {
            get { return spinrate; }
            set
            {
                spinrate = (value < .3f) ? .3f : (value > 2f) ? 2f : value;
                this.Refresh();
            }
        }

        public Image KnobBase
        {
            get { return this.BottomImage; }
            set
            {
                this.BottomImage = value;
                this.Refresh();
            }
        }

        public Image KnobDial
        {
            get { return this.MidImage; }
            set
            {
                this.MidImage = value;
                this.Refresh();
            }
        }
        public Image KnobTop
        {
            get { return this.TopImage; }
            set
            {
                this.TopImage = value;
                this.Refresh();
            }
        }

        public delegate void ValueChangedEventHandler(object sender, float e);
        public event ValueChangedEventHandler ValueChanged;

        protected void OnValueChanged(float e)
        {
            if (this.ValueChanged != null) this.ValueChanged(this, e);
        }

        private void BigKnobs_MouseDown(object sender, MouseEventArgs e)
        {
            rtating = true;
            touchpoint = (float)Math.Atan2(e.Y - (float)this.ClientRectangle.Height / 2f,
                    e.X - (float)this.ClientRectangle.Width / 2f) * 180f / (float)Math.PI + 180f;
        }

        private void BigKnobs_MouseUp(object sender, MouseEventArgs e)
        {
            if (rtating)
            {
                rtating = false;
                OnValueChanged(adjustment());
                this.Refresh();
            }
        }

        private void BigKnobs_MouseMove(object sender, MouseEventArgs e)
        {
            if (rtating)
            {
                float movepoint = (float)Math.Atan2(e.Y - (float)this.ClientRectangle.Height / 2f,
                    e.X - (float)this.ClientRectangle.Width / 2f) * 180f / (float)Math.PI + 180f;
                float travel = (movepoint < touchpoint) ? (movepoint + 360f - touchpoint) : movepoint - touchpoint;

                travel = (travel > 180) ? travel - 360f : travel;
                travel *= spinrate;
                rtate += travel;

                rtate = (rtate > span) ? span : (rtate < 0) ? 0 : rtate;

                touchpoint = movepoint;
                OnValueChanged(adjustment());
                this.Refresh();
            }
        }

        private float adjustment()
        {
            return rtate * (maxvalue - minvalue) / span + minvalue;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (MidImage != null)
            {
                using (Bitmap bmp = new Bitmap((int)((float)this.ClientRectangle.Width),
                    (int)((float)this.ClientRectangle.Height)))
                {

                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        SizeF rotsize = new SizeF(this.ClientRectangle.Width ,
                            this.ClientRectangle.Height);
                        RectangleF rct = new RectangleF(0, 0, this.ClientRectangle.Width * this.AutoScaleFactor.Width,
                            this.ClientRectangle.Height);
                        GraphicsUnit gu = GraphicsUnit.Pixel;
                        g.CompositingMode = CompositingMode.SourceOver;
                        if (this.BottomImage != null)
                        {
                            g.DrawImage(this.BottomImage, rct, this.BottomImage.GetBounds(ref gu), GraphicsUnit.Pixel);
                        }
                        else
                        {
                            g.FillRectangle(new SolidBrush(this.BackColor), this.ClientRectangle);
                        }

                        
                        g.TranslateTransform(rotsize.Width / 2f, rotsize.Height / 2f);
                        g.RotateTransform(rtate + offset);
                        g.TranslateTransform(rotsize.Width / -2f, rotsize.Height / -2f);

                        g.DrawImage(MidImage, rct, this.BottomImage.GetBounds(ref gu), GraphicsUnit.Pixel);
                        g.ResetTransform();

                        if (TopImage != null) g.DrawImage(TopImage, rct, this.BottomImage.GetBounds(ref gu), GraphicsUnit.Pixel);

                    }

                    e.Graphics.DrawImage(bmp, 0, 0);
                }
            }
            //base.OnPaint(e);
        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            if (this.MidImage == null)
            {

                e.Graphics.FillRectangle(new SolidBrush(Color.Ivory), this.ClientRectangle);
            }
            else
            {
                base.OnPaintBackground(e);
            }

        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
        }
    }
}
