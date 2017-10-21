using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;
using System.ComponentModel;
using System.Diagnostics;

namespace NKTOUA
{
    class olExplorer : IDisposable
    {
        #region "Propertiess"
        private Outlook.Explorer _explorer = null;
        private Outlook.Application _application = null;
        private bool _active = false;
        private bool _workerStarted = false;
        private BackgroundWorker _worker = null;

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
            if (_workerStarted)
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
            if (!_workerStarted)
            {
                if (_worker == null)
                {
                    _worker = new BackgroundWorker();
                    _worker.WorkerReportsProgress = true;
                    _worker.DoWork += DoCategorize;
                    _worker.ProgressChanged += OnCategorizeProgressChanged;
                    _worker.RunWorkerCompleted += OnCategorizeCompleted;
                }
                frmCategorizing frm = new frmCategorizing(_worker);
                frm.Show();
                _worker.RunWorkerAsync();
            }
            else
            {
                if (null != _worker)
                {
                    _worker.CancelAsync();
                }
            }
        }

        private void DoCategorize(object sender, DoWorkEventArgs e)
        {
            _workerStarted = true;
            if (null == _explorer)
            {
                return;
            }

            List<Outlook.Folder> deletePaths = new List<Microsoft.Office.Interop.Outlook.Folder>();
            Dictionary<string, string> addPaths = new Dictionary<string, string>();
            foreach (Outlook.Store store in Application.Session.Stores)
            {
                if (null != store)
                {
                    try
                    {
                        Outlook.Folder defFolder = store.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox) as Outlook.Folder;
                        if (null != defFolder)
                        {
                            WalkDir(defFolder, store, false, ref deletePaths, ref addPaths);
                        }

                        Outlook.Folder curFolder = null;
                        for (int i = deletePaths.Count - 1; i >= 0; i--)
                        {
                            curFolder = deletePaths[i];
                            if (!addPaths.ContainsKey(curFolder.Name))
                            {
                                Debug.Print("Deleting... " + curFolder.FullFolderPath);
                                curFolder.Delete();
                            }
                        }
                        deletePaths.Clear();

                        foreach (string path in addPaths.Keys)
                        {
                            defFolder.Folders.Add(path);
                        }
                        addPaths.Clear();


                        defFolder = store.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderJunk) as Outlook.Folder;
                        if (null != defFolder)
                        {
                            WalkDir(defFolder, store, false, ref deletePaths, ref addPaths);
                        }
                        curFolder = null;
                        for (int i = deletePaths.Count - 1; i >= 0; i--)
                        {
                            curFolder = deletePaths[i];
                            if (!addPaths.ContainsKey(curFolder.Name))
                            {
                                Debug.Print("Deleting... " + curFolder.FullFolderPath);
                                curFolder.Delete();
                            }
                        }
                        deletePaths.Clear();

                        foreach(string path in addPaths.Keys)
                        {
                            defFolder.Folders.Add(path);
                        }
                        addPaths.Clear();
                    }
                    catch(Exception ex) {; }
                }
            }
        }

        private void WalkDir(Outlook.Folder root, Outlook.Store store, bool addToDelete, ref List<Outlook.Folder> deletePaths, ref Dictionary<string, string> addPaths)
        {
            if(null != root)
            {
                Debug.Print(root.FullFolderPath);
                string categoryName = "";
                if( (addToDelete) && (null != deletePaths) )
                {
                    deletePaths.Add(root);
                }
                foreach(Outlook.MailItem item in root.Items)
                {
                    switch (AppSettings.Instance.Categorize.Criteria)
                    {
                        case ECategorizeBy.Address:
                            categoryName = item.Sender.Name;
                            if (categoryName.Length == 0)
                            {
                                categoryName = item.Sender.Address;
                            }
                            break;
                        case ECategorizeBy.Date:
                            categoryName = string.Format("{0}.{1}", item.ReceivedTime.Year, item.ReceivedTime.Month);
                            break;
                        case ECategorizeBy.Subject:
                            categoryName = item.Subject;
                            if (item.Subject.Length == 0)
                            {
                                categoryName = "(Empty)";
                            }
                            break;
                    }
                    if ((null != store) && (categoryName.Length > 0) && (null != addPaths))
                    {
                        if (!addPaths.ContainsKey(categoryName))
                        {
                            addPaths.Add(categoryName, root.FullFolderPath);
                        }
                        categoryName = "";
                    }
                }
                

                if (root.Folders.Count > 0)
                {
                    foreach(Outlook.Folder child in root.Folders)
                    {
                        WalkDir(child, store, true, ref deletePaths, ref addPaths);
                    }
                }
            }
        }

        private void OnCategorizeProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            
        }

        private void OnCategorizeCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _workerStarted = false;
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
            Debug.Print("OnFolderSwitch: "+ _explorer.CurrentFolder.FullFolderPath);
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
            Outlook.View view = _explorer.CurrentView as Outlook.View;
            if (null != view)
            {
                switch (view.ViewType)
                {
                    case Microsoft.Office.Interop.Outlook.OlViewType.olBusinessCardView:
                        Debug.Print("OnViewSwitch: olBusinessCardView");
                        break;
                    case Microsoft.Office.Interop.Outlook.OlViewType.olCalendarView:
                        Debug.Print("OnViewSwitch: olCalendarView");
                        break;
                    case Microsoft.Office.Interop.Outlook.OlViewType.olCardView:
                        Debug.Print("OnViewSwitch: olCardView");
                        break;
                    case Outlook.OlViewType.olDailyTaskListView:
                        Debug.Print("OnViewSwitch: olDailyTaskListView");
                        break;
                    case Outlook.OlViewType.olIconView:
                        Debug.Print("OnViewSwitch: olIconView");
                        break;
                    case Outlook.OlViewType.olPeopleView:
                        Debug.Print("OnViewSwitch: olPeopleView");
                        break;
                    case Outlook.OlViewType.olTableView:
                        Debug.Print("OnViewSwitch: olTableView");
                        break;
                    case Outlook.OlViewType.olTimelineView:
                        Debug.Print("OnViewSwitch: olTimelineView");
                        break;
                    default:
                        Debug.Print("OnViewSwitch: Unknown");
                        break;
                }
            }
        }
        #endregion
    }
}
