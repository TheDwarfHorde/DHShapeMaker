namespace ShapeMaker
{
    partial class HelpForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.RTB = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // RTB
            // 
            this.RTB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RTB.Location = new System.Drawing.Point(0, 1);
            this.RTB.Name = "RTB";
            this.RTB.Size = new System.Drawing.Size(784, 475);
            this.RTB.TabIndex = 0;
            this.RTB.Text = "";
            this.RTB.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.RTB_LinkClicked);
            this.RTB.MouseClick += new System.Windows.Forms.MouseEventHandler(this.RTB_MouseClick);
            this.RTB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RTB_KeyDown);
            this.RTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RTB_KeyPress);
            this.RTB.MouseMove += new System.Windows.Forms.MouseEventHandler(this.RTB_MouseMove);
            // 
            // HelpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 474);
            this.Controls.Add(this.RTB);
            this.Name = "HelpForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DH ShapeMaker Help";
            this.Load += new System.EventHandler(this.HelpForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox RTB;
    }
}