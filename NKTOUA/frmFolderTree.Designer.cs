namespace NKTOUA
{
    partial class frmFolderTree
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
            this.treeFolders = new System.Windows.Forms.TreeView();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblChoseFolders = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // treeFolders
            // 
            this.treeFolders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeFolders.CheckBoxes = true;
            this.treeFolders.FullRowSelect = true;
            this.treeFolders.Location = new System.Drawing.Point(3, 31);
            this.treeFolders.Name = "treeFolders";
            this.treeFolders.Size = new System.Drawing.Size(367, 227);
            this.treeFolders.TabIndex = 0;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnOK.Location = new System.Drawing.Point(150, 260);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(72, 24);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // lblChoseFolders
            // 
            this.lblChoseFolders.AutoSize = true;
            this.lblChoseFolders.Location = new System.Drawing.Point(3, 9);
            this.lblChoseFolders.Name = "lblChoseFolders";
            this.lblChoseFolders.Size = new System.Drawing.Size(0, 13);
            this.lblChoseFolders.TabIndex = 2;
            // 
            // frmFolderTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 286);
            this.Controls.Add(this.lblChoseFolders);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.treeFolders);
            this.Name = "frmFolderTree";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "NKTOUA_FolderTree";
            this.Load += new System.EventHandler(this.frmFolderTree_Load);
            this.SizeChanged += new System.EventHandler(this.frmFolderTree_SizeChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeFolders;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblChoseFolders;
    }
}