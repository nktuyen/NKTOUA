namespace NKTOUA
{
    partial class frmCategorizing
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
            this.prgCategorizingProgress = new System.Windows.Forms.ProgressBar();
            this.lblStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // prgCategorizingProgress
            // 
            this.prgCategorizingProgress.Location = new System.Drawing.Point(12, 44);
            this.prgCategorizingProgress.Name = "prgCategorizingProgress";
            this.prgCategorizingProgress.Size = new System.Drawing.Size(478, 19);
            this.prgCategorizingProgress.TabIndex = 0;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoEllipsis = true;
            this.lblStatus.Location = new System.Drawing.Point(12, 2);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(478, 37);
            this.lblStatus.TabIndex = 1;
            // 
            // frmCategorizing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 83);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.prgCategorizingProgress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmCategorizing";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Categorizing";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCategorizing_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmCategorizing_FormClosed);
            this.Load += new System.EventHandler(this.frmCategorizing_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar prgCategorizingProgress;
        private System.Windows.Forms.Label lblStatus;
    }
}