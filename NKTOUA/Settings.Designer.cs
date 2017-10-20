namespace NKTOUA
{
    partial class frmSettings
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
            this.tabSettings = new System.Windows.Forms.TabControl();
            this.pageCategorize = new System.Windows.Forms.TabPage();
            this.radCategorizeByAddredd = new System.Windows.Forms.RadioButton();
            this.radCategorizeBySubject = new System.Windows.Forms.RadioButton();
            this.radCategorizeByDate = new System.Windows.Forms.RadioButton();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.tabSettings.SuspendLayout();
            this.pageCategorize.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabSettings
            // 
            this.tabSettings.Controls.Add(this.pageCategorize);
            this.tabSettings.Location = new System.Drawing.Point(3, 2);
            this.tabSettings.Multiline = true;
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.SelectedIndex = 0;
            this.tabSettings.ShowToolTips = true;
            this.tabSettings.Size = new System.Drawing.Size(549, 370);
            this.tabSettings.TabIndex = 0;
            // 
            // pageCategorize
            // 
            this.pageCategorize.Controls.Add(this.radCategorizeByDate);
            this.pageCategorize.Controls.Add(this.radCategorizeBySubject);
            this.pageCategorize.Controls.Add(this.radCategorizeByAddredd);
            this.pageCategorize.Location = new System.Drawing.Point(4, 22);
            this.pageCategorize.Name = "pageCategorize";
            this.pageCategorize.Padding = new System.Windows.Forms.Padding(3);
            this.pageCategorize.Size = new System.Drawing.Size(541, 344);
            this.pageCategorize.TabIndex = 0;
            this.pageCategorize.Text = "Categorize";
            this.pageCategorize.UseVisualStyleBackColor = true;
            // 
            // radCategorizeByAddredd
            // 
            this.radCategorizeByAddredd.AutoSize = true;
            this.radCategorizeByAddredd.Checked = true;
            this.radCategorizeByAddredd.Location = new System.Drawing.Point(41, 28);
            this.radCategorizeByAddredd.Name = "radCategorizeByAddredd";
            this.radCategorizeByAddredd.Size = new System.Drawing.Size(63, 17);
            this.radCategorizeByAddredd.TabIndex = 0;
            this.radCategorizeByAddredd.Text = "Address";
            this.radCategorizeByAddredd.UseVisualStyleBackColor = true;
            // 
            // radCategorizeBySubject
            // 
            this.radCategorizeBySubject.AutoSize = true;
            this.radCategorizeBySubject.Location = new System.Drawing.Point(185, 28);
            this.radCategorizeBySubject.Name = "radCategorizeBySubject";
            this.radCategorizeBySubject.Size = new System.Drawing.Size(61, 17);
            this.radCategorizeBySubject.TabIndex = 0;
            this.radCategorizeBySubject.Text = "Subject";
            this.radCategorizeBySubject.UseVisualStyleBackColor = true;
            // 
            // radCategorizeByDate
            // 
            this.radCategorizeByDate.AutoSize = true;
            this.radCategorizeByDate.Location = new System.Drawing.Point(327, 28);
            this.radCategorizeByDate.Name = "radCategorizeByDate";
            this.radCategorizeByDate.Size = new System.Drawing.Size(48, 17);
            this.radCategorizeByDate.TabIndex = 0;
            this.radCategorizeByDate.Text = "Date";
            this.radCategorizeByDate.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(482, 374);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(70, 24);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(408, 374);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(70, 24);
            this.btnApply.TabIndex = 2;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(334, 374);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(70, 24);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 402);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tabSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSettings";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.frmSettings_Load);
            this.tabSettings.ResumeLayout(false);
            this.pageCategorize.ResumeLayout(false);
            this.pageCategorize.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabSettings;
        private System.Windows.Forms.TabPage pageCategorize;
        private System.Windows.Forms.RadioButton radCategorizeByAddredd;
        private System.Windows.Forms.RadioButton radCategorizeByDate;
        private System.Windows.Forms.RadioButton radCategorizeBySubject;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnOK;
    }
}