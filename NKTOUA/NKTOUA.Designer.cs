namespace NKTOUA
{
    partial class NKTOUA : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public NKTOUA()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

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
            this.tabNKTOUA = this.Factory.CreateRibbonTab();
            this.grNKTOUA = this.Factory.CreateRibbonGroup();
            this.btnApply = this.Factory.CreateRibbonButton();
            this.btnSettings = this.Factory.CreateRibbonButton();
            this.tabNKTOUA.SuspendLayout();
            this.grNKTOUA.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabNKTOUA
            // 
            this.tabNKTOUA.Groups.Add(this.grNKTOUA);
            this.tabNKTOUA.Label = "NKTOUA";
            this.tabNKTOUA.Name = "tabNKTOUA";
            // 
            // grNKTOUA
            // 
            this.grNKTOUA.Items.Add(this.btnApply);
            this.grNKTOUA.Items.Add(this.btnSettings);
            this.grNKTOUA.Label = "NKTOUA";
            this.grNKTOUA.Name = "grNKTOUA";
            // 
            // btnApply
            // 
            this.btnApply.Label = "Apply";
            this.btnApply.Name = "btnApply";
            this.btnApply.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnApply_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.Label = "Settings";
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnSettings_Click);
            // 
            // NKTOUA
            // 
            this.Name = "NKTOUA";
            this.RibbonType = "Microsoft.Outlook.Mail.Read";
            this.Tabs.Add(this.tabNKTOUA);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.NKTOUA_Load);
            this.tabNKTOUA.ResumeLayout(false);
            this.tabNKTOUA.PerformLayout();
            this.grNKTOUA.ResumeLayout(false);
            this.grNKTOUA.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tabNKTOUA;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup grNKTOUA;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnApply;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnSettings;
    }

    partial class ThisRibbonCollection
    {
        internal NKTOUA NKTOUA
        {
            get { return this.GetRibbon<NKTOUA>(); }
        }
    }
}
