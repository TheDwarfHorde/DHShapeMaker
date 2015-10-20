using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace ShapeMaker
{
    public partial class Shortcuts : Form
    {
        public Shortcuts()
        {
            InitializeComponent();
        }

        private void Shortcuts_Load(object sender, EventArgs e)
        {

            Assembly asm = Assembly.GetExecutingAssembly();
            using (Stream stream = asm.GetManifestResourceStream("ShapeMaker.Resources.Keyboard.rtf"))
            {
                rt3.LoadFile(stream, RichTextBoxStreamType.RichText);
            }
            using (Stream stream = asm.GetManifestResourceStream("ShapeMaker.Resources.Mouse.rtf"))
            {
                rt1.LoadFile(stream, RichTextBoxStreamType.RichText);
            }
            using (Stream stream = asm.GetManifestResourceStream("ShapeMaker.Resources.Misc.rtf"))
            {
                rt2.LoadFile(stream, RichTextBoxStreamType.RichText);
            }

        }


        private void Shortcuts_Paint(object sender, PaintEventArgs e)
        {
            using (Pen p = new Pen(Color.DarkGray))
            {
                p.Width = 4;
                e.Graphics.DrawRectangle(p, 0, 0, ClientSize.Width - 2, ClientSize.Height - 2);
                p.Dispose();
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_VisibleChanged(object sender, EventArgs e)
        {

        }

    }
}
