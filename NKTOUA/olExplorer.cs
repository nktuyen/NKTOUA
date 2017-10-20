using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;
using System.ComponentModel;
namespace NKTOUA
{
    class olExplorer : IDisposable
    {
        #region "Propertiess"
        private Outlook.Explorer _explorer = null;
        private Outlook.Application _application = null;
        private bool _active = false;
        private BackgroundWorker _worker = new BackgroundWorker();

        public Outlook.Explorer Explorer
        {
            get { return _explorer; }
            set
            {
                Outlook.ExplorerEvents_10_Event explEvents = null;
                if (null != _explorer)
                {
                    explEvents = _explorer as Outlook.ExplorerEvents_10_Event;
                    if (null != explEvents)
                    {
                        explEvents.Activate -= OnActive;
                        explEvents.BeforeFolderSwitch -= BeforeFolderSwitch;
                        explEvents.Close -= OnClose;
                        explEvents.Deactivate -= OnDeactive;
                        explEvents.FolderSwitch -= OnFolderSwitch;
                        explEvents.SelectionChange -= OnSelectionChange;
                        explEvents.ViewSwitch -= OnViewSwitch;
                    }
                }

                _explorer = value as Outlook.Explorer;
                if (null != _explorer)
                {
                    explEvents = _explorer as Outlook.ExplorerEvents_10_Event;
                    if (null != explEvents)
                    {
                        explEvents.Activate += OnActive;
                        explEvents.BeforeFolderSwitch += BeforeFolderSwitch;
                        explEvents.Close += OnClose;
                        explEvents.Deactivate += OnDeactive;
                        explEvents.FolderSwitch += OnFolderSwitch;
                        explEvents.SelectionChange += OnSelectionChange;
                        explEvents.ViewSwitch += OnViewSwitch;
                    }
                }
            }
        }

        public Outlook.Application Application
        {
            get { return _application; }
            set { _application = value as Outlook.Application; }
        }


        public bool Activated
        {
            get{return _active; }
            set { _active = value; }
        }
        #endregion

        #region "Life cycle methods"
        public olExplorer(Outlook.Explorer explorer)
        {
            Explorer = explorer;
        }

        public void Dispose()
        {
            Explorer = null;
        }

        ~olExplorer()
        {
            Dispose();
        }
        #endregion

        #region "Event handlers"
        /// <summary>
        /// 
        /// </summary>
        public void OnInit()
        {
            Ribbon.Instance.Categorize += OnCategorize;
            Ribbon.Instance.Load += OnRibbonLoad;
            Ribbon.Instance.Settings += OnSettings;
            Ribbon.Instance.About += OnAbout;
            Ribbon.Instance.CategorizeLabel += OnCategorizeLabel;
        }

        private void OnRibbonLoad(Office.IRibbonUI ribbonUI)
        {
            
        }


        private string OnCategorizeLabel(Office.IRibbonControl control)
        {
            if (_worker.IsBusy)
            {
                return "Cancel Categorize";
            }
            else
            {
                return "Categorize";
            }
        }

        private void OnAbout(Office.IRibbonControl Ctrl)
        {
            frmAbout frm = new frmAbout();
            frm.ShowDialog();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Ctrl"></param>
        /// <param name="CancelDefault"></param>
        private void OnSettings(Office.IRibbonControl Ctrl)
        {
            frmSettings frm = new frmSettings();
            frm.ShowDialog();
        }

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Ctrl"></param>
        private void OnCategorize(Office.IRibbonControl Ctrl)
        {
            MessageBox.Show(Ctrl.Id);
        }

        /// <summary>
        /// 
        /// </summary>
        public void OnActive()
        {
            Activated = true;
        }

        /// <summary>
        /// 
        /// </summary>
        private void OnClose()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        private void OnDeactive()
        {
            Activated = false;
        }

        /// <summary>
        /// 
        /// </summary>
        private void BeforeFolderSwitch(object NewFolder, ref bool Cancel)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        private void OnFolderSwitch()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        private void OnSelectionChange()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        private void OnViewSwitch()
        {

        }
        #endregion
    }
}
