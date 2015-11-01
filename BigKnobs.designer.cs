namespace Controlz
{
    partial class BigKnobs
    {
       ///
       ///  Hey Nonny Nonny - EER was here!
       /// 
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // BigKnobs
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.Transparent;
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size(100, 100);
            this.Name = "BigKnobs";
            this.Size = new System.Drawing.Size(100, 100);
            this.Load += new System.EventHandler(this.UserControl1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BigKnobs_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.BigKnobs_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BigKnobs_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
