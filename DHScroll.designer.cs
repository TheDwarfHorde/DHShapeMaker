namespace ShapeMaker
{
    partial class dhScroll
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // dhScroll
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "dhScroll";
            this.Size = new System.Drawing.Size(159, 28);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dhScroll_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dhScroll_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dhScroll_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
