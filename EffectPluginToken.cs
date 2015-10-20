using System;
using System.Collections;
using System.Drawing;
using PaintDotNet;
using PaintDotNet.Effects;
using System.Drawing.Drawing2D;

namespace ShapeMaker
{
    public class EffectPluginConfigToken : PaintDotNet.Effects.EffectConfigToken
    {
        public GraphicsPath[] GP
        {
            get;
            set;
        }
        public ArrayList PathData
        {
            get;
            set;
        }
        public bool Draw
        {
            get;
            set;
        }
        public decimal Scale
        {
            get;
            set;
        }
        public bool SnapTo
        {
            get;
            set;
        }
        public string ShapeName
        {
            get;
            set;
        }
        public bool SolidFill
        {
            get;
            set;
        }
        public EffectPluginConfigToken(GraphicsPath[] gp,ArrayList pathdata , bool draw, decimal scale, bool snap,string shapename,bool solidfill)
            : base()
        {
            GP = gp;
            PathData = pathdata;
            Draw = draw;
            Scale = scale;
            SnapTo = snap;
            ShapeName = shapename;
            SolidFill = solidfill;
        }

        protected EffectPluginConfigToken(EffectPluginConfigToken copyMe)
            : base(copyMe)
        {
            GP = copyMe.GP;
            PathData = copyMe.PathData;
            Draw = copyMe.Draw;
            Scale = copyMe.Scale;
            SnapTo = copyMe.SnapTo;
            ShapeName = copyMe.ShapeName;
            SolidFill = copyMe.SolidFill;
        }

        public override object Clone()
        {
            return new EffectPluginConfigToken(this);
        }
    }
}