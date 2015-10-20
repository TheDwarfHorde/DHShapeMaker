using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using PaintDotNet;
using PaintDotNet.Effects;
using System.Windows.Forms;

namespace ShapeMaker
{
    [PluginSupportInfo(typeof(PluginSupportInfo), DisplayName = "ShapeMaker")]
    public class EffectPlugin
        : PaintDotNet.Effects.Effect
    {
        public static string StaticName
        {
            get
            {
                return "DH ShapeMaker";
            }
        }

        
        public static Bitmap StaticImage
        {
            get { return ShapeMaker.Properties.Resources.pdndwarvesicon2; }
        }

        public static string StaticSubMenuName
        {
            get
            {
                return  "Advanced"; 
            }
        }

        public EffectPlugin()
            : base(EffectPlugin.StaticName, EffectPlugin.StaticImage, EffectPlugin.StaticSubMenuName, EffectFlags.Configurable)
        {

        }

        public override EffectConfigDialog CreateConfigDialog()
        {
            return new EffectPluginConfigDialog();
        }
        protected override void OnSetRenderInfo(EffectConfigToken parameters, RenderArgs dstArgs, RenderArgs srcArgs)
        {
            EffectPluginConfigToken token = (EffectPluginConfigToken)parameters;
            PGP = token.GP;
            Draw = token.Draw;
            if (PGP != null) MyRender(dstArgs.Surface, srcArgs.Surface);
            base.OnSetRenderInfo(parameters, dstArgs, srcArgs);
        }

        GraphicsPath[] PGP = new GraphicsPath[0];
        bool Draw = false;

        private void MyRender(Surface dst, Surface src)
        {
            PdnRegion selectionRegion = EnvironmentParameters.GetSelection(src.Bounds);
            ColorBgra PrimaryColor = (ColorBgra)EnvironmentParameters.PrimaryColor;
            ColorBgra SecondaryColor = (ColorBgra)EnvironmentParameters.SecondaryColor;
            int BrushWidth = (int)EnvironmentParameters.BrushWidth;
            if (PGP.Length > 0 && Draw )
            {
                using (Graphics g = new RenderArgs(dst).Graphics)
                {
                    using (Region reg = new Region(selectionRegion.GetRegionData()))
                    {
                        g.SetClip(reg, CombineMode.Replace);
                    }
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    Pen p = new Pen(PrimaryColor);
                    p.Width = BrushWidth;
                    for (int i = 0; i < PGP.Length; i++)
                    {
                        if (PGP[i].PointCount > 0)
                        {
                            
                            g.DrawPath(p, PGP[i]);
                        }
                    }
                }
            }
        }

        public override void Render(EffectConfigToken parameters, RenderArgs dstArgs, RenderArgs srcArgs, Rectangle[] rois, int startIndex, int length)
        {
        }
    }
}