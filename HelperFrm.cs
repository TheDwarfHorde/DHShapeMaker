using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ShapeMaker
{

    public partial class HelpForm : Form
    {
        private List<bmark> hotspots = new List<bmark>();
        private Dictionary<string, int> targets = new Dictionary<string, int>();

        public HelpForm()
        {
            InitializeComponent();
        }

        private void HelpForm_Load(object sender, EventArgs e)
        {
            string strRtf = string.Empty;
            Cursor.Current=Cursors.WaitCursor;
            try
            {
                if (File.Exists(Application.StartupPath + @"\Effects\" + "ShapeMaker.rtf"))
                {
                    using (TextReader tr = File.OpenText(Application.StartupPath + @"\Effects\" + "ShapeMaker.rtf"))
                    {
                        strRtf = tr.ReadToEnd();
                    }
                }
                else
                {
                    MessageBox.Show("Help File Not Found!");
                    Cursor.Current = Cursors.Default;
                    return;
                }
            }
            catch (Exception c)
            {
                MessageBox.Show("File Load Error - " + c);
                Cursor.Current = Cursors.Default;
                return;
            }


            if (strRtf == string.Empty)
            {
                Cursor.Current = Cursors.Default;
                return;
            }
            int result = 0;
            int result2 = 0;
            int indexer = 0;
            int stopper = 0;

            RichTextBox rtbTmp = new RichTextBox();

            //find bookmarks
            string seek = @"{\*\bkmkstart ";
            do
            {
                result = strRtf.IndexOf(seek, result);
                if (result != -1)
                {
                    result2 = strRtf.IndexOf("}", result);
                    int pos = result + seek.Length;
                    rtbTmp.Rtf = strRtf.Substring(0, result) + "}";
                    targets.Add(strRtf.Substring(pos, result2 - pos), rtbTmp.Text.Length);
                    result = result2;
                }
            } while (result != -1);

            //find nyperlinks
            result = 0;
            seek = "HYPERLINK  ";

            do
            {
                result = strRtf.IndexOf(@seek, result);

                if (result != -1)
                {
                    string look = "{\\field";
                    result2 = strRtf.LastIndexOf(@look, result);

                    look = "" + (char)34;
                    int res = strRtf.IndexOf(look, result) + 1;
                    indexer = strRtf.IndexOf(look, res);

                    int counter = 0;
                    int len = result2;
                    do
                    {
                        string countchar = strRtf.Substring(len++, 1);
                        counter = (countchar == "{") ? counter + 1 : (countchar == "}") ? counter - 1 : counter;

                    } while (counter != 0);
                    stopper = len;

                    rtbTmp.Rtf = strRtf.Substring(0, result2) + "}";
                    int start2 = rtbTmp.Text.Length;

                    rtbTmp.Rtf = strRtf.Substring(0, stopper) + "}";
                    int end2 = rtbTmp.Text.Length;

                    hotspots.Add(new bmark()
                    {
                        BookMark = strRtf.Substring(res, indexer - res)
                        ,
                        start = start2,
                        end = end2
                    });
                    result = stopper + 1;

                }
            } while (result != -1);

            RTB.Rtf = strRtf;
            strRtf = String.Empty;
            rtbTmp.Dispose();
            Cursor.Current = Cursors.Default;
        }

        private void RTB_MouseClick(object sender, MouseEventArgs e)
        {
            int index = RTB.GetCharIndexFromPosition(e.Location);
            foreach (bmark h in hotspots)
            {
                if (h.start <= index && index <= h.end)
                {
                    RTB.SelectionLength = 0;
                    RTB.SelectionStart = targets[h.BookMark];
                    RTB.ScrollToCaret();
                }
            }
        }

        private void RTB_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        private void RTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void RTB_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("http://www.getpaint.net/redirect/plugins.html");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open the Link." + ex.Message);
            }
        }

        private void RTB_MouseMove(object sender, MouseEventArgs e)
        {
            int index = RTB.GetCharIndexFromPosition(RTB.PointToClient(MousePosition));
            bool hand = false;
            foreach (bmark h in hotspots)
            {
                if (h.start <= index && index <= h.end) hand = true;
            }

            if (hand)
            {
                this.Cursor = Cursors.Hand;
            }
            else
            {
                this.Cursor = RTB.Cursor;
            }
        }
    }
    public class bmark
    {
        public string BookMark
        {
            get;
            set;
        }

        public int start
        {
            get;
            set;
        }

        public int end
        {
            get;
            set;
        }
    }
}
