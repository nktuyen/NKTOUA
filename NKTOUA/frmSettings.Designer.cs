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
            this.settingTabs = new System.Windows.Forms.TabControl();
            this.tabGrouping = new System.Windows.Forms.TabPage();
            this.grCategorizeBy = new System.Windows.Forms.GroupBox();
            this.radCategorizeByDate = new System.Windows.Forms.RadioButton();
            this.radCategorizeBySubject = new System.Windows.Forms.RadioButton();
            this.radCategorizeByAddress = new System.Windows.Forms.RadioButton();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.tabGeneral = new System.Windows.Forms.TabPage();
            this.settingTabs.SuspendLayout();
            this.tabGrouping.SuspendLayout();
            this.grCategorizeBy.SuspendLayout();
            this.SuspendLayout();
            // 
            // settingTabs
            // 
            this.settingTabs.Controls.Add(this.tabGeneral);
            this.settingTabs.Controls.Add(this.tabGrouping);
            this.settingTabs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settingTabs.Location = new System.Drawing.Point(3, 2);
            this.settingTabs.Multiline = true;
            this.settingTabs.Name = "settingTabs";
            this.settingTabs.SelectedIndex = 0;
            this.settingTabs.ShowToolTips = true;
            this.settingTabs.Size = new System.Drawing.Size(549, 370);
            this.settingTabs.TabIndex = 0;
            // 
            // tabGrouping
            // 
            this.tabGrouping.Controls.Add(this.grCategorizeBy);
            this.tabGrouping.Location = new System.Drawing.Point(4, 22);
            this.tabGrouping.Name = "tabGrouping";
            this.tabGrouping.Padding = new System.Windows.Forms.Padding(3);
            this.tabGrouping.Size = new System.Drawing.Size(541, 344);
            this.tabGrouping.TabIndex = 0;
            this.tabGrouping.Text = "Group";
            this.tabGrouping.UseVisualStyleBackColor = true;
            // 
            // grCategorizeBy
            // 
            this.grCategorizeBy.Controls.Add(this.radCategorizeByDate);
            this.grCategorizeBy.Controls.Add(this.radCategorizeBySubject);
            this.grCategorizeBy.Controls.Add(this.radCategorizeByAddress);
            this.grCategorizeBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grCategorizeBy.Location = new System.Drawing.Point(6, 6);
            this.grCategorizeBy.Name = "grCategorizeBy";
            this.grCategorizeBy.Size = new System.Drawing.Size(529, 65);
            this.grCategorizeBy.TabIndex = 1;
            this.grCategorizeBy.TabStop = false;
            this.grCategorizeBy.Text = "Categorize by";
            // 
            // radCategorizeByDate
            // 
            this.radCategorizeByDate.AutoSize = true;
            this.radCategorizeByDate.Location = new System.Drawing.Point(332, 29);
            this.radCategorizeByDate.Name = "radCategorizeByDate";
            this.radCategorizeByDate.Size = new System.Drawing.Size(48, 17);
            this.radCategorizeByDate.TabIndex = 3;
            this.radCategorizeByDate.Text = "Date";
            this.radCategorizeByDate.UseVisualStyleBackColor = true;
            this.radCategorizeByDate.CheckedChanged += new System.EventHandler(this.radCategorizeByDate_CheckedChanged);
            // 
            // radCategorizeBySubject
            // 
            this.radCategorizeBySubject.AutoSize = true;
            this.radCategorizeBySubject.Location = new System.Drawing.Point(177, 29);
            this.radCategorizeBySubject.Name = "radCategorizeBySubject";
            this.radCategorizeBySubject.Size = new System.Drawing.Size(61, 17);
            this.radCategorizeBySubject.TabIndex = 2;
            this.radCategorizeBySubject.Text = "Subject";
            this.radCategorizeBySubject.UseVisualStyleBackColor = true;
            this.radCategorizeBySubject.CheckedChanged += new System.EventHandler(this.radCategorizeBySubject_CheckedChanged);
            // 
            // radCategorizeByAddress
            // 
            this.radCategorizeByAddress.AutoSize = true;
            this.radCategorizeByAddress.Checked = true;
            this.radCategorizeByAddress.Location = new System.Drawing.Point(20, 29);
            this.radCategorizeByAddress.Name = "radCategorizeByAddress";
            this.radCategorizeByAddress.Size = new System.Drawing.Size(63, 17);
            this.radCategorizeByAddress.TabIndex = 1;
            this.radCategorizeByAddress.TabStop = true;
            this.radCategorizeByAddress.Text = "Address";
            this.radCategorizeByAddress.UseVisualStyleBackColor = true;
            this.radCategorizeByAddress.CheckedChanged += new System.EventHandler(this.radCategorizeByAddress_CheckedChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(462, 374);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(89, 24);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(372, 374);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(89, 24);
            this.btnApply.TabIndex = 2;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(282, 374);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(89, 24);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // tabGeneral
            // 
            this.tabGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Size = new System.Drawing.Size(541, 344);
            this.tabGeneral.TabIndex = 1;
            this.tabGeneral.Text = "General";
            this.tabGeneral.UseVisualStyleBackColor = true;
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 402);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.settingTabs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSettings";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.frmSettings_Load);
            this.settingTabs.ResumeLayout(false);
            this.tabGrouping.ResumeLayout(false);
            this.grCategorizeBy.ResumeLayout(false);
            this.grCategorizeBy.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl settingTabs;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TabPage tabGrouping;
        private System.Windows.Forms.GroupBox grCategorizeBy;
        private System.Windows.Forms.RadioButton radCategorizeByDate;
        private System.Windows.Forms.RadioButton radCategorizeBySubject;
        private System.Windows.Forms.RadioButton radCategorizeByAddress;
        private System.Windows.Forms.TabPage tabGeneral;
    }
}