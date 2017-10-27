using System;
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
            AppSettings.Instance.Load(NKTOUA_Application.Instance.DataPath+"\\Settings.xml");
            _settings = AppSettings.Instance.Clone();
            this.Text = Properties.Resources.NKTOUA_SETTINGS_BUTTON_LABEL;
            this.tabGrouping.Text = Properties.Resources.frmSettings_TAB_Grouping;
            this.tabGeneral.Text = Properties.Resources.frmSettings_TAB_General;
            this.grCategorizeBy.Text = Properties.Resources.frmSettings_GROUP_Criteria;
            this.radCategorizeByAddress.Text = Properties.Resources.frmSettings_RADIO_Address;
            this.radCategorizeByDate.Text = Properties.Resources.frmSettings_RADIO_Date;
            this.radCategorizeBySubject.Text = Properties.Resources.frmSettings_RADIO_Subject;
            this.btnApply.Text = Properties.Resources.frmSettings_BUTTON_Apply;
            this.btnOK.Text = Properties.Resources.frmSettings_BUTTON_OK;
            this.btnCancel.Text = Properties.Resources.frmSettings_BUTTON_Cancel;

            switch (_settings.Grouping.Criteria)
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

                if (!System.IO.Directory.Exists(NKTOUA_Application.Instance.DataPath))
                {
                    System.IO.Directory.CreateDirectory(NKTOUA_Application.Instance.DataPath);
                }

                AppSettings.Instance.Save(NKTOUA_Application.Instance.DataPath + "\\Settings.xml");
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

                if (!System.IO.Directory.Exists(NKTOUA_Application.Instance.DataPath))
                {
                    System.IO.Directory.CreateDirectory(NKTOUA_Application.Instance.DataPath);
                }

                AppSettings.Instance.Save(NKTOUA_Application.Instance.DataPath + "\\Settings.xml");
            }

            this.Close();
        }

        private void radCategorizeByAddress_CheckedChanged(object sender, EventArgs e)
        {
            _settings.Grouping.Criteria = ECategorizeBy.Address;
        }

        private void radCategorizeBySubject_CheckedChanged(object sender, EventArgs e)
        {
            _settings.Grouping.Criteria = ECategorizeBy.Subject;
        }

        private void radCategorizeByDate_CheckedChanged(object sender, EventArgs e)
        {
            _settings.Grouping.Criteria = ECategorizeBy.Date;
        }
    }
}
