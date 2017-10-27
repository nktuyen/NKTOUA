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
    public partial class frmGrouping : Form
    {
        private BackgroundWorker _worker = null;

        public BackgroundWorker Worker
        {
            get { return _worker; }
            set
            {
                if (null != _worker)
                {
                    _worker.ProgressChanged -= OnCategorizeProgressChanged;
                    _worker.RunWorkerCompleted -= OnCategorizeCompleted;
                }
                _worker = value;
                if (null != _worker)
                {
                    _worker.ProgressChanged += OnCategorizeProgressChanged;
                    _worker.RunWorkerCompleted += OnCategorizeCompleted;
                }
            }
        }

        public frmGrouping(BackgroundWorker worker)
        {
            InitializeComponent();
            Worker = worker;
        }

        private void frmCategorizing_Load(object sender, EventArgs e)
        {
            this.Text = Properties.Resources.NKTOUA_GROUPING_BUTTON_LABEL;
        }

        private void frmCategorizing_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void frmCategorizing_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_worker.IsBusy)
            {
                if (MessageBox.Show(Properties.Resources.frmGrouping_Message_AreYouSureToCancel, NKTOUA_Application.Instance.Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    e.Cancel = true;
                    return;
                }

                _worker.CancelAsync();
            }
        }

        private void OnCategorizeProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == -1)
            {
                prgCategorizingProgress.Style = ProgressBarStyle.Marquee;
                prgCategorizingProgress.MarqueeAnimationSpeed = 100;
            }
            else
            {
                prgCategorizingProgress.Style = ProgressBarStyle.Blocks;
                prgCategorizingProgress.Value = e.ProgressPercentage;
            }
            lblStatus.Text = e.UserState.ToString();
        }

        private void OnCategorizeCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Close();
        }
    }
}
