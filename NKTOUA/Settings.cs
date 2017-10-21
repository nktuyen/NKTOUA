﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NKTOUA
{
    public partial class frmSettings : Form
    {
        private AppSettings _settings = null;
        public frmSettings()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmSettings_Load(object sender, EventArgs e)
        {
            AppSettings.Instance.Load(ThisAddIn.Instance.AppDataPath+"\\Settings.xml");
            _settings = AppSettings.Instance.Clone();

            switch (_settings.Categorize.Criteria)
            {
                case ECategorizeBy.Address:
                    radCategorizeByAddress.Checked = true;
                    break;
                case ECategorizeBy.Date:
                    radCategorizeByDate.Checked = true;
                    break;
                case ECategorizeBy.Subject:
                    radCategorizeBySubject.Checked = true;
                    break;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnApply_Click(object sender, EventArgs e)
        {
            if (!AppSettings.Instance.Equal(_settings))
            {
                AppSettings.Instance.Copy(_settings);

                if (!System.IO.Directory.Exists(ThisAddIn.Instance.AppDataPath))
                {
                    System.IO.Directory.CreateDirectory(ThisAddIn.Instance.AppDataPath);
                }

                AppSettings.Instance.Save(ThisAddIn.Instance.AppDataPath + "\\Settings.xml");
            }

            btnApply.Enabled = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!AppSettings.Instance.Equal(_settings))
            {
                AppSettings.Instance.Copy(_settings);

                if (!System.IO.Directory.Exists(ThisAddIn.Instance.AppDataPath))
                {
                    System.IO.Directory.CreateDirectory(ThisAddIn.Instance.AppDataPath);
                }

                AppSettings.Instance.Save(ThisAddIn.Instance.AppDataPath + "\\Settings.xml");
            }

            this.Close();
        }

        private void radCategorizeByAddress_CheckedChanged(object sender, EventArgs e)
        {
            _settings.Categorize.Criteria = ECategorizeBy.Address;
        }

        private void radCategorizeBySubject_CheckedChanged(object sender, EventArgs e)
        {
            _settings.Categorize.Criteria = ECategorizeBy.Subject;
        }

        private void radCategorizeByDate_CheckedChanged(object sender, EventArgs e)
        {
            _settings.Categorize.Criteria = ECategorizeBy.Date;
        }
    }
}
